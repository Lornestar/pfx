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
    public class BancBox
    {
        Site sitetemp = new Site();

        public void CreateClient(Users user)
        {
            Hashtable hstemp = new Hashtable();
            //hstemp.Add("referenceId", "");
            hstemp.Add("firstName", user.First_name);
            hstemp.Add("middleInitial", "");
            hstemp.Add("lastName", user.Last_name);            
            hstemp.Add("ssn", "555-55-5555");//NNN-NN-NNNN
            hstemp.Add("dob", "1978-10-10");//YYYY-MM-DD
            Hashtable hsaddress = new Hashtable();
            hsaddress.Add("line1","13 mockingbird lane");
            //hsaddress.Add("line2","Dallas");
            hsaddress.Add("city","Dallas");
            hsaddress.Add("state","TX");
            hsaddress.Add("zipcode","75230");

            hstemp.Add("address", hsaddress);
            hstemp.Add("homePhone", "5555555555");
            //hstemp.Add("mobilePhone", "");
            //hstemp.Add("workPhone", "");
            hstemp.Add("email", user.Email);
            //hstemp.Add("username", "");
            string strresponse = Web_Request("createClient", hstemp);

            //get clientid
            JObject o = JObject.Parse(strresponse);

            int status = (int)o["status"];
            if (status == 1){
                //request worked
                JObject o2 = (JObject)o["clientId"];
                int clientid = (int)o2["bancBoxId"];
                Peerfx_DB.SPs.UpdateBancBoxClientid(user.User_key, clientid).Execute();

                string clientstatus = (string)o["clientStatus"];
                Peerfx_DB.SPs.UpdateBancBoxClientstatus(clientid, clientstatus).Execute();
            }            
        }


        public void VerifyClient(Users user)
        {
            Hashtable hstemp = new Hashtable();
                        
                        
            hstemp.Add("clientId", Get_hsclient(user.Bancbox_client_id));
            hstemp.Add("generateQuestions", 2);

            string strresponse = Web_Request("verifyClient", hstemp);
            //get clientid
            JObject o = JObject.Parse(strresponse);

            int status = (int)o["status"];
            if (status == 1)
            {
                string cipStatus = (string)o["cipStatus"];
                Peerfx_DB.SPs.UpdateBancBoxCipstatus(user.Bancbox_client_id, cipStatus).Execute();
            }
        }

        public Int64 OpenAccount(Users user)
        {
            Int64 returnpaymentobject = 0;
            Hashtable hstemp = new Hashtable();

            hstemp.Add("clientId", Get_hsclient(user.Bancbox_client_id));
            hstemp.Add("title", "Passport USD Account");

            Hashtable hsroutable = new Hashtable();
            hsroutable.Add("credits", "YES");
            hsroutable.Add("debits", "NO");
            hstemp.Add("routable", hsroutable);

            string strresponse = Web_Request("openAccount", hstemp);

            JObject o = JObject.Parse(strresponse);

            int status = (int)o["status"];
            if (status == 1)
            {
                JObject o2 = (JObject)o["account"];
                JObject o3 = (JObject)o2["id"];
                Int64 accountid = (Int64)o3["bancBoxId"];
                string routing = (string)o2["routingNumber"];
                returnpaymentobject = sitetemp.insert_bancbox_account_returnpaymentobject(user.User_key, 3, sitetemp.getBancBoxOrganizationkey(), "BancBox Account", user.User_key, accountid.ToString(), "", "", routing, user.First_name, user.Last_name, "");
            }
            return returnpaymentobject;
        }

        public bool SendFunds_External(int userkey_sender, Int64 bank_account_receiver_receiver, decimal amount, string description, bool Recordtx, int purpose_type, int purpose_object_key)
        {
            bool txstatus = false;
            Hashtable hstemp = new Hashtable();
            Users usersender = sitetemp.get_user_info(userkey_sender);

            //get source bank account id
            BankAccounts bankaccount = sitetemp.getBankAccounts(0, usersender.Bancbox_payment_object_key);
            Hashtable hssourceaccount = new Hashtable();
            hssourceaccount.Add("bancBoxId",bankaccount.Account_number);
            hstemp.Add("sourceAccount", hssourceaccount);

            hstemp.Add("method", "ach");
            hstemp.Add("memo", description);
            

            bankaccount = sitetemp.getBankAccounts(0, bank_account_receiver_receiver);
            Hashtable hsach = new Hashtable();
            hsach.Add("routingNumber", bankaccount.ABArouting);
            hsach.Add("accountNumber", bankaccount.Account_number);
            hsach.Add("holderName", bankaccount.First_name + " " + bankaccount.Last_name);
            hsach.Add("bankAccountType", "SAVING");

            Hashtable hsaccount = new Hashtable();
            hsaccount.Add("bankAccount", hsach);
            Hashtable hsnewExternalAccount = new Hashtable();
            //hsnewExternalAccount.Add("account", hsaccount);
            hsnewExternalAccount.Add("bankAccount", hsach);

            Hashtable hsdestinationAccount = new Hashtable();
            hsdestinationAccount.Add("newExternalAccount", hsnewExternalAccount);
            hstemp.Add("destinationAccount", hsdestinationAccount);

            //add in items            
            List<Hashtable> listhsitems = new List<Hashtable>();
            Hashtable hsitems = new Hashtable();
            //hsitems.Add("scheduled", hsscheduled);
            //hsitems.Add("scheduleDate", DateTime.Now.AddDays(1).Date.ToString("yyyy-MM-dd"));//YYYY-MM-DD
            hsitems.Add("amount", decimal.Round(amount,2));
            //hsitems.Add("memo", "please work");
            listhsitems.Add(hsitems);
            hstemp.Add("items", listhsitems);

            string strresponse = Web_Request("sendFunds", hstemp);

            JObject o = JObject.Parse(strresponse);

            int status = (int)o["status"];
            if (status == 1)
            {
                //tx went through
                //report external transaction
                if (Recordtx)
                {                    
                    Peerfx_DB.SPs.UpdateTransactionsExternal(0, 1, 3, amount, usersender.Bancbox_payment_object_key, bank_account_receiver_receiver, sitetemp.get_ipaddress(), 0, description, "", 0,purpose_type,purpose_object_key).Execute();
                }                
            }
            return txstatus;
        }

        public bool SendFunds_Internal(int userkey_sender, int userkey_receiver, decimal amount, string description, bool Recordtx, int purpose_type, int purpose_object_key)
        {
            bool txstatus = false;
            Hashtable hstemp = new Hashtable();

            Users usersender = sitetemp.get_user_info(userkey_sender);
            Users userreceiver = sitetemp.get_user_info(userkey_receiver);

            //get source bank account id
            BankAccounts bankaccount = sitetemp.getBankAccounts(0, usersender.Bancbox_payment_object_key);
            Hashtable hssourceaccount = new Hashtable();
            hssourceaccount.Add("bancBoxId", bankaccount.Account_number);
            hstemp.Add("sourceAccount", hssourceaccount);

            hstemp.Add("method", "book");
            hstemp.Add("memo", description);

            //get destination account id
            bankaccount = sitetemp.getBankAccounts(0, userreceiver.Bancbox_payment_object_key);
            Hashtable hssourceaccount2 = new Hashtable();
            hssourceaccount2.Add("bancBoxId", bankaccount.Account_number);

            Hashtable hsaccount = new Hashtable();
            hsaccount.Add("account", hssourceaccount2);
            hstemp.Add("destinationAccount", hsaccount);

            //add in items            
            List<Hashtable> listhsitems = new List<Hashtable>();
            Hashtable hsitems = new Hashtable();
            //hsitems.Add("scheduled", hsscheduled);
            //hsitems.Add("scheduleDate", DateTime.Now.AddDays(1).Date.ToString("yyyy-MM-dd"));//YYYY-MM-DD
            hsitems.Add("amount", decimal.Round(amount, 2));
            //hsitems.Add("memo", "please work");
            listhsitems.Add(hsitems);
            hstemp.Add("items", listhsitems);

            string strresponse = Web_Request("sendFunds", hstemp);

            JObject o = JObject.Parse(strresponse);

            int status = (int)o["status"];
            if (status == 1)
            {
                //tx went through
                //report internal transaction
                if (Recordtx)
                {
                    Peerfx_DB.SPs.UpdateTransactionsInternal(0, 2, 3, amount, usersender.Bancbox_payment_object_key, userreceiver.Bancbox_payment_object_key, sitetemp.get_ipaddress(), 0, description, 0,purpose_type,purpose_object_key).Execute();
                }                
            }
            return txstatus;
        }

        /*public bool TransferFunds(int userkey_sender, int userkey_receiver, decimal amount)
        {
            bool txstatus = false;
            Hashtable hstemp = new Hashtable();

            //get source bank account id
            Users usersender = sitetemp.get_user_info(userkey_sender);
            Users userreceiver = sitetemp.get_user_info(userkey_receiver);
            BankAccounts bankaccount = sitetemp.getBankAccounts(0, usersender.Bancbox_payment_object_key);
            Hashtable hssourceaccount = new Hashtable();
            hssourceaccount.Add("bancBoxId", bankaccount.Account_number);
            hstemp.Add("sourceAccount", hssourceaccount);

            //get destination account id
            bankaccount = sitetemp.getBankAccounts(0, userreceiver.Bancbox_payment_object_key);
            Hashtable hssourceaccount2 = new Hashtable();
            hssourceaccount2.Add("bancBoxId", bankaccount.Account_number);
            hstemp.Add("destinationAccount", hssourceaccount2);

            //add in items            
            List<Hashtable> listhsitems = new List<Hashtable>();
            Hashtable hsitems = new Hashtable();
            //hsitems.Add("scheduled", hsscheduled);
            //hsitems.Add("scheduleDate", DateTime.Now.Date.ToString("yyyy-MM-dd"));//YYYY-MM-DD
            hsitems.Add("amount", decimal.Round(amount, 2));
            //hsitems.Add("memo", "please work");
            listhsitems.Add(hsitems);
            hstemp.Add("items", listhsitems);

            string strresponse = Web_Request("transferFunds", hstemp);

            JObject o = JObject.Parse(strresponse);

            int status = (int)o["status"];
            if (status == 1)
            {
                //tx went through
                //report internal transaction
            }

            return txstatus;
        }*/

        public bool CollectFunds(Int64 payment_object_receiver, string routingnumber, string accountnumber, string holdername, decimal amount)
        {
            bool txstatus = false;
            Hashtable hstemp = new Hashtable();

            //get source bank account id
            BankAccounts bankaccount = sitetemp.getBankAccounts(0, payment_object_receiver);
            Hashtable hssourceaccount = new Hashtable();
            hssourceaccount.Add("bancBoxId",bankaccount.Account_number);
            hstemp.Add("destinationAccount", hssourceaccount);

            hstemp.Add("method", "ach");            
            
            Hashtable hsach = new Hashtable();
            hsach.Add("routingNumber", routingnumber );
            hsach.Add("accountNumber", accountnumber );
            hsach.Add("holderName", holdername);
            hsach.Add("bankAccountType", "SAVING");

            Hashtable hsaccount = new Hashtable();
            hsaccount.Add("bankAccount", hsach);
            Hashtable hsnewExternalAccount = new Hashtable();
            //hsnewExternalAccount.Add("account", hsaccount);
            hsnewExternalAccount.Add("bankAccount", hsach);

            Hashtable hsdestinationAccount = new Hashtable();
            hsdestinationAccount.Add("newExternalAccount", hsnewExternalAccount);
            hstemp.Add("source", hsdestinationAccount);

            //add in items            
            List<Hashtable> listhsitems = new List<Hashtable>();
            Hashtable hsitems = new Hashtable();
            //hsitems.Add("scheduled", hsscheduled);
            //hsitems.Add("scheduleDate", DateTime.Now.AddDays(1).Date.ToString("yyyy-MM-dd"));//YYYY-MM-DD
            hsitems.Add("amount", decimal.Round(amount,2));
            //hsitems.Add("memo", "please work");
            listhsitems.Add(hsitems);
            hstemp.Add("items", listhsitems);

            string strresponse = Web_Request("collectFunds", hstemp);

            JObject o = JObject.Parse(strresponse);

            int status = (int)o["status"];
            if (status == 1)
            {
                //tx went through
                //report external transaction
            }
            return txstatus;            
        }

        private Hashtable Get_hsclient(int userkey)
        {
            Hashtable hsclientid = new Hashtable();
            hsclientid.Add("bancBoxId", userkey);
            //hsclientid.Add("subscriberReferenceId","");

            return hsclientid;
        }

        public Int64 Create_user_account(Users user)
        {
            Int64 returnpaymentobject = 0;
            if (user.Bancbox_client_id == 0)
            {
                //Create client id
                CreateClient(user);
                //update user object with bancbox clientid
                user = sitetemp.get_user_info(user.User_key);

                
            }
            //VerifyClient(user);
            returnpaymentobject = OpenAccount(user);
            return returnpaymentobject;
        }

        private string Web_Request(string callurl, Hashtable hstemp)
        {
            //use live credentials
            string url = ConfigurationSettings.AppSettings["BancBox_url_demo"];
            string apikey = ConfigurationSettings.AppSettings["BancBox_api_key_demo"];
            string apisecret = ConfigurationSettings.AppSettings["BancBox_api_secret"];
            int subscriberid = Convert.ToInt32(ConfigurationSettings.AppSettings["BancBox_subscriber_id"]);
            /*if (ConfigurationSettings.AppSettings["Root_url"].Contains("localhost"))
            {
                //use demo credentials
                url = ConfigurationSettings.AppSettings["Embee_URL_demo"]; //https://www.embeepay.com/fb/embeeqa/api/
                apiuserid = ConfigurationSettings.AppSettings["Embee_userid_demo"];
                apipwd = ConfigurationSettings.AppSettings["Embee_pwd_demo"];
            } */


            url += callurl;


            HttpWebResponse webResponse;
            /*StringBuilder requestString = new StringBuilder();

            
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


            string request = requestString.ToString();*/

            Hashtable hsauth = new Hashtable();
            hsauth.Add("apiKey", apikey);
            hsauth.Add("secret", apisecret);
            hstemp.Add("authentication", hsauth);
            hstemp.Add("subscriberId", subscriberid);
            string request = JsonConvert.SerializeObject(hstemp);
            
            //request = "{\"authentication\":{\"apiKey\":\"59a6d8abcdb0cd910d2485b1534864a3\",\"secret\":\"44c728c7d3bf58f4b60bd7a294118c8c\"},\"subscriberId\":202689}";

            // Create request object
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.Method = "POST";
            //webRequest.Credentials = new NetworkCredential(apiuserid, apipwd);
            //webRequest.Headers.Add("UserName", apiuserid);
            //webRequest.Headers.Add("Password", apipwd);            
            webRequest.ContentType = "application/json";
            webRequest.MediaType = "application/json";


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