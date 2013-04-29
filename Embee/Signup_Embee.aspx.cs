using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SubSonic;
using Peerfx.Models;

namespace Peerfx.Embee
{
    public partial class Signup_Embee : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        External_APIs.Mixpanel mx = new External_APIs.Mixpanel();
        protected void Page_Load(object sender, EventArgs e)
        {
                            
            
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            string strid = null;
            if ((Request.QueryString["id"] != null) && (Request.QueryString["id"] != ""))
            {
                strid = Request.QueryString["id"].ToString();
            }

            

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
            else if (strid == null)
            {
                lblerror.Text = "Could not find Embee ID";
            }
            else
            {
                //sign up user & log them in
                StoredProcedure sp_UpdateSignup1 = Peerfx_DB.SPs.UpdateUsers(0, "", txtfirstname.Text, "", txtlastname.Text, null, null, txtemail.Text, HttpContext.Current.Request.UserHostAddress, 0);
                sp_UpdateSignup1.Execute();

                int temp_user_key = Convert.ToInt32(sp_UpdateSignup1.Command.Parameters[9].ParameterValue.ToString());

                Peerfx_DB.SPs.UpdateUsersInfo(temp_user_key, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null).Execute();

                Peerfx_DB.SPs.UpdateUsersInfoSignupTab3(temp_user_key, "", txtpassword.Text).Execute();

                Peerfx_DB.SPs.UpdateUsersReferral(temp_user_key, strid).Execute();

                mx.TrackEvent("Sign Up - Embee", temp_user_key, null);

                Users user = sitetemp.view_users_info_email(txtemail.Text);
                HttpContext.Current.Session["currentuser"] = user;
                Response.Redirect("/User/Verification.aspx");

                //send verification email
                External_APIs.SendGrid sg = new External_APIs.SendGrid();
                sg.Send_Email_Verification(temp_user_key);

                
            }



        }
    }
}