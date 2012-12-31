using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Telerik.Web.UI;
using System.Data;
using SubSonic;
using System.Net.Mail;
using System.Net.Mime;


namespace Peerfx
{
    public partial class Signup : System.Web.UI.Page
    {
        int user_key;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlbirthyear.DataTextField = "text";
                ddlbirthyear.DataValueField = "value";
                ddlbirthyear.DataSource = Master.populateyear();
                ddlbirthyear.DataBind();

                ddlbirthday.DataTextField = "text";
                ddlbirthday.DataValueField = "value";
                ddlbirthday.DataSource = Master.populateday();
                ddlbirthday.DataBind();

                DataTable dtcountries = Master.populatecountrylist();

                ddlcountryresidence.DataTextField = "Country_Text";
                ddlcountryresidence.DataValueField = "info_country_key";
                ddlcountryresidence.DataSource = dtcountries;
                ddlcountryresidence.DataBind();
                
                ddlCountrytab2.DataTextField = "Country_Text";
                ddlCountrytab2.DataValueField = "info_country_key";
                ddlCountrytab2.DataSource = dtcountries;
                ddlCountrytab2.DataBind();


                ddlIdentityNationality.DataTextField = "Country_Text";
                ddlIdentityNationality.DataValueField = "info_country_key";
                ddlIdentityNationality.DataSource = dtcountries;
                ddlIdentityNationality.DataBind();

                DataTable dtcountrycodes = Master.populatecountrycodelist();

                ddlPhoneCountryCode1.DataTextField = "Country_Code";
                ddlPhoneCountryCode1.DataValueField = "info_country_key";
                ddlPhoneCountryCode1.DataSource = dtcountrycodes;
                ddlPhoneCountryCode1.DataBind();

                ddlPhoneCountryCode2.DataTextField = "Country_Code";
                ddlPhoneCountryCode2.DataValueField = "info_country_key";
                ddlPhoneCountryCode2.DataSource = dtcountrycodes;
                ddlPhoneCountryCode2.DataBind();

                DataTable dtphonetype = Master.populatephonetype();

                ddlPhoneType1.DataTextField = "Phone_Type_Text";
                ddlPhoneType1.DataValueField = "info_phone_type_key";
                ddlPhoneType1.DataSource = dtphonetype;
                ddlPhoneType1.DataBind();

                ddlPhoneType2.DataTextField = "Phone_Type_Text";
                ddlPhoneType2.DataValueField = "info_phone_type_key";
                ddlPhoneType2.DataSource = dtphonetype;
                ddlPhoneType2.DataBind();

                DataTable dtsecurityquestions = Master.populatesecurityquestions();

                ddlSecurityQuestion1.DataTextField = "question";
                ddlSecurityQuestion1.DataValueField = "info_security_questions_key";
                ddlSecurityQuestion1.DataSource = dtsecurityquestions;
                ddlSecurityQuestion1.DataBind();

                ddlSecurityQuestion2.DataTextField = "question";
                ddlSecurityQuestion2.DataValueField = "info_security_questions_key";
                ddlSecurityQuestion2.DataSource = dtsecurityquestions;
                ddlSecurityQuestion2.DataBind();

