using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace Peerfx.Admin
{
    public partial class Admin_Scheduled_Tasks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
        {
            switch (RadTabStrip1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
            }
        }
        
    }
}