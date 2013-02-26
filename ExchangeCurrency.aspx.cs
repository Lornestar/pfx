using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;
using System.Data;
using SubSonic;
using Telerik.Web.UI;

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

                LoadRates(true);

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
                txtfirstnamesender.Text = currentuser.First_name;
                txtlastnamesender.Text = currentuser.Last_name;

                if (!IsPostBack)
                {
                    LoadRecipientList();
                }
            }
            else if (hduserkey.Value != "0")
            {
                currentuser = sitetemp.getcurrentuser(false);
            }
            if (!IsPostBack)
            {
                LoadRates(true);
            }
        }

        protected void LoadRecipientList(){
            
            ddlReceivers.Items.Clear();

            //if logged in & have recipient list
            currentuser = sitetemp.getcurrentuser(false);
            DataSet dsrecipient = Peerfx_DB.SPs.ViewRecipientsByuserAndcurrency(currentuser.User_key,Convert.ToInt32(ddlbuycurrency.SelectedValue)).GetDataSet();
            if (dsrecipient.Tables[0].Rows.Count > 0)
            {
                //have at least 1 person on list
                ddlReceivers.DataTextField = "ddltext";
                ddlReceivers.DataValueField = "payment_object_key";
                ddlReceivers.DataSource = dsrecipient.Tables[0];
                ddlReceivers.DataBind();

                Loadtxtreceiverfields(Convert.ToInt64(ddlReceivers.SelectedValue));
            }
            //Add New Recipient
            RadComboBoxItem rdtemp = new RadComboBoxItem();
            rdtemp.Value = "0";
            rdtemp.Text = "New Recipient";
            ddlReceivers.Items.Add(rdtemp);

            //Add Other Passport User
            RadComboBoxItem rdtemp3 = new RadComboBoxItem();
            rdtemp3.Value = "-1";
            rdtemp3.Text = "Other Passport User";
            ddlReceivers.Items.Add(rdtemp3);

            DataTable dtuserbalance = sitetemp.getuserbalance_datatable(currentuser.User_key, Convert.ToInt32(ddlbuycurrency.SelectedValue));
            RadComboBoxItem rdtemp2 = new RadComboBoxItem();
            rdtemp2.Value = dtuserbalance.Rows[0]["payment_object_key"].ToString();
            rdtemp2.Text = dtuserbalance.Rows[0]["user_balance_text"].ToString();
            ddlReceivers.Items.Insert(0,rdtemp2);

            ddlReceivers.SelectedIndex = 0;
            
            pnlnewreceiver.Visible = false;
            pnlexistingreceiver.Visible = true;
            
            /*else
            {
                pnlnewreceiver.Visible = true;
                pnlexistingreceiver.Visible = false;
                Cleartxtreceiverfields();
            }*/
        }

        protected void txtsell_TextChanged(object sender, EventArgs e)
        {
            LoadRates(true);            
        }

        protected void ddlexistingreceiver_changed(object sender, EventArgs e)
        {
            if (ddlReceivers.SelectedValue == "0")
            {
                //open new recipient
                pnlnewreceiver.Visible = true;
                pnlotherpassportuser.Visible = false;
                Cleartxtreceiverfields();
            }
            else if (ddlReceivers.SelectedValue == "-1")
            {
                //open other passport users
                pnlotherpassportuser.Visible = true;
                pnlnewreceiver.Visible = false;
                Cleartxtreceiverfields();
            }
            else
            {
                pnlnewreceiver.Visible = false;
                pnlotherpassportuser.Visible = false;
                pnlexistingreceiver.Visible = true;

                //populate with receiver info
                if (sitetemp.IsBankAccount(Convert.ToInt64(ddlReceivers.SelectedValue)))
                {
                    Loadtxtreceiverfields(Convert.ToInt64(ddlReceivers.SelectedValue));
                }
            }            
        }

        protected void Loadtxtreceiverfields(Int64 paymentkey)
        {
            BankAccounts ba = sitetemp.getBankAccounts(0, paymentkey);
            txtfirstnamereceiver.Text = ba.First_name;
            txtlastnamereceiver.Text = ba.Last_name;
            txtIbanAccount.Text = ba.IBAN;
            txtABArouting.Text = ba.ABArouting;
            txtaccountnumber.Text = ba.Account_number;
            txtBankCode.Text = ba.BIC;
            txtdescription.Text = ba.Bank_account_description;                
        }

        protected void Cleartxtreceiverfields()
        {
            txtfirstnamereceiver.Text = "";
            txtlastnamereceiver.Text = "";
            txtIbanAccount.Text = "";
            txtABArouting.Text = "";
            txtaccountnumber.Text = "";
            txtBankCode.Text = "";
            txtdescription.Text = "";
        }

        protected void ddlotherpassportusers_changed(object sender, EventArgs e)
        {

        }

        protected void ddlotherpassportusers_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            if (e.Text.Length > 0)
            {
                //reload other user's in list
                DataTable data = Peerfx_DB.SPs.ViewUsersDropDown(e.Text).GetDataSet().Tables[0];

                int itemOffset = e.NumberOfItems;
                int endOffset = Math.Min(itemOffset + 10, data.Rows.Count);
                e.EndOfItems = endOffset == data.Rows.Count;

                for (int i = itemOffset; i < endOffset; i++)
                {
                    ddlotherpassportusers.Items.Add(new RadComboBoxItem(data.Rows[i]["user_dropdown_text"].ToString(), data.Rows[i]["payment_object_key"].ToString()));
                }

                e.Message = GetStatusMessage(endOffset, data.Rows.Count);
                ddlotherpassportusers.ShowMoreResultsBox = true;
            }
            else
            {
                ddlotherpassportusers.ShowMoreResultsBox = false;
            }
        }

        private static string GetStatusMessage(int offset, int total)
        {
            if (total <= 0)
                return "No matches";
            
            return String.Format("Items <b>1</b>-<b>{0}</b> out of <b>{1}</b>", offset, total);
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
            LoadRates(true);            
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
            LoadRates(true);
            if (sitetemp.isloggedin())
            {
                LoadRecipientList();
            }            
        }

        protected void LoadRates(bool updaterecipientlist)
        {
            decimal sellamount = Convert.ToDecimal(txtsell.Text);
            int sellcurrency = Convert.ToInt32(ddlsellcurrency.SelectedValue);
            Quote quotetemp = sitetemp.getQuote(sellamount, sellcurrency, Convert.ToInt32(ddlbuycurrency.SelectedValue));

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

            if (currentuser != null)
            {
                ddlpaymentmethod.Items.Clear();
                //Check if have enough balance in account            
                DataTable dtfundingsources = sitetemp.getpossiblefundingsources(currentuser.User_key, sellcurrency, sellamount);
                if (dtfundingsources.Rows.Count > 0)
                {
                    //Has enough in balance            
                    ddlpaymentmethod.DataTextField = "user_balance_text";
                    ddlpaymentmethod.DataValueField = "payment_object_key";
                    ddlpaymentmethod.DataSource = dtfundingsources;
                    ddlpaymentmethod.DataBind();
                }
                RadComboBoxItem rdtemp = new RadComboBoxItem();
                rdtemp.Value = "0";
                rdtemp.Text = "Bank Account";
                ddlpaymentmethod.Items.Add(rdtemp);

                if (updaterecipientlist)
                {
                    LoadRecipientList();
                }                
            }            
        }

        protected void btnContinue1_Click(object sender, EventArgs e)
        {
            //check validation
            bool isvalid = true;
            string errormessage = "";

            if (ddlReceivers.SelectedValue == "-1")
            {
                //chose other passport user
                if (ddlotherpassportusers.SelectedValue == "")
                {
                    isvalid = false;
                    errormessage = "You must choose a Passport user";
                }                
            }

            if (isvalid)
            {
                //Change tab & fill in tab2 with all the info
                changetab(1);
                updateconfirmationtab();
                LoadRates(false);
                lblerrormessage.Visible = false;
            }
            else
            {
                lblerrormessage.Visible = true;
                lblerrormessage.Text = errormessage;
            }
        }

        protected void btnContinue2_Click(object sender, EventArgs e)
        {            

            LoadRates(false);

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

            Int64 receiverpaymentobject = 0;
            Int64 senderpaymentobject = 0;
            //even if it's not a bank account, will still enter the correct payment object
            //figure out which bank account to receive payment
            DataSet dstemp = Peerfx_DB.SPs.ViewAdminBankAccountCurrencyExchange(Convert.ToInt32(ddlsellcurrency.SelectedValue), currentuser.Country_residence).GetDataSet();
            lblalreadyconfirmedpeerfxbankaccount.Text = sitetemp.getBankAccountDescription(Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_key"]));
                        
            //if new recipient, save to database            
            if ((pnlexistingreceiver.Visible) && (ddlReceivers.SelectedValue != "0"))
            {                
                if (ddlReceivers.SelectedValue == "-1")
                {
                    //passport user
                    receiverpaymentobject = Convert.ToInt64(ddlotherpassportusers.SelectedValue);
                }                
                else{
                    receiverpaymentobject = Convert.ToInt64(ddlReceivers.SelectedValue);
                }
            }
            else
            {
                //new recipient
                receiverpaymentobject = sitetemp.insert_bank_account_returnpaymentobject(0, Convert.ToInt32(ddlbuycurrency.SelectedValue), 11, null, currentuserkey, lblconfirmreceiverAccount.Text, lblconfirmreceiverIBAN.Text, lblconfirmreceiverBankCode.Text, lblconfirmreceiverABArouting.Text, txtfirstnamereceiver.Text, txtlastnamereceiver.Text, null);
                Peerfx_DB.SPs.UpdateRecipients(0, currentuser.User_key, receiverpaymentobject).Execute();
                /*StoredProcedure sp_UpdateBank_account = Peerfx_DB.SPs.UpdateBankAccounts(0, null, Convert.ToInt32(ddlbuycurrency.SelectedValue), null, null, currentuserkey, HttpContext.Current.Request.UserHostAddress, lblconfirmreceiverAccount.Text, lblconfirmreceiverIBAN.Text, lblconfirmreceiverBankCode.Text, lblconfirmreceiverABArouting.Text, txtfirstnamereceiver.Text, txtlastnamereceiver.Text, null, 0);
                sp_UpdateBank_account.Execute();
                int bank_account_key = Convert.ToInt32(sp_UpdateBank_account.Command.Parameters[14].ParameterValue.ToString());
                //Save payment object
                StoredProcedure sp_UpdatePaymentObject = Peerfx_DB.SPs.UpdatePaymentObjects(0, 1, bank_account_key, 0);
                sp_UpdatePaymentObject.Execute();
                receiverpaymentobject = Convert.ToInt64(sp_UpdatePaymentObject.Command.Parameters[3].ParameterValue.ToString());*/
            }

            if (pnlloggedinsender.Visible)
            {
                if (sitetemp.IsUserBalance(Convert.ToInt64(ddlpaymentmethod.SelectedValue)))
                {
                    senderpaymentobject = Convert.ToInt64(ddlpaymentmethod.SelectedValue);
                }               
            }            
            

            //Confirming quote, create in database
            //Save & get Quote            
            StoredProcedure sp_UpdateQuotes = Peerfx_DB.SPs.UpdateQuotes(0, Convert.ToDecimal(txtsell.Value), Convert.ToInt32(ddlsellcurrency.SelectedValue), Convert.ToDecimal(txtbuy.Value), Convert.ToInt32(ddlbuycurrency.SelectedValue), Convert.ToDecimal(lblrate.Text), Convert.ToDecimal(hdservicefee.Value), null, null, 0);
            sp_UpdateQuotes.Execute();
            int quote_key = Convert.ToInt32(sp_UpdateQuotes.Command.Parameters[9].ParameterValue.ToString());
             
            //Save & get Payment key
                        
            StoredProcedure sp_UpdatePayments = Peerfx_DB.SPs.UpdatePayments(0, quote_key, 0, 0, currentuserkey, lblconfirmreceiverdescription.Text,senderpaymentobject,receiverpaymentobject);
            sp_UpdatePayments.Execute();
            int payment_key = Convert.ToInt32(sp_UpdatePayments.Command.Parameters[3].ParameterValue.ToString());
            lblpaymentnum.Text = payment_key.ToString();
            //update payment status to confirmed
            Peerfx_DB.SPs.UpdatePaymentStatus(payment_key, 2).Execute();

            bool isuserbalance = false;
            if (pnlloggedinsender.Visible)
            {
                if (sitetemp.IsUserBalance(Convert.ToInt64(ddlpaymentmethod.SelectedValue)))
                {
                    //instantly convert the payment, because source funding is balance

                    //initiate conversion
                    sitetemp.insert_quote_actual_convert_currency(payment_key, Convert.ToInt32(ddlsellcurrency.SelectedValue), Convert.ToInt32(ddlbuycurrency.SelectedValue), currentuser, Convert.ToDecimal(txtsell.Value),true);
                    Response.Redirect("Default.aspx");
                }
            }
            
            if (!isuserbalance)            
            {
                //Send email with instructions etc.
                Peerfx.External_APIs.SendGrid sg = new Peerfx.External_APIs.SendGrid();
                sg.Send_Email_Payment_Confirmed(payment_key, currentuser);

                //Change tab to bank transfer info
                changetab(2);
            }            
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            RadTabStrip1.Tabs[2].Visible = true;
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
            bool receiverbankaccount = true;
            if (ddlReceivers.SelectedValue != "0")
            {
                if (ddlReceivers.SelectedValue == "-1")
                {
                    //selected other passport user
                    lblreceivinguserbalance.Text = ddlotherpassportusers.Text;                    
                    receiverbankaccount = false;
                }
                else if (sitetemp.IsUserBalance(Convert.ToInt64(ddlReceivers.SelectedValue)))
                {
                    //it's a user balance, get user balance info
                    lblreceivinguserbalance.Text = ddlReceivers.SelectedItem.Text;                    
                    receiverbankaccount = false;
                }

                if (!receiverbankaccount)
                {
                    pnlreceivinguserbalance.Visible = true;
                    pnlreceivingbankaccount.Visible = false;                    
                }
            }
            lblconfirmreceiverIBAN.Text = txtIbanAccount.Text;
            lblconfirmreceiverABArouting.Text = txtABArouting.Text;
            lblconfirmreceiverAccount.Text = txtaccountnumber.Text;
            lblconfirmreceiverBankCode.Text = txtBankCode.Text;
            lblconfirmreceiverdescription.Text = txtdescription.Text;
            lblconfirmreceiveremail.Text = txtemailreceiver.Text;

            lblFundingSource.Text = ddlpaymentmethod.SelectedItem.Text;

            bool isuserbalance = false;
            if (pnlloggedinsender.Visible)
            {
                if (sitetemp.IsUserBalance(Convert.ToInt64(ddlpaymentmethod.SelectedValue)))
                {
                    //it's coming from a user balance                    
                    RadTabStrip1.Tabs[2].Visible = false;
                    isuserbalance = true;
                }                
            }
            
            if (!isuserbalance) 
            {                
                RadTabStrip1.Tabs[2].Visible = true;
            }
        }                

        protected void updatealreadyconfirmedtab()
        {
            //update tab info
            lblalreadyconfirmedfrom.Text = lblconfirmsenderfullname.Text;
            //lblalreadyconfirmedfrom2.Text = lblconfirmsenderfullname.Text;
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

            switch (selectedtab)
            {
                case 0: RadTabStrip1.Tabs[0].Enabled = true;
                    break;
                case 1: RadTabStrip1.Tabs[1].Enabled = true;
                    break;
                case 2: RadTabStrip1.Tabs[2].Enabled = true;
                    break;                
            }
            RadTabStrip1.SelectedIndex = selectedtab;
            RadMultiPage1.SelectedIndex = selectedtab;
        }
    }
}