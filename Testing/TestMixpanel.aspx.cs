using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Peerfx.Testing
{
    public partial class TestMixpanel : System.Web.UI.Page
    {
        string token;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btntest_Click(object sender, EventArgs e)
        {
            System.Collections.Hashtable hstemp = new System.Collections.Hashtable();
            hstemp.Add("testingproperty", "5464");

            External_APIs.Mixpanel mx = new External_APIs.Mixpanel();
            mx.TrackEvent("Testing", 10,hstemp);
        }
    }
}