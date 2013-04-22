using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Peerfx.User_Controls
{
    public partial class CurrencyCloud_PaymentDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadInfo(string ccpaymentid)
        {
            lblclientcost.Text = "";
            lblcurrency.Text = "";
            lbldealref.Text = "";
            lblpaymentid.Text = "";
            lblpaymentreference.Text = "";
            lblpaymenttype.Text = "";
            lblreason.Text = "";
            lblstatus.Text = "";
            lbltransfereddate.Text = "";

            if (ccpaymentid != null)
            {
                if (ccpaymentid != "")
                {
                    External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
                    Hashtable hstemp = cc.getPaymentDetails(ccpaymentid);

                    if (hstemp.Count > 0)
                    {
                        if (hstemp["client_cost"] != null)
                        {
                            lblclientcost.Text = hstemp["client_cost"].ToString();
                        }
                        
                        lblcurrency.Text = hstemp["ccy"].ToString();
                        lbldealref.Text = hstemp["deal_ref"].ToString();
                        lblpaymentid.Text = ccpaymentid;
                        lblpaymentreference.Text = hstemp["payment_reference"].ToString();
                        lblpaymenttype.Text = hstemp["payment_type"].ToString();
                        if (hstemp["reason"] != null)
                        {
                            lblreason.Text = hstemp["reason"].ToString();
                        }                        
                        lblstatus.Text = hstemp["status"].ToString();
                        if (hstemp["transferred_at"] != null)
                        {
                            lbltransfereddate.Text = hstemp["transferred_at"].ToString();
                        }                        
                    }

                }
            }
        }
    }
}