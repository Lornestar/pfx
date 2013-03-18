using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;

namespace Peerfx.User_Controls
{
    public partial class UserBalances : System.Web.UI.UserControl
    {        

        protected void Page_Load(object sender, EventArgs e)
        {            
        }


        public void LoadBalances(int userkey)
        {            
            RadListView1.DataSource = Peerfx_DB.SPs.ViewUserCurrencyList(userkey).GetDataSet().Tables[0];
            RadListView1.DataBind();
        }
    }
}