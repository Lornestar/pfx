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
                }
            }
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
        }

        protected void btnPassport_Click(object sender, EventArgs e)
        {

        }


    }
}