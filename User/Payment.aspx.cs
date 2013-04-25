using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;
using System.Data;

namespace Peerfx.User
{
    public partial class Payment : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;
        int paymentkey = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["paymentkey"] != null) && (Request.QueryString["paymentkey"] != ""))
            {
                paymentkey = Convert.ToInt32(Request.QueryString["paymentkey"]);
            }

            currentuser = sitetemp.getcurrentuser(false);
            if (!IsPostBack)
            {
                if (paymentkey != 0)
                {
                    Paymentdetails.LoadInfo(paymentkey,currentuser.User_key);
                }                
            }

        }

        protected void LoadInfo()
        {
            
        }

    }
}