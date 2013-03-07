using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;

namespace Peerfx.Embee
{
    public partial class EmbeeIPN : System.Web.UI.Page
    {
        string transid = "";
        string status = "";
        string message = "";
        Site sitetemp = new Site();

        protected void Page_Load(object sender, EventArgs e)
        {
            External_APIs.SendGrid sg = new External_APIs.SendGrid();
            

            if ((Request.QueryString["transid"] != null) && (Request.QueryString["transid"] != ""))
            {
                transid = Request.QueryString["transid"].ToString();
            }
            if ((Request.Form["transid"] != null) && (Request.Form["transid"] != ""))
            {
                transid = Request.Form["transid"].ToString();
            }
            if ((Request.QueryString["status"] != null) && (Request.QueryString["status"] != ""))
            {
                status = Request.QueryString["status"].ToString();
            }
            if ((Request.Form["status"] != null) && (Request.Form["status"] != ""))
            {
                status = Request.Form["status"].ToString();
            }
            if ((Request.QueryString["message"] != null) && (Request.QueryString["message"] != ""))
            {
                message = Request.QueryString["message"].ToString();
            }
            if ((Request.Form["message"] != null) && (Request.Form["message"] != ""))
            {
                message = Request.Form["message"].ToString();
            }

            sg.SimpleEmail("Lorne", "Passport PostBack", "lorne@lornestar.com", "", "Request Postback was pinged forms count =" + Request.Form.Count.ToString() + ", querystring count = " + Request.QueryString.Count.ToString() + ". transid = " + transid + "; message = " + message + "; status = " + status, "Request Postback");

          /*  if (transid != "")
            {
                int paymentkey = sitetemp.getPaymentKey_fromEmbeetransid(Convert.ToInt32(transid));
                EmbeeObject embeeobject = sitetemp.getEmbeeObject(paymentkey);

                //Process transaction
                if (status.Trim().ToUpper() == "COMPLETED")
                {
                    //complete transaction
                    Peerfx_DB.SPs.UpdateEmbeeObjectsIpn(Convert.ToInt32(transid), message, 2).Execute();
                    Peerfx_DB.SPs.UpdatePaymentStatus(paymentkey, 5).Execute();

                    //email to say top up was sent                    
                    sg.Send_Email_Payment_Completed_Embee(embeeobject);
                }
                else if (status.Trim().ToUpper() == "CANCELED")
                {
                    //cancel transaction
                    Peerfx_DB.SPs.UpdateEmbeeObjectsIpn(Convert.ToInt32(transid), message, 3).Execute();
                    Peerfx_DB.SPs.UpdatePaymentStatus(paymentkey, 7).Execute();

                    //email to say top up was cancelled
                }
            }*/

        }
    }
}