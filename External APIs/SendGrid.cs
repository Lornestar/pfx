using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using Peerfx.Models;
using System.Collections;

namespace Peerfx.External_APIs
{
    public class SendGrid
    {
        Site sitetemp = new Site();

        public void SimpleEmail(string strTo, string strFrom, string strToEmail, string strFromEmail, string body, string strSubject)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress(strToEmail, strTo));

                // From
                if (strFromEmail.Length > 0){
                    mailMsg.From = new MailAddress(strFromEmail, strFrom);
                }
                else{
                    mailMsg.From = new MailAddress(ConfigurationSettings.AppSettings["DefaultFromEmailAddress"], ConfigurationSettings.AppSettings["DefaultFromEmailName"]);
                }
                

                // Subject and multipart/alternative Body
                mailMsg.Subject = strSubject;
                //string text = "text body";
                string html = body;
                //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["Sendgrid_username"], ConfigurationSettings.AppSettings["Sendgrid_pwd"]);
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Send_Email_Verification(int user_key)
        {
            Users currentuser = sitetemp.get_user_info(user_key);
            //create unique code & update db with it            
            string struniquecode = sitetemp.GenerateCode();            
            Peerfx_DB.SPs.UpdateVerificationEmail(user_key, false, sitetemp.get_ipaddress(), struniquecode).Execute();

            string thebody = getHeader(currentuser.Full_name) + System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/account_created.txt")) + getFooter();

            DataSet dstemp = Peerfx_DB.SPs.ViewUsersInfo(user_key).GetDataSet();
            string the_url = ConfigurationSettings.AppSettings["Verification_URL"] + struniquecode;

            thebody = thebody.Replace("THE_URL", the_url);

            SimpleEmail(currentuser.Full_name, "", currentuser.Email, "", thebody, "Passport email verification");
        }

        public void Send_Email_Verification_Confirmed(int user_key)
        {
            Users currentuser = sitetemp.get_user_info(user_key);

            string thebody = getHeader(currentuser.Full_name) + System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/email_verification.txt")) + getFooter();

            thebody = thebody.Replace("FIRST_NAME", currentuser.First_name);
            thebody = thebody.Replace("LAST_NAME", currentuser.Last_name);
            thebody = thebody.Replace("THE_URL", ConfigurationSettings.AppSettings["Root_url"].ToString());

            SimpleEmail(currentuser.First_name + " " + currentuser.Last_name, "", currentuser.Email, "", thebody, "Passport email verification confirmation");
        }

        public void Send_Email_Payment_Confirmed(int paymentkey, Users currentuser)
        {
            Payment paymenttemp = sitetemp.getPayment(paymentkey);            

            if (paymenttemp.Payment_object_receiver_type == 7)//embee top up
            {
                Send_Email_Payment_Confirmed_Embee(paymentkey);
            }
            else //all other types of payments
            {

                string thebody = getHeader(currentuser.Full_name) + System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/payment_confirmed.txt")) + getPaymentdetails(paymentkey) + getFooter();

                if (sitetemp.IsUserBalance(paymenttemp.Payment_object_sender)) //funding source is user balance
                {                    
                    thebody = thebody.Replace("DEPOSITINSTRUCTIONS", "");
                }
                else
                {
                    //funding source is bank account, include deposit instructions
                    string thebodydepositinstructions = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/payment_confirmed_depositinstructions.txt"));
                    string peerfxbankaccount = sitetemp.getBankAccountDescription(sitetemp.get_Payment_Object_sendmoneyto_For_Payment(currentuser.User_key, paymenttemp.Sell_currency));

                    thebody = thebody.Replace("DEPOSITINSTRUCTIONS", thebodydepositinstructions);
                    thebody = thebody.Replace("BANKACCOUNT", peerfxbankaccount);
                    thebody = thebody.Replace("NEXTSTEPS", sitetemp.RenderUserControl("~/User_Controls/ExchangeCurrency_NextSteps.ascx"));
                }

                     

                SimpleEmail(currentuser.Full_name, "", currentuser.Email, "", thebody, "Passport Payment Confirmed");
            }                     
        }

