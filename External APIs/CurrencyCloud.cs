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
        public string Authentication_New(){
            string strstatus = "error";
            Hashtable hstemp = new Hashtable();
            hstemp.Add("login_id", "Lorne@Lornestar.com");
            hstemp.Add("api_key", getapikey());
            strstatus = Web_Request("/api/en/v1.0/authentication/token/new", hstemp);
            
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
                int playground = Convert.ToInt32(ConfigurationSettings.AppSettings["CurrencyCloud_Environment"]);
                string url = geturl();
                string token = view_info_currencycloud_token();                                
                
                url += "/api/en/v1.0/" + token + "/prices/market/" + strcurrencycodes;

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
                }

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
            string url = "";
            string apikey = "";
            int playground = Convert.ToInt32(ConfigurationSettings.AppSettings["CurrencyCloud_Environment"]);

            switch (playground)
            {
                case 0: url = ConfigurationSettings.AppSettings["CurrencyCloud_api_url_reference"];
                    apikey = ConfigurationSettings.AppSettings["CurrencyCloud_api_key_reference"];
                    break;
                case 1: url = ConfigurationSettings.AppSettings["CurrencyCloud_api_url_demo"];
                    apikey = ConfigurationSettings.AppSettings["CurrencyCloud_api_key_demo"];
                    break;
                case 2: url = ConfigurationSettings.AppSettings["CurrencyCloud_api_url_live"];
                    apikey = ConfigurationSettings.AppSettings["CurrencyCloud_api_key_live"];
                    break;
            }
            url += callurl;

            HttpWebResponse webResponse;            
            StringBuilder requestString = new StringBuilder();

            if (hstemp != null)
            {
                foreach (DictionaryEntry Item in hstemp)
                {
                    if (requestString.Length == 0)
                    {
                        requestString.Append(Item.Key + "=" + Item.Value);
                    }
                    else
                    {
                        requestString.Append("&" + Item.Key + "=" + Item.Value);
                    }                    
                }
            }
            
            
            string request = requestString.ToString();
            
            // Create request object
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.MediaType = "application/x-www-form-urlencoded";


            // Write the request string to the request object
            StreamWriter writer = new StreamWriter(webRequest.GetRequestStream());
            writer.Write(request);
            writer.Close();

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
            string responseString = reader.ReadToEnd();
            reader.Close();
                        
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

        
    }    
}