using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;

namespace Peerfx.ScheduledTasks
{
    public partial class PollEmbeeTransStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dttemp = Peerfx_DB.SPs.ViewEmbeeObjectsCurrentlyProcessing().GetDataSet().Tables[0];
            foreach (DataRow dr in dttemp.Rows)
            {
                if (dr["transid"] != DBNull.Value){
                    string transid = dr["transid"].ToString();
                    Peerfx.External_APIs.Embee em = new Peerfx.External_APIs.Embee();
                    EmbeeObject embeeobject = em.GetStatus(transid);

                    Peerfx.Site sitetemp = new Peerfx.Site();
                    int paymentkey = sitetemp.getPaymentKey_fromEmbeetransid(Convert.ToInt32(transid));
                    embeeobject.Payment_key = paymentkey;
                    if (embeeobject.Transstatus == 2)
                    {
                        //complete transaction
                        Peerfx_DB.SPs.UpdateEmbeeObjectsIpn(Convert.ToInt32(transid), embeeobject.Message, 2).Execute();
                        Peerfx_DB.SPs.UpdatePaymentStatus(paymentkey, 5).Execute();

                        //email to say top up was sent                    
                        Peerfx.External_APIs.SendGrid sg = new Peerfx.External_APIs.SendGrid();
                        sg.Send_Email_Payment_Completed_Embee(paymentkey);
                    }
                    else if (embeeobject.Transstatus == -1)
                    {
                        //cancel transaction
                        Peerfx_DB.SPs.UpdateEmbeeObjectsIpn(Convert.ToInt32(transid), embeeobject.Message, 3).Execute();
                        Peerfx_DB.SPs.UpdatePaymentStatus(paymentkey, 7).Execute();
                    }
                }                
            }

        }
    }
}