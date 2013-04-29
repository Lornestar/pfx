using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using RestSharp;
using Peerfx.Models;

namespace Peerfx.External_APIs
{
    public class CurrencyCloud
    {
        Site sitetemp = new Site();

        public string Authentication_New(){
            string strstatus = "error";
            Hashtable hstemp = new Hashtable();
            hstemp.Add("login_id", ConfigurationSettings.AppSettings["CurrencyCloud_login_id"]);
            hstemp.Add("api_key", getapikey());
            strstatus = Web_Request("/authentication/token/new", hstemp);
            
            JObject o = JObject.Parse(strstatus); 
            string newtoken = (string)o["data"];

            return newtoken;
        }

        public Hashtable Exchange_Rate_ccy_pair(int currency1, int currency2)
        {
            Hashtable hstemp = new Hashtable();
            Site sitetemp = new Site();
            string strcurrencycodes = sitetemp.getcurrencycode(currency1) + sitetemp.getcurrencycode(currency2);
            if (currency1 != currency2)
            {                
                string url = "/prices/market/" + strcurrencycodes+ "?accept_stale=true";

                /*
                RestClient client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.AddParameter("accept_stale", "true");
                // execute the request
                RestResponse response = (RestResponse)client.Execute(request);
                string responseString = response.Content; // raw content as string
                if (responseString.ToLower().Contains("error"))
                {
                    token = update_info_currencycloud_token();

                    client.BaseUrl = geturl() + "/api/en/v1.0/" + token + "/prices/market/" + strcurrencycodes;
                    response = (RestResponse)client.Execute(request);
                    responseString = response.Content; // raw content as string
                }*/                
                string responseString = CallWeb_Request(url, hstemp);

                hstemp = JsonConvert.DeserializeObject<Hashtable>(responseString);
                hstemp = JsonConvert.DeserializeObject<Hashtable>(hstemp["data"].ToString());
            }
            else
            {
                //yyyyMMdd-HH:mm:ss
                hstemp.Add("bid_price_timestamp", DateTime.Now.ToString("yyyyMMdd-HH:mm:ss"));
                hstemp.Add("bid_price",0.9998);
                hstemp.Add("broker_bid",0.9958);
                hstemp.Add("offer_price_timestamp",DateTime.Now.ToString("yyyyMMdd-HH:mm:ss"));
                hstemp.Add("offer_price",1.0002);
                hstemp.Add("broker_offer",1.0052);
                hstemp.Add("market_price",1);
                hstemp.Add("value_date",DateTime.Now.ToString("yyyyMMdd"));
                hstemp.Add("quote_condition","open");
                hstemp.Add("real_market",strcurrencycodes);
                hstemp.Add("ccy_pair",strcurrencycodes);
            }
            
            return hstemp;
        }

        public string Validate_BankAccount(BankAccounts ba)
        {
            string currencycode = sitetemp.getcurrencycode(ba.Currency_key);
            string countrycode = sitetemp.getCountryValueFromCurrency(ba.Currency_key);
            Boolean isvalid = false;
            string strreturn = "";

            string strstatus = "error";
            Hashtable hstemp = ConvertBankAccountstoHashtable(ba);

            string strquery = sitetemp.ConvertHashtabletoString(hstemp);
            hstemp.Clear();

            strstatus = CallWeb_Request("/beneficiary/validate_details?"+strquery, hstemp);

            try
            {
                JObject o = JObject.Parse(strstatus);
                string status = (string)o["status"];
                if (status == "success")
                {
                    isvalid = true;
                    strreturn = "true";
                }
                else
                {
                    strreturn = (string)o["message"];
                }
            }
            catch
            {
                strreturn = "error validating bank account";
            }
            

            return strreturn;
        }

