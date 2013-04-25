using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;
using Telerik.Web.UI;
using SubSonic;
namespace Peerfx.User
{
    public partial class Withdraw : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(false);
            if (!IsPostBack)
            {
                Loadcurrency();
                if (ddlcurrency.SelectedIndex > -1)
                {
                    Loadreceiverlist();
                }                
                BankAccountEntry1.hidecurrency();                
            }
        }

        protected void Loadcurrency()
        {
            DataTable dtfundingsources = Peerfx_DB.SPs.ViewUserCurrenciesHasBalancein(currentuser.User_key).GetDataSet().Tables[0];
            if (dtfundingsources.Rows.Count > 0)
            {
                pnldonthavebalance.Visible = false;
                pnlhavebalance.Visible = true;
                
                ddlcurrency.DataValueField = "info_currencies_key";
                ddlcurrency.DataTextField = "user_balance_text";
                ddlcurrency.DataSource = dtfundingsources;
                ddlcurrency.DataBind();

                BankAccountEntry1.hidecurrency();
                BankAccountEntry1.updatecurrency(Convert.ToInt32(ddlcurrency.SelectedValue));
            }
            setamountmax();
        }

        protected void Loadreceiverlist()
        {
            ddlReceivers.Items.Clear();
            DataSet dsrecipient = Peerfx_DB.SPs.ViewRecipientsByuserAndcurrency(currentuser.User_key, Convert.ToInt32(ddlcurrency.SelectedValue)).GetDataSet();
            if (dsrecipient.Tables[0].Rows.Count > 0)
            {
                //have at least 1 person on list                
                ddlReceivers.DataTextField = "ddltext";
                ddlReceivers.DataValueField = "payment_object_key";
                ddlReceivers.DataSource = dsrecipient.Tables[0];
                ddlReceivers.DataBind();

                BankAccountEntry1.Visible = false;
            }
            else
            {
                BankAccountEntry1.Visible = true;
            }
            //Add New Recipient
            RadListBoxItem rdtemp = new RadListBoxItem();
            rdtemp.Value = "0";
            rdtemp.Text = "Bank Account";
            ddlReceivers.Items.Add(rdtemp);

            ddlReceivers.SelectedIndex = 0;
            
        }

        protected void ddlReceivers_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (ddlReceivers.SelectedValue == "0")
            {
                BankAccountEntry1.Visible = true;
            }
            else
            {
                BankAccountEntry1.Visible = false;
            }
        }

        protected void ddlcurrency_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            BankAccountEntry1.updatecurrency(Convert.ToInt32(ddlcurrency.SelectedValue));
            Loadreceiverlist();
            setamountmax();
        }

        protected void setamountmax()
        {
            if (ddlcurrency.SelectedIndex > -1)
            {
                DataTable dtfundingsources = Peerfx_DB.SPs.ViewUserCurrenciesHasBalancein(currentuser.User_key).GetDataSet().Tables[0];
                txtamount.MaxValue = Convert.ToDouble(dtfundingsources.Rows[ddlcurrency.SelectedIndex]["user_balance_money"]);
            }            
        }

        protected void btncontinue1_Click(object sender, EventArgs e)
        {
            Boolean isvalid = false;
            if (ddlReceivers.SelectedValue == "0")
            {
                isvalid = BankAccountEntry1.ValidateBankAccount();
            }
            else{
                isvalid = true;
            }
            if (txtamount.Value == 0)
            {
                isvalid = false;
                lblerror.Visible = true;
            }

            if (isvalid)
            {
                lblerror.Visible = false;
                RadTabStrip1.SelectedIndex = 1;
                lblamount.Text = txtamount.Text;
                lblcurrency.Text = ddlcurrency.SelectedItem.Text;
                BankAccountEntry2.ViewasLabels();

                BankAccounts ba = new BankAccounts();
                if (ddlReceivers.SelectedValue == "0"){
                    ba = BankAccountEntry1.gettxtfields();
                }
                else{
                    ba = sitetemp.getBankAccounts(0,Convert.ToInt64(ddlReceivers.SelectedValue));
                }
                BankAccountEntry2.LoadFields(ba);

                RadMultiPage1.SelectedIndex = 1;
            }
            
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            RadTabStrip1.SelectedIndex = 0;
            RadMultiPage1.SelectedIndex = 0;
        }

        protected void btncontinue2_Click(object sender, EventArgs e)
        {
            Int64 receiverpaymentobject = 0;
            Int64 senderpaymentobject = sitetemp.getpaymentobject_UserBalance(currentuser.User_key, Convert.ToInt32(ddlcurrency.SelectedValue));

            if (ddlReceivers.SelectedValue == "0")
            {
                BankAccounts ba = BankAccountEntry1.gettxtfields();
                //new recipient
                receiverpaymentobject = BankAccountEntry1.InsertBankAccount(currentuser.User_key);
                Peerfx_DB.SPs.UpdateRecipients(0, currentuser.User_key, receiverpaymentobject).Execute();
            }
            else
            {
                receiverpaymentobject = Convert.ToInt64(ddlReceivers.SelectedValue);
            }

            //Confirming quote, create in database
            //Save & get Quote            
            //Quoting no service fee
            StoredProcedure sp_UpdateQuotes = Peerfx_DB.SPs.UpdateQuotes(0, Convert.ToDecimal(txtamount.Value), Convert.ToInt32(ddlcurrency.SelectedValue), Convert.ToDecimal(txtamount.Value), Convert.ToInt32(ddlcurrency.SelectedValue), 1, 0, null, null, 0);
            sp_UpdateQuotes.Execute();
            int quote_key = Convert.ToInt32(sp_UpdateQuotes.Command.Parameters[9].ParameterValue.ToString());

            //Save & get Payment key
            StoredProcedure sp_UpdatePayments = Peerfx_DB.SPs.UpdatePayments(0, quote_key, 0, 0,currentuser.User_key, "Withdrawl Request", senderpaymentobject, receiverpaymentobject);
            sp_UpdatePayments.Execute();
            int payment_key = Convert.ToInt32(sp_UpdatePayments.Command.Parameters[3].ParameterValue.ToString());
            
            //update payment status to confirmed
            Peerfx_DB.SPs.UpdatePaymentStatus(payment_key, 2).Execute();

            //send money from user balance to payment object            
            Int64 payment_payment_object_key = sitetemp.getpaymentobject(6, payment_key);
            Peerfx_DB.SPs.UpdateTransactionsInternal(0, 2, Convert.ToInt32(ddlcurrency.SelectedValue), Convert.ToDecimal(txtamount.Value), senderpaymentobject, payment_payment_object_key, sitetemp.get_ipaddress(), currentuser.User_key, "user balance to payment", 0, 1, payment_key).Execute();

            //initiate conversion
            sitetemp.payment_initiate(payment_key);
            Response.Redirect("/User/Dashboard.aspx?notification=true");
        }

    }
}