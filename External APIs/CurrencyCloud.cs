using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Text;

namespace Peerfx.External_APIs
{
    public class CurrencyCloud
    {
        public string Authentication_New(int playground){
            string strstatus = "error";
            Hashtable hstemp = new Hashtable();
            hstemp.Add("login_id", "lorne@lornestar.com");
            hstemp.Add("api_key", ConfigurationSettings.AppSettings["CurrencyCloud_api_key_reference"]);
            strstatus = Web_Request(playground, "/api/en/v1.0/authentication/token/new", hstemp);
            
            return strstatus;
        }


        private string Web_Request(int playground, string callurl, Hashtable hstemp)
        {
            string url = "";
            string apikey = "";

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

    }    
}