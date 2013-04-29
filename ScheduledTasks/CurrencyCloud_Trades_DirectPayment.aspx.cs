using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peerfx.ScheduledTasks
{
    public partial class CurrencyCloud_Trades_DirectPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
            cc.CheckCC_Trades_DirectPayment();
        }
    }
}