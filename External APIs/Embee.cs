using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
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
    public class Embee
    {

        public Hashtable getCatalog(string countrycode)
        {            
            Hashtable hstemp = new Hashtable();
            hstemp.Add("method", "get_catalog");
            hstemp.Add("country", countrycode);
            string strresponse = Web_Request("?", hstemp);

            JObject o = JObject.Parse(strresponse);
            JArray items = (JArray)o["catalog"];

            JObject item;
            JToken jtoken;

            for (int i = 0; i < items.Count; i++) //loop through rows
            {
                JObject thecompany = (JObject)items[i];
                JToken thecompanyname = (JToken)thecompany.First;
                string strcompany = ((JProperty)thecompanyname).Name.ToString();
                JArray items2 = (JArray)thecompany[strcompany];
                for (int j = 0; j < items2.Count; j++) //loop through rows
                {
                    item = (JObject)items2[j];
                    EmbeeCatalog catalog = new EmbeeCatalog();
                    catalog.Productname = (string)item["product_name"];
                    string tempproductid = (string)item["product_id"];
                    catalog.Productid = Convert.ToInt32(tempproductid);
                    string tempprice = (string)item["price_in_dollars"];
                    catalog.Price = Convert.ToDecimal(tempprice);
                    catalog.Carrier = strcompany;                    
                    hstemp.Add(i.ToString() + j.ToString(), catalog);
                }                
            }
            return hstemp;
        }

        public void UpdateCatalog()
        {
            Hashtable countriessupporting = new Hashtable();
            countriessupporting.Add(2, "USA");
            countriessupporting.Add(1, "CAN");
            countriessupporting.Add(130, "PHL");
            countriessupporting.Add(79, "IDN");
            countriessupporting.Add(190, "BGD");
            countriessupporting.Add(169, "THA");
            countriessupporting.Add(99, "MYS");

            Peerfx_DB.SPs.DeleteEmbeeCatalog().Execute();

            foreach (DictionaryEntry entry in countriessupporting)
            {
                Hashtable hstemp = new Hashtable();
                hstemp = getCatalog(entry.Value.ToString());

                foreach (DictionaryEntry entrycatalog in hstemp)
                {
                    try
                    {
                        EmbeeCatalog catalogtemp = (EmbeeCatalog)entrycatalog.Value;
                        Peerfx_DB.SPs.UpdateEmbeeCatalog(Convert.ToInt32(entry.Key), catalogtemp.Carrier, catalogtemp.Productid, catalogtemp.Productname, catalogtemp.Price).Execute();
                    }
                    catch
                    {
                    }                    
                }
            }
            Peerfx_DB.SPs.UpdateScheduledTask(1).Execute();
        }

        public int RequestPurchase(string productid, string phonenumber, string email, string ipaddress, int user_id, int paymentkey)
        {
            if (email == "")
            {
                email = "lorne@lornestar.com";
            }

            int transid = 0;            
            string strrequest = "?";

            Hashtable hstemp = new Hashtable();
            hstemp.Add("method","request_purchase");
            hstemp.Add("channel_user_id", user_id.ToString());            
            //using payment key instead of tx id, because for now only 1 tx request can be made 
            hstemp.Add("channel_trans_id", paymentkey.ToString());
            hstemp.Add("product_id", productid);
            hstemp.Add("phone_number", phonenumber);
            hstemp.Add("email",email);
            hstemp.Add("ip",ipaddress);
            
            string strresponse = Web_Request(strrequest, hstemp);

            JObject o = JObject.Parse(strresponse);
            int result = (int)o["result"];
            if (result == 1)
            {
                transid = (int)o["trans_id"];
            }

            return transid;
        }

        public EmbeeObject GetStatus(string transid){
            EmbeeObject embeetemp = new EmbeeObject();
            embeetemp.Transstatus = 1;

            Hashtable hstemp = new Hashtable();
            string strresponse = Web_Request("?method=get_status&trans_id="+transid, hstemp);

            JObject o = JObject.Parse(strresponse);
            int result = (int)o["result"];
            if (result == 1)
            {
                string strstatus = (string)o["status"];
                if (strstatus.ToUpper() == "COMPLETED")
                {
                    embeetemp.Transstatus = 2;                    
                }
                if (strstatus.ToUpper() == "CANCELED")
                {
                    embeetemp.Transid = -1;
                }
                embeetemp.Message = (string)o["message"];                
            }
            
            return embeetemp;
        }
            


        private string Web_Request(string callurl, Hashtable hstemp)
        {
            //use live credentials
            string url = ConfigurationSettings.AppSettings["Embee_URL_live"]; //https://www.embeepay.com/fb/wallet/api/
            string apiuserid = ConfigurationSettings.AppSettings["Embee_userid_live"];
            string apipwd = ConfigurationSettings.AppSettings["Embee_pwd_live"];
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