using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peerfx
{
    public partial class _Default : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sitetemp.isloggedin())
                {
                    //if logged in redirect to dashboard
                    Response.Redirect("/User/Dashboard.aspx");
                }
            }
        }

        protected void btnsignup_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signup.aspx");
        }
    }
}