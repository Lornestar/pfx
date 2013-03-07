using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Peerfx.Admin
{
    public partial class Admin_Scheduled_Tasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LastUpdated();
            }
        }

        protected void btnEmbeeCatalog_Click(object sender, EventArgs e)
        {
            Peerfx.External_APIs.Embee embee = new External_APIs.Embee();
            embee.UpdateCatalog();

            LastUpdated();
        }

        protected void LastUpdated()
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