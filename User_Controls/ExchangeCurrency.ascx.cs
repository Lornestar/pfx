using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Peerfx.Models;
using System.Configuration;

namespace Peerfx.User_Controls
{
    public partial class ExchangeCurrency : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Load Currency dropdowns

                ddlsellcurrency.DataTextField = "info_currency_code";
                ddlsellcurrency.DataValueField = "info_currencies_key";
                ddlsellcurrency.DataSource = sitetemp.view_info_currencies_cansell();
                ddlsellcurrency.DataBind();

                ddlbuycurrency.DataTextField = "info_currency_code";
                ddlbuycurrency.DataValueField = "info_currencies_key";
                ddlbuycurrency.DataSource = sitetemp.view_info_currencies_canbuy();
                ddlbuycurrency.DataBind();

                ddlsellcurrency.SelectedIndex = 1;

                LoadRates();
            }
        }

        protected void btnExchange_Click(object sender, EventArgs e)
        {
            string payamount = txtsell.Text;
            string paycurrency = ddlsellcurrency.SelectedValue;
            string buycurrency = ddlbuycurrency.SelectedValue;
            
            Response.Redirect(ConfigurationSettings.AppSettings["Root_url"].ToString() + "ExchangeCurrency.aspx?sell=" + payamount + "&sellc=" + paycurrency + "&buyc=" + buycurrency);
        }

        protected void txtsell_TextChanged(object sender, EventArgs e)
        {
            LoadRates();
        }
               
        protected void ddlsellcurrency_changed(object sender, EventArgs e)
        {
            if (ddlsellcurrency.SelectedValue == ddlbuycurrency.SelectedValue)
            {
                if (ddlbuycurrency.SelectedIndex != 0)
                {
                    ddlbuycurrency.SelectedIndex = 0;
                }
                else
                {
                    ddlbuycurrency.SelectedIndex = 1;
                }
            }
            LoadRates();
        }

        protected void ddlbuycurrency_changed(object sender, EventArgs e)
        {
            if (ddlsellcurrency.SelectedValue == ddlbuycurrency.SelectedValue)
            {
                if (ddlsellcurrency.SelectedIndex != 0)
                {
                    ddlsellcurrency.SelectedIndex = 0;
                }
                else
                {
                    ddlsellcurrency.SelectedIndex = 1;
                }
            }
            LoadRates();
        }

        protected void LoadRates()
        {            

            Quote quotetemp = sitetemp.getQuote(Convert.ToDecimal(txtsell.Text), Convert.ToInt32(ddlsellcurrency.SelectedValue), Convert.ToInt32(ddlbuycurrency.SelectedValue));

            hdbuyrate.Value = quotetemp.Peerfx_Rate.ToString();
            hdbuycurrencysymbol.Value = sitetemp.GetCurrencySymbol(ddlbuycurrency.SelectedItem.Text) + " ";
            hdservicefee.Value = quotetemp.Peerfx_Servicefee.ToString("F");
            hdbuyamount.Value = quotetemp.Buyamount.ToString("F");

            lblrate.Text = hdbuyrate.Value;
            lblservicefee.Text = hdbuycurrencysymbol.Value + hdservicefee.Value;
            lblyouget.Text = hdbuycurrencysymbol.Value + hdbuyamount.Value;
            txtbuy.Value = Convert.ToDouble(quotetemp.Buyamount);
        }

    }
}