        private Hashtable ConvertBankAccountstoHashtable(BankAccounts ba)
        {
            Hashtable hstemp = new Hashtable();

            //Bank account info
            string countrycode = sitetemp.getCountryValueFromCurrency(ba.Currency_key);
            hstemp.Add("nickname", ba.Currency_text + " Account");
            hstemp.Add("acct_ccy", ba.Currency_text);
            hstemp.Add("beneficiary_name", ba.First_name + " " + ba.Last_name);
            hstemp.Add("destination_country_code", countrycode);

            if (ba.ABArouting != null)
            {
                if (ba.ABArouting != "")
                {
                    hstemp.Add("aba", ba.ABArouting);
                }                
            }
            if (ba.Account_number != null)
            {
                if (ba.Account_number != "")
                {
                    hstemp.Add("acct_number", ba.Account_number);
                }                
            }
            /*
            if (SingaporeBankCode.Length > 0)
            {
                hstemp.Add("bank_code", SingaporeBankCode);
            }*/
            if (ba.Institutionnumber != null)
            {
                if (ba.Institutionnumber != "")
                {
                    hstemp.Add("institution_no", ba.Institutionnumber);
                }                
            }
            if (ba.Bankname != null)
            {
                if (ba.Bankname != "")
                {
                    hstemp.Add("bank_name", ba.Bankname);
                }                
            }
            if (ba.Branchcode != null)
            {
                if (ba.Branchcode != "")
                {
                    hstemp.Add("branch_code", ba.Branchcode);
                }                
            }
            if (ba.BIC != null)
            {
                if (ba.BIC != "")
                {
                    hstemp.Add("bic_swift", ba.BIC);
                }                
            }
            if (ba.BSB != null)
            {
                if (ba.BSB != "")
                {
                    hstemp.Add("bsb_code", ba.BSB);
                }                
            }
            if (ba.IBAN != null)
            {
                if (ba.IBAN != "")
                {
                    hstemp.Add("iban", ba.IBAN);
                }                
            }
            if (ba.Sortcode != null)
            {
                if (ba.Sortcode != "")
                {
                    hstemp.Add("sort_code", ba.Sortcode);
                }                
            }
            if (ba.Islocalpayment)
            {                
                hstemp.Add("payment_types", "local");
            }

            return hstemp;
        }

        public Hashtable RequiredFields_BankAccounts(int currency)
        {
            string currencycode = sitetemp.getcurrencycode(currency);
            string country = sitetemp.getCountryValueFromCurrency(currency);
            Hashtable hstemp = new Hashtable();            
            string responseString = CallWeb_Request("/beneficiaries/required_fields?ccy=" + currencycode + "&destination_country_code=" + country, hstemp);

            Hashtable hsreturn = new Hashtable();
            JObject o = JObject.Parse(responseString);
            JArray o2 = (JArray)o["data"];
            JObject data;
            if (currencycode == "GBP")
            {
                data = (JObject)o2[1];
            }
            else
            {
                data = (JObject)o2[0];
            }

            JArray required = (JArray)data["required"];
            for (int i = 0; i < required.Count; i++)
            {
                hsreturn.Add(i, (string)required[i]);
            }
            
            //example for USD
            //"{\"status\":\"success\",\"data\":[{\"required\":[\"acct_number\",\"aba\"]},{\"required\":[\"acct_number\",\"bic_swift\"]}]}"
            
            return hsreturn;
        }

        public string RequiredFields_BankAccounts_rawresponse(int currency, int country)
        {
            string currencycode = sitetemp.getcurrencycode(currency);
            string countryvalue = sitetemp.getCountryValue(country);
            Hashtable hstemp = new Hashtable();
            string responseString = CallWeb_Request("/beneficiaries/required_fields?payment_type=local&ccy=" + currencycode + "&destination_country_code=" + countryvalue, hstemp);

            

            //example for USD
            //"{\"status\":\"success\",\"data\":[{\"required\":[\"acct_number\",\"aba\"]},{\"required\":[\"acct_number\",\"bic_swift\"]}]}"

            return responseString;
        }

