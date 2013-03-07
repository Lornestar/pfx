using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peerfx.Testing
{
    public partial class Testhomesend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Peerfx.External_APIs.Homesend hs = new External_APIs.Homesend();
            hs.SendRemittance();
        }
    }
}