using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using Peerfx.Models;
namespace Peerfx.User_Controls
{
    public partial class Admin_CurrencyCloud_Deposits : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();
        Users currentuser;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(true);
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (RadTabStrip1.SelectedIndex == 0)
            {
                //withdrawls
                RadGrid1.DataSource = Peerfx_DB.SPs.ViewCurrencyCloudTradeBystatus(2).GetDataSet().Tables[0];

                RadGrid1.MasterTableView.GroupByExpressions.Clear();                
                RadGrid1.MasterTableView.GroupByExpressions.Add(new GridGroupByExpression("sell_currency_text Group By sell_currency_text"));
                //RadGrid1.MasterTableView.Columns[5].Visible = true;
                RadGrid1.MasterTableView.Columns[5].Visible = true;
                RadGrid1.MasterTableView.Columns[8].Visible = true;
                RadGrid1.MasterTableView.Columns[6].Visible = false;
                RadGrid1.MasterTableView.Columns[7].Visible = false;                
            }
            else if (RadTabStrip1.SelectedIndex == 1)
            {
                //ready for deposit
                RadGrid1.DataSource = Peerfx_DB.SPs.ViewCurrencyCloudTradeBystatus(3).GetDataSet().Tables[0];                               
                RadGrid1.MasterTableView.GroupByExpressions.Clear();
                RadGrid1.MasterTableView.GroupByExpressions.Add(new GridGroupByExpression("buy_currency_text Group By buy_currency_text"));
                RadGrid1.MasterTableView.Columns[5].Visible = false;
                RadGrid1.MasterTableView.Columns[8].Visible = false;
                RadGrid1.MasterTableView.Columns[6].Visible = true;
                RadGrid1.MasterTableView.Columns[7].Visible = true;                
            }
            else if (RadTabStrip1.SelectedIndex == 2)
            {
                RadGrid1.DataSource = Peerfx_DB.SPs.ViewCurrencyCloudTradeBystatus(4).GetDataSet().Tables[0];
                RadGrid1.MasterTableView.GroupByExpressions.Clear();
                //RadGrid1.MasterTableView.DetailTables[0].GroupByExpressions.Add(new GridGroupByExpression("buy_currency_text Group By buy_currency_text"));
                //RadGrid1.MasterTableView.Columns[5].Visible = false;
                RadGrid1.MasterTableView.Columns[5].Visible = true;
                RadGrid1.MasterTableView.Columns[8].Visible = false;
                RadGrid1.MasterTableView.Columns[6].Visible = false;
                RadGrid1.MasterTableView.Columns[7].Visible = true;                
            }
        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            RadGrid1.Rebind();
            switch (RadTabStrip1.SelectedIndex)
            {
                case 0:
                    RadMultiPage1.SelectedIndex = 0;
                    break;
                case 1: RadMultiPage1.SelectedIndex = 0;
                    break;
                case 2: RadMultiPage1.SelectedIndex = 0;
                    break;
            }
        }

        protected void RadGrid1_DetailTableDataBind(object source, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
        {
            //load hierarchical table
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            int cc_settlement_key = Convert.ToInt32(dataItem.GetDataKeyValue("currencycloud_settlement_key"));

            DataTable dttemp = new DataTable();            
            dttemp = Peerfx_DB.SPs.ViewCurrencyCloudTradesBysettlementkeyBydirectlyfromcurrencycloud(cc_settlement_key, 0).GetDataSet().Tables[0];            
            e.DetailTableView.DataSource = dttemp;
        }        

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "btntradedetails")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int paymentkey = Convert.ToInt32(item["payments_key"].Text);
                LoadTradeDetails(paymentkey);
                pnlpaymentdetails.Visible = true;
            }
            else if (e.CommandName == "btnProcessSettlement")
            {                
                GridDataItem item = (GridDataItem)e.Item;
                Int64 ccsettlementkey = Convert.ToInt64(item["currencycloud_settlement_key"].Text);
                int status = Convert.ToInt32(item["status"].Text);
                if (status == 2)//withdrawl
                {
                    Peerfx_DB.SPs.UpdateCurrencyCloudSettlementsWithdrawlsent(ccsettlementkey).Execute();                    
                }
                else //deposit
                {
                    DataTable dttemp = Peerfx_DB.SPs.ViewCurrencyCloudTradesBysettlementkey(ccsettlementkey).GetDataSet().Tables[0];
                    foreach (DataRow dr in dttemp.Rows)
                    {
                        int paymentskey = Convert.ToInt32(dr["payments_key"]);
                        Models.Payment paymenttemp = sitetemp.getPayment(paymentskey);
                        sitetemp.payment_complete(paymenttemp);
                    }
                    Peerfx_DB.SPs.UpdateCurrencyCloudSettlementsFundsreceived(ccsettlementkey).Execute();                    
                }
                RadGrid1.Rebind();
            }
            else if (e.CommandName == "btnProcessTrade")
            {
                GridDataItem item = (GridDataItem)e.Item;
                Int64 cctradekey = Convert.ToInt64(item["currencycloud_trade_key"].Text);
                int status = Convert.ToInt32(item["cctrade_status"].Text);
                int paymentskey = Convert.ToInt32(item["payments_key"].Text);
                Payment paymenttemp = sitetemp.getPayment(paymentskey);
                if (status == 2)//withdrawl
                {
                    Peerfx_DB.SPs.UpdateCurrencyCloudTradesWithdrawlsent(cctradekey).Execute();

                    //move money from payment object to cc object
                    Peerfx_DB.SPs.UpdateConvertCurrencyCurrencyCloudSendtoCC(paymentskey, sitetemp.get_ipaddress(), paymenttemp.Requestor_user_key).Execute();
                    //change status to 9, Processing Transaction/At CurrencyCloud
                    Peerfx_DB.SPs.UpdatePaymentStatus(paymentskey, 9).Execute();                    
                }
                else //deposit
                {
                    Peerfx_DB.SPs.UpdateCurrencyCloudTradesFundsreceived(cctradekey).Execute();

                    //move money from cc object to payment object
                    Users cctreasury = sitetemp.get_treasury_account(2);                    
                    Int64 cctreasurypaymentobject = sitetemp.getpaymentobject_UserBalance(cctreasury.User_key,paymenttemp.Buy_currency);                 
                    Int64 paymentpaymentobject = sitetemp.getpaymentobject(6,paymentskey);
                    sitetemp.InternalTransaction(paymenttemp.Buy_currency, paymenttemp.Buy_amount, cctreasurypaymentobject, paymentpaymentobject, paymenttemp.Requestor_user_key, "CurrencyCloud to Payment Object", 1, paymentskey);

                    //complete payment, status will get changed in this function
                    sitetemp.payment_complete(paymenttemp);
                    
                }
                RadGrid1.Rebind();
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            //default values
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                RadButton radbtn = (RadButton)item["Actions"].FindControl("btnProcessTrade");
                if (RadTabStrip1.SelectedIndex == 2)
                {
                    radbtn.Visible = false;
                }
                else
                {
                    radbtn.Visible = true;
                }
            } 
        }

        protected void LoadTradeDetails(int paymentskey)
        {
            Paymentdetails1.LoadInfo(paymentskey,currentuser.User_key);
            Payment paymenttemp = sitetemp.getPayment(paymentskey);
            CCTradeDetails1.LoadInfo(paymenttemp.Currencycloudtradeid);
            CCPaymentDetails1.LoadInfo(paymenttemp.Currencycloudpaymentid);
        }
        
    }
}