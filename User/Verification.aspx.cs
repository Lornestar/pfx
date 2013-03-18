using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;

namespace Peerfx.User
{
    public partial class Verification : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(false);
            if (!IsPostBack)
            {
                ucVerification.LoadPage(currentuser);
            }            
        }
    }
}