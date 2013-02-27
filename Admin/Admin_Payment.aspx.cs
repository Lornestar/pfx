using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;
using Telerik.Web.UI;
using System.Data;

namespace Peerfx.Admin
{
    public partial class Admin_Payment : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(true);
            if (!IsPostBack)
            {

            }
        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            RadGrid1.Rebind();            
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet dstemp = new DataSet();
            switch (RadTabStrip1.SelectedIndex)
            {
                case 0:
                    dstemp = Peerfx_DB.SPs.ViewPaymentsByStatusExternalobjects(2).GetDataSet();
                    break;
                case 1:
                    dstemp = Peerfx_DB.SPs.ViewPaymentsByStatusExternalobjects(3).GetDataSet();
                    break;
                case 2:
                    dstemp = Peerfx_DB.SPs.ViewPaymentsByStatusExternalobjects(4).GetDataSet();
                    break;
                case 3:
                    dstemp = Peerfx_DB.SPs.ViewPaymentsByStatusExternalobjects(5).GetDataSet();
                    break;
                case 4:
                    dstemp = Peerfx_DB.SPs.ViewPaymentsInternalOnly().GetDataSet();
                    break;
            }            
            RadGrid1.DataSource = dstemp.Tables[0];
        }

        protected void RadGrid1_DetailTableDataBind(object source, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            int payments_key = Convert.ToInt32(dataItem.GetDataKeyValue("payments_key"));
            e.DetailTableView.DataSource = sitetemp.view_transaction_all_specificpayment(payments_key);
            
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {            
            if (e.CommandName == "btnupdatestatus")
            {
                GridDataItem item = (GridDataItem)e.Item;
                RadComboBox ddlconnectuser = (RadComboBox)item.FindControl("ddlupdatestatus");
                RadButton btnupdatestatus = (RadButton)item.FindControl("btnupdatestatus");
                RadButton btnconfirmmoneysent = (RadButton)item.FindControl("btnconfirmmoneysent");
                RadButton btncancelmoneysent = (RadButton)item.FindControl("btncancelmoneysent");
                Label lblbankaccountsent = (Label)item.FindControl("lblbankaccountsent");
                int paymentkey = Convert.ToInt32(item["payments_key"].Text);
                Int64 receiverpaymentobjectkey = 0;
                RadNumericTextBox txtamount = (RadNumericTextBox)item.FindControl("txtamount");
                if (sitetemp.IsNumeric(item["payment_object_receiver"].Text))
                {
                    receiverpaymentobjectkey = Convert.ToInt64(item["payment_object_receiver"].Text);
                }                
                Panel pnlmoneysent = (Panel)item.FindControl("pnlmoneysent");
                if (!ddlconnectuser.IsEmpty)
                {
                    if (ddlconnectuser.SelectedValue == "5")
                    {
                        //Payment delivered
                        btnupdatestatus.Visible = false;
                        pnlmoneysent.Visible = true;
                        lblbankaccountsent.Text = sitetemp.getBankAccountDescription(receiverpaymentobjectkey);
                        ddlconnectuser.Enabled = false;
                        txtamount.Value = 0;                        
                    }
                    else
                    {
                        //Change payment status
                        Peerfx_DB.SPs.UpdatePaymentStatus(paymentkey, Convert.ToInt32(ddlconnectuser.SelectedValue)).Execute();
                        RadGrid1.Rebind();
                    }                    
                }
            }
            else if (e.CommandName == "btnconfirmmoneysent")
            {
                GridDataItem item = (GridDataItem)e.Item;
                Panel pnlmoneysent = (Panel)item.FindControl("pnlmoneysent");
                RadComboBox ddlconnectuser = (RadComboBox)item.FindControl("ddlupdatestatus");
                RadButton btnupdatestatus = (RadButton)item.FindControl("btnupdatestatus");
                int paymentkey = Convert.ToInt32(item["payments_key"].Text);
                decimal buyamount = Convert.ToDecimal(item["buy_amount"].Text);
                RadNumericTextBox txtamount = (RadNumericTextBox)item.FindControl("txtamount");

                //Check to make sure amount is correct
                if (buyamount == Convert.ToDecimal(txtamount.Value))
                {                    
                    Peerfx_DB.SPs.UpdateProcessWithdrawlPayment(Convert.ToDecimal(txtamount.Text), paymentkey, sitetemp.get_ipaddress(), currentuser.User_key).Execute();
                    pnlmoneysent.Visible = false;
                    ddlconnectuser.Enabled = true;
                    btnupdatestatus.Visible = true;
                    ddlconnectuser.Text = "";
                    ddlconnectuser.ClearSelection();
                    RadGrid1.Rebind();
                }
                else
                {
                    Label lblerror = (Label)item.FindControl("lblerror");
                    lblerror.Visible = true;
                    lblerror.Text = "Buy amount & amount you typed do not match";
                }                
            }
            else if (e.CommandName == "btncancelmoneysent")
            {
                //cancel that
                GridDataItem item = (GridDataItem)e.Item;
                Panel pnlmoneysent = (Panel)item.FindControl("pnlmoneysent");
                RadComboBox ddlconnectuser = (RadComboBox)item.FindControl("ddlupdatestatus");
                RadButton btnupdatestatus = (RadButton)item.FindControl("btnupdatestatus");
                pnlmoneysent.Visible = false;
                ddlconnectuser.Enabled = true;
                btnupdatestatus.Visible = true;
                ddlconnectuser.Text = "";
                ddlconnectuser.ClearSelection();
            }
            else if (e.CommandName == "btnconvertcurrency")
            {
                GridDataItem item = (GridDataItem)e.Item;                
                int paymentkey = Convert.ToInt32(item["payments_key"].Text);
                int sellcurrency = Convert.ToInt32(item["sell_currency"].Text);
                int buycurrency = Convert.ToInt32(item["buy_currency"].Text);
                
                decimal sellamount = Convert.ToDecimal(item["sell_amount"].Text);
                

                
                    //Add in actual quote & convert currency                    
                    sitetemp.insert_quote_actual_convert_currency(paymentkey, sellcurrency, buycurrency, currentuser,sellamount,false);

                    RadGrid1.Rebind();
                
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                if (item.OwnerTableView.Name == "Payments")
                {
                    DataRowView row = (DataRowView)e.Item.DataItem;
                    RadComboBox ddlconnectuser = (RadComboBox)item.FindControl("ddlupdatestatus");
                    Panel pnlupdatestatus = (Panel)item.FindControl("pnlupdatestatus");
                    Panel pnlmoneysent = (Panel)item.FindControl("pnlmoneysent");
                    Panel pnlconvertcurrency = (Panel)item.FindControl("pnlconvertcurrency");
                    int paymentstatus = Convert.ToInt32(item["payment_status"].Text);
                    if (RadTabStrip1.SelectedIndex != 4)
                    {
                        //it's not an internal only payment

                        if (paymentstatus == 3)//Bank Transfer Received
                        {
                            Int64 receiverpaymentobjectkey = 0;
                            if (sitetemp.IsNumeric(item["payment_object_receiver"].Text))
                            {
                                receiverpaymentobjectkey = Convert.ToInt64(item["payment_object_receiver"].Text);
                            }
                            if (sitetemp.Isexternal(receiverpaymentobjectkey))
                            {
                                pnlconvertcurrency.Visible = true;
                            }
                        }
                        else if (paymentstatus == 4)
                        {
                            pnlmoneysent.Visible = true;
                            Label lblbankaccountsent = (Label)item.FindControl("lblbankaccountsent");
                            Int64 receiverpaymentobjectkey = 0;
                            RadNumericTextBox txtamount = (RadNumericTextBox)item.FindControl("txtamount");
                            if (sitetemp.IsNumeric(item["payment_object_receiver"].Text))
                            {
                                receiverpaymentobjectkey = Convert.ToInt64(item["payment_object_receiver"].Text);
                            }
                            lblbankaccountsent.Text = sitetemp.getBankAccountDescription(receiverpaymentobjectkey);
                            txtamount.Value = 0;
                            Label lblcurrencysymbol = (Label)item.FindControl("lblcurrencysymbol");
                            int buycurrency = Convert.ToInt32(item["buy_currency"].Text);
                            lblcurrencysymbol.Text = sitetemp.GetCurrencySymbol(buycurrency);
                            Label lblerror = (Label)item.FindControl("lblerror");
                            lblerror.Visible = false;
                        }
                    }
                    
                    ddlconnectuser.DataTextField = "payment_status_description";
                    ddlconnectuser.DataValueField = "payment_status_key";
                    ddlconnectuser.DataSource = sitetemp.view_payment_status();
                    ddlconnectuser.DataBind();
                    
                    
                }
                else if (item.OwnerTableView.Name == "Transactions")
                {
                    DataRowView row = (DataRowView)e.Item.DataItem;
                    Label lblfrom = (Label)item.FindControl("lblfrom");
                    Label lblto = (Label)item.FindControl("lblto");
                    if (sitetemp.IsNumeric(item["payment_object_sender"].Text))
                    {
                        Int64 payment_object_sender = Convert.ToInt64(item["payment_object_sender"].Text);
                        if (payment_object_sender > 0)
                        {
                            lblfrom.Text = sitetemp.getBankAccountDescription(payment_object_sender);
                        }                        
                    }
                    if (sitetemp.IsNumeric(item["payment_object_receiver"].Text))
                    {
                        Int64 payment_object_receiver = Convert.ToInt64(item["payment_object_receiver"].Text);
                        if (payment_object_receiver > 0)
                        {
                            lblto.Text = sitetemp.getBankAccountDescription(payment_object_receiver);
                        }                        
                    }                                       
                }
            }
        }

    }
}