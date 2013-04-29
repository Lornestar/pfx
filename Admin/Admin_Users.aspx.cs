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
        External_APIs.Mixpanel mx = new External_APIs.Mixpanel();

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(true);
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersAll().GetDataSet();
            RadGrid1.DataSource = dstemp.Tables[0];
            if (!IsPostBack)
            {
                GridSortExpression expression = new GridSortExpression();
                expression.FieldName = "last_online";
                expression.SortOrder = GridSortOrder.Descending;
                RadGrid1.MasterTableView.SortExpressions.AddSortExpression(expression);
            }            
            //RadGrid1.MasterTableView.Rebind();
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
            if (currentuser.Signed_up != null)
            {
                lblaccountcreated.Text = currentuser.Signed_up.ToString();
            }
            if (currentuser.Last_online != null)
            {
                lblaccountlastlogin.Text = currentuser.Last_online.ToString();
            }            
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
                hypfb.NavigateUrl += fbuser.fb_uid.ToString();
                hypfb2.NavigateUrl = hypfb.NavigateUrl;
                imgfb.ImageUrl = "https://graph.facebook.com/" + fbuser.fb_uid.ToString() +"/picture?type=normal";
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
                int userkey = Convert.ToInt32(hduserkey.Value);
                int verificationmethod = Convert.ToInt32(dttemp.Rows[lvdi.DataItemIndex]["verification_method_key"]);
                Peerfx_DB.SPs.UpdateVerification(userkey, verificationmethod, true, sitetemp.get_ipaddress(), null).Execute();
                LoadUserProfile(Convert.ToInt32(hduserkey.Value));
                if ((verificationmethod == 2) || (verificationmethod == 3))
                {
                    External_APIs.SendGrid sg = new External_APIs.SendGrid();
                    sg.Send_Email_Verification_Approved(userkey, verificationmethod);

                    if (verificationmethod == 2)
                    {
                        mx.TrackEvent("Verification - Passport ID Confirmed", userkey, null);
                    }
                    else
                    {
                        mx.TrackEvent("Verification - Address Confirmed", userkey, null);
                    }
                }
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