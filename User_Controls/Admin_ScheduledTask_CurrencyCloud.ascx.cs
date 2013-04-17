using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace Peerfx.User_Controls
{
    public partial class Admin_ScheduledTask_CurrencyCloud : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LastUpdated();
        }

        public void LastUpdated()
        {
            DataTable dttemp = Peerfx_DB.SPs.ViewScheduledTask(2).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0]["date_changed"] != DBNull.Value)
                {
                    lblrun1lasttime.Text = dttemp.Rows[0]["date_changed"].ToString();
                }
            }

            dttemp = Peerfx_DB.SPs.ViewScheduledTask(3).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0]["date_changed"] != DBNull.Value)
                {
                    lblrun2lasttime.Text = dttemp.Rows[0]["date_changed"].ToString();
                }
            }

            DataTable dttrades = Peerfx_DB.SPs.ViewCurrencyCloudTradesAwaitingSettlement(1).GetDataSet().Tables[0];
            lblpendingtrades1.Text = dttrades.Rows.Count.ToString();

            dttrades = Peerfx_DB.SPs.ViewCurrencyCloudTradesAwaitingSettlement(2).GetDataSet().Tables[0];
            lblpendingtrades2.Text = dttrades.Rows.Count.ToString();
        }

        protected void btndorun1_Click(object sender, EventArgs e)
        {
            ScheduledTasks.CurrencyCloud_Settlements ccs = new ScheduledTasks.CurrencyCloud_Settlements();
            ccs.dorun(1);
            LastUpdated();
        }

        protected void btndorun2_Click(object sender, EventArgs e)
        {
            ScheduledTasks.CurrencyCloud_Settlements ccs = new ScheduledTasks.CurrencyCloud_Settlements();
            ccs.dorun(2);
            LastUpdated();
        }
    }
}