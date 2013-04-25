using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Data;
using SubSonic;
using Peerfx.Models;
using System.IO;

namespace Peerfx.Facebook
{
    public partial class fblogin : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(false);
            if ((Request.QueryString["code"] != null) && (Request.QueryString["code"] != ""))
            {
                Setfb();
            }
            else if ((Request.QueryString["error"] != null) && (Request.QueryString["error"] != ""))
            {
                Response.Redirect("/User/Verification.aspx");
            }                
        }

        protected void Setfb()
        {
            string oauth = Request.QueryString["code"].ToString();
            Peerfx.External_APIs.Facebook fb = new External_APIs.Facebook();
            string accesstoken = fb.getaccesstoken(oauth, HttpContext.Current.Request.Url.AbsoluteUri,currentuser.User_key);

            //Get user id
            fb.updateuserinfo(currentuser.User_key);

            sitetemp.VerificationReward(5, currentuser.User_key);

            External_APIs.Mixpanel mx = new External_APIs.Mixpanel();
            mx.TrackEvent("Verification - Facebook Connected",currentuser.User_key);

            string msg = "";
            if (currentuser.Referral != null)
            {
                //Embee Referral
                string url = "https://www.embeepay.com/fb/wallet/bin/embee_reward.php?id=" + currentuser.Referral;
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.MediaType = "application/x-www-form-urlencoded";            
                webRequest.Method = "GET";
                string responseString;
                try
                {
                    HttpWebResponse webResponse;
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
                    mx.TrackEvent("Referral Complete", currentuser.User_key);
                    msg = "?msg=You have completed your Embee task. Thanks! Feel free to continue to play around with our site.";
                }
                catch (Exception e)
                {
                    Peerfx_DB.SPs.UpdateApiErrors(3, "", e.Message, url).Execute();
                    string Toemail = System.Configuration.ConfigurationSettings.AppSettings.Get("ErrorToEmail").ToString();
                    External_APIs.SendGrid sg = new External_APIs.SendGrid();
                    sg.SimpleEmail("Lorne", "Passportfx API Error", Toemail, "Error@passportfx.com", e.Message, "Embee Error");                
                }
            }            

            //redirect back to verification page
            Response.Redirect("/User/Verification.aspx" + msg);
        }

    }
}