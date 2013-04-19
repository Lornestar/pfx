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
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (RadTabStrip1.SelectedIndex == 0)
            {
                //withdrawls
                RadGrid1.DataSource = Peerfx_DB.SPs.ViewCurrencyCloudSettlementBystatus(2).GetDataSet().Tables[0];

                RadGrid1.MasterTableView.DetailTables[0].GroupByExpressions.Clear();                
                RadGrid1.MasterTableView.DetailTables[0].GroupByExpressions.Add(new GridGroupByExpression("sell_currency_text Group By sell_currency_text"));
                RadGrid1.MasterTableView.Columns[5].Visible = true;
            }
            else if (RadTabStrip1.SelectedIndex == 1)
            {
                //ready for deposit
                RadGrid1.DataSource = Peerfx_DB.SPs.ViewCurrencyCloudSettlementBystatus(3).GetDataSet().Tables[0];                               
                RadGrid1.MasterTableView.DetailTables[0].GroupByExpressions.Clear();
                RadGrid1.MasterTableView.DetailTables[0].GroupByExpressions.Add(new GridGroupByExpression("buy_currency_text Group By buy_currency_text"));
                RadGrid1.MasterTableView.Columns[5].Visible = true;
            }
            else if (RadTabStrip1.SelectedIndex == 2)
            {
                RadGrid1.DataSource = Peerfx_DB.SPs.ViewCurrencyCloudSettlementBystatus(4).GetDataSet().Tables[0];
                RadGrid1.MasterTableView.DetailTables[0].GroupByExpressions.Clear();
                RadGrid1.MasterTableView.DetailTables[0].GroupByExpressions.Add(new GridGroupByExpression("buy_currency_text Group By buy_currency_text"));
                RadGrid1.MasterTableView.Columns[5].Visible = false;
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
            if ((RadTabStrip1.SelectedIndex == 1) || (RadTabStrip1.SelectedIndex == 2))
            {
                dttemp = Peerfx_DB.SPs.ViewCurrencyCloudTradesBysettlementkeyBydirectlyfromcurrencycloud(cc_settlement_key, 0).GetDataSet().Tables[0];
            }
            else
            {
                dttemp = Peerfx_DB.SPs.ViewCurrencyCloudTradesBysettlementkey(cc_settlement_key).GetDataSet().Tables[0];
            }
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
            if (e.CommandName == "btnProcessSettlement")
            {                
                GridDataItem item = (GridDataItem)e.Item;
                Int64 ccsettlementkey = Convert.ToInt64(item["currencycloud_settlement_key"].Text);
                int status = Convert.ToInt32(item["status"].Text);
                if (status == 2)//withdrawl
                {
                    Peerfx_DB.SPs.UpdateCurrencyCloudSettlementsWithdrawlsent(ccsettlementkey).Execute();
                    RadGrid1.Rebind();
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
                    RadGrid1.Rebind();
                }                
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            //default values

        }

        protected void LoadTradeDetails(int paymentskey)
        {
            Paymentdetails1.LoadInfo(paymentskey);
            Payment paymenttemp = sitetemp.getPayment(paymentskey);
            CCTradeDetails1.LoadInfo(paymenttemp.Currencycloudtradeid);
        }
        
    }
}