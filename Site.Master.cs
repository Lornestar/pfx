using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using SubSonic;

namespace Peerfx
{
    public partial class Site : System.Web.UI.MasterPage
    {        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (isloggedin())
            {
                //logged in change navigation links
                pnlloggedin.Visible = true;
                pnlloggedout.Visible = false;
            }
        }

        public Users getcurrentuser(bool MustbeAdmin)
        {
            Users user = new Users();
            //Check if logged in
            if (HttpContext.Current.Session["currentuser"] != null)
            {
                //User logged in
                user = (Users)HttpContext.Current.Session["currentuser"];
                user = get_user_info(user.User_key);
                HttpContext.Current.Session["currentuser"] = user;
                if ((user.Isadmin == false) && (MustbeAdmin))
                {
                    //Redirect to login page
                    HttpContext.Current.Response.Redirect(ConfigurationSettings.AppSettings["Root_url"] + "Login.aspx");
                }
            }
            else
            {
                //Redirect to login page
                HttpContext.Current.Response.Redirect(ConfigurationSettings.AppSettings["Root_url"] + "Login.aspx");
            }
            return user;
        }

        public bool isloggedin()
        {
            bool isloggedin = false;

            if (HttpContext.Current.Session["currentuser"] != null)
            {
                isloggedin = true;
            }

            return isloggedin;
        }

        public DataTable populateyear()
        {
            DataTable dttemp = new DataTable();
            dttemp.Columns.Add("text", typeof(string));
            dttemp.Columns.Add("value", typeof(string));

            for (int i = 1994; i >= 1910; i--)
            {
                DataRow dr = dttemp.NewRow();
                dr["text"] = i.ToString();
                dr["value"] = i.ToString();
                dttemp.Rows.Add(dr);
            }

            return dttemp;
        }

        public DataTable populateday()
        {
            DataTable dttemp = new DataTable();
            dttemp.Columns.Add("text", typeof(string));
            dttemp.Columns.Add("value", typeof(string));

            for (int i = 1; i <= 31; i++)
            {
                DataRow dr = dttemp.NewRow();
                dr["text"] = i.ToString();
                dr["value"] = i.ToString();
                dttemp.Rows.Add(dr);
            }

            return dttemp;
        }

