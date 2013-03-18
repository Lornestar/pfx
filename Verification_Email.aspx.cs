using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;

namespace Peerfx
{
    public partial class Verification_Email : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Request.QueryString["code"] != null) && (Request.QueryString["code"] != ""))
            {
                //a code is present
                string code = Request.QueryString["code"].ToString();
                DataSet dstemp = Peerfx_DB.SPs.ViewUsersVerifiedByCodeNouserkey(code, 1).GetDataSet();
                if (dstemp.Tables[0].Rows.Count > 0)
                {
                    //code is correct
                    int user_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["user_key"]);
                    Site sitetemp = new Site();
                    Peerfx_DB.SPs.UpdateVerificationEmail(user_key, true, sitetemp.get_ipaddress(), code).Execute();

                    Users currentuser = sitetemp.get_user_info(user_key);
                    
                    lblverificationresposne.Text = "Thank you " + currentuser.Full_name + ", your email (" + currentuser.Email + ") has been verified. Your account is now Active.";

                    //For now change user's status to Active
                    Peerfx_DB.SPs.UpdateUsersStatus(user_key, 5).Execute();

                    //Send email to confirm validation
                    Peerfx.External_APIs.SendGrid se = new External_APIs.SendGrid();
                    se.Send_Email_Verification_Confirmed(user_key);
                }
            }
        }
    }
}