        public Boolean Trade_Execute(int paymentkey)
        {
            Boolean tradesuccessful = false;
            
            Payment paymenttemp = sitetemp.getPayment(paymentkey);
            BankAccounts ba = new BankAccounts();

            if (paymenttemp.Directlyfromcurrencycloud == 0) //comes back to our local bank accounts
            {
                int country = sitetemp.getCountryFromCurrency(paymenttemp.Buy_currency);
                ba = sitetemp.getBankAccounts(0, sitetemp.get_PaymentObject_AdminBankAccounts(paymenttemp.Buy_currency, country));
            }
            else //goes directly to recipient's bank account
            {
                ba = sitetemp.getBankAccounts(0, paymenttemp.Payment_object_receiver);
            }

            string strstatus = "error";
            Hashtable hstemp = ConvertBankAccountstoHashtable(ba);
            hstemp.Add("buy_currency", paymenttemp.Buy_currency_text);
            hstemp.Add("sell_currency", paymenttemp.Sell_currency_text);
            hstemp.Add("side", "1");
            hstemp.Add("amount", paymenttemp.Buy_amount.ToString("F"));
            hstemp.Add("term_agreement", "true");
            hstemp.Add("return_details", "true");
            
            string strrequest = sitetemp.ConvertHashtabletoString(hstemp);

            strstatus = CallWeb_Request("/trade/execute_with_payment", hstemp);
            JObject o = JObject.Parse(strstatus);
            string status = (string)o["status"];
            if (status == "success")
            {
                tradesuccessful = true;
                //record new tradeid
                JObject o2 = (JObject)o["data"];
                string newtradeid = (string)o2["trade_id"];
                JArray o3 = (JArray)o2["payments"];
                string newccpaymentid = (string)o3[0];

                Peerfx_DB.SPs.UpdateCurrencyCloudTrades(paymentkey, newtradeid,newccpaymentid).Execute();
                Peerfx_DB.SPs.UpdatePaymentStatus(paymenttemp.Payments_Key, 9).Execute();
                Peerfx_DB.SPs.DeleteCurrencyCloudTradesErrors(paymenttemp.Payments_Key).Execute();
            }
            else
            {
                tradesuccessful = false;
                string message = (string)o["message"];
                Peerfx_DB.SPs.UpdateCurrencyCloudTradesErrors(paymentkey, strrequest, strstatus).Execute();
            }

            return tradesuccessful;
        }

        public string Settlement_Create()
        {
            string strreturn = "";

            Hashtable hstemp = new Hashtable();
            strreturn = CallWeb_Request("/settlement/create", hstemp);
            JObject o = JObject.Parse(strreturn);
            string strstatus = (string)o["status"];           
            if (strstatus == "success")
            {
                JObject o2 = (JObject)o["data"];
                strreturn = (string)o2["settlement_id"];
                Peerfx_DB.SPs.UpdateCurrencyCloudSettlements(strreturn).Execute();
            }            

            return strreturn;
        }

        public int Settlement_AddTrades(string settlementid, int cutoff)
        {
            int tradesadded = 0;
            Hashtable hstemp = new Hashtable();

            DataTable dttrades = Peerfx_DB.SPs.ViewCurrencyCloudTradesAwaitingSettlement(cutoff).GetDataSet().Tables[0];
            foreach (DataRow dr in dttrades.Rows)
            {
                hstemp.Clear();
                string cctradeid = dr["cc_tradeid"].ToString();
                Int64 tradekey = Convert.ToInt64(dr["currencycloud_trade_key"]);
                
                //hstemp.Add("settlement_id", settlementid);
                hstemp.Add("trade_id", cctradeid);

                string strresponse = CallWeb_Request("/settlement/" + settlementid + "/add_trade", hstemp);
                JObject o = JObject.Parse(strresponse);
                string strstatus = (string)o["status"];
                if (strstatus == "success")
                {
                    tradesadded += 1;
                    Int64 settlementkey = sitetemp.getCurrencyCloudSettlementKey_From_ccsettlementid(settlementid);
                    Peerfx_DB.SPs.UpdateCurrencyCloudTradesAddedtoSettlement(settlementkey, tradekey).Execute();
                }
            }                      
            

            return tradesadded;
        }


