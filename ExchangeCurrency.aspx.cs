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
            currentuser = sitetemp.getcurrentuser(false);

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
                Checkifcanofferpremium();

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

                //load countries into ddlembeecountry
                ddlembeecountry.DataTextField = "country_text";
                ddlembeecountry.DataValueField = "country";
                ddlembeecountry.DataSource = Peerfx_DB.SPs.ViewEmbeeCountries().GetDataSet().Tables[0];
                ddlembeecountry.DataBind();                
                
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

                    //check if verified or not
                    if (currentuser.Verification_points < 100)
                    {
                        btnContinue1.Visible = false;
                        btnNotVerified.Visible = true;
                    }
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

                Loadtxtreceiverfields(Convert.ToInt64(ddlReceivers.Items[0].Value));
            }
            //Add New Recipient
            RadListBoxItem rdtemp = new RadListBoxItem();
            rdtemp.Value = "0";
            rdtemp.Text = "Bank Account";
            ddlReceivers.Items.Add(rdtemp);

            if (sitetemp.isCurrencyCanhold(Convert.ToInt32(ddlbuycurrency.SelectedValue)))
            {
                //Add Other Passport User
                RadListBoxItem rdtemp3 = new RadListBoxItem();
                rdtemp3.Value = "-1";
                rdtemp3.Text = "Another Passport User";
                ddlReceivers.Items.Add(rdtemp3);
            }            

            //Add Embee Telco
            RadListBoxItem rdtemp4 = new RadListBoxItem();
            rdtemp4.Value = "-2";
            rdtemp4.Text = "Top Up Phone";
            ddlReceivers.Items.Add(rdtemp4);

            if (sitetemp.isCurrencyCanhold(Convert.ToInt32(ddlbuycurrency.SelectedValue)))
            {
                DataTable dtuserbalance = sitetemp.getuserbalance_datatable(currentuser.User_key, Convert.ToInt32(ddlbuycurrency.SelectedValue));
                RadListBoxItem rdtemp2 = new RadListBoxItem();
                rdtemp2.Value = dtuserbalance.Rows[0]["payment_object_key"].ToString();
                rdtemp2.Text = dtuserbalance.Rows[0]["user_balance_text"].ToString();
                ddlReceivers.Items.Insert(0, rdtemp2);
            }            

            ddlReceivers.SelectedIndex = 0;

            pnlembee.Visible = false;
            pnlotherpassportuser.Visible = false;
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
            Checkifcanofferpremium();
        }

        protected void ddlembeecountry_changed(object sender, EventArgs e)
        {
            ddlembeecatalog.ClearSelection();
            ddlembeecatalog.DataTextField = "product_name";
            ddlembeecatalog.DataValueField = "product_id";
            ddlembeecatalog.DataSource = Peerfx_DB.SPs.ViewEmbeeCatalogBycountry(Convert.ToInt32(ddlembeecountry.SelectedValue)).GetDataSet().Tables[0];
            ddlembeecatalog.DataBind();
            ddlembeecatalog.Visible = true;
        }

        protected void ddlembeecatalog_changed(object sender, EventArgs e)
        {
            //disable quote controls                
            ddlbuycurrency.Enabled = false;
            txtsell.Enabled = false;
            lbltopupinfo.Visible = true;
            ddlbuycurrency.SelectedValue = "3";

            //calculate proper amounts
            int productid = Convert.ToInt32(ddlembeecatalog.SelectedValue);
            decimal price = 0;
            DataTable dttemp = Peerfx_DB.SPs.ViewEmbeeCatalogByproductid(productid).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                price = Convert.ToDecimal(dttemp.Rows[0]["price_in_dollars"]);
            }
            
            Quote quotetemp = sitetemp.getQuote_reverse(price, Convert.ToInt32(ddlsellcurrency.SelectedValue), Convert.ToInt32(ddlbuycurrency.SelectedValue), true);
            
            LoadRatesFillinfo(quotetemp);

            txtembeephone.Visible = true;

            UpdatePaymentMethod(Convert.ToInt32(ddlsellcurrency.SelectedValue),Convert.ToDecimal(txtsell.Value));
        }

        protected void ddlexistingreceiver_changed(object sender, EventArgs e)
        {
            pnlnewreceiver.Visible = false;
            pnlotherpassportuser.Visible = false;
            pnlembee.Visible = false;            
            ddlbuycurrency.Enabled = true;
            txtsell.Enabled = true;
            lbltopupinfo.Visible = false;

            if (ddlReceivers.SelectedValue == "0")
            {
                //open new recipient
                pnlnewreceiver.Visible = true;                
                Cleartxtreceiverfields();
                BankAccountEntry1.hidecurrency();
                BankAccountEntry1.updatecurrency(Convert.ToInt32(ddlbuycurrency.SelectedValue));
            }
            else if (ddlReceivers.SelectedValue == "-1")
            {
                //open other passport users
                pnlotherpassportuser.Visible = true;                
                Cleartxtreceiverfields();
            }
            else if (ddlReceivers.SelectedValue == "-2")
            {
                //open embee top up
                pnlembee.Visible = true;
                ddlembeecatalog.Visible = false;
                ddlembeecountry.ClearSelection();
                txtembeephone.Text = "";
                txtembeephone.Visible = false;
            }
            else
            {                
                pnlexistingreceiver.Visible = true;

                //populate with receiver info
                if (sitetemp.IsBankAccount(Convert.ToInt64(ddlReceivers.SelectedValue)))
                {
                    Loadtxtreceiverfields(Convert.ToInt64(ddlReceivers.SelectedValue));
                }
            }
            Checkifcanofferpremium();
        }

        protected void Loadtxtreceiverfields(Int64 paymentkey)
        {
            BankAccounts ba = sitetemp.getBankAccounts(0, paymentkey);
            /*txtfirstnamereceiver.Text = ba.First_name;
            txtlastnamereceiver.Text = ba.Last_name;
            txtIbanAccount.Text = ba.IBAN;
            txtABArouting.Text = ba.ABArouting;
            txtaccountnumber.Text = ba.Account_number;
            txtBankCode.Text = ba.BIC;*/
            BankAccountEntry1.LoadFields(ba);
            txtdescription.Text = ba.Bank_account_description;                
        }

        protected void Cleartxtreceiverfields()
        {
            BankAccountEntry1.resetaddnew();
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

            if (ddlReceivers.SelectedValue != "-2")
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
            else
            {
                LoadRates(false);
            }
            Checkifcanofferpremium();
        }

        protected void ddlbuycurrency_changed(object sender, EventArgs e)
        {
            if (ddlReceivers.SelectedValue != "-2")
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
            }
            else
            {
                LoadRates(false);
            }
            Checkifcanofferpremium();
                        
        }

        protected void UpdatePaymentMethod(int sellcurrency, decimal sellamount)
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
            RadListBoxItem rdtemp = new RadListBoxItem();
            rdtemp.Value = "0";
            rdtemp.Text = "Bank Account";
            ddlpaymentmethod.Items.Add(rdtemp);

            ddlpaymentmethod.SelectedIndex = 0;
        }

        protected void LoadRatesFillinfo(Quote quotetemp)
        {
            hdbuyrate.Value = quotetemp.Peerfx_Rate.ToString();
            hdsellcurrencysymbol.Value = sitetemp.GetCurrencySymbol(ddlsellcurrency.SelectedItem.Text) + " ";
            hdbuycurrencysymbol.Value = sitetemp.GetCurrencySymbol(ddlbuycurrency.SelectedItem.Text) + " ";
            hdservicefee.Value = quotetemp.Peerfx_Servicefee.ToString("F");
            hdbuyamount.Value = quotetemp.Buyamount.ToString("F");

            lblrate.Text = hdbuyrate.Value;
            lblservicefee.Text = hdbuycurrencysymbol.Value + hdservicefee.Value;
            lblyouget.Text = hdbuycurrencysymbol.Value + hdbuyamount.Value;
            txtbuy.Value = Convert.ToDouble(quotetemp.Buyamount);
            txtsell.Value = Convert.ToDouble(quotetemp.Sellamount);

            /*lblconfirmquotereceiveamount.Text = lblyouget.Text;
            lblconfirmquoteservicefee.Text = lblservicefee.Text;
            lblconfirmquoteyouget.Text = lblyouget.Text;
            lblconfirmquoteexchangerate.Text = lblrate.Text;

            lblalreadyconfirmedquotesenderamount2.Text = hdsellcurrencysymbol.Value + txtsell.Text;
            lblalreadyconfirmedquotesenderamount.Text = lblalreadyconfirmedquotesenderamount2.Text;
             */
        }

        protected void LoadRates(bool updaterecipientlist)
        {
            decimal sellamount = Convert.ToDecimal(txtsell.Text);
            int sellcurrency = Convert.ToInt32(ddlsellcurrency.SelectedValue);
            Quote quotetemp;
            if (ddlReceivers.SelectedValue != "-2")//is not embee
            {
                if (chkpremium.Checked)
                {
                    //calculate with premium rate
                    quotetemp = sitetemp.getQuote(sellamount, sellcurrency, Convert.ToInt32(ddlbuycurrency.SelectedValue),true);
                }
                else
                {
                    quotetemp = sitetemp.getQuote(sellamount, sellcurrency, Convert.ToInt32(ddlbuycurrency.SelectedValue),false);
                }                
            }
            else
            {
                quotetemp = sitetemp.getQuote_reverse(Convert.ToDecimal(txtbuy.Text), sellcurrency, Convert.ToInt32(ddlbuycurrency.SelectedValue), true);
            }            

            LoadRatesFillinfo(quotetemp);            

            if (currentuser != null)
            {
                UpdatePaymentMethod(sellcurrency, sellamount);

                if (updaterecipientlist)
                {
                    LoadRecipientList();
                }                
            }
            
        }

        protected void btnContinue1_Click(object sender, EventArgs e)
        {            
            //update seller & receiver payment objects
            hdsenderpaymentobjectkey.Value = ddlpaymentmethod.SelectedValue;

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
            else if (ddlReceivers.SelectedValue == "-2")
            {
                if (ddlembeecatalog.SelectedValue == "") 
                {
                    isvalid = false;
                    errormessage = "You must choose a Top Up Plan";
                }
                if (txtembeephone.Text == "")
                {
                    isvalid = false;
                    errormessage = "You must enter a phone number";
                }
            }
            else if (ddlReceivers.SelectedValue == "0") //sending to new bank account
            {
                isvalid = BankAccountEntry1.ValidateBankAccount();
            }


            if (txtdescription.Text.Length < 1)
            {
                isvalid = false;
                errormessage = "You must write a description for this payment";
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

            //LoadRates(false);            

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
                        
                        
            //if new recipient, save to database            
            if ((pnlexistingreceiver.Visible) && (ddlReceivers.SelectedValue != "0"))
            {                
                if (ddlReceivers.SelectedValue == "-1")
                {
                    //passport user
                    receiverpaymentobject = Convert.ToInt64(ddlotherpassportusers.SelectedValue);
                }
                else if (ddlReceivers.SelectedValue == "-2")
                {
                    //top up embee
                    //1st step record the embee payment object
                    string strphone = txtembeephone.Text;
                    strphone = strphone.Replace("-", "").Replace(" ", "");
                    while (strphone.Substring(0, 1) == "0")
                    {
                        strphone = strphone.Substring(1, strphone.Length - 1);
                    }

                    StoredProcedure sp_UpdateEmbeeObject = Peerfx_DB.SPs.UpdateEmbeeCatalogRecordpaymentobject(Convert.ToInt32(ddlembeecatalog.SelectedValue),strphone, 0);
                    sp_UpdateEmbeeObject.Execute();
                    receiverpaymentobject = Convert.ToInt64(sp_UpdateEmbeeObject.Command.Parameters[2].ParameterValue.ToString());
                }
                else
                {
                    receiverpaymentobject = Convert.ToInt64(ddlReceivers.SelectedValue);
                }
            }
            else
            {
                BankAccounts ba = BankAccountEntry1.gettxtfields();
                //new recipient
                receiverpaymentobject = BankAccountEntry1.InsertBankAccount(currentuser.User_key);
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
                if (sitetemp.IsUserBalance(Convert.ToInt64(hdsenderpaymentobjectkey.Value)))
                {
                    //user balance
                    senderpaymentobject = Convert.ToInt64(hdsenderpaymentobjectkey.Value);
                }
                else
                {
                    //bank account
                    senderpaymentobject = 0;
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
            
            //Assign proper treasury type
            int treasurytype = 2; //default = cc
            if (chkpremium.Checked)
            {
                treasurytype = 1;
            }
            if (sitetemp.getpaymentobjecttype(receiverpaymentobject) == 7)//receiver is embee
            {
                treasurytype = 1;
            }
            Peerfx_DB.SPs.UpdatePaymentTreasury(payment_key, treasurytype).Execute();

            //Send confirmation email with instructions etc.
            Peerfx.External_APIs.SendGrid sg = new Peerfx.External_APIs.SendGrid();
            sg.Send_Email_Payment_Confirmed(payment_key, currentuser);

            bool isuserbalance = false;
            if (pnlloggedinsender.Visible)
            {
                if (sitetemp.IsUserBalance(Convert.ToInt64(hdsenderpaymentobjectkey.Value)))
                {
                    //send money from user balance to payment object
                    Int64 userbalance_payment_object_key = sitetemp.getpaymentobject_UserBalance(currentuser.User_key,Convert.ToInt32(ddlsellcurrency.SelectedValue));
                    Int64 payment_payment_object_key = sitetemp.getpaymentobject(6,payment_key);
                    Peerfx_DB.SPs.UpdateTransactionsInternal(0, 2, Convert.ToInt32(ddlsellcurrency.SelectedValue), Convert.ToDecimal(txtsell.Value), userbalance_payment_object_key, payment_payment_object_key, sitetemp.get_ipaddress(), currentuser.User_key, "user balance to payment", 0, 1, payment_key).Execute();

                    //instantly convert the payment, because source funding is balance
                    //initiate conversion
                    sitetemp.payment_initiate(payment_key);
                    Response.Redirect("/User/Dashboard.aspx?notification=true");
                }
            }
            
            if (!isuserbalance)            
            {                

                //Change tab to bank transfer info
                changetab(2);

                //Status to Awaiting User Deposit
                Peerfx_DB.SPs.UpdatePaymentStatus(payment_key, 11).Execute();
            }            

            //populate labels
            updatealreadyconfirmedtab();
        }
        

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            RadTabStrip1.Tabs[2].Visible = true;
            changetab(0);
        }

        protected void updateconfirmationtab()
        {            

            lblconfirmquotesendamount.Text = sitetemp.GetCurrencySymbol(ddlsellcurrency.SelectedItem.Text) + " " + txtsell.Text + " " + ddlsellcurrency.SelectedItem.Text;
            lblconfirmquotereceiveamount.Text = sitetemp.GetCurrencySymbol(ddlbuycurrency.SelectedItem.Text) + " " + txtbuy.Text + " " + ddlbuycurrency.SelectedItem.Text;
            lblconfirmquoteyouget.Text = lblconfirmquotereceiveamount.Text;
            lblconfirmquoteexchangerate.Text = lblrate.Text;
            lblconfirmquoteservicefee.Text = lblservicefee.Text + " " + ddlbuycurrency.SelectedItem.Text;
            lblconfirmmoneyarrives.Text = lblmoneyarrives.Text;

            lblconfirmsenderfullname.Text = txtfirstnamesender.Text + " " + txtlastnamesender.Text;
            lblconfirmsenderdob.Text = txtbirthday.Text + "/" + txtbirthmonth.Text + "/" + txtbirthyear.Text;
            lblconfirmsenderaddress.Text = txtAddress1.Text;
            lblconfirmsendercity.Text = txtCity.Text;
            lblconfirmsenderpostalcode.Text = txtpostalzipcode.Text;
            lblconfirmsenderstate.Text = txtState.Text;
            lblconfirmsendercountry.Text = ddlcountryresidence.SelectedItem.Text;
            lblconfirmsenderemail.Text = txtemailsender.Text;
            lblconfirmsenderphone.Text = txtphone.Text;
            
            bool receiverbankaccount = true;
            if (ddlReceivers.SelectedValue != "0")
            {
                if (ddlReceivers.SelectedValue == "-1")
                {
                    //selected other passport user
                    lblreceivinguserbalance.Text = ddlotherpassportusers.Text;                    
                    receiverbankaccount = false;
                }
                else if (ddlReceivers.SelectedValue == "-2")
                {
                    //selected embee top up
                    lblreceivinguserbalance.Text = ddlembeecatalog.SelectedItem.Text;
                    receiverbankaccount = false;
                }
                else 
                {
                    if (ddlReceivers.SelectedValue != "")
                    {
                        if (sitetemp.IsUserBalance(Convert.ToInt64(ddlReceivers.SelectedValue)))
                        {
                            //it's a user balance, get user balance info
                            lblreceivinguserbalance.Text = ddlReceivers.SelectedItem.Text;
                            receiverbankaccount = false;
                        }                            
                    }                        
                }

                if (!receiverbankaccount)
                {
                    pnlreceivinguserbalance.Visible = true;
                    pnlreceivingbankaccount.Visible = false;                    
                }
            }            
            BankAccounts ba = BankAccountEntry1.gettxtfields();
            BankAccountEntry2.ViewasLabels();
            BankAccountEntry2.LoadFields(ba);
            lblconfirmreceiverdescription.Text = txtdescription.Text;

            bool isuserbalance = false;
            if (pnlloggedinsender.Visible)
            {
                lblFundingSource.Text = ddlpaymentmethod.SelectedItem.Text;
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
            BankAccounts ba = BankAccountEntry1.gettxtfields();
            BankAccountEntry3.ViewasLabels();
            BankAccountEntry3.LoadFields(ba);
            
            lblalreadyconfirmeddescription.Text = txtdescription.Text;
            
            lblalreadyconfirmedquotesenderamount.Text = lblconfirmquotesendamount.Text;

            //figure out which bank account to receive payment            
            DepositInstructions1.LoadInfo(currentuser.User_key, Convert.ToInt32(ddlsellcurrency.SelectedValue));
            DepositInstructions1.LoadReference("P" + lblpaymentnum.Text);            
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

        protected void LoadTiming()
        {
            if (ddlReceivers.SelectedValue == "-2")//embee top up
            {
                lblmoneyarrives.Text = sitetemp.getPaymentTimingDescription(4);
            }
            else if (chkpremium.Checked)
            {
                if (sitetemp.IsUserBalance(Convert.ToInt64(ddlReceivers.SelectedValue)))
                {
                    lblmoneyarrives.Text = sitetemp.getPaymentTimingDescription(3);
                }
                else
                {
                    lblmoneyarrives.Text = sitetemp.getPaymentTimingDescription(2);
                }                
            }
            else
            {
                lblmoneyarrives.Text = sitetemp.getPaymentTimingDescription(1);
            }

        }

        protected void Checkifcanofferpremium()
        {
            if (ddlReceivers.SelectedValue == "-2")//embee top up
            {
                pnlpremium.Visible = false;
                chkpremium.Checked = true;
            }
            else
            {
                Boolean canofferpremium = sitetemp.Iscanofferpremium(Convert.ToInt32(ddlsellcurrency.SelectedValue), Convert.ToInt32(ddlbuycurrency.SelectedValue), Convert.ToDecimal(txtbuy.Text));
                if (canofferpremium)
                {
                    pnlpremium.Visible = true;
                }
                else
                {
                    pnlpremium.Visible = false;
                    chkpremium.Checked = false;
                }
            }            
            LoadTiming();
        }

        protected void chkpremium_Click(object sender, EventArgs e)
        {
            LoadTiming();
            LoadRates(false);
        }

    }
}