        public DataTable populatecountrylist()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCountryList().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable populatecountrycodelist()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCountryCodeList().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable populatephonetype()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoPhoneType().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable populatesecurityquestions()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoSecurityQuestions().GetDataSet();
            return dstemp.Tables[0];
        }

        public Users get_user_info(int userkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersInfo(userkey).GetDataSet();
            Users users = view_users_info_getdbinfo(dstemp);
            users.User_key = userkey;                                   
            return users;
        }

        public DataTable view_users_info_dt(int userkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersInfo(userkey).GetDataSet();            
            return dstemp.Tables[0];
        }

        public Users view_users_info_email(string useremail)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersEmail(useremail).GetDataSet();
            Users users = view_users_info_getdbinfo(dstemp);
            users.Email = useremail;
            return users;
        }

        private Users view_users_info_getdbinfo(DataSet dstemp)
        {
            Users users = new Users();
            users.User_key = 0;
            if (dstemp.Tables[0].Rows[0]["user_key"] != DBNull.Value)
            {
                users.User_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["user_key"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["account_number"] != DBNull.Value)
            {
                users.Account_number = dstemp.Tables[0].Rows[0]["account_number"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["title"] != DBNull.Value)
            {
                users.Title = dstemp.Tables[0].Rows[0]["title"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["first_name"] != DBNull.Value)
            {
                users.First_name = dstemp.Tables[0].Rows[0]["first_name"].ToString();
                users.Full_name = users.First_name;
            }
            if (dstemp.Tables[0].Rows[0]["middle_name"] != DBNull.Value)
            {
                users.Middle_name = dstemp.Tables[0].Rows[0]["middle_name"].ToString();
                users.Full_name += " " + users.Middle_name;
            }
            if (dstemp.Tables[0].Rows[0]["last_name"] != DBNull.Value)
            {
                users.Last_name = dstemp.Tables[0].Rows[0]["last_name"].ToString();
                users.Full_name += " " + users.Last_name;
            }
            if (dstemp.Tables[0].Rows[0]["dob"] != DBNull.Value)
            {
                users.Dob = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["dob"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["country_residence"] != DBNull.Value)
            {
                users.Country_residence = Convert.ToInt32(dstemp.Tables[0].Rows[0]["country_residence"].ToString());
            } if (dstemp.Tables[0].Rows[0]["email"] != DBNull.Value)
            {
                users.Email = dstemp.Tables[0].Rows[0]["email"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["ip_address"] != DBNull.Value)
            {
                users.Ip_address = dstemp.Tables[0].Rows[0]["ip_address"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["last_changed"] != DBNull.Value)
            {
                users.Last_changed = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["last_changed"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["signed_up"] != DBNull.Value)
            {
                users.Signed_up = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["signed_up"].ToString());
            } if (dstemp.Tables[0].Rows[0]["user_status"] != DBNull.Value)
            {
                users.User_status = Convert.ToInt32(dstemp.Tables[0].Rows[0]["user_status"].ToString());
            } if (dstemp.Tables[0].Rows[0]["isadmin"] != DBNull.Value)
            {
                users.Isadmin = Convert.ToBoolean(dstemp.Tables[0].Rows[0]["isadmin"].ToString());
            } if (dstemp.Tables[0].Rows[0]["address1"] != DBNull.Value)
            {
                users.Address1 = dstemp.Tables[0].Rows[0]["address1"].ToString();
            } if (dstemp.Tables[0].Rows[0]["address2"] != DBNull.Value)
            {
                users.Address2 = dstemp.Tables[0].Rows[0]["address2"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["city"] != DBNull.Value)
            {
                users.City = dstemp.Tables[0].Rows[0]["city"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["state"] != DBNull.Value)
            {
                users.State = dstemp.Tables[0].Rows[0]["state"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["country"] != DBNull.Value)
            {
                users.Country = Convert.ToInt32(dstemp.Tables[0].Rows[0]["country"].ToString());
            } if (dstemp.Tables[0].Rows[0]["postalcode"] != DBNull.Value)
            {
                users.Postalcode = dstemp.Tables[0].Rows[0]["postalcode"].ToString();
            } if (dstemp.Tables[0].Rows[0]["phonecountrycode1"] != DBNull.Value)
            {
                users.Phonecountrycode1 = dstemp.Tables[0].Rows[0]["phonecountrycode1"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["phonetype1"] != DBNull.Value)
            {
                users.Phonetype1 = Convert.ToInt32(dstemp.Tables[0].Rows[0]["phonetype1"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["phonenumber1"] != DBNull.Value)
            {
                users.Phonenumber1 = dstemp.Tables[0].Rows[0]["phonenumber1"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["phonecountrycode2"] != DBNull.Value)
            {
                users.Phonecountrycode2 = dstemp.Tables[0].Rows[0]["phonecountrycode2"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["phonetype2"] != DBNull.Value)
            {
                users.Phonetype2 = Convert.ToInt32(dstemp.Tables[0].Rows[0]["phonetype2"].ToString());
            } if (dstemp.Tables[0].Rows[0]["phonenumber2"] != DBNull.Value)
            {
                users.Phonenumber2 = dstemp.Tables[0].Rows[0]["phonenumber2"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["identitynationality"] != DBNull.Value)
            {
                users.Identitynationality = Convert.ToInt32(dstemp.Tables[0].Rows[0]["identitynationality"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["user_status_text"] != DBNull.Value)
            {
                users.User_status_text = dstemp.Tables[0].Rows[0]["user_status_text"].ToString();
            }                        
            return users;
        }

        public BankAccounts getBankAccounts(int bankaccountkey, Int64 paymentkey)
        {
            DataSet dstemp = new DataSet();
            BankAccounts tempbankaccount = new BankAccounts();

            if (bankaccountkey > 0)
            {
                dstemp = Peerfx_DB.SPs.ViewBankAccountsSpecific(bankaccountkey).GetDataSet();
                tempbankaccount.Bank_account_key = bankaccountkey;
                if (dstemp.Tables[0].Rows[0]["payment_object_key"] != DBNull.Value)
                {
                    tempbankaccount.Payment_object_key = Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_key"]);
                }
            }
            else if (paymentkey > 0)
            {
                tempbankaccount.Payment_object_key = paymentkey;
                dstemp = Peerfx_DB.SPs.ViewBankAccountsSpecificPaymentkey(paymentkey).GetDataSet();
                if (dstemp.Tables[0].Rows[0]["bank_account_key"] != DBNull.Value)
                {
                    tempbankaccount.Bank_account_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["bank_account_key"]);
                }
            }

            if (dstemp.Tables[0].Rows[0]["payment_object_type"] != DBNull.Value)
            {
                tempbankaccount.Payment_object_type = Convert.ToInt32(dstemp.Tables[0].Rows[0]["payment_object_type"]);
            }
            if (dstemp.Tables[0].Rows[0]["date_created"] != DBNull.Value)
            {
                tempbankaccount.Date_created = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["date_created"]);
            }
            if (dstemp.Tables[0].Rows[0]["user_key"] != DBNull.Value)
            {
                tempbankaccount.User_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["user_key"]);
            }
            if (dstemp.Tables[0].Rows[0]["organization_key"] != DBNull.Value)
            {
                tempbankaccount.Organization_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["organization_key"]);
            }
            if (dstemp.Tables[0].Rows[0]["bank_account_description"] != DBNull.Value)
            {
                tempbankaccount.Bank_account_description = dstemp.Tables[0].Rows[0]["bank_account_description"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["user_key_updated"] != DBNull.Value)
            {
                tempbankaccount.User_key_updated = Convert.ToInt32(dstemp.Tables[0].Rows[0]["user_key_updated"]);
            }
            if (dstemp.Tables[0].Rows[0]["ip_address"] != DBNull.Value)
            {
                tempbankaccount.Ip_address = dstemp.Tables[0].Rows[0]["ip_address"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["business_name"] != DBNull.Value)
            {
                tempbankaccount.Business_name = dstemp.Tables[0].Rows[0]["business_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["last_changed"] != DBNull.Value)
            {
                tempbankaccount.Last_changed = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["last_changed"]);
            }
            if (dstemp.Tables[0].Rows[0]["bank_account_info"] != DBNull.Value)
            {
                tempbankaccount.Bank_account_info = dstemp.Tables[0].Rows[0]["bank_account_info"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["organization_name"] != DBNull.Value)
            {
                tempbankaccount.Organization_name = dstemp.Tables[0].Rows[0]["organization_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["country_text"] != DBNull.Value)
            {
                tempbankaccount.Country_text = dstemp.Tables[0].Rows[0]["country_text"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["currency_text"] != DBNull.Value)
            {
                tempbankaccount.Currency_text = dstemp.Tables[0].Rows[0]["currency_text"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["first_name"] != DBNull.Value)
            {
                tempbankaccount.First_name = dstemp.Tables[0].Rows[0]["first_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["last_name"] != DBNull.Value)
            {
                tempbankaccount.Last_name = dstemp.Tables[0].Rows[0]["last_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["account_number"] != DBNull.Value)
            {
                tempbankaccount.Account_number = dstemp.Tables[0].Rows[0]["account_number"].ToString();                
            }
            if (dstemp.Tables[0].Rows[0]["IBAN"] != DBNull.Value)
            {
                tempbankaccount.IBAN = dstemp.Tables[0].Rows[0]["IBAN"].ToString();                
            }
            if (dstemp.Tables[0].Rows[0]["BIC"] != DBNull.Value)
            {
                tempbankaccount.BIC = dstemp.Tables[0].Rows[0]["BIC"].ToString();                
            }
            if (dstemp.Tables[0].Rows[0]["ABArouting"] != DBNull.Value)
            {
                tempbankaccount.ABArouting = dstemp.Tables[0].Rows[0]["ABArouting"].ToString();                
            }
            if (dstemp.Tables[0].Rows[0]["currency_key"] != DBNull.Value)
            {
                tempbankaccount.Currency_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["currency_key"].ToString());
            }

            return tempbankaccount;
        }

        public string getBankAccountDescription(Int64 paymentobjectkey)
        {
            //output bank account in html format
            string strtemp = "";
            string strbuffer = "";

            DataSet dstemp = Peerfx_DB.SPs.ViewBankAccountsSpecificPaymentkey(paymentobjectkey).GetDataSet();
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                if (dstemp.Tables[0].Rows[0]["IBAN"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["IBAN"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "IBAN - " + strbuffer + "<br/>";
                    }
                }
                if (dstemp.Tables[0].Rows[0]["BIC"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["BIC"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "BIC - " + strbuffer + "<br/>";
                    }
                }
                if (dstemp.Tables[0].Rows[0]["ABArouting"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["ABArouting"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "ABA Routing - " + strbuffer + "<br/>";
                    }
                }
                if (dstemp.Tables[0].Rows[0]["account_number"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["account_number"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "Account Number - " + strbuffer + "<br/>";
                    }
                }

                if (dstemp.Tables[0].Rows[0]["organization_name"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["organization_name"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "Bank Name - " + strbuffer + "<br/>";
                    }
                }

                if (dstemp.Tables[0].Rows[0]["country_text"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["country_text"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "Country - " + strbuffer;
                    }
                }            
            }
            

            return strtemp;
        }

        public string GetCurrencySymbol(string strtemp)
        {            
            string strsymbol = "$";

            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrencySymbol(strtemp.ToUpper()).GetDataSet();
            strsymbol = dstemp.Tables[0].Rows[0]["info_currency_symbol"].ToString();

            return strsymbol;
        }

        public string GetCurrencySymbol(int currencykey)
        {
            string strsymbol = "$";

            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrenciesSpecific(currencykey).GetDataSet();
            strsymbol = dstemp.Tables[0].Rows[0]["info_currency_symbol"].ToString();
            return strsymbol;
        }

        public int getbankaccountcurrency(int bankaccountkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewBankAccountsSpecific(bankaccountkey).GetDataSet();

            int currencykey = 0;
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                currencykey = Convert.ToInt32(dstemp.Tables[0].Rows[0]["currency_key"]);
            }
            return currencykey;
        }

        public DateTime getcurrencyclouddate(string thedate){
            //"20110218-10:37:11"
            DateTime dttemp;
            if (thedate.Length == 8)
            {
                dttemp = DateTime.ParseExact(thedate,"yyyyMMdd",null);
            }
            else{
                dttemp = DateTime.ParseExact(thedate,"yyyyMMdd-HH:mm:ss",null);
            }
            return dttemp;
        }

        public Quote getQuote(decimal sellamount, int sellcurrency, int buycurrency)
        {
            Quote quotetemp = new Quote();
            External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
            Hashtable hstemp = cc.Exchange_Rate_ccy_pair(sellcurrency,buycurrency); 

            if (!hstemp.ContainsValue("error")){
                quotetemp.Bid_Price_Timestamp = getcurrencyclouddate(hstemp["bid_price_timestamp"].ToString());
                quotetemp.Bid_Price = Convert.ToDecimal(hstemp["bid_price"]);
                quotetemp.Broker_Bid = Convert.ToDecimal(hstemp["broker_bid"]);
                quotetemp.Offer_Price_Timestamp = getcurrencyclouddate(hstemp["offer_price_timestamp"].ToString());
                quotetemp.Offer_Price = Convert.ToDecimal(hstemp["offer_price"]);
                quotetemp.Broker_Offer = Convert.ToDecimal(hstemp["broker_offer"]);
                quotetemp.Market_Price = Convert.ToDecimal(hstemp["market_price"]);
                quotetemp.Value_Date = getcurrencyclouddate(hstemp["value_date"].ToString());
                quotetemp.Quote_Condition = hstemp["quote_condition"].ToString();
                quotetemp.Real_Market = hstemp["real_market"].ToString();
                quotetemp.Ccy_Pair = hstemp["ccy_pair"].ToString();
                                
                //calculate Peerfx servicefee & rate
                
                if (sellamount > 0)
                {   
                    quotetemp.Sellamount = sellamount;
                    decimal peerfxservicefee = 0;
                    decimal buyamount = 0;
                    decimal peerfxrate = 0;                    

                    //Calculate peerfx service fee
                    Fees fees = getFees(sellcurrency,buycurrency);                    

                    //peerfxrate
                    peerfxrate = quotetemp.Broker_Offer;
                    if (fees.Fee_Percentage != 0){
                        peerfxrate += fees.Fee_Percentage;
                    }
                    
                    //peerfx service fee
                    if (fees.Fee_Base != 0)
                    {
                        peerfxservicefee += fees.Fee_Base;
                    }
                    if (fees.Fee_Addon != 0)
                    {
                        peerfxservicefee += fees.Fee_Addon;
                    }
                    if (fees.Fee_Min != 0)
                    {
                        if (fees.Fee_Min > peerfxservicefee){
                            peerfxservicefee = fees.Fee_Min;
                        }
                    }
                    if (fees.Fee_Max != 0)
                    {
                        if (fees.Fee_Max < peerfxservicefee){
                            peerfxservicefee = fees.Fee_Max;
                        }
                    }

                    //calculate buyingamount
                    buyamount = sellamount * peerfxrate;
                    buyamount = buyamount - peerfxservicefee;

                    //assign values
                    quotetemp.Peerfx_Servicefee = decimal.Round(peerfxservicefee,2);
                    quotetemp.Peerfx_Rate = peerfxrate;                    
                    quotetemp.Buyamount = decimal.Round(buyamount,2);
                }                
            }
            return quotetemp;
        }

        public Fees getFees(int sellcurrency, int buycurrency)
        {
            Fees fees = new Fees();

            DataSet dstemp = Peerfx_DB.SPs.ViewInfoFeeTypes(sellcurrency, buycurrency).GetDataSet();
            
            if (dstemp.Tables[0].Rows[0]["organization_name"] != DBNull.Value)
            {
                fees.Organization_Name = dstemp.Tables[0].Rows[0]["organization_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["description"] != DBNull.Value)
            {
                fees.Description = dstemp.Tables[0].Rows[0]["description"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["fee_base"] != DBNull.Value)
            {
                fees.Fee_Base = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_base"]);
            }
            if (dstemp.Tables[0].Rows[0]["fee_percentage"] != DBNull.Value)
            {
                fees.Fee_Percentage = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_percentage"]);
            }
            if (dstemp.Tables[0].Rows[0]["fee_addon"] != DBNull.Value)
            {
                fees.Fee_Addon = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_addon"]);
            }
            if (dstemp.Tables[0].Rows[0]["fee_min"] != DBNull.Value)
            {
                fees.Fee_Min = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_min"]);
            }
            if (dstemp.Tables[0].Rows[0]["fee_max"] != DBNull.Value)
            {
                fees.Fee_Max = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_max"]);
            }
            if (sellcurrency > 0)
            {
                fees.Currency1 = sellcurrency;
            }
            if (buycurrency > 0)
            {
                fees.Currency2 = buycurrency;
            }

            return fees;
        }

        public string getcurrencycode(int currency_key)
        {
            Site sitetemp = new Site();
            DataTable dttemp = sitetemp.view_info_currency_specific(currency_key);
            return dttemp.Rows[0]["info_currency_code"].ToString();
        }

        public Int64 getpaymentobject(int bankaccountkey)
        {
            //input bankaccountkey output paymentobjectkey
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentObjectBankAccount(bankaccountkey).GetDataSet();

            Int64 paymentobjectkey = 0;
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                paymentobjectkey = Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_key"]);
            }
            return paymentobjectkey;
        }

        public DataTable view_info_banks()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoBanks().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_info_currencies()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrencies().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_info_currency_specific(int currency_key)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrenciesSpecific(currency_key).GetDataSet();
            return dstemp.Tables[0];
        }

        public string get_ipaddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        public DataTable view_system_bank_accounts()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewSystemBankAccounts().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_users_all()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersAll().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_transaction_all_specificpayment(int paymentkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewTransactionAllSpecificPayment(paymentkey).GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_transaction_fees(int tx_type)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewTransactionFees(tx_type).GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_transaction_fees_txkey(int tx_type, int tx_key)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewTransactionFeesTxkey(tx_type, tx_key).GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_info_currencies_cansell()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrenciesCanSell().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_info_currencies_canbuy()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrenciesCanBuy().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_payments_confirmed()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentsConfirmed().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_bank_accounts_users()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewBankAccountsUsers().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_payment_status()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentStatus().GetDataSet();
            return dstemp.Tables[0];
        }

        public Int64 insert_bank_account_returnpaymentobject(int userkey, int currencykey, int organizationkey, string bankaccountdescription, int userkeyupdated, string accountnumber, string IBAN, string BIC, string ABArouting, string firstname, string lastname, string businessname)
        {
            StoredProcedure sp_UpdateBank_account = Peerfx_DB.SPs.UpdateBankAccounts(0, userkey, currencykey, organizationkey, bankaccountdescription, userkeyupdated, get_ipaddress(), accountnumber, IBAN, BIC, ABArouting, firstname, lastname, businessname, 0);
            sp_UpdateBank_account.Execute();
            int bankaccountkey = Convert.ToInt32(sp_UpdateBank_account.Command.Parameters[14].ParameterValue.ToString());
            StoredProcedure sp_UpdatePaymentObject = Peerfx_DB.SPs.UpdatePaymentObjects(0, 1, bankaccountkey, 0);
            sp_UpdatePaymentObject.Execute();
            Int64 returnpaymentobject = Convert.ToInt64(sp_UpdatePaymentObject.Command.Parameters[3].ParameterValue.ToString());

            return returnpaymentobject;
        }

        public bool IsNumeric(string strTextEntry)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strTextEntry)
                 && (strTextEntry != "");
        }
    }
}