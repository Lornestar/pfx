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
            DataSet dstemp = Peerfx_DB.SPs.ViewAdminDeposits(1).GetDataSet();
            RadGrid1.DataSource = dstemp.Tables[0];
        }

        protected void RadGrid2_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewAdminDeposits(2).GetDataSet();
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
                int userkey = Convert.ToInt32(ddlconnectuser.SelectedValue);
                Peerfx_DB.SPs.UpdateTransactionExternalStatus(txkey, 2, sitetemp.get_ipaddress(), userkey, 0).Execute();
                RadGrid1.Rebind();

            }
            else if (e.CommandName == "btnremovedeposit")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int txkey = Convert.ToInt32(item["tx_external_key"].Text);
                Peerfx_DB.SPs.UpdateTransactionExternalStatus(txkey, 3, sitetemp.get_ipaddress(), null, 0).Execute();
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
                    item["sender_bank_name"].Text = row["sender_bank_name1"].ToString();
                    item["receiver_bank_name"].Text = row["receiver_bank_name1"].ToString() + " " + row["receiver_bank_account1"].ToString();
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
                        ddlbank2.DataTextField = "organization_name_full";
                        ddlbank2.DataValueField = "bank_account_key";
                        ddlbank2.DataSource = sitetemp.view_system_bank_accounts();
                        ddlbank2.DataBind();
                        ddlbank2.ComboBoxControl.MarkFirstMatch = true;

                        RadComboBox ddlcurrency = (RadComboBox)e.Item.FindControl("ddlcurrency");
                        ddlcurrency.DataTextField = "info_currency_code";
                        ddlcurrency.DataValueField = "info_currencies_key";
                        ddlcurrency.DataSource = sitetemp.view_info_currencies();
                        ddlcurrency.DataBind();
                        ddlcurrency.MarkFirstMatch = true;
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
                string sender_bank_key = (insertedItem["sender_bank_name"].Controls[0] as RadComboBox).Text;
                string sender_bankaccount = (insertedItem["sender_bank_account"].Controls[0] as TextBox).Text;
                int receiver_bank_key = Convert.ToInt32((insertedItem["receiver_bank_name"].Controls[0] as RadComboBox).SelectedValue);
                string Description = (insertedItem["tx_external_description"].Controls[0] as TextBox).Text;
                int currency = Convert.ToInt32((insertedItem["info_currency_code"].FindControl("ddlcurrency") as RadComboBox).SelectedValue);
                decimal amount = Convert.ToDecimal((insertedItem["amount"].FindControl("txtamount") as RadNumericTextBox).Text);
                string bankreference = (insertedItem["bank_reference"].Controls[0] as TextBox).Text;

                StoredProcedure sp_NewPendingDeposit = Peerfx_DB.SPs.UpdateTransactionsExternal(0, 1, 1, currency, amount, null, receiver_bank_key, sitetemp.get_ipaddress(), null, Description, sender_bank_key, sender_bankaccount, "", "", null, bankreference, 0);
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