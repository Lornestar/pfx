using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;

namespace Peerfx
{
    public partial class Login : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool isvalidlogin = false;
            //Try to login
            Users user = sitetemp.view_users_info_email(txtemail.Text);
            if (user.User_key > 0)
            {
                    isvalidlogin = true;
            }

            if (isvalidlogin)
            {
                //log them in                           
                HttpContext.Current.Session["currentuser"] = user;
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "Incorrect email/password combination.";
            }
        }
    }
}