using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;
using System.Collections;
using Telerik.Web.UI;
using System.Data;
using System.Xml.Linq;
using System.Net;
using System.IO;
using Peerfx.External_APIs;

namespace Peerfx.User_Controls
{
    public partial class Verification : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();
        string checkmarkurl = "/images/checkmark.png";
        Site currentsite;
        External_APIs.Mixpanel mx = new External_APIs.Mixpanel();            

        protected void Page_Load(object sender, EventArgs e)
        {
            currentsite = (Peerfx.Site) Page.Master;
        }

        public void LoadPage(Users currentuser){
            hduserkey.Value = currentuser.User_key.ToString(); ;
            Hashtable hsverifications = sitetemp.getusersverified(currentuser.User_key);
            foreach (DictionaryEntry entry in hsverifications)
            {
                Peerfx.Models.Verification verificationtemp = (Peerfx.Models.Verification)entry.Value;
                int methodkey = Convert.ToInt32(entry.Key);
                switch (methodkey)
                {
                    case 1: if (verificationtemp.Isverified)
                        {
                            //Email verified
                            imgvalid1.ImageUrl = checkmarkurl;
                            btnemail.Enabled = false;
                            btnemail.Text = "Verification Complete";
                        }
                        break;
                    case 2: if (verificationtemp.Isverified)
                        {
                            //Passport verified
                            imgvalid2.ImageUrl = checkmarkurl;
                            btnpassportopen.Enabled = false;
                            btnpassportopen.Text = "Verification Complete";
                        }                        
                        break;
                    case 3: if (verificationtemp.Isverified)
                        {
                            //Address verified
                            imgvalid3.ImageUrl = checkmarkurl;
                            btnopenaddress.Enabled = false;
                            btnopenaddress.Text = "Verification Complete";
                        }
                        break;
                    case 4: if (verificationtemp.Isverified)                        
                        {
                            //Phone verified
                            imgvalid4.ImageUrl = checkmarkurl;
                            btnphone.Enabled = false;
                            btnphone.Text = "Verification Complete";
                           
                        }
                        break;
                    case 5: if (verificationtemp.Isverified)
                        {
                            //fb verified
                            imgvalid5.ImageUrl = checkmarkurl;
                            imgfbbutton.Visible = false;
                            btnFacebook.Visible = true;
                            btnFacebook.Enabled = false;
                            btnFacebook.Text = "Verification Complete";

                            //check if need to upload fb image to user
                            string file = Server.MapPath("/Files/UserImages/") + "\\" + currentuser.User_key.ToString() + ".jpg";
                            if (currentuser.Image_url == null)
                            {
                                Models.Users_Facebook fbuser = sitetemp.get_user_Facebook(currentuser.User_key);
                                string url = "https://graph.facebook.com/" + fbuser.fb_uid.ToString() + "/picture?type=large";
                                sitetemp.SaveImagefromInternet(file, url);
                            }
                        }
                        break;
                }
            }
            
            //ddlcountry
            DataTable dtcountries = Peerfx_DB.SPs.ViewInfoCountries().GetDataSet().Tables[0];

            ddlcountryphone.DataTextField = "Country_Text";
            ddlcountryphone.DataValueField = "info_country_key";
            ddlcountryphone.DataSource = dtcountries;
            ddlcountryphone.DataBind();

            ddlCountryAddress.DataTextField = "Country_Text";
            ddlCountryAddress.DataValueField = "info_country_key";
            ddlCountryAddress.DataSource = dtcountries;
            ddlCountryAddress.DataBind();

            //insert existing passport # if previously entered
            if (currentuser.Passportnumber != null)
            {
                txtPassport1.Text = currentuser.Passportnumber.Substring(0, 9);
                txtPassport2.Text = currentuser.Passportnumber.Substring(9, 1);
                txtPassport3.Text = currentuser.Passportnumber.Substring(10, 3);
                txtPassport4.Text = currentuser.Passportnumber.Substring(13, 7);
                txtPassport5.Text = currentuser.Passportnumber.Substring(20, 1);
                txtPassport6.Text = currentuser.Passportnumber.Substring(21, 7);
                //txtPassport7.Text = currentuser.Passportnumber.Substring(28, 14);
                txtPassport8.Text = currentuser.Passportnumber.Substring(42, 1);
                txtPassport9.Text = currentuser.Passportnumber.Substring(43, 1);
            }
            txtAddress1.Text = currentuser.Address1;
            txtAddress2.Text = currentuser.Address2;
            txtCity.Text = currentuser.City;
            txtState.Text = currentuser.State;
            txtpostalzipcode.Text = currentuser.Postalcode;
            if (currentuser.Country != 0)
            {
                ddlCountryAddress.SelectedValue = currentuser.Country.ToString();
            }
        }

