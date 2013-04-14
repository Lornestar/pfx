using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peerfx.Testing
{
    public partial class TestCurrencyCloud_RequiredFields : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlcurrency.DataTextField = "info_currency_code";
                ddlcurrency.DataValueField = "info_currencies_key";
                ddlcurrency.DataSource = sitetemp.view_info_currencies_canbuy();
                ddlcurrency.DataBind();                
                
                ddlcountry.DataTextField = "Country_Text";
                ddlcountry.DataValueField = "info_country_key";
                ddlcountry.DataSource = Peerfx_DB.SPs.ViewInfoCountries().GetDataSet().Tables[0];
                ddlcountry.DataBind();                
            }
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            Checkccrequiredfields();
        }

        protected void ddlcurrency_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int countrykey = sitetemp.getCountryKeyFromCurrency(Convert.ToInt32(ddlcurrency.SelectedValue));
            ddlcountry.SelectedValue = countrykey.ToString();
            Checkccrequiredfields();
        }

        protected void Checkccrequiredfields()
        {
            External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
            lblccresult.Text = cc.RequiredFields_BankAccounts_rawresponse(Convert.ToInt32(ddlcurrency.SelectedValue), Convert.ToInt32(ddlcountry.SelectedValue));
        }

    }
}