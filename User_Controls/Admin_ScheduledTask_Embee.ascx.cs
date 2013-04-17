using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;

namespace Peerfx.User_Controls
{
    public partial class Admin_ScheduledTask_Embee : System.Web.UI.UserControl
    {
        Users currentuser = new Users();
        Site sitetemp = new Site();

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(true);
        }        

        protected void btnEmbeeCatalog_Click(object sender, EventArgs e)
        {
            Peerfx.External_APIs.Embee embee = new External_APIs.Embee();
            embee.UpdateCatalog();

            LastUpdated();
        }

        public void LastUpdated()
        {
            DataTable dttemp = Peerfx_DB.SPs.ViewScheduledTask(1).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0]["date_changed"] != DBNull.Value)
                {
                    lblEmbeeCatalogUpdated.Text = dttemp.Rows[0]["date_changed"].ToString();
                }
            }
        }
    }
}