                ddlSecurityQuestion3.DataTextField = "question";
                ddlSecurityQuestion3.DataValueField = "info_security_questions_key";
                ddlSecurityQuestion3.DataSource = dtsecurityquestions;
                ddlSecurityQuestion3.DataBind();
                
            }
            if (hduserkey.Value != "0")
            {
                user_key = Convert.ToInt32(hduserkey.Value);
            }
        }

        protected void btnContinue1_Click(object sender, EventArgs e)
        {
            //save to db
            DateTime dttemp = new DateTime(Convert.ToInt32(ddlbirthyear.SelectedValue),Convert.ToInt32(ddlbirthmonth.SelectedValue),Convert.ToInt32(ddlbirthday.SelectedValue));
            
            StoredProcedure sp_UpdateSignup1 = Peerfx_DB.SPs.UpdateUsers(0, ddlTitle.SelectedValue, txtfirstname.Text, txtmiddlename.Text, txtlastname.Text, dttemp, Convert.ToInt32(ddlcountryresidence.SelectedValue), txtemail.Text, HttpContext.Current.Request.UserHostAddress,0);
            sp_UpdateSignup1.Execute();
            int temp_user_key = Convert.ToInt32(sp_UpdateSignup1.Command.Parameters[9].ParameterValue.ToString());
            hduserkey.Value = temp_user_key.ToString();

            //mixpanel

            //send email            

            //go to next screen
            changetab(1);
        }

        protected void changetab(int selectedtab)
        {
            RadTabStrip1.Tabs[0].Enabled = false;
            RadTabStrip1.Tabs[1].Enabled = false;
            RadTabStrip1.Tabs[2].Enabled = false;
            RadTabStrip1.Tabs[3].Enabled = false;

            switch (selectedtab)
            {
                case 0: RadTabStrip1.Tabs[0].Enabled = true;
                    break;
                case 1: RadTabStrip1.Tabs[1].Enabled = true;
                    break;
                case 2: RadTabStrip1.Tabs[2].Enabled = true;
                    break;
                case 3: RadTabStrip1.Tabs[3].Enabled = true;
                    break;
            }
            RadTabStrip1.SelectedIndex = selectedtab;
            RadMultiPage1.SelectedIndex = selectedtab;
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            //go to previous screen
            changetab(0);
        }

        protected void btnContinue2_Click(object sender, EventArgs e)
        {            

            //save to db
            string strpassport = txtPassport1.Text + txtPassport2.Text + txtPassport3.Text + txtPassport4.Text + txtPassport5.Text + txtPassport6.Text + txtPassport7.Text + txtPassport8.Text + txtPassport9;
            int phonecountrycode2 = 0;
            if (ddlPhoneCountryCode2.SelectedIndex > -1)
            {
                phonecountrycode2 = Convert.ToInt32(ddlPhoneCountryCode2.SelectedValue);
            }
            int phonetype2 = 0;
            if (ddlPhoneType2.SelectedIndex > -1)
            {
                phonetype2 = Convert.ToInt32(ddlPhoneType2.SelectedValue);
            }

            Peerfx_DB.SPs.UpdateUsersInfo(user_key, txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtState.Text, Convert.ToInt32(ddlCountrytab2.SelectedValue), txtpostalzipcode.Text, Convert.ToInt32(ddlPhoneCountryCode1.SelectedValue), Convert.ToInt32(ddlPhoneType1.SelectedValue), txtPhone1.Text, phonecountrycode2, phonetype2, txtPhone2.Text, Convert.ToInt32(ddlIdentityNationality.SelectedValue), txtOccupation.Text, strpassport).Execute();
            
            //Check Passport info

            //mixpanel

            //send email            

            //go to next screen
            changetab(2);
        }

        protected void btnBack3_Click(object sender, EventArgs e)
        {
            //go to previous screen
            changetab(1);
        }

        protected void btnContinue3_Click(object sender, EventArgs e)
        {
            //check captcha
            RadCaptcha1.Validate();
            if (RadCaptcha1.IsValid)
            {
                //save to db
                Peerfx_DB.SPs.UpdateUsersSecurityAnswers(user_key, Convert.ToInt32(ddlSecurityQuestion1.SelectedValue), txtSecurityAnswer1.Text).Execute();
                Peerfx_DB.SPs.UpdateUsersSecurityAnswers(user_key, Convert.ToInt32(ddlSecurityQuestion2.SelectedValue), txtSecurityAnswer2.Text).Execute();
                Peerfx_DB.SPs.UpdateUsersSecurityAnswers(user_key, Convert.ToInt32(ddlSecurityQuestion3.SelectedValue), txtSecurityAnswer3.Text).Execute();

                Peerfx_DB.SPs.UpdateUsersInfoSignupTab3(user_key, txtUsername.Text, txtPassword.Text).Execute();

                //mixpanel

                //send email            

                //go to next screen
                changetab(3);

                //made it to confirmation screen
                DataTable dtuserinfo = Master.view_users_info_dt(user_key);
                lblemailaddress.Text = dtuserinfo.Rows[0]["email"].ToString();
                lblemailaddress2.Text = lblemailaddress.Text;
                lblclientnumber.Text = dtuserinfo.Rows[0]["user_key"].ToString();

                //send verification email
                External_APIs.SendGrid sg = new External_APIs.SendGrid();
                sg.Send_Email_Verification(user_key);
            }
            else
            {
            }
            
        }

        

    }
}