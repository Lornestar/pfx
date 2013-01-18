using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;
using System.Data;

namespace Peerfx
{
    public partial class ExchangeCurrency : System.Web.UI.Page
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

                DataTable dtcountries = sitetemp.populatecountrylist();

                ddlcountryresidence.DataTextField = "Country_Text";
                ddlcountryresidence.DataValueField = "info_country_key";
                ddlcountryresidence.DataSource = dtcountries;
                ddlcountryresidence.DataBind();

                if ((Request.QueryString["sell"] != null) && (Request.QueryString["sell"] != ""))
                {
                    txtsell.Text = Request.QueryString["sell"].ToString();
                    ddlsellcurrency.SelectedValue = Request.QueryString["sellc"].ToString();
                    ddlbuycurrency.SelectedValue = Request.QueryString["buyc"].ToString();
                }
            }
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

            if (ddlbuycurrency.SelectedItem.Text == "USD")
            {
                pnlIBAN.Visible = false;
                pnlBankCode.Visible = false;
                pnlABArouting.Visible = true;
                pnlAccountNumber.Visible = true;
            }
            else
            {
                pnlIBAN.Visible = true;
                pnlBankCode.Visible = true;
                pnlABArouting.Visible = false;
                pnlAccountNumber.Visible = false;
            }
        }

        protected void btnContinue1_Click(object sender, EventArgs e)
        {
            //check validation

            //Change tab & fill in tab2 with all the info
            changetab(1);
            updateconfirmationtab();
        }

        protected void btnContinue2_Click(object sender, EventArgs e)
        {
            //Confirming quote, create in database
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            changetab(0);
        }

        protected void updateconfirmationtab()
        {
            lblconfirmquotesendamount.Text = sitetemp.GetCurrencySymbol(ddlsellcurrency.SelectedItem.Text) + " " + txtsell.Text;
            lblconfirmquotereceiveamount.Text = sitetemp.GetCurrencySymbol(ddlbuycurrency.SelectedItem.Text) + " " + txtbuy.Text;
            lblconfirmquoteyouget.Text = lblconfirmquotereceiveamount.Text;
            lblconfirmquoteexchangerate.Text = lblrate.Text;
            lblconfirmquoteservicefee.Text = lblservicefee.Text;

            lblconfirmsenderfullname.Text = txtfirstnamesender.Text + " " + txtlastnamesender.Text;
            lblconfirmsenderdob.Text = txtbirthday.Text + "/" + txtbirthmonth.Text + "/" + txtbirthyear.Text;
            lblconfirmsenderaddress.Text = txtAddress1.Text;
            lblconfirmsendercity.Text = txtCity.Text;
            lblconfirmsenderpostalcode.Text = txtpostalzipcode.Text;
            lblconfirmsenderstate.Text = txtState.Text;
            lblconfirmsendercountry.Text = ddlcountryresidence.SelectedItem.Text;
            lblconfirmsenderemail.Text = txtemailsender.Text;
            lblconfirmsenderphone.Text = txtphone.Text;

            lblconfirmreceiverfullname.Text = txtfirstnamereceiver.Text + " " + txtlastnamereceiver.Text;
            lblconfirmreceiverIBAN.Text = txtIbanAccount.Text;
            lblconfirmreceiverABArouting.Text = txtABArouting.Text;
            lblconfirmreceiverAccount.Text = txtaccountnumber.Text;
            lblconfirmreceiverBankCode.Text = txtBankCode.Text;
            lblconfirmreceiverdescription.Text = txtdescription.Text;
            lblconfirmreceiveremail.Text = txtemailreceiver.Text;
        }

        protected void updatealreadyconfirmedtab()
        {
            //update tab info
            lblalreadyconfirmedfrom.Text = lblconfirmsenderfullname.Text;
            lblalreadyconfirmedto.Text = lblconfirmreceiverfullname.Text;
        }

        protected void changetab(int selectedtab)
        {
            RadTabStrip1.Tabs[0].Enabled = false;
            RadTabStrip1.Tabs[1].Enabled = false;
            RadTabStrip1.Tabs[2].Enabled = false;
            RadTabStrip1.Tabs[3].Enabled = false;

            switch (selectedtab)
            {
                case 0: RadTabStrip1.Tabs[0].Enabled = true;
                    break;
                case 1: RadTabStrip1.Tabs[1].Enabled = true;
                    break;
                case 2: RadTabStrip1.Tabs[2].Enabled = true;
                    break;
                case 3: RadTabStrip1.Tabs[3].Enabled = true;
                    break;
            }
            RadTabStrip1.SelectedIndex = selectedtab;
            RadMultiPage1.SelectedIndex = selectedtab;
        }
    }
}