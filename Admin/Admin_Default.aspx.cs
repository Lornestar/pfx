using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;

namespace Peerfx.Admin
{
    public partial class Admin_Default : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(true);
            if (!IsPostBack)
            {
                LoadCurrencyTable();
            }
        }

        protected void LoadCurrencyTable()
        {
            RadListView1.DataSource = Peerfx_DB.SPs.ViewUserCurrencyListTreasury().GetDataSet().Tables[0];
            RadListView1.DataBind();
        }
    }
}