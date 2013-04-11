using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace Peerfx.ScheduledTasks
{
    public partial class UpdateCurrencyCloudRates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            Peerfx.External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
            DataTable dttemp = Peerfx_DB.SPs.ViewInfoFeeTypesAll().GetDataSet().Tables[0];
            Hashtable hstemp = new Hashtable();
            foreach (DataRow dr in dttemp.Rows){
                int currency1 = Convert.ToInt32(dr["currency1"]);
                int currency2 = Convert.ToInt32(dr["currency2"]);
                hstemp = cc.Exchange_Rate_ccy_pair(currency1, currency2);
                if (!hstemp.ContainsValue("error"))
                {
                    decimal rate = Convert.ToDecimal(hstemp["market_price"]);
                    Peerfx_DB.SPs.UpdateInfoFeeTypesExchangeRate(currency1, currency2, rate).Execute();
                }
            }

            
        }
    }
}