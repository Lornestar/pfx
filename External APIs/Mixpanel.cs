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
using Peerfx.Models;
using System.Security.Cryptography;

namespace Peerfx.External_APIs
{
    public class Mixpanel
    {
        Site sitetemp = new Site();

        public void TrackEvent(string eventname,int userkey)
        {
            string token = ConfigurationSettings.AppSettings["Mixpaneltoken"];
            Hashtable hsproperties = new Hashtable();
            hsproperties.Add("distinct_id", userkey.ToString());
            hsproperties.Add("ip", sitetemp.get_ipaddress());
            hsproperties.Add("token", token);

            Hashtable hstemp = new Hashtable();
            hstemp.Add("event", eventname);
            hstemp.Add("properties", hsproperties);

            Web_Request(hstemp);
        }

        private string Web_Request(Hashtable hstemp)
        {
            string url = ConfigurationSettings.AppSettings["Mixpanelurl"];            
            
            HttpWebResponse webResponse;

            string request = JsonConvert.SerializeObject(hstemp);
            request = sitetemp.EncodeTo64(request).ToString();
            url += request;

            // Create request object
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.MediaType = "application/x-www-form-urlencoded";
            webRequest.Method = "GET";            

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
                Peerfx_DB.SPs.UpdateApiErrors(2, request, e.Message, url).Execute();
                string Toemail = System.Configuration.ConfigurationSettings.AppSettings.Get("ErrorToEmail").ToString();
                SendGrid sg = new SendGrid();
                sg.SimpleEmail("Lorne", "Passportfx API Error", Toemail, "Error@passportfx.com", e.Message, "Mixpanel Error");
            }

            return responseString;
        }

    }

}