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
            //create unique code & update db with it
            string struniquecode = Membership.GeneratePassword(8, 0);
            struniquecode = Regex.Replace(struniquecode, @"[^a-zA-Z0-9]", m => "9");
            Site sitetemp = new Site();
            Peerfx_DB.SPs.UpdateVerificationEmail(user_key, false, sitetemp.get_ipaddress(), struniquecode).Execute();

            string thebody = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/account_created.txt"));

            DataSet dstemp = Peerfx_DB.SPs.ViewUsersInfo(user_key).GetDataSet();

            string first_name = "";
            string last_name = "";
            string email = "";
            string the_url = ConfigurationSettings.AppSettings["Verification_URL"] + struniquecode;

            if (dstemp.Tables[0].Rows[0]["first_name"] != DBNull.Value)
            { first_name = dstemp.Tables[0].Rows[0]["first_name"].ToString(); }
            if (dstemp.Tables[0].Rows[0]["last_name"] != DBNull.Value)
            { last_name = dstemp.Tables[0].Rows[0]["last_name"].ToString(); }
            if (dstemp.Tables[0].Rows[0]["email"] != DBNull.Value)
            { email = dstemp.Tables[0].Rows[0]["email"].ToString(); }            

            thebody = thebody.Replace("FIRST_NAME", first_name);
            thebody = thebody.Replace("LAST_NAME", last_name);
            thebody = thebody.Replace("THE_URL", the_url);

            SimpleEmail(first_name + " " + last_name, "", email, "", thebody, "Tradepfx email verification");
        }

        public void Send_Email_Verification_Confirmed(int user_key)
        {
            string thebody = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/email_verification.txt"));

            Users currentuser = sitetemp.get_user_info(user_key);

            thebody = thebody.Replace("FIRST_NAME", currentuser.First_name);
            thebody = thebody.Replace("LAST_NAME", currentuser.Last_name);
            thebody = thebody.Replace("THE_URL", ConfigurationSettings.AppSettings["Root_url"].ToString());

            SimpleEmail(currentuser.First_name + " " + currentuser.Last_name, "", currentuser.Email, "", thebody, "Tradepfx email verification confirmation");
        }

        public void Send_Email_Payment_Confirmed(int paymentkey, Users currentuser)
        {
            string thebody = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/payment_confirmed.txt"));

            Payment paymenttemp = sitetemp.getPayment(paymentkey);

            DataSet dstemp = Peerfx_DB.SPs.ViewAdminBankAccountCurrencyExchange(Convert.ToInt32(paymenttemp.Sell_currency), currentuser.Country_residence).GetDataSet();
            string peerfxbankaccount = sitetemp.getBankAccountDescription(Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_key"]));

            thebody = thebody.Replace("FIRST_NAME", currentuser.First_name);
            thebody = thebody.Replace("LAST_NAME", currentuser.Last_name);
            thebody = thebody.Replace("PAYMENTNUM", paymentkey.ToString());
            thebody = thebody.Replace("SENDAMOUNT", sitetemp.GetCurrencySymbol(paymenttemp.Sell_currency) + " " + paymenttemp.Sell_amount.ToString("F"));
            thebody = thebody.Replace("RECEIVERNAME", paymenttemp.Receiver_name);
            thebody = thebody.Replace("BANKACCOUNTINFO", sitetemp.getBankAccountDescription(paymenttemp.Payment_object_receiver));
            thebody = thebody.Replace("DESCRIPTION", paymenttemp.Payment_description);
            thebody = thebody.Replace("BANKACCOUNT", peerfxbankaccount);
            thebody = thebody.Replace("NEXTSTEPS", sitetemp.RenderUserControl("~/User_Controls/ExchangeCurrency_NextSteps.ascx"));

            SimpleEmail(currentuser.Full_name, "", currentuser.Email, "", thebody, "Tradepfx Payment Confirmed");
        }

    }
}