using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peerfx.User_Controls
{
    public partial class UserRecentPayments : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadPayments(int userkey)
        {
            RadListView2.DataSource = Peerfx_DB.SPs.ViewPaymentsRequestedbyuser(userkey).GetDataSet().Tables[0];
            RadListView2.DataBind();
        }

    }
}