        public void Send_Email_Payment_Completed(int paymentkey, Users currentuser)
        {
            Payment paymenttemp = sitetemp.getPayment(paymentkey);            

            string thebody = getHeader(currentuser.Full_name) + System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/payment_completed.txt")) + getPaymentdetails(paymentkey) + getFooter();

            SimpleEmail(currentuser.Full_name, "", currentuser.Email, "", thebody, "Passport Payment Completed");
        }

        public string getHeader(string fullname)
        {
            string strreturn = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/header.txt"));
            strreturn = strreturn.Replace("FULL_NAME", fullname);
            return strreturn;
        }

        public string getFooter()
        {
            string strreturn = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/footer.txt"));            
            return strreturn;
        }

        public string getPaymentdetails(int paymentkey)
        {
            string strreturn = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/payment_details.txt"));
            Payment paymenttemp = sitetemp.getPayment(paymentkey);

            if (paymenttemp.Payment_object_receiver_type == 3)
            {
                //going to user balance
                strreturn = strreturn.Replace("BANKACCOUNTINFO", "Passport Balance");
            }
            else //going to bank account
            {
                strreturn = strreturn.Replace("BANKACCOUNTINFO", sitetemp.getBankAccountDescription(paymenttemp.Payment_object_receiver));
            }


            strreturn = strreturn.Replace("PAYMENTNUM", paymentkey.ToString());
            strreturn = strreturn.Replace("SENDAMOUNT", sitetemp.GetCurrencySymbol(paymenttemp.Sell_currency) + " " + paymenttemp.Sell_amount.ToString("F") + " " + sitetemp.getcurrencycode(paymenttemp.Sell_currency));
            strreturn = strreturn.Replace("RECEIVERNAME", paymenttemp.Receiver_name);
            strreturn = strreturn.Replace("DESCRIPTION", paymenttemp.Payment_description);           

            return strreturn;
        }

        public void Send_Email_Payment_Completed_Embee(int paymentkey)
        {            

            EmbeeObject embeetemp = sitetemp.getEmbeeObject(paymentkey);
            Payment paymenttemp = sitetemp.getPayment(embeetemp.Payment_key);
            Users currentuser = sitetemp.get_user_info(paymenttemp.Requestor_user_key);

            string thebody = getHeader(currentuser.Full_name) + System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/payment_completed_embee.txt")) + getFooter();

            thebody = thebody.Replace("FIRST_NAME", currentuser.First_name);
            thebody = thebody.Replace("LAST_NAME", currentuser.Last_name);
            thebody = thebody.Replace("TOPUPPRICE", embeetemp.Price.ToString("F"));
            thebody = thebody.Replace("TOPUPDESCRIPTION", embeetemp.Productname);
            thebody = thebody.Replace("PAYMENTDESCRIPTION", paymenttemp.Payment_description);
            thebody = thebody.Replace("PHONENUMBER", embeetemp.Phone);
            thebody = thebody.Replace("THEMESSAGE", embeetemp.Message);

            SimpleEmail(currentuser.Full_name, "", currentuser.Email, "", thebody, "Passport Top Up Completed");
        }

        public void Send_Email_Payment_Confirmed_Embee(int paymentkey)
        {
            
            EmbeeObject embeetemp = sitetemp.getEmbeeObject(paymentkey);
            Payment paymenttemp = sitetemp.getPayment(embeetemp.Payment_key);
            Users currentuser = sitetemp.get_user_info(paymenttemp.Requestor_user_key);

            string thebody = getHeader(currentuser.Full_name) + System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/payment_confirmed_embee.txt")) + getFooter();

            thebody = thebody.Replace("FIRST_NAME", currentuser.First_name);
            thebody = thebody.Replace("LAST_NAME", currentuser.Last_name);
            thebody = thebody.Replace("TOPUPPRICE", embeetemp.Price.ToString("F"));
            thebody = thebody.Replace("TOPUPDESCRIPTION", embeetemp.Productname);
            thebody = thebody.Replace("PAYMENTDESCRIPTION", paymenttemp.Payment_description);
            thebody = thebody.Replace("PHONENUMBER", embeetemp.Phone);
            thebody = thebody.Replace("THEMESSAGE", paymenttemp.Payment_description);

            SimpleEmail(currentuser.Full_name, "", currentuser.Email, "", thebody, "Passport Top Up Confirmed");
        }


