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

namespace Peerfx
{
    public partial class Site : System.Web.UI.MasterPage
    {        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Users getcurrentuser(bool MustbeAdmin)
        {
            Users user = new Users();
            //Check if logged in
            if (HttpContext.Current.Session["currentuser"] != null)
            {
                //User logged in
                user = (Users)HttpContext.Current.Session["currentuser"];
                user = view_users_info(user.User_key);
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

        public Users view_users_info(int userkey)
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
            }
            if (dstemp.Tables[0].Rows[0]["middle_name"] != DBNull.Value)
            {
                users.Middle_name = dstemp.Tables[0].Rows[0]["middle_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["last_name"] != DBNull.Value)
            {
                users.Last_name = dstemp.Tables[0].Rows[0]["last_name"].ToString();
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
            return users;
        }

        public string GetCurrencySymbol(string strtemp)
        {            
            string strsymbol = "$";

            if (strtemp.Contains("EUR"))
            {
                strsymbol = "€";
            }
            else if (strtemp.Contains("GBP"))
            {
                strsymbol = "£";
            }
            else if (strtemp.Contains("ILS"))
            {
                strsymbol = "₪";
            }
            else if (strtemp.Contains("PLN"))
            {
                strsymbol = "zł";
            }
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
    }
}