        public Boolean Settlement_Release(string settlementid)
        {
            Boolean issuccess = false;
            
            Hashtable hstemp = new Hashtable();
            //hstemp.Add("settlement_id", settlementid);
            string strresponse = CallWeb_Request("/settlement/" + settlementid + "/release", hstemp);
            JObject o = JObject.Parse(strresponse);
            string strstatus = (string)o["status"];
            if (strstatus == "success")
            {
                issuccess = true;
                Int64 settlementkey = sitetemp.getCurrencyCloudSettlementKey_From_ccsettlementid(settlementid);
                Peerfx_DB.SPs.UpdateCurrencyCloudSettlementsReleased(settlementkey).Execute();
            }

            return issuccess;
        }

        public Hashtable getTradeDetails(string cctradeid)
        {            
            Hashtable hstemp = new Hashtable();
            string strresponse = CallWeb_Request("/trade/" + cctradeid + "?", hstemp);

            JObject o = JObject.Parse(strresponse);
            string strstatus = (string)o["status"];
            if (strstatus == "success")
            {
                JObject data = (JObject)o["data"];
                hstemp.Clear();
                hstemp = JsonConvert.DeserializeObject<Hashtable>(data.ToString());
            }

            return hstemp;
        }

        public Hashtable getPaymentDetails(string ccpaymentid)
        {
            Hashtable hstemp = new Hashtable();
            string strresponse = CallWeb_Request("/payment/" + ccpaymentid + "?", hstemp);

            JObject o = JObject.Parse(strresponse);
            string strstatus = (string)o["status"];
            if (strstatus == "success")
            {
                JObject data = (JObject)o["data"];
                hstemp.Clear();
                if (data != null)
                {
                    hstemp = JsonConvert.DeserializeObject<Hashtable>(data.ToString());
                }                
            }

            return hstemp;
        }

        public void CheckCC_Trades_DirectPayment()
        {
            //trades currently awaiting payment from CC
            DataTable dttemp = Peerfx_DB.SPs.ViewCurrencyCloudTradeBystatus(5).GetDataSet().Tables[0];

            foreach (DataRow dr in dttemp.Rows){
                if (dr["cc_paymentid"].ToString().Length > 0)
                {
                    Hashtable hstemp = getPaymentDetails(dr["cc_paymentid"].ToString());
                    if (hstemp.Count > 0)
                    {
                        if (hstemp["status"].ToString() == "completed")
                        {
                            //trade has finally been sent to recipient
                            Int64 cctradekey = Convert.ToInt64(dr["currencycloud_trade_key"]);
                            int paymentskey = Convert.ToInt32(dr["payments_key"]);
                            Payment paymenttemp = sitetemp.getPayment(paymentskey);

                            Peerfx_DB.SPs.UpdateCurrencyCloudTradesFundsreceived(cctradekey).Execute();

                            //move money from cc object to payment object
                            Users cctreasury = sitetemp.get_treasury_account(2);
                            Int64 cctreasurypaymentobject = sitetemp.getpaymentobject_UserBalance(cctreasury.User_key, paymenttemp.Buy_currency);
                            sitetemp.InternalTransaction(paymenttemp.Buy_currency, paymenttemp.Buy_amount, cctreasurypaymentobject, paymenttemp.Payment_object_receiver, paymenttemp.Requestor_user_key, "CurrencyCloud to Receiver Object", 1, paymentskey);

                            //change status to Transaction Complete
                            Peerfx_DB.SPs.UpdatePaymentStatus(paymentskey, 5).Execute();

                            //payment in Payment Sent, send email                                        
                            Peerfx.External_APIs.SendGrid sg = new Peerfx.External_APIs.SendGrid();
                            Users user_requestor = sitetemp.get_user_info(paymenttemp.Requestor_user_key);
                            sg.Send_Email_Payment_Completed(paymenttemp.Payments_Key, user_requestor);
                        }
                    }
                }                
            }
            Peerfx_DB.SPs.UpdateScheduledTask(4).Execute();
        }

