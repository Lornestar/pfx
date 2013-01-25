using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;
using System.Data;
using SubSonic;

namespace Peerfx
{
    public partial class ExchangeCurrency : System.Web.UI.Page
    {

        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Load Currency dropdowns
                ddlsellcurrency.DataTextField = "info_currency_code";
                ddlsellcurrency.DataValueField = "info_currencies_key";
                ddlsellcurrency.DataSource = sitetemp.view_info_currencies_cansell();
                ddlsellcurrency.DataBind();

                ddlbuycurrency.DataTextField = "info_currency_code";
                ddlbuycurrency.DataValueField = "info_currencies_key";
                ddlbuycurrency.DataSource = sitetemp.view_info_currencies_canbuy();
                ddlbuycurrency.DataBind();

                ddlsellcurrency.SelectedIndex = 1;

                LoadRates();

                DataTable dtcountries = sitetemp.populatecountrylist();

                ddlcountryresidence.DataTextField = "Country_Text";
                ddlcountryresidence.DataValueField = "info_country_key";
                ddlcountryresidence.DataSource = dtcountries;
                ddlcountryresidence.DataBind();

                if ((Request.QueryString["sell"] != null) && (Request.QueryString["sell"] != ""))
                {
                    txtsell.Text = Request.QueryString["sell"].ToString();
                    ddlsellcurrency.SelectedValue = Request.QueryString["sellc"].ToString();
                    ddlbuycurrency.SelectedValue = Request.QueryString["buyc"].ToString();
                }
            }
            if (sitetemp.isloggedin())
            {
                currentuser = sitetemp.getcurrentuser(false);
                hduserkey.Value = currentuser.User_key.ToString();

                pnlloggedinsender.Visible = true;
                pnlloggedinsender2.Visible = true;
                pnlnewsender.Visible = false;
                pnlnewsender2.Visible = false;
                ucUserInfo1.Choose_User(currentuser.User_key);
                ucUserInfo2.Choose_User(currentuser.User_key);
            }
            else if (hduserkey.Value != "0")
            {
                currentuser = sitetemp.getcurrentuser(false);
            }
        }

        protected void txtsell_TextChanged(object sender, EventArgs e)
        {
            LoadRates();
        }

        protected void ddlsellcurrency_changed(object sender, EventArgs e)
        {
            if (ddlsellcurrency.SelectedValue == ddlbuycurrency.SelectedValue)
            {
                if (ddlbuycurrency.SelectedIndex != 0)
                {
                    ddlbuycurrency.SelectedIndex = 0;
                }
                else
                {
                    ddlbuycurrency.SelectedIndex = 1;
                }
            }
            LoadRates();            
        }

        protected void ddlbuycurrency_changed(object sender, EventArgs e)
        {
            if (ddlsellcurrency.SelectedValue == ddlbuycurrency.SelectedValue)
            {
                if (ddlsellcurrency.SelectedIndex != 0)
                {
                    ddlsellcurrency.SelectedIndex = 0;
                }
                else
                {
                    ddlsellcurrency.SelectedIndex = 1;
                }
            }
            LoadRates();            
        }

        protected void LoadRates()
        {

            Quote quotetemp = sitetemp.getQuote(Convert.ToDecimal(txtsell.Text), Convert.ToInt32(ddlsellcurrency.SelectedValue), Convert.ToInt32(ddlbuycurrency.SelectedValue));

            hdbuyrate.Value = quotetemp.Peerfx_Rate.ToString();
            hdsellcurrencysymbol.Value = sitetemp.GetCurrencySymbol(ddlsellcurrency.SelectedItem.Text) + " ";
            hdbuycurrencysymbol.Value = sitetemp.GetCurrencySymbol(ddlbuycurrency.SelectedItem.Text) + " ";
            hdservicefee.Value = quotetemp.Peerfx_Servicefee.ToString("F");
            hdbuyamount.Value = quotetemp.Buyamount.ToString("F");

            lblrate.Text = hdbuyrate.Value;
            lblservicefee.Text = hdbuycurrencysymbol.Value + hdservicefee.Value;
            lblyouget.Text = hdbuycurrencysymbol.Value + hdbuyamount.Value;
            txtbuy.Value = Convert.ToDouble(quotetemp.Buyamount);

            lblconfirmquotereceiveamount.Text = lblyouget.Text;
            lblconfirmquoteservicefee.Text = lblservicefee.Text;
            lblconfirmquoteyouget.Text = lblyouget.Text;
            lblconfirmquoteexchangerate.Text = lblrate.Text;

            lblalreadyconfirmedquotesenderamount2.Text = hdsellcurrencysymbol.Value + txtsell.Text;
            lblalreadyconfirmedquotesenderamount.Text = lblalreadyconfirmedquotesenderamount2.Text;

            if (ddlbuycurrency.SelectedItem.Text == "USD")
            {
                pnlIBAN.Visible = false;
                pnlBankCode.Visible = false;
                pnlABArouting.Visible = true;
                pnlAccountNumber.Visible = true;

                pnlalreadyconfirmedIBAN.Visible = false;
                pnlalreadyconfirmedIBAN2.Visible = false;
                pnlconfirmreceiverIBAN.Visible = false;

                pnlconfirmreceiverBankCode.Visible = false;
                pnlalreadyconfirmedBankCode.Visible = false;
                pnlalreadyconfirmedBankCode2.Visible = false;

                pnlconfirmreceiverABArouting.Visible = true;
                pnlalreadyconfirmedABArouting.Visible = true;
                pnlalreadyconfirmedABArouting2.Visible = true;

                pnlconfirmreceiverAccount.Visible = true;
                pnlalreadyconfirmedAccountNumber.Visible = true;
                pnlalreadyconfirmedAccountNumber2.Visible = true;
            }
            else
            {
                pnlIBAN.Visible = true;
                pnlBankCode.Visible = true;
                pnlABArouting.Visible = false;
                pnlAccountNumber.Visible = false;

                pnlalreadyconfirmedIBAN.Visible = true;
                pnlalreadyconfirmedIBAN2.Visible = true;
                pnlconfirmreceiverIBAN.Visible = true;

                pnlconfirmreceiverBankCode.Visible = true;
                pnlalreadyconfirmedBankCode.Visible = true;
                pnlalreadyconfirmedBankCode2.Visible = true;

                pnlconfirmreceiverABArouting.Visible = false;
                pnlalreadyconfirmedABArouting.Visible = false;
                pnlalreadyconfirmedABArouting2.Visible = false;

                pnlconfirmreceiverAccount.Visible = false;
                pnlalreadyconfirmedAccountNumber.Visible = false;
                pnlalreadyconfirmedAccountNumber2.Visible = false;
            }
        }

        protected void btnContinue1_Click(object sender, EventArgs e)
        {
            //check validation

            //Change tab & fill in tab2 with all the info
            changetab(1);
            updateconfirmationtab();
            LoadRates();
        }

        protected void btnContinue2_Click(object sender, EventArgs e)
        {
            LoadRates();

            //populate labels
            updatealreadyconfirmedtab();

            //Save current user
            int currentuserkey = 0;
            if (sitetemp.isloggedin())
            {
                //user logged in
                currentuserkey = currentuser.User_key;
            }
            else
            {
                //create new user in db & attach userkey to payment key
                DateTime dttemp = new DateTime(Convert.ToInt32(txtbirthyear.Value), Convert.ToInt32(txtbirthmonth.Value), Convert.ToInt32(txtbirthyear.Value));
                StoredProcedure sp_UpdateSignup1 = Peerfx_DB.SPs.UpdateUsers(0, null, txtfirstnamesender.Text, null, txtlastnamesender.Text, dttemp, Convert.ToInt32(ddlcountryresidence.SelectedValue), txtemailsender.Text, HttpContext.Current.Request.UserHostAddress, 0);
                sp_UpdateSignup1.Execute();
                currentuserkey = Convert.ToInt32(sp_UpdateSignup1.Command.Parameters[9].ParameterValue.ToString());
            }

            //if new recipient, save to database
            StoredProcedure sp_UpdateBank_account = Peerfx_DB.SPs.UpdateBankAccounts(0, null, Convert.ToInt32(ddlbuycurrency.SelectedValue), null, null, currentuserkey, HttpContext.Current.Request.UserHostAddress, lblconfirmreceiverAccount.Text, lblconfirmreceiverIBAN.Text, lblconfirmreceiverBankCode.Text, lblconfirmreceiverABArouting.Text, txtfirstnamereceiver.Text, txtlastnamereceiver.Text, null, 0);
            sp_UpdateBank_account.Execute();
            int bank_account_key = Convert.ToInt32(sp_UpdateBank_account.Command.Parameters[14].ParameterValue.ToString());
            //Save payment object
            Peerfx_DB.SPs.UpdatePaymentObjects(0, 1, bank_account_key, 0).Execute();

            //Confirming quote, create in database
            //Save & get Quote            
            StoredProcedure sp_UpdateQuotes = Peerfx_DB.SPs.UpdateQuotes(0, Convert.ToDecimal(txtsell.Value), Convert.ToInt32(ddlsellcurrency.SelectedValue), Convert.ToDecimal(txtbuy.Value), Convert.ToInt32(ddlbuycurrency.SelectedValue), Convert.ToDecimal(lblrate.Text), Convert.ToDecimal(hdservicefee.Value), null, null, 0);
            sp_UpdateQuotes.Execute();
            int quote_key = Convert.ToInt32(sp_UpdateQuotes.Command.Parameters[9].ParameterValue.ToString());
             
            //Save & get Payment key
            StoredProcedure sp_UpdatePayments = Peerfx_DB.SPs.UpdatePayments(0, quote_key, 0, 0, currentuserkey, txtdescription.Text);
            sp_UpdatePayments.Execute();
            int payment_key = Convert.ToInt32(sp_UpdatePayments.Command.Parameters[3].ParameterValue.ToString());
            lblpaymentnum.Text = payment_key.ToString();
            //update payment status to confirmed
            Peerfx_DB.SPs.UpdatePaymentStatus(payment_key, 2).Execute();

            //Send email with instructions etc.

            //Change tab to bank transfer info
            changetab(2);
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            changetab(0);
        }

        protected void updateconfirmationtab()
        {
            lblconfirmquotesendamount.Text = sitetemp.GetCurrencySymbol(ddlsellcurrency.SelectedItem.Text) + " " + txtsell.Text;
            lblconfirmquotereceiveamount.Text = sitetemp.GetCurrencySymbol(ddlbuycurrency.SelectedItem.Text) + " " + txtbuy.Text;
            lblconfirmquoteyouget.Text = lblconfirmquotereceiveamount.Text;
            lblconfirmquoteexchangerate.Text = lblrate.Text;
            lblconfirmquoteservicefee.Text = lblservicefee.Text;

            lblconfirmsenderfullname.Text = txtfirstnamesender.Text + " " + txtlastnamesender.Text;
            lblconfirmsenderdob.Text = txtbirthday.Text + "/" + txtbirthmonth.Text + "/" + txtbirthyear.Text;
            lblconfirmsenderaddress.Text = txtAddress1.Text;
            lblconfirmsendercity.Text = txtCity.Text;
            lblconfirmsenderpostalcode.Text = txtpostalzipcode.Text;
            lblconfirmsenderstate.Text = txtState.Text;
            lblconfirmsendercountry.Text = ddlcountryresidence.SelectedItem.Text;
            lblconfirmsenderemail.Text = txtemailsender.Text;
            lblconfirmsenderphone.Text = txtphone.Text;

            lblconfirmreceiverfullname.Text = txtfirstnamereceiver.Text + " " + txtlastnamereceiver.Text;
            lblconfirmreceiverIBAN.Text = txtIbanAccount.Text;
            lblconfirmreceiverABArouting.Text = txtABArouting.Text;
            lblconfirmreceiverAccount.Text = txtaccountnumber.Text;
            lblconfirmreceiverBankCode.Text = txtBankCode.Text;
            lblconfirmreceiverdescription.Text = txtdescription.Text;
            lblconfirmreceiveremail.Text = txtemailreceiver.Text;
        }        

        protected void updatealreadyconfirmedtab()
        {
            //update tab info
            lblalreadyconfirmedfrom.Text = lblconfirmsenderfullname.Text;
            lblalreadyconfirmedfrom2.Text = lblconfirmsenderfullname.Text;
            lblalreadyconfirmedto.Text = lblconfirmreceiverfullname.Text;

            lblalreadyconfirmedIBAN2.Text = txtIbanAccount.Text;
            lblalreadyconfirmedABArouting2.Text = txtABArouting.Text;
            lblalreadyconfirmedAccountNumber2.Text = txtaccountnumber.Text;
            lblalreadyconfirmedBankCode2.Text = txtBankCode.Text;
            lblalreadyconfirmeddescription.Text = txtdescription.Text;
        }

        protected void changetab(int selectedtab)
        {
            RadTabStrip1.Tabs[0].Enabled = false;
            RadTabStrip1.Tabs[1].Enabled = false;
            RadTabStrip1.Tabs[2].Enabled = false;
            RadTabStrip1.Tabs[3].Enabled = false;

            switch (selectedtab)
            {
                case 0: RadTabStrip1.Tabs[0].Enabled = true;
                    break;
                case 1: RadTabStrip1.Tabs[1].Enabled = true;
                    break;
                case 2: RadTabStrip1.Tabs[2].Enabled = true;
                    break;
                case 3: RadTabStrip1.Tabs[3].Enabled = true;
                    break;
            }
            RadTabStrip1.SelectedIndex = selectedtab;
            RadMultiPage1.SelectedIndex = selectedtab;
        }
    }
}