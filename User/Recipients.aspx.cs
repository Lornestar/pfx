using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;
using System.Collections;

namespace Peerfx.User
{
    public partial class Recipients : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(false);
            LoadListView();
            if (!IsPostBack)
            {
                ddlcurrency.DataTextField = "info_currency_code";
                ddlcurrency.DataValueField = "info_currencies_key";
                ddlcurrency.DataSource = sitetemp.view_info_currencies_canbuy();
                ddlcurrency.DataBind();
            }
        }

        protected void LoadListView()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewRecipientsByuser(currentuser.User_key).GetDataSet();
            RadListView1.DataSource = dstemp.Tables[0];
            RadListView1.DataBind();
        }

        protected void btnaddrecipient_Click(object sender, EventArgs e)
        {
            //add new recipient
            pnladdnew.Visible = true;
            resetaddnew();
        }

        protected void resetaddnew()
        {
            pnlIBAN.Visible = true;
            pnlBankCode.Visible = true;
            pnlAccountNumber.Visible = false;
            pnlABArouting.Visible = false;
            txtIbanAccount.Text = "";
            txtBankCode.Text = "";
            txtABArouting.Text = "";
            txtaccountnumber.Text = "";
            hdcurrentbankaccountkey.Value = "0";
        }

        protected void ddlcurrency_changed(object sender, EventArgs e)
        {
            if (ddlcurrency.SelectedItem.Text == "USD")
            {
                pnlIBAN.Visible = false;
                pnlBankCode.Visible = false;
                pnlABArouting.Visible = true;
                pnlAccountNumber.Visible = true;
            }
            else
            {
                pnlIBAN.Visible = true;
                pnlBankCode.Visible = true;
                pnlAccountNumber.Visible = false;
                pnlABArouting.Visible = false;
            }
        }

        protected void btnsavechange_Click(object sender, EventArgs e)
        {
            if (hdcurrentbankaccountkey.Value == "0")
            {
                //insert new bank account
                Int64 paymentobjectkey = sitetemp.insert_bank_account_returnpaymentobject(0, Convert.ToInt32(ddlcurrency.SelectedValue), 11, null, currentuser.User_key, txtaccountnumber.Text, txtIbanAccount.Text, txtBankCode.Text, txtABArouting.Text, txtfirstname.Text, txtlastname.Text, null);

                Peerfx_DB.SPs.UpdateRecipients(0, currentuser.User_key, paymentobjectkey).Execute();
            }
            else
            {
                //update existing
                int bankaccountkey = Convert.ToInt32(hdcurrentbankaccountkey.Value);
                Peerfx_DB.SPs.UpdateBankAccounts(bankaccountkey, null, Convert.ToInt32(ddlcurrency.SelectedValue), null, null, currentuser.User_key, sitetemp.get_ipaddress(), txtaccountnumber.Text, txtIbanAccount.Text, txtBankCode.Text, txtABArouting.Text, txtfirstname.Text, txtlastname.Text, null, 0).Execute();
            }
            LoadListView();
            pnladdnew.Visible = false;
        }

        protected void RadListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hashtable values = new Hashtable();
            int selectedindex = RadListView1.SelectedItems[0].DataItemIndex;
            RadListView1.SelectedItems[0].ExtractValues(values);
            
            int bankaccountkey = Convert.ToInt32(values["bank_account_key"]);
            hdcurrentbankaccountkey.Value = bankaccountkey.ToString();
            DataSet dstemp = Peerfx_DB.SPs.ViewBankAccountsSpecific(bankaccountkey).GetDataSet();

            pnlAccountNumber.Visible=false;
            pnlABArouting.Visible = false;
            pnlBankCode.Visible=false;
            pnlIBAN.Visible = false;
            if (dstemp.Tables[0].Rows[0]["first_name"] != DBNull.Value)
            {
                txtfirstname.Text = dstemp.Tables[0].Rows[0]["first_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["last_name"] != DBNull.Value)
            {
                txtlastname.Text = dstemp.Tables[0].Rows[0]["last_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["account_number"] != DBNull.Value)
            {
                txtaccountnumber.Text = dstemp.Tables[0].Rows[0]["account_number"].ToString();
                if (txtaccountnumber.Text.Trim().Length > 0){
                    pnlAccountNumber.Visible=true;
                }                
            }
            if (dstemp.Tables[0].Rows[0]["IBAN"] != DBNull.Value)
            {
                txtIbanAccount.Text = dstemp.Tables[0].Rows[0]["IBAN"].ToString();
                if (txtIbanAccount.Text.Trim().Length > 0){
                    pnlIBAN.Visible=true;
                }                
            }
            if (dstemp.Tables[0].Rows[0]["BIC"] != DBNull.Value)
            {
                txtBankCode.Text = dstemp.Tables[0].Rows[0]["BIC"].ToString();
                if (txtBankCode.Text.Trim().Length > 0){
                    pnlBankCode.Visible = true;
                }
            }
            if (dstemp.Tables[0].Rows[0]["ABArouting"] != DBNull.Value)
            {
                txtABArouting.Text = dstemp.Tables[0].Rows[0]["ABArouting"].ToString();
                if (txtABArouting.Text.Trim().Length > 0){
                    pnlABArouting.Visible = true;
                }
            }
            if (dstemp.Tables[0].Rows[0]["currency_key"] != DBNull.Value)
            {
                ddlcurrency.SelectedValue = dstemp.Tables[0].Rows[0]["currency_key"].ToString();
            }

            pnladdnew.Visible = true;
        }

        protected void editrow(string bankaccountkey)
        {
            //string strtemp = e.CommandArgument.ToString(); 
            pnladdnew.Visible = true;
        }    
        

    }
}