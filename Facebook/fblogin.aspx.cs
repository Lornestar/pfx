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
        }

        protected void Setfb()
        {
            string oauth = Request.QueryString["code"].ToString();
            Peerfx.External_APIs.Facebook fb = new External_APIs.Facebook();
            string accesstoken = fb.getaccesstoken(oauth, HttpContext.Current.Request.Url.AbsoluteUri,currentuser.User_key);

            //Get user id
            fb.updateuserinfo(currentuser.User_key);                       

            //redirect back to verification page
            Response.Redirect("/User/Verification.aspx");
        }

    }
}