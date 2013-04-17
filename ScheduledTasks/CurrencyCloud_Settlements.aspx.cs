using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peerfx.ScheduledTasks
{
    public partial class CurrencyCloud_Settlements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int cutoff = 1;
            if ((Request.QueryString["cutoff"] != null) && (Request.QueryString["cutoff"] != ""))
            {
                cutoff = Convert.ToInt32(Request.QueryString["cutoff"]);
            }


            dorun(cutoff);
        }

        public void dorun(int cutoff){
            External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();

            string strsettlementid;
            //Create the Settlement
            strsettlementid = cc.Settlement_Create();

            //Add each transaction
            cc.Settlement_AddTrades(strsettlementid, cutoff);

            //Release the batch
            Boolean releasesuccess = cc.Settlement_Release(strsettlementid);

            if (releasesuccess)
            {
                if (cutoff == 1)
                {
                    Peerfx_DB.SPs.UpdateScheduledTask(2).Execute();
                }
                else
                {
                    Peerfx_DB.SPs.UpdateScheduledTask(3).Execute();
                }
            }      
        }
        
    }
}