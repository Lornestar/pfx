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


namespace Peerfx.User
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(false);
            if (!IsPostBack)
            {
                LoadCurrencyTable();
                LoadPaymentTable();
                lblusername.Text = currentuser.Full_name;
                lbluseremail.Text = currentuser.Email;
                lblaccountstatus.Text = currentuser.User_status_text;
                if (Request.QueryString["notification"] == "true")
                {
                    RadNotification1.Show();
                }
                
            }
            //insert profile img
            if (currentuser.Image_url != null)
            {
                Insertimgurl();
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
            RadListView1.DataSource = Peerfx_DB.SPs.ViewUserCurrencyList(currentuser.User_key).GetDataSet().Tables[0];
            RadListView1.DataBind();
        }

        protected void LoadPaymentTable()
        {
            RadListView2.DataSource = Peerfx_DB.SPs.ViewPaymentsRequestedbyuser(currentuser.User_key).GetDataSet().Tables[0];
            RadListView2.DataBind();
        }

        protected void RadListView1_PageIndexChanged(object sender, RadListViewPageChangedEventArgs e)
        {
            RadListView2.DataSource = Peerfx_DB.SPs.ViewPaymentsRequestedbyuser(currentuser.User_key).GetDataSet().Tables[0];
            RadListView2.DataBind();
        }

        protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            string file = Server.MapPath("/Files/UserImages/") + "\\" + currentuser.User_key.ToString() + ".jpg";
            if (currentuser.Image_url.Length > 0)
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
        }
               
    }
}