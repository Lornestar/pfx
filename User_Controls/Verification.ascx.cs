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
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    case 2: break;
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
                            imgfbbutton.Visible = false;
                            btnFacebook.Visible = true;
                            btnFacebook.Enabled = false;
                            btnFacebook.Text = "Verification Complete";
                        }
                        break;
                }
            }
            
            //ddlcountry
            ddlcountryphone.DataTextField = "Country_Text";
            ddlcountryphone.DataValueField = "info_country_key";
            ddlcountryphone.DataSource = Peerfx_DB.SPs.ViewInfoCountries().GetDataSet();
            ddlcountryphone.DataBind();
        }

        protected void btnemail_Click(object sender, EventArgs e)
        {
            int user_key = Convert.ToInt32(hduserkey.Value);
            //send verification email
            External_APIs.SendGrid sg = new External_APIs.SendGrid();
            sg.Send_Email_Verification(user_key);
        }

        protected void btnaddress_Click(object sender, EventArgs e)
        {

        }

        protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            UploadFiles("Verification/ID",e);
        }

        protected void AsyncUpload2_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            UploadFiles("Verification/Address", e);
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

            string file = folder + "\\" + e.File.FileName;
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
        }

        protected void btnpassportopen_Click(object sender, EventArgs e)
        {
            pnlpassport.Visible = true;
        }

        protected void btnpassportnext_Click(object sender, EventArgs e)
        {
            pnlPassportPhoto.Visible = true;
        }

        protected void btnaddressnext_Click(object sender, EventArgs e)
        {
            pnladdress.Visible = true;
        }

        protected void btnaddressnext2_Click(object sender, EventArgs e)
        {
            pnladdressimage.Visible = true;
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
            }
            else
            {
                lblphoneerror2.Text = "Incorrect code";
            }

        }


    }
}