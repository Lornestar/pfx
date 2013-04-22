using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peerfx.User
{
    public partial class Deposit : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Models.Users currentuser = new Models.Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(false);
            if (!IsPostBack)
            {
                ddlcurrency.DataTextField = "info_currency_code";
                ddlcurrency.DataValueField = "info_currencies_key";
                ddlcurrency.DataSource = sitetemp.view_info_currencies_cannhold();
                ddlcurrency.DataBind();
            }
        }

        protected void ddlcurrency_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            pnlinstructions.Visible = true;
            DepositInstructions1.LoadInfo(currentuser.User_key, Convert.ToInt32(ddlcurrency.SelectedValue));
            DepositInstructions1.LoadReference("U" + currentuser.Account_number);
        }
    }
}