using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peerfx.Admin
{
    public partial class Admin_CurrencyCloud : System.Web.UI.Page
    {
        Models.Users currentuser;
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(true);
        }
    }
}