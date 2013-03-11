using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using SubSonic;
using Peerfx.Models;

namespace Peerfx.Admin
{
    public partial class Admin_Deposits : System.Web.UI.Page
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
            switch (RadTabStrip1.SelectedIndex)
            {
                case 0: RadGrid1.Rebind();
                    break;
                case 1: RadGrid2.Rebind();
                    break;
            }
        }

        protected void RadGrid1_DetailTableDataBind(object source, Telerik.Web.UI.GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.DetailTableView.ParentItem;
            int tx_key = Convert.ToInt32(dataItem.GetDataKeyValue("tx_external_key"));            
            e.DetailTableView.DataSource = sitetemp.view_transaction_fees_txkey(0, tx_key);
            
            //e.DetailTableView.DataBind();
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewAdminDeposits(false).GetDataSet();
            RadGrid1.DataSource = dstemp.Tables[0];
        }

        protected void RadGrid2_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewAdminDeposits(true).GetDataSet();
            RadGrid2.DataSource = dstemp.Tables[0];
        }

        protected void RadGrid_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
        {
        }


        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            //tx statuses 
            //1 = pending
            //2 = processed
            //3 = removed
            if (e.CommandName == "btnconnectuser")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int txkey = Convert.ToInt32(item["tx_external_key"].Text);
                RadComboBox ddlconnectuser = (RadComboBox)item.FindControl("ddlconnectuser");
                if (ddlconnectuser.SelectedIndex > -1)
                {
                    int userkey = Convert.ToInt32(ddlconnectuser.SelectedValue);
                    Peerfx_DB.SPs.UpdateProcessDeposit(txkey, 2, userkey).Execute();
                    RadGrid1.Rebind();
                }
                else
                {
                    Label lblerror = (Label)item.FindControl("lblerror");
                    lblerror.Text = "You must select a user";
                    lblerror.Visible = true;
                }
            }
            else if (e.CommandName == "btnconnectpayment")
            {
                //connect tx to a payment
                GridDataItem item = (GridDataItem)e.Item;
                int txkey = Convert.ToInt32(item["tx_external_key"].Text);
                RadComboBox ddlconnectuser = (RadComboBox)item.FindControl("ddlconnectpayment");
                if (ddlconnectuser.SelectedIndex > -1)
                {
                    int userkey = Convert.ToInt32(ddlconnectuser.SelectedValue);
                    Peerfx_DB.SPs.UpdateProcessDeposit(txkey, 1, userkey).Execute();
                    RadGrid1.Rebind();
                    
                    //Send to currency conversion
                    sitetemp.payment_convert_currency(userkey);
                }
                else
                {
                    Label lblerror = (Label)item.FindControl("lblerror");
                    lblerror.Text = "You must select a payment";
                    lblerror.Visible = true;
                }
            }
            else if (e.CommandName == "btnremovedeposit")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int txkey = Convert.ToInt32(item["tx_external_key"].Text);
                Peerfx_DB.SPs.UpdateTransactionExternalStatus(txkey, 3, sitetemp.get_ipaddress(),currentuser.User_key).Execute();
                RadGrid1.Rebind();
            }
            else if (e.CommandName == "Update")
            {
                //updating fees
                GridEditFormItem item = (GridEditFormItem)e.Item;

                Label lbltxfees = (Label)item.FindControl("lbltxfeeskey");
                int txfees = Convert.ToInt32(lbltxfees.Text);
                RadNumericTextBox txtamount = (RadNumericTextBox)item.FindControl("txtamount");
                RadComboBox ddlconnectuser = (RadComboBox)item.FindControl("ddlcurrency");
                string description = (item["description"].Controls[0] as TextBox).Text;
                Peerfx_DB.SPs.UpdateTransactionFees(txfees, 0, 0, Convert.ToDecimal(txtamount.Text), Convert.ToInt32(ddlconnectuser.SelectedValue), description, null,0).Execute();
            }
            else if (e.CommandName == "btninsertexisting")
            {
                //insert new deposit & connect it to existing bank account

                GridEditFormInsertItem insertedItem = (GridEditFormInsertItem)e.Item;
                decimal amount = Convert.ToDecimal((insertedItem["tx_external_key"].FindControl("txtamountexisting") as RadNumericTextBox).Text);
                int sender_bank_key = Convert.ToInt32((insertedItem["tx_external_key"].FindControl("ddlexistingbankaccounts") as RadComboBox).SelectedValue);
                int receiver_bank_key = Convert.ToInt32((insertedItem["tx_external_key"].FindControl("ddlreceiveraccount") as RadComboBox).SelectedValue);
                string Description = (insertedItem["tx_external_key"].FindControl("txtdeposit") as RadTextBox).Text;
                string bankreference = (insertedItem["tx_external_key"].FindControl("txtbankref") as RadTextBox).Text;

                Peerfx_DB.SPs.UpdateTransactionsExternal(0, 1, sitetemp.getbankaccountcurrency(receiver_bank_key), amount, sitetemp.getpaymentobject(sender_bank_key), sitetemp.getpaymentobject(receiver_bank_key), sitetemp.get_ipaddress(), currentuser.User_key, Description, bankreference, 0, null, null).Execute();

                RadGrid1.EditIndexes.Clear();
                RadGrid1.MasterTableView.IsItemInserted = false;
                RadGrid1.MasterTableView.Rebind();  
            }
        }

        protected void RadGrid2_ItemCommand(object source, GridCommandEventArgs e)
        { 

        }


        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {                
                GridDataItem item = (GridDataItem)e.Item;
                if (item.OwnerTableView.Name == "Fees")
                {
                    DataRowView row = (DataRowView)e.Item.DataItem;
                    item["tx_fees_key"].Text = row["tx_fees_key"].ToString();
                    item["amount"].Text = row["amount"].ToString();
                    item["info_currency_code"].Text = row["info_currency_code"].ToString();
                    item["date_created"].Text = row["date_created"].ToString();                    
                }
                else
                {
                    DataRowView row = (DataRowView)e.Item.DataItem;
                    item["sender_bank_name"].Text = row["sender_bank_name"].ToString();
                    item["receiver_bank_name"].Text = row["receiver_bank_name"].ToString() + " " + row["receiver_bank_account"].ToString();
                    item["tx_external_key"].Text = row["tx_external_key"].ToString();
                    item["info_currency_code"].Text = row["info_currency_code"].ToString();
                    item["amount"].Text = row["amount"].ToString();
                    item["last_changed"].Text = row["last_changed"].ToString();
                    item["proceeds"].Text = row["proceeds"].ToString();
                    RadComboBox ddlconnectuser = (RadComboBox)item.FindControl("ddlconnectuser");
                    ddlconnectuser.DataTextField = "user_info_full";
                    ddlconnectuser.DataValueField = "user_key";
                    ddlconnectuser.DataSource = sitetemp.view_users_all();
                    ddlconnectuser.DataBind();

                    RadComboBox ddlconnectpayment = (RadComboBox)item.FindControl("ddlconnectpayment");
                    ddlconnectpayment.DataTextField = "payments_info";
                    ddlconnectpayment.DataValueField = "payments_key";
                    ddlconnectpayment.DataSource = sitetemp.view_payments_confirmed();
                    ddlconnectpayment.DataBind();             
                }                                
            }                  
            
            if (e.Item is GridEditableItem && (e.Item as GridEditableItem).IsInEditMode)            
            {
                GridEditableItem editedItem = e.Item as GridEditableItem;
                GridEditManager editMan = editedItem.EditManager;                    
                if (editedItem.OwnerTableView.Name == "Fees")
                {
                    RadComboBox ddlcurrency = (RadComboBox)e.Item.FindControl("ddlcurrency");
                    ddlcurrency.DataTextField = "info_currency_code";
                    ddlcurrency.DataValueField = "info_currencies_key";
                    ddlcurrency.DataSource = sitetemp.view_info_currencies();
                    ddlcurrency.DataBind();
                    ddlcurrency.MarkFirstMatch = true;

                    if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)
                    {
                    }
                    else
                    {
                        //is edit form
                        DataRowView row = (DataRowView)e.Item.DataItem;
                        RadNumericTextBox txtamount = (RadNumericTextBox)e.Item.FindControl("txtamount");
                        txtamount.Text = row["amount"].ToString();
                        Label lbltxfeeskey = (Label)e.Item.FindControl("lbltxfeeskey");
                        lbltxfeeskey.Text = row["tx_fees_key"].ToString();
                    }
                }
                else
                {
                    if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)
                    {
                        // insert item
                        GridDropDownListColumnEditor ddlbank = editMan.GetColumnEditor("sender_bank_name") as GridDropDownListColumnEditor;
                        ddlbank.DataTextField = "organization_name";
                        ddlbank.DataValueField = "info_organizations_key";
                        ddlbank.DataSource = sitetemp.view_info_banks();
                        ddlbank.DataBind();
                        ddlbank.ComboBoxControl.MarkFirstMatch = true;
                        ddlbank.ComboBoxControl.AllowCustomText = true;

                        GridDropDownListColumnEditor ddlbank2 = editMan.GetColumnEditor("receiver_bank_name") as GridDropDownListColumnEditor;
                        ddlbank2.DataTextField = "bank_account_info";
                        ddlbank2.DataValueField = "bank_account_key";
                        ddlbank2.DataSource = sitetemp.view_system_bank_accounts();
                        ddlbank2.DataBind();
                        ddlbank2.ComboBoxControl.MarkFirstMatch = true;

                        RadComboBox ddlbank3 = (RadComboBox)e.Item.FindControl("ddlreceiveraccount");
                        ddlbank3.DataTextField = "bank_account_info";
                        ddlbank3.DataValueField = "bank_account_key";
                        ddlbank3.DataSource = sitetemp.view_system_bank_accounts();
                        ddlbank3.DataBind();
                        ddlbank3.MarkFirstMatch = true;                        

                        RadComboBox ddlcurrency = (RadComboBox)e.Item.FindControl("ddlcurrency");
                        ddlcurrency.DataTextField = "info_currency_code";
                        ddlcurrency.DataValueField = "info_currencies_key";
                        ddlcurrency.DataSource = sitetemp.view_info_currencies();
                        ddlcurrency.DataBind();
                        ddlcurrency.MarkFirstMatch = true;

                        RadComboBox ddlexistingbankaccounts = (RadComboBox)e.Item.FindControl("ddlexistingbankaccounts");
                        ddlexistingbankaccounts.DataTextField = "bank_account_info";
                        ddlexistingbankaccounts.DataValueField = "payment_object_key";
                        ddlexistingbankaccounts.DataSource = sitetemp.view_bank_accounts_users();
                        ddlexistingbankaccounts.DataBind();
                        ddlexistingbankaccounts.MarkFirstMatch = true;                        
                    }                    
                }                
            }
        }

        protected void RadGrid2_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
            //insert new row into db
            //Get the GridEditFormInsertItem of the RadGrid             
            GridEditFormInsertItem insertedItem = (GridEditFormInsertItem)e.Item;

            if (insertedItem.OwnerTableView.Name == "Fees")
            {
                string Description = (insertedItem["description"].Controls[0] as TextBox).Text;
                int currency = Convert.ToInt32((insertedItem["info_currency_code"].FindControl("ddlcurrency") as RadComboBox).SelectedValue);
                decimal amount = Convert.ToDecimal((insertedItem["amount"].FindControl("txtamount") as RadNumericTextBox).Text);

                GridDataItem parentItem = e.Item.OwnerTableView.ParentItem;
                
                int tx_key = Convert.ToInt32(parentItem["tx_external_key"].Text);
                
                Peerfx_DB.SPs.UpdateTransactionFees(0, 0, tx_key, amount, currency, Description, null, 0).Execute();
            }
            else
            {
                int sender_bank_key = Convert.ToInt32((insertedItem["sender_bank_name"].Controls[0] as RadComboBox).SelectedValue);
                string sender_bankaccount = (insertedItem["sender_bank_account"].Controls[0] as TextBox).Text;
                int receiver_bank_key = Convert.ToInt32((insertedItem["receiver_bank_name"].Controls[0] as RadComboBox).SelectedValue);
                string Description = (insertedItem["tx_external_description"].Controls[0] as TextBox).Text;
                int currency = Convert.ToInt32((insertedItem["info_currency_code"].FindControl("ddlcurrency") as RadComboBox).SelectedValue);
                decimal amount = Convert.ToDecimal((insertedItem["amount"].FindControl("txtamount") as RadNumericTextBox).Text);
                string bankreference = (insertedItem["bank_reference"].Controls[0] as TextBox).Text;

                StoredProcedure sp_UpdateBank_account = Peerfx_DB.SPs.UpdateBankAccounts(0, null, currency, Convert.ToInt32(sender_bank_key), null, currentuser.User_key, sitetemp.get_ipaddress(), sender_bankaccount, null, null, null, null, null, null, 0);
                sp_UpdateBank_account.Execute();
                int bank_account_key = Convert.ToInt32(sp_UpdateBank_account.Command.Parameters[14].ParameterValue.ToString());
                //Save payment object
                StoredProcedure sp_Updatepaymentobject = Peerfx_DB.SPs.UpdatePaymentObjects(0, 1, bank_account_key, 0);
                sp_Updatepaymentobject.Execute();
                Int64 paymentobjectsender = Convert.ToInt64(sp_Updatepaymentobject.Command.Parameters[3].ParameterValue);

                StoredProcedure sp_NewPendingDeposit = Peerfx_DB.SPs.UpdateTransactionsExternal(0, 1, currency, amount, paymentobjectsender, sitetemp.getpaymentobject(receiver_bank_key), sitetemp.get_ipaddress(), currentuser.User_key, Description, bankreference, 0,null,null);
                sp_NewPendingDeposit.Execute();            
            }            
        }

        protected void RadGrid1_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
        {
            GridEditFormInsertItem insertedItem = (GridEditFormInsertItem)e.Item;

            if (insertedItem.OwnerTableView.Name == "Fees")
            {
                string Description = (insertedItem["description"].Controls[0] as TextBox).Text;
                int currency = Convert.ToInt32((insertedItem["info_currency_code"].FindControl("ddlcurrency") as RadComboBox).SelectedValue);
                decimal amount = Convert.ToDecimal((insertedItem["amount"].FindControl("txtamount") as RadNumericTextBox).Text);

                GridDataItem parentItem = e.Item.OwnerTableView.ParentItem;

                int tx_key = Convert.ToInt32(parentItem["tx_external_key"].Text);

                Peerfx_DB.SPs.UpdateTransactionFees(0, 0, tx_key, amount, currency, Description, null, 0).Execute();
            }
            
        }
        
    }
}