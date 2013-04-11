using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peerfx.User_Controls
{
    public partial class Footer : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sitetemp.isloggedin())
            {
                ucLogin.Visible = false;
            }
            else
            {
                NavigationLinks.Visible = false;
            }
        }
    }
}