using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Peerfx.Testing
{
    public partial class TestEmbee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Peerfx.External_APIs.Embee embee = new External_APIs.Embee();
            //Hashtable strtest = embee.getCatalog("USA");
            embee.UpdateCatalog();
            //embee.RequestPurchase("2538", "1338863322", "1338863322@yahoo.com", "1.1.1.1");
            //string strresult = embee.GetStatus("16522740");
        }
    }
}