using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Peerfx
{
    public partial class TestCurrencyCloud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
           Hashtable hstemp = cc.Exchange_Rate_ccy_pair(2,1);
        }
    }
}