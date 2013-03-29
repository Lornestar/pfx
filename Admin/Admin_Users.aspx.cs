using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;
using Telerik.Web.UI;
using System.Collections;

namespace Peerfx.Admin
{
    public partial class Admin_Users : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;
        string notavailable = "Not Available";

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(true);
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersAll().GetDataSet();
            RadGrid1.DataSource = dstemp.Tables[0];
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {            
            if (e.CommandName == "Details")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int userkey = Convert.ToInt32(item["user_key"].Text);
                LoadUserProfile(userkey);
                RadTabStrip1.SelectedIndex = 1;
                RadMultiPage1.SelectedIndex = 1;                
                userbalances1.LoadBalances(userkey);
                ucUserRecentPayment1.LoadPayments(userkey);
            }
        }

        protected void LoadUserProfile(int userkey)
        {
            Users currentuser = sitetemp.get_user_info(userkey);
            lblname.Text = currentuser.Full_name;
            lblemail.Text = currentuser.Email;
            lblaccountstatus.Text = currentuser.User_status_text;
            imguser.ImageUrl = currentuser.Image_url;

            //Load Passport files
            ViewUploadedPics1.LoadPics("/Files/Verification/ID/" + userkey.ToString());
            ViewUploadedPics2.LoadPics("/Files/Verification/Address/" + userkey.ToString());

            RadListView1.DataSource = Peerfx_DB.SPs.ViewVerificationMethods().GetDataSet().Tables[0];
            RadListView1.DataBind();

            lblpoints.Text = currentuser.Verification_points.ToString();
            if (currentuser.Passportnumber != null)
            {
                lblpassportnumber.Text = currentuser.Passportnumber;
            }
            else
            {
                lblpassportnumber.Text = notavailable;
            }

            lbladdress1.Text = currentuser.Address1;
            lbladdress2.Text = currentuser.Address2;
            lblcity.Text = currentuser.City;
            lblstate.Text = currentuser.State;
            lblpostalcode.Text = currentuser.Postalcode;
            if (currentuser.Country != 0){
                lblcountry.Text = sitetemp.getcountrytext(currentuser.Country);
            }            

            hduserkey.Value = userkey.ToString();
            RadListView1.Rebind();

            //Load fb info
            Users_Facebook fbuser = sitetemp.get_user_Facebook(userkey);
            if (fbuser.fb_uid > 0)
            {
                lblfbemail.Text = fbuser.fb_email;
                lblfbfriendscount.Text = fbuser.fb_friends_count.ToString();
                lblfbfullname.Text = fbuser.fb_first_name + " " + fbuser.fb_last_name;
                if (fbuser.fb_ismale)
                {
                    lblfbgender.Text = "Male";
                }
                else
                {
                    lblfbgender.Text = "Female";
                }
                lblfblocation.Text = fbuser.fb_location;
                lblfbverified.Text = fbuser.fb_isverified.ToString();
            }
        }

        protected void RadListView1_Databound(object sender, RadListViewItemEventArgs e)
        {
            if ((e.Item.ItemType == RadListViewItemType.DataItem) || (e.Item.ItemType == RadListViewItemType.AlternatingItem))
            {
                DataTable dttemp = Peerfx_DB.SPs.ViewVerificationMethods().GetDataSet().Tables[0];
                Label lblmethod = (Label)e.Item.FindControl("lblmethodkey");                
                RadListViewDataItem lvdi = (RadListViewDataItem)e.Item;
                Verification verification = sitetemp.view_users_verified(Convert.ToInt32(hduserkey.Value), Convert.ToInt32(dttemp.Rows[lvdi.DataItemIndex]["verification_method_key"]));
                RadButton btnvalid = (RadButton)e.Item.FindControl("btnvalid");
                RadButton btnreject = (RadButton)e.Item.FindControl("btnreject");

                if (verification.Isverified)
                {
                    RadBinaryImage img = (RadBinaryImage)e.Item.FindControl("imgstatus");
                    img.ImageUrl = "/images/checkmark.png";

                    btnvalid.Enabled = false;
                    btnreject.Enabled = true;
                }

            }

        }

        protected void RadListView1_ItemCommand(object source, RadListViewCommandEventArgs e)
        {
            if (e.CommandName == "Validate")
            {
                DataTable dttemp = Peerfx_DB.SPs.ViewVerificationMethods().GetDataSet().Tables[0];
                RadListViewDataItem lvdi = (RadListViewDataItem)e.ListViewItem;
                Peerfx_DB.SPs.UpdateVerification(Convert.ToInt32(hduserkey.Value), Convert.ToInt32(dttemp.Rows[lvdi.DataItemIndex]["verification_method_key"]), true, sitetemp.get_ipaddress(), null).Execute();
                LoadUserProfile(Convert.ToInt32(hduserkey.Value));
            }
            else if (e.CommandName == "Reject")
            {
                DataTable dttemp = Peerfx_DB.SPs.ViewVerificationMethods().GetDataSet().Tables[0];
                RadListViewDataItem lvdi = (RadListViewDataItem)e.ListViewItem;
                Peerfx_DB.SPs.UpdateVerification(Convert.ToInt32(hduserkey.Value), Convert.ToInt32(dttemp.Rows[lvdi.DataItemIndex]["verification_method_key"]), false, sitetemp.get_ipaddress(), null).Execute();
                LoadUserProfile(Convert.ToInt32(hduserkey.Value));
            }
        }

    }
}