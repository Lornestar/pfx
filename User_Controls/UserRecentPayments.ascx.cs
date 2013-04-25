using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Peerfx.Models;
namespace Peerfx.User_Controls
{
    public partial class UserRecentPayments : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();
        Users currentuser = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadPayments(int userkey)
        {
            Type t = Page.Master.GetType();
            if (t.Name == "site_master")
            {
                Site currentsite = (Peerfx.Site)Page.Master;
                currentuser = currentsite.getcurrentuser(false);
            }            

            RadListView2.DataSource = Peerfx_DB.SPs.ViewPaymentsRequestedbyuser(userkey).GetDataSet().Tables[0];
            RadListView2.DataBind();
        }


      /*  protected void RadListView2_ItemDataBinding(object sender, RadListViewItemEventArgs e)
        {
            RadListViewDataItem bindingContainer = (RadListViewDataItem)(((Control)sender).BindingContainer);            
            
            if (e.Item is RadListViewDataItem)
            {
                RadListViewDataItem item = (RadListViewDataItem)e.Item;
                Label lbldatecreated = (Label)item.FindControl("lbldatecreated");
                string strtest = item.DataItem.ToString();
            }
        }*/

        protected void RadListView2_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            //default values
            if (e.Item is RadListViewDataItem)
            {                
                RadListViewDataItem item = (RadListViewDataItem)e.Item;
                Label lbldatecreated = (Label)item.FindControl("lbldatecreated");
                DateTime date_created = (DateTime)DataBinder.Eval(item.DataItem, "date_created");
                lbldatecreated.Text = date_created.AddHours(sitetemp.getTimezoneOffset(currentuser.Timezoneid)).ToString();
            }
        }        

    }
}