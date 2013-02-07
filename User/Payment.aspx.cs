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
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentSpecific(paymentkey).GetDataSet();
            int sellcurrency = 0;
            int buycurrency = 0;
            decimal sellamount = 0;
            decimal buyamount = 0;
            if (dstemp.Tables[0].Rows.Count>0){
                if (dstemp.Tables[0].Rows[0]["receiver_name"] !=DBNull.Value){
                    lblto.Text = dstemp.Tables[0].Rows[0]["receiver_name"].ToString();
                }
                if (dstemp.Tables[0].Rows[0]["sender_name"] != DBNull.Value){
                    lblfrom.Text = dstemp.Tables[0].Rows[0]["sender_name"].ToString();
                }
                if (dstemp.Tables[0].Rows[0]["sell_currency"] != DBNull.Value)
                {
                    sellcurrency = Convert.ToInt32(dstemp.Tables[0].Rows[0]["sell_currency"]);
                }
                if (dstemp.Tables[0].Rows[0]["buy_currency"] != DBNull.Value)
                {
                    buycurrency = Convert.ToInt32(dstemp.Tables[0].Rows[0]["buy_currency"]);
                }
                if (dstemp.Tables[0].Rows[0]["sell_amount"] != DBNull.Value)
                {
                    sellamount = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["sell_amount"]);
                }
                if (dstemp.Tables[0].Rows[0]["buy_amount"] != DBNull.Value)
                {
                    buyamount = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["buy_amount"]);
                }
                
                if (dstemp.Tables[0].Rows[0]["payment_object_receiver"] != DBNull.Value)
                {
                    lblreceiveraccount.Text = sitetemp.getBankAccountDescription(Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_receiver"]));
                }

                if (dstemp.Tables[0].Rows[0]["payment_status_description"] != DBNull.Value)
                {
                    lblstatus.Text = dstemp.Tables[0].Rows[0]["payment_status_description"].ToString();
                    if (Convert.ToInt32(dstemp.Tables[0].Rows[0]["payment_status"]) == 2)
                    {
                        //Show instructions -- it's been confirmed
                        pnlinstructions.Visible = true;
                        lblalreadyconfirmedquotesenderamount2.Text = sitetemp.GetCurrencySymbol(sellcurrency) + sellamount.ToString("F");

                        //figure out which bank account to receive payment
                        DataSet dstempbankaccount = Peerfx_DB.SPs.ViewAdminBankAccountCurrencyExchange(sellcurrency, currentuser.Country_residence).GetDataSet();
                        lblalreadyconfirmedpeerfxbankaccount.Text = sitetemp.getBankAccountDescription(Convert.ToInt64(dstempbankaccount.Tables[0].Rows[0]["payment_object_key"]));
                    }
                }

                lblpaymentnum.Text = paymentkey.ToString();
                lblsenderamount.Text = sitetemp.GetCurrencySymbol(sellcurrency) + sellamount.ToString("F");
                lblreceiveramount.Text = sitetemp.GetCurrencySymbol(buycurrency) + buyamount.ToString("F");
                                
            }            
        }

    }
}