using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Net.Mail;
using System.Net.Mime;

namespace Peerfx
{
    public class SendGrid
    {

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
            string struniquecode = Membership.GeneratePassword(8, 1);
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

    }
}