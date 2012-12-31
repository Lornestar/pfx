using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;

namespace Peerfx.Admin
{
    public partial class Admin_Users : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(true);
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersAll().GetDataSet();
            RadGrid1.DataSource = dstemp.Tables[0];
        }
    }
}