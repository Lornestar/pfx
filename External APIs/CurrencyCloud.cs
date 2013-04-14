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

namespace Peerfx.External_APIs
{
    public class CurrencyCloud
    {
        Site sitetemp = new Site();

        public string Authentication_New(){
            string strstatus = "error";
            Hashtable hstemp = new Hashtable();
            hstemp.Add("login_id", "Lorne@Lornestar.com");
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

        public string Validate_BankAccount(int currency, string FullName, string aba, string accountnumber, string SingaporeBankCode, string CanadaInstitutionNumber, string BIC, string BranchCode, string Australiabsbcode, string IBAN, string BritishSortCode)
        {
            string currencycode = sitetemp.getcurrencycode(currency);
            string countrycode = sitetemp.getCountryValueFromCurrency(currency);
            Boolean isvalid = false;
            string strreturn = "";

            string strstatus = "error";
            Hashtable hstemp = new Hashtable();
            hstemp.Add("nickname", currencycode + " Account");
            hstemp.Add("acct_ccy", currencycode);
            hstemp.Add("beneficiary_name", FullName);
            hstemp.Add("destination_country_code", countrycode);
            hstemp.Add("is_beneficiary", "true");
            hstemp.Add("is_source", "false");

            if (aba.Length > 0)
            {
                hstemp.Add("aba", aba);
            }
            if (accountnumber.Length > 0)
            {
                hstemp.Add("acct_number", accountnumber);
            }
            if (SingaporeBankCode.Length > 0)
            {
                hstemp.Add("bank_code", SingaporeBankCode);
            }
            if (CanadaInstitutionNumber.Length > 0)
            {
                hstemp.Add("institution_no", CanadaInstitutionNumber);
            }
            if (BIC.Length > 0)
            {
                hstemp.Add("bic_swift", BIC);
            }
            if (BranchCode.Length > 0)
            {
                hstemp.Add("branch_code", BranchCode);
            }
            if (Australiabsbcode.Length > 0)
            {
                hstemp.Add("bsb_code", Australiabsbcode);
            }
            if (IBAN.Length > 0)
            {
                hstemp.Add("iban", IBAN);
            }
            if (BritishSortCode.Length > 0)
            {
                hstemp.Add("sort_code", BritishSortCode);
            }
            ///api/en/v1.0/:token/beneficiary/validate_details

            string strquery = sitetemp.ConvertHashtabletoString(hstemp);
            hstemp.Clear();

            strstatus = CallWeb_Request("/beneficiary/validate_details?"+strquery, hstemp);

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

            return strreturn;
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
            string responseString = CallWeb_Request("/beneficiaries/required_fields?ccy=" + currencycode + "&destination_country_code=" + countryvalue, hstemp);

            

            //example for USD
            //"{\"status\":\"success\",\"data\":[{\"required\":[\"acct_number\",\"aba\"]},{\"required\":[\"acct_number\",\"bic_swift\"]}]}"

            return responseString;
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
            catch
            {
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
            if (strreturn.Contains("error"))
            {
                string token = update_info_currencycloud_token();
                strreturn = Web_Request(callurl, hstemp);
            }
            return strreturn;
        }
        
    }    
}