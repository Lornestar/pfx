using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Peerfx.Models;

namespace Peerfx.Admin
{
    public partial class Admin_Withdrawl : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(true);
        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            RadGrid1.Rebind();
            RadMultiPage1.SelectedIndex = 0;
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataTable dttemp;
            switch (RadTabStrip1.SelectedIndex)
            {
                case 0: 
                    dttemp = Peerfx_DB.SPs.ViewPaymentsByStatus(10).GetDataSet().Tables[0];
                    RadGrid1.DataSource = dttemp;
                    if (!IsPostBack)
                    {
                        GridSortExpression expression = new GridSortExpression();
                        expression.FieldName = "date_created";
                        expression.SortOrder = GridSortOrder.Descending;
                        RadGrid1.MasterTableView.SortExpressions.AddSortExpression(expression);
                    }            
                    break;
                case 1:
                    dttemp = Peerfx_DB.SPs.ViewPaymentsProcessedWithdrawls().GetDataSet().Tables[0];
                    RadGrid1.DataSource = dttemp;                    
                    break;
            }            
            //RadGrid1.MasterTableView.Rebind();
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "btntradedetails")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int paymentkey = Convert.ToInt32(item["payments_key"].Text);
                LoadTradeDetails(paymentkey);
                pnltradedetails.Visible = true;
            }
            if (e.CommandName == "btnWithdraw")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int paymentkey = Convert.ToInt32(item["payments_key"].Text);
                Payment paymenttemp = sitetemp.getPayment(paymentkey);
                Int64 payment_payment_object_key = sitetemp.getpaymentobject(6, paymentkey);
                Users user_requestor = sitetemp.get_user_info(paymenttemp.Requestor_user_key);

                sitetemp.InternalTransaction(paymenttemp.Buy_currency, paymenttemp.Buy_amount, payment_payment_object_key, paymenttemp.Payment_object_receiver, currentuser.User_key, "From Payment object to Withdrawl Bank Account", 1, paymentkey);                
                Peerfx_DB.SPs.UpdatePaymentStatus(paymentkey, 5).Execute(); //payment delivered

                //payment completed, send email 
                Peerfx.External_APIs.SendGrid sg = new Peerfx.External_APIs.SendGrid();   
                sg.Send_Email_Payment_Completed(paymenttemp.Payments_Key, user_requestor);

                RadGrid1.Rebind();
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                DataRowView row = (DataRowView)e.Item.DataItem;
                Int64 receiver_payment_object_key = Convert.ToInt32(row["payment_object_receiver"]);
                item["bank_account_description"].Text = sitetemp.getBankAccountDescription(receiver_payment_object_key);

                if (RadTabStrip1.SelectedIndex == 0)
                {
                    item.FindControl("btnWithdraw").Visible = true;
                }
                else
                {
                    item.FindControl("btnWithdraw").Visible = false;
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