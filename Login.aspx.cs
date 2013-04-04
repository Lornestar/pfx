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
            DataTable dttemp = Peerfx_DB.SPs.ViewUsersLogin(txtemail.Text, txtpassword.Text).GetDataSet().Tables[0];
            int userkey = 0;
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0]["user_key"] != DBNull.Value){
                    userkey = Convert.ToInt32(dttemp.Rows[0]["user_key"]);
                    isvalidlogin = true;                    
                }                
            }            

            if (isvalidlogin)
            {
                //log them in           
                Users user = sitetemp.get_user_info(userkey);
                HttpContext.Current.Session["currentuser"] = user;
                Response.Redirect("/User/Dashboard.aspx");
            }
            else
            {
                lblerror.Visible = true;
                lblerror.Text = "Incorrect email/password combination.";
            }
        }
    }
}