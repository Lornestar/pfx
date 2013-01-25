using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Peerfx.User_Controls
{
    public partial class UserInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Choose_User(int user_key)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersInfo(user_key).GetDataSet();
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                lblfirstname.Text = dstemp.Tables[0].Rows[0]["first_name"].ToString();
                lbllastname.Text = dstemp.Tables[0].Rows[0]["last_name"].ToString();
            }           

        }
    }
}