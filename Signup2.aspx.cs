using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SubSonic;
using Peerfx.Models;

namespace Peerfx
{
    public partial class Signup2 : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        External_APIs.Mixpanel mx = new External_APIs.Mixpanel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Request.QueryString["type"] != null) && (Request.QueryString["type"] != ""))
                {
                    string strtype = Request.QueryString["type"].ToString();
                    if (strtype == "1")
                    {
                        pnlinfo.Visible = true;
                    }
                }
            }
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            //check if email exists
            DataTable dttemp = Peerfx_DB.SPs.ViewUsersEmail(txtemail.Text).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                //user exists
                lblerror.Text = "Email address already Signed Up";
            }
            else if (txtemail.Text == "")
            {
                lblerror.Text = "Please enter email address";
            }
            else if (!sitetemp.IsValidEmail(txtemail.Text))
            {
                lblerror.Text = "Please enter a valid email address";
            }
            else if (txtfirstname.Text == "")
            {
                lblerror.Text = "Please enter first name";
            }
            else if (txtlastname.Text == "")
            {
                lblerror.Text = "Please enter last name";
            }
            else if (txtpassword.Text == "")
            {
                lblerror.Text = "Please enter password";
            }
            else
            {
                //sign up user & log them in
                StoredProcedure sp_UpdateSignup1 = Peerfx_DB.SPs.UpdateUsers(0, "", txtfirstname.Text, "", txtlastname.Text, null, null, txtemail.Text, HttpContext.Current.Request.UserHostAddress, 0);
                sp_UpdateSignup1.Execute();

                int temp_user_key = Convert.ToInt32(sp_UpdateSignup1.Command.Parameters[9].ParameterValue.ToString());

                Peerfx_DB.SPs.UpdateUsersInfo(temp_user_key, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null).Execute();

                Peerfx_DB.SPs.UpdateUsersInfoSignupTab3(temp_user_key, "", txtpassword.Text).Execute();


                mx.TrackEvent("Sign Up", temp_user_key, null);
                
                Users user = sitetemp.view_users_info_email(txtemail.Text);
                HttpContext.Current.Session["currentuser"] = user;
                //Response.Redirect("/User/Dashboard.aspx");

                //send verification email
                External_APIs.SendGrid sg = new External_APIs.SendGrid();
                sg.Send_Email_Verification(temp_user_key);

                Page.ClientScript.RegisterStartupScript(GetType(), "h", "Loginuser();", true);
            }

            

        }
    }
}