        private string geturl()
        {
            string url = "";
            int playground = Convert.ToInt32(ConfigurationSettings.AppSettings["CurrencyCloud_Environment"]);
            switch (playground)
            {
                case 0: url = ConfigurationSettings.AppSettings["CurrencyCloud_api_url_reference"];                    
                    break;
                case 1: url = ConfigurationSettings.AppSettings["CurrencyCloud_api_url_demo"];                    
                    break;
                case 2: url = ConfigurationSettings.AppSettings["CurrencyCloud_api_url_live"];                    
                    break;
            }
            return url;
        }

        private string getapikey()
        {
            string key = "";
            int playground = Convert.ToInt32(ConfigurationSettings.AppSettings["CurrencyCloud_Environment"]);
            switch (playground)
            {
                case 0: key = ConfigurationSettings.AppSettings["CurrencyCloud_api_key_reference"];
                    break;
                case 1: key = ConfigurationSettings.AppSettings["CurrencyCloud_api_key_demo"];
                    break;
                case 2: key = ConfigurationSettings.AppSettings["CurrencyCloud_api_key_live"];
                    break;
            }
            return key;
        }        


        private string Web_Request(string callurl, Hashtable hstemp)
        {
            string url = geturl();            

            string token = view_info_currencycloud_token();
            if (callurl.Contains("authentication/token/new"))
            {
                url += "/api/en/v1.0";
            }
            else
            {
                url += "/api/en/v1.0/" + token;
            }            
            url += callurl;

            HttpWebResponse webResponse;

            string request = sitetemp.ConvertHashtabletoString(hstemp);
            
            // Create request object
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.MediaType = "application/x-www-form-urlencoded";
            if (url.Contains("?"))
            {
                webRequest.Method = "GET";
            }
            else
            {
                webRequest.Method = "POST";
                // Write the request string to the request object
                StreamWriter writer = new StreamWriter(webRequest.GetRequestStream());
                writer.Write(request);
                writer.Close();
            }
                       

            string responseString = "";
            try
            {                

                // Get the response from the request object and verify the status
                webResponse = webRequest.GetResponse() as HttpWebResponse;
                if (!webRequest.HaveResponse)
                {
                    throw new Exception();
                }
                if (webResponse.StatusCode != HttpStatusCode.OK && webResponse.StatusCode != HttpStatusCode.Accepted)
                {
                    throw new Exception();
                }

                // Read the response string
                StreamReader reader = new StreamReader(webResponse.GetResponseStream());
                responseString = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception e)
            {
                Peerfx_DB.SPs.UpdateApiErrors(1,request,e.Message,url).Execute(); 
                //string Toemail = System.Configuration.ConfigurationSettings.AppSettings.Get("ErrorToEmail").ToString();
                //SendGrid sg = new SendGrid();
                //sg.SimpleEmail("Lorne", "Passportfx API Error", Toemail, "Error@passportfx.com", e.Message, "CurrencyCloud Error");                
            }            
                        
            return responseString;
        }

        
        //Get token for reading exchange rates
        private string view_info_currencycloud_token()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrencyCloudTokens().GetDataSet();
            return dstemp.Tables[0].Rows[0]["Info_CurrencyCloud_Token"].ToString();
        }

        //Renew token for reading exchange rates
        private string update_info_currencycloud_token()
        {
            string newtoken = Authentication_New();
            Peerfx_DB.SPs.UpdateInfoCurrencyCloudTokens(1, newtoken).Execute();
            return newtoken;
        }

        private string CallWeb_Request(string callurl, Hashtable hstemp)
        {
            string strreturn;
            strreturn = Web_Request(callurl, hstemp);
            if ((strreturn.Contains("error")) || (strreturn == ""))
            {
                string token = update_info_currencycloud_token();
                strreturn = Web_Request(callurl, hstemp);
            }
            return strreturn;
        }
        
    }    
}