        public void Send_Email_Deposit_Received(int userkey, int paymentkey, int deposittype, decimal amount, int currency)
        {
            //deposit types -->
            // 0 = user balance
            // 1 = payment
            Users currentuser = sitetemp.get_user_info(userkey);

            string thebody;                     

            string thebodymessage;
            if (deposittype == 0)
            {
                thebody = getHeader(currentuser.Full_name) + System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/deposit_received.txt")) + getFooter();
                thebodymessage = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/deposit_received_messageuserbalance.txt"));
                thebody = thebody.Replace("THEMESSAGE", thebodymessage);
            }
            else
            {
                thebody = getHeader(currentuser.Full_name) + System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/deposit_received.txt")) + getPaymentdetails(paymentkey) + getFooter();
                thebodymessage = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/deposit_received_messagepayment.txt"));
                thebody = thebody.Replace("THEMESSAGE", thebodymessage);
            }

            thebody = thebody.Replace("THEAMOUNT", sitetemp.GetCurrencySymbol(currency) + amount.ToString("F") + " " + sitetemp.getcurrencycode(currency) );

            SimpleEmail(currentuser.Full_name, "", currentuser.Email, "", thebody, "Passport Deposit Received");
        }

        public void Send_Email_Verification_Approved(int userkey, int verificationmethod)
        {
            Users currentuser = sitetemp.get_user_info(userkey);

            string thebody;
            string thesubject;

            if (verificationmethod == 2)
            {
                //passport
                thesubject = "Passport ID verified";
                thebody = getHeader(currentuser.Full_name) + System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/verification_id.txt")) + getverificationstatus(userkey) + getFooter();
            }
            else 
            {
                //address
                thesubject = "Passport Address verified";
                thebody = getHeader(currentuser.Full_name) + System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/verification_address.txt")) + getverificationstatus(userkey) + getFooter();
            }

            SimpleEmail(currentuser.Full_name, "", currentuser.Email, "", thebody, "Passport Deposit Received");

        }

        protected string getverificationstatus(int userkey)
        {
            string strreturn = "";

            strreturn = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/verification_current_status.txt"));            

            Hashtable hsverifications = sitetemp.getusersverified(userkey);
            foreach (DictionaryEntry entry in hsverifications)
            {
                Peerfx.Models.Verification verificationtemp = (Peerfx.Models.Verification)entry.Value;
                int methodkey = Convert.ToInt32(entry.Key);
                switch (methodkey)
                {
                    case 1: if (verificationtemp.Isverified)
                        {
                            //Email verified
                            strreturn = strreturn.Replace("EMAILVERIFIED", "Approved");
                        }
                        break;
                    case 2: if (verificationtemp.Isverified)
                        {
                            //Passport verified
                            strreturn = strreturn.Replace("IDVERIFIED", "Approved");
                        }
                        break;
                    case 3: if (verificationtemp.Isverified)
                        {
                            //Address verified
                            strreturn = strreturn.Replace("ADDRESSVERIFIED", "Approved");
                        }
                        break;
                }
            }
            strreturn = strreturn.Replace("EMAILVERIFIED", "Not Approved");
            strreturn = strreturn.Replace("IDVERIFIED", "Not Approved");
            strreturn = strreturn.Replace("ADDRESSVERIFIED", "Not Approved");

            return strreturn;
        }

    }
}