using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Peerfx.User_Controls
{
    public partial class CurrencyCloud_TradeDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadInfo(string cctradeid)
        {
            if (cctradeid != null)
            {
                if (cctradeid != "")
                {
                    External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
                    Hashtable hstemp = cc.getTradeDetails(cctradeid);

                    if (hstemp.Count > 0)
                    {
                        lblbuyamount.Text = hstemp["client_buy_amt"].ToString();
                        lblbuycurrency.Text = hstemp["client_buy_ccy"].ToString();
                        lblclientrate.Text = hstemp["client_invr"].ToString();
                        if (hstemp["delivery_date"] != null)
                        {
                            lbldeliverydate.Text = hstemp["delivery_date"].ToString();
                        }
                        lblmarketrate.Text = hstemp["fxc_market_rate"].ToString();
                        lblsellamount.Text = hstemp["client_sell_amt"].ToString();
                        lblsellcurrency.Text = hstemp["client_sell_ccy"].ToString();
                        if ((hstemp["settlement_date"] != null) && (hstemp["settlement_time"] != null))
                        {
                            lblsettlementdate.Text = hstemp["settlement_date"].ToString() + " " + hstemp["settlement_time"].ToString();
                        }
                        lblstatus.Text = hstemp["status"].ToString();
                        if ((hstemp["traded_at_date"] != null) && (hstemp["traded_at_time"] != null))
                        {
                            lbltradeddate.Text = hstemp["traded_at_date"].ToString() + " " + hstemp["traded_at_time"].ToString();
                        }
                        lbltradeid.Text = cctradeid;
                    }
                }
            }            
        }

    }
}