        protected void btnemail_Click(object sender, EventArgs e)
        {
            int user_key = Convert.ToInt32(hduserkey.Value);
            //send verification email
            External_APIs.SendGrid sg = new External_APIs.SendGrid();
            sg.Send_Email_Verification(user_key);

            RadNotification1.Text = "A verification email has just been sent to your email address.";
            RadNotification1.Show();

            mx.TrackEvent("Verification - Email Initiated", Convert.ToInt32(hduserkey.Value), null);
        }

        protected void btnaddress_Click(object sender, EventArgs e)
        {

        }

        protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            UploadFiles("Verification/ID",e);
            ViewUploadedPics1.LoadPics("/Files/Verification/ID/" + hduserkey.Value);

            mx.TrackEvent("Verification - PassportID Image Added", Convert.ToInt32(hduserkey.Value), null);
        }

        protected void AsyncUpload2_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            UploadFiles("Verification/Address", e);
            ViewUploadedPics2.LoadPics("/Files/Verification/Address/" + hduserkey.Value);
            mx.TrackEvent("Verification - Address Image Added", Convert.ToInt32(hduserkey.Value), null);
        }

        protected void UploadFiles(string thisfolder, FileUploadedEventArgs e)
        {
            string folder = Server.MapPath("/Files/" + thisfolder + "/") + hduserkey.Value;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            byte[] imageData;
            using (Stream stream = e.File.InputStream)
            {
                imageData = new byte[stream.Length];
                stream.Read(imageData, 0, (int)stream.Length);
            }


            //save image

            string file = folder + "\\" + e.File.FileName.Replace(" ", "");
            //AsyncUpload1.UploadedFiles[0].SaveAs(file);

            string fullurl = Request.Url.AbsoluteUri;
            //string saveimgurl = //fullurl.Substring(0, fullurl.ToLower().IndexOf("order_form2.aspx")) + Thumbnail.ImageUrl.Replace("~/", "");

            //sitetemp.savepicurl2(saveimgurl, file);

            FileStream fs = new FileStream(file, FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
            try
            {
                w.Write(imageData);
            }
            finally
            {
                fs.Close();
                w.Close();
            }

            RadNotification1.Text = "Your files have been uploaded.<br/><br/> We will review your verification and notify you shortly on the status of it.";
            RadNotification1.Show();
            
        }

        protected void btnpassportopen_Click(object sender, EventArgs e)
        {
            pnlpassport.Visible = true;
        }

        protected void btnpassportnext_Click(object sender, EventArgs e)
        {
            if ((txtPassport1.Text.Length == txtPassport1.MaxLength) && (txtPassport2.Text.Length == txtPassport2.MaxLength) && (txtPassport3.Text.Length == txtPassport3.MaxLength) && (txtPassport4.Text.Length == txtPassport4.MaxLength) && (txtPassport5.Text.Length == txtPassport5.MaxLength) && (txtPassport6.Text.Length == txtPassport6.MaxLength) && (txtPassport8.Text.Length == txtPassport8.MaxLength))
            {
                //is valid
                lblpassporterror.Text = "";
                pnlPassportPhoto.Visible = true;

                string passportnumber = txtPassport1.Text + txtPassport2.Text + txtPassport3.Text + txtPassport4.Text + txtPassport5.Text + txtPassport6.Text + txtPassport7.Text + txtPassport8.Text + txtPassport9.Text;
                Peerfx_DB.SPs.UpdateUsersPassport(Convert.ToInt32(hduserkey.Value), passportnumber).Execute();
                //cross reference world check

                //Upload pics or Webcam

                //Show existing pics
                ViewUploadedPics1.LoadPics("/Files/Verification/ID/" + hduserkey.Value);

                mx.TrackEvent("Verification - PassportID Added", Convert.ToInt32(hduserkey.Value), null);
            }
            else
            {
                lblpassporterror.Text = "Please complete the entire Passport info";
            }
            
        }

        protected void btnaddressnext_Click(object sender, EventArgs e)
        {
            pnladdress.Visible = true;
        }

        protected void btnaddressnext2_Click(object sender, EventArgs e)
        {
            bool isvalid = false;
            if ((txtAddress1.Text.Length > 0) && (txtCity.Text.Length > 0) && (txtState.Text.Length > 0) && (txtpostalzipcode.Text.Length > 0) && (ddlCountryAddress.SelectedValue.Length > 0))
            {
                isvalid = true;
                Peerfx_DB.SPs.UpdateUsersAddress(Convert.ToInt32(hduserkey.Value), txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtState.Text, Convert.ToInt32(ddlCountryAddress.SelectedValue), txtpostalzipcode.Text).Execute();
                lbladdresserror.Text = "";
                pnladdressimage.Visible = true;

                ViewUploadedPics2.LoadPics("/Files/Verification/Address/" + hduserkey.Value);

                mx.TrackEvent("Verification - Address Added", Convert.ToInt32(hduserkey.Value), null);
            }
            else
            {
                lbladdresserror.Text = "Please fill in your address";
            }            
        }

        protected void btnFacebook_Click(object sender, EventArgs e)
        {

        }

        protected void btnphone_Click(object sender, EventArgs e)
        {
            pnlphonesendverification.Visible = true;
            pnlphoneverification.Visible = false;            
        }

        protected void btnphonesendverification_Click(object sender, EventArgs e)
        {
            if ((ddlcountryphone.SelectedValue != "") && (txtphonesendverfication.Text.Length > 5))
            {
                string strcode = sitetemp.GenerateCode_Numbersonly();
                Twilio twillio = new Twilio();
                string thebody = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/SMS/verification_sms.txt"));
                thebody = thebody.Replace("THECODE", strcode);
                twillio.SendSMS(txtphonesendverfication.Text, thebody, Convert.ToInt32(ddlcountryphone.SelectedValue));

                Peerfx_DB.SPs.UpdateUsersPhoneNumber(Convert.ToInt32(hduserkey.Value), txtphonesendverfication.Text).Execute();

                pnlphoneverification.Visible = true;
                Peerfx_DB.SPs.UpdateVerification(Convert.ToInt32(hduserkey.Value), 4, false, sitetemp.get_ipaddress(), strcode).Execute();

                RadNotification1.Text = "After you receive an sms in the next 30 seconds, enter the Passport account code, to complete Phone Verification.";
                RadNotification1.Show();

                mx.TrackEvent("Verification - Phone Initiated", Convert.ToInt32(hduserkey.Value), null);
            }
            else
            {
                lblphoneerror.Text = "Select a country and a valid phone number";
            }            
            
        }

        protected void btnPassport_Click(object sender, EventArgs e)
        {

        }

        protected void btnphonecode_Click(object sender, EventArgs e)
        {
            //Check if phone code was right
            DataTable dttemp = Peerfx_DB.SPs.ViewUsersVerifiedByCode(txtphonecode.Text, 4, Convert.ToInt32(hduserkey.Value)).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                //it exists, so correct code
                lblphoneerror2.Text = "Correct code.  Your phone has been connected";
                lblphoneerror2.ForeColor = System.Drawing.Color.Blue;
                Peerfx_DB.SPs.UpdateVerification(Convert.ToInt32(hduserkey.Value), 4, true, sitetemp.get_ipaddress(),txtphonecode.Text).Execute();

                sitetemp.VerificationReward(4, Convert.ToInt32(hduserkey.Value));
                mx.TrackEvent("Verification - Phone Connected", Convert.ToInt32(hduserkey.Value), null);

                Response.Redirect("/User/Verification.aspx");
            }
            else
            {
                lblphoneerror2.Text = "Incorrect code";
            }

        }


    }
}