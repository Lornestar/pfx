using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;
using RestSharp;
using Peerfx.Models;
using System.Data;
using System.Configuration;

namespace Peerfx.External_APIs
{
    public class Facebook
    {
        Site sitetemp = new Site();
        public string getaccesstoken(string oauth, string thereturnpage, int userkey)
        {            
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8; //This is if you have non english characters

            string strsend = "https://graph.facebook.com/oauth/access_token?client_id=" + ConfigurationSettings.AppSettings["fb_app_id"].ToString() + "&redirect_uri=" + thereturnpage + "&client_secret=" + ConfigurationSettings.AppSettings["fb_app_secret"].ToString() + "&code=" + oauth;
            string result = "";
            try
            {
                result = wc.DownloadString(strsend);
            }
            catch (Exception e)
            {
                Peerfx_DB.SPs.UpdateApiErrors(4, strsend, e.Message, result).Execute();
            }
            string accesstoken = result.Replace("access_token=", "");

            Peerfx_DB.SPs.UpdateFacebookAccessToken(userkey, accesstoken).Execute();

            return accesstoken;
        }
            

        public void updateuserinfo(int userkey){

            Users_Facebook fbuser = sitetemp.get_user_Facebook(userkey);
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8; //This is if you have non english characters
            string result2 = "";
            try
            {
                result2 = wc.DownloadString("https://graph.facebook.com/me?access_token=" + fbuser.fb_access_token);
            }
            catch (Exception e)
            {
                Peerfx_DB.SPs.UpdateApiErrors(4, fbuser.fb_access_token, e.Message, result2).Execute();
            }

            try
            {
                JObject o = JObject.Parse(result2);
                string strtemp = "";
                strtemp = (string)o["id"];
                fbuser.fb_uid = Convert.ToInt64(strtemp);
                                
                if (o["email"] != null)
                {
                    fbuser.fb_email = (string)o["email"];
                }
                if (o["first_name"] != null)
                {
                    fbuser.fb_first_name = (string)o["first_name"];
                }
                if (o["last_name"] != null)
                {
                    fbuser.fb_last_name = (string)o["last_name"];
                }
                if (o["verified"] != null)
                {
                    fbuser.fb_isverified = (Boolean)o["verified"];                     
                }
                if (o["gender"] != null)
                {
                    strtemp = (string)o["gender"];
                    if (strtemp == "male")
                    {
                        fbuser.fb_ismale = true;
                    }
                    else
                    {
                        fbuser.fb_ismale = false;
                    }
                }
                if (o["location"] != null)
                {
                    JObject o2 = (JObject)o["location"];
                    fbuser.fb_location = (string)o2["name"];
                }

                try
                {
                    result2 = wc.DownloadString("https://graph.facebook.com/me/friends?access_token=" + fbuser.fb_access_token);
                    o = JObject.Parse(result2);
                    if (o["data"] != null)
                    {
                        JArray o2 = (JArray)o["data"];
                        fbuser.fb_friends_count = o2.Count;
                    }
                    
                }
                catch
                {
                }
                


                Peerfx_DB.SPs.UpdateFacebookUserInfo(userkey, fbuser.fb_uid, fbuser.fb_location, fbuser.fb_email, fbuser.fb_friends_count, fbuser.fb_ismale, fbuser.fb_first_name, fbuser.fb_last_name, fbuser.fb_isverified).Execute();

                //update verification
                if (fbuser.fb_uid > 0)
                {
                    Peerfx_DB.SPs.UpdateVerification(userkey, 5, true, sitetemp.get_ipaddress(), "").Execute();
                }                
            }
            catch
            {
            }

            
        }
        

    }
}