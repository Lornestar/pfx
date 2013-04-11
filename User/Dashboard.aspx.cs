using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;
using Telerik.Web.UI;
using System.Data;
using System.Xml.Linq;
using System.Net;
using System.IO;
using System.Collections;

namespace Peerfx.User
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(false);
            //currentuser = sitetemp.get_user_info(10);
            //HttpContext.Current.Session["currentuser"] = currentuser;
            if (!IsPostBack)
            {
                LoadCurrencyTable();
                LoadPaymentTable();
                lblusername.Text = currentuser.Full_name;
                lbluseremail.Text = currentuser.Email;                
                if (Request.QueryString["notification"] == "true")
                {
                    Master.NotificationShow("Your Payment went through.<br/><br/>You should receive an email with information about your Request.");
                }
                CheckVerifications();

                ddlcurrencyview.DataTextField = "info_currency_code";
                ddlcurrencyview.DataValueField = "info_currencies_key";
                ddlcurrencyview.DataSource = sitetemp.view_info_currencies_cansell();
                ddlcurrencyview.DataBind();

                if (currentuser.Default_currency > 0)
                {
                    ddlcurrencyview.SelectedValue = currentuser.Default_currency.ToString();
                }

                LoadNetBalance();
            }
            //insert profile img
            if (currentuser.Image_url != null)
            {
                Insertimgurl();
            }
            if (currentuser.Isverified)
            {
                imgverificationheader.ImageUrl = "/images/buttons/Verified_yes.png";
            }
            else if (currentuser.Verification_points > 0)
            {
                imgverificationheader.ImageUrl = "/images/buttons/Verified_middle.png";
            }
        }

        protected void LoadNetBalance()
        {
            int currency = Convert.ToInt32(ddlcurrencyview.SelectedValue);
            DataTable dttemp = Peerfx_DB.SPs.ViewUserNetBalance(currentuser.User_key, currency).GetDataSet().Tables[0];
            string strcurrency = sitetemp.GetCurrencySymbol(currency);
            string strcurrencycode = sitetemp.getcurrencycode(currency);
            decimal userbalance = 0;
            decimal userbalancefrozen = 0;
            decimal userpaymentpending = 0;
            if (dttemp.Rows[0]["userbalance"] != DBNull.Value){
                userbalance = Convert.ToDecimal(dttemp.Rows[0]["userbalance"]);
            }
            if (dttemp.Rows[0]["userbalancefrozen"] != DBNull.Value)
            {
                userbalancefrozen = Convert.ToDecimal(dttemp.Rows[0]["userbalancefrozen"]);
            }
            if (dttemp.Rows[0]["userpaymentpending"] != DBNull.Value)
            {
                userpaymentpending = Convert.ToDecimal(dttemp.Rows[0]["userpaymentpending"]);
            }

            lblnetbalance.Text = strcurrency + userbalance.ToString("F") + " " + strcurrencycode ;
            lblnetfrozenbalance.Text = "Net Frozen Balance = " + strcurrency + userbalancefrozen.ToString("F") + " " + strcurrencycode;
            lblnetpendingpayment.Text = "Net Pending Transfers = " + strcurrency + userpaymentpending.ToString("F") + " " + strcurrencycode;

            if (userbalancefrozen == 0)
            {
                lblnetfrozenbalance.Visible = false;
            }
            if (userpaymentpending == 0)
            {
                lblnetpendingpayment.Visible = false;
            }

            Peerfx_DB.SPs.UpdateUsersDefaultCurrency(currentuser.User_key, currency).Execute();
        }

        protected void CheckVerifications()
        {
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
                            imgVerificationEmail.Visible = true;
                        }
                        break;
                    case 2: if (verificationtemp.Isverified)
                        {
                            //passport verified
                            imgVerificationPassport.Visible = true;
                        }                            
                        break;
                    case 3: if (verificationtemp.Isverified)
                        {
                            //address verified
                            imgVerificationAddress.Visible = true;
                        }
                        break;
                }
            }
        }

        protected void Insertimgurl()
        {
            imguser.ImageUrl = currentuser.Image_url;
            imguser.Visible = true;
            imgNopic.Visible = false;
        }

        protected void LoadCurrencyTable()
        {
            userbalances1.LoadBalances(currentuser.User_key);
        }

        protected void LoadPaymentTable()
        {
            ucUserRecentPayment1.LoadPayments(currentuser.User_key);
        }


        protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            string file = Server.MapPath("/Files/UserImages/") + "\\" + currentuser.User_key.ToString() + ".jpg";
            if (currentuser.Image_url != null)
            {
                File.Delete(file);
            }

            byte[] imageData;
            using (Stream stream = e.File.InputStream)
            {
                imageData = new byte[stream.Length];
                stream.Read(imageData, 0, (int)stream.Length);
            }


            //save image
            
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

            currentuser = sitetemp.getcurrentuser(false);
            Insertimgurl();

            imguser.ImageUrl += "?r=" + DateTime.Now.TimeOfDay.ToString();
        }

        protected void ddlcurrencyview_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            LoadNetBalance();            
        }
               
    }
}