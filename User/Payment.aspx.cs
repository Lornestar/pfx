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
                LoadInfo();
            }

        }

        protected void LoadInfo()
        {
            Peerfx.Models.Payment paymenttemp = sitetemp.getPayment(paymentkey);
            int sellcurrency = 0;
            int buycurrency = 0;
            decimal sellamount = 0;
            decimal buyamount = 0;
            
            lblto.Text = paymenttemp.Receiver_name;
            lblfrom.Text = paymenttemp.Sender_name;
            sellcurrency = paymenttemp.Sell_currency;
            buycurrency = paymenttemp.Buy_currency;                
            sellamount = paymenttemp.Sell_amount;
            buyamount = paymenttemp.Buy_amount;
            lblreceiveraccount.Text = sitetemp.getBankAccountDescription(paymenttemp.Payment_object_receiver);
            lblstatus.Text = paymenttemp.Payment_description;                
                    
            if (paymenttemp.Payment_status == 2)
            {
                //Show instructions -- it's been confirmed
                pnlinstructions.Visible = true;
                lblalreadyconfirmedquotesenderamount2.Text = sitetemp.GetCurrencySymbol(sellcurrency) + sellamount.ToString("F");

                //figure out which bank account to receive payment
                DataSet dstempbankaccount = Peerfx_DB.SPs.ViewAdminBankAccountCurrencyExchange(sellcurrency, currentuser.Country_residence).GetDataSet();
                lblalreadyconfirmedpeerfxbankaccount.Text = sitetemp.getBankAccountDescription(Convert.ToInt64(dstempbankaccount.Tables[0].Rows[0]["payment_object_key"]));
            }                

                lblpaymentnum.Text = paymentkey.ToString();
                lblsenderamount.Text = sitetemp.GetCurrencySymbol(sellcurrency) + sellamount.ToString("F");
                lblreceiveramount.Text = sitetemp.GetCurrencySymbol(buycurrency) + buyamount.ToString("F");
                      
        }

    }
}