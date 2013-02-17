using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;
using System.Configuration;

namespace Peerfx.User_Controls
{
    public partial class Login : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sitetemp.isloggedin())
            {
                //is logged in
                pnlLoginSignup.Visible = false;
                pnlSignedIn.Visible = true;
                Users users = sitetemp.getcurrentuser(false);
                lblusername.Text = users.Email;
                if (users.Isadmin)
                {
                    hypAdmin.Visible = true;
                }                
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["currentuser"] = null;
            Response.Redirect(ConfigurationSettings.AppSettings["Root_url"] + "default.aspx");
        }
    }
}