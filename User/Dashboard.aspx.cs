using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;

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
            }            
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

    }
}