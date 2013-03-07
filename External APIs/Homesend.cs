using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    public class Homesend
    {
        public string SendRemittance()
        {
            string strresponse = "";

            Hashtable hstemp = new Hashtable();

            strresponse = Web_Request("", hstemp);

            return strresponse;
        }

        private string Web_Request(string callurl, Hashtable hstemp)
        {
            //use live credentials
            string url = "http://www.eservglobal.com/homesend/hws/2.3/remittance";
            string apiuserid = "Robert.Bell@MoneyBoxCapital.com";
            string apipwd = "$Bell0503Home£%2013SendCertificationProgramme$";
            /*if (ConfigurationSettings.AppSettings["Root_url"].Contains("localhost"))
            {
                //use demo credentials
                url = ConfigurationSettings.AppSettings["Embee_URL_demo"]; //https://www.embeepay.com/fb/embeeqa/api/
                apiuserid = ConfigurationSettings.AppSettings["Embee_userid_demo"];
                apipwd = ConfigurationSettings.AppSettings["Embee_pwd_demo"];
            } */


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

            requestString.Append(System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/External APIs/homesendtest.txt")));

            string request = requestString.ToString();

            // Create request object
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.Credentials = new NetworkCredential(apiuserid, apipwd);
            //webRequest.Headers.Add("UserName", apiuserid);
            //webRequest.Headers.Add("Password", apipwd);            
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