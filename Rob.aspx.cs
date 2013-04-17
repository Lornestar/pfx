using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;
using System.Data;
using Telerik.Web.UI;
using SubSonic;

namespace Peerfx
{
    public partial class Rob : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //load countries into ddlembeecountry
                ddlembeecountry.DataTextField = "country_text";
                ddlembeecountry.DataValueField = "country";
                ddlembeecountry.DataSource = Peerfx_DB.SPs.ViewEmbeeCountries().GetDataSet().Tables[0];
                ddlembeecountry.DataBind();                
            }            
        }

        protected void ddlembeecountry_changed(object sender, EventArgs e)
        {
            ddlembeecatalog.ClearSelection();
            ddlembeecatalog.DataTextField = "product_name";
            ddlembeecatalog.DataValueField = "product_id";
            ddlembeecatalog.DataSource = Peerfx_DB.SPs.ViewEmbeeCatalogBycountry(Convert.ToInt32(ddlembeecountry.SelectedValue)).GetDataSet().Tables[0];
            ddlembeecatalog.DataBind();
            ddlembeecatalog.Visible = true;
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (txtpin.Text != "1806")
            {
                lblresult.Text = "Wrong PIN";
            }
            else if(ddlembeecatalog.SelectedValue == "") {
                lblresult.Text = "No Top Up selected";
            }
            else{
                Int64 receiverpaymentobject = 0;
                Int64 senderpaymentobject = 0;

                Users currentuser = sitetemp.get_user_info(21);
                //top up embee
                //1st step record the embee payment object
                string strphone = txtembeephone.Text;
                strphone = strphone.Replace("-", "").Replace(" ", "");
                while (strphone.Substring(0, 1) == "0")
                {
                    strphone = strphone.Substring(1, strphone.Length - 1);
                }

                StoredProcedure sp_UpdateEmbeeObject = Peerfx_DB.SPs.UpdateEmbeeCatalogRecordpaymentobject(Convert.ToInt32(ddlembeecatalog.SelectedValue), strphone, 0);
                sp_UpdateEmbeeObject.Execute();
                receiverpaymentobject = Convert.ToInt64(sp_UpdateEmbeeObject.Command.Parameters[2].ParameterValue.ToString());

                senderpaymentobject = 72; //Rob's User Balance
                int quote_key = 55; //Quote key from Rob's previous top up

                StoredProcedure sp_UpdatePayments = Peerfx_DB.SPs.UpdatePayments(0, quote_key, 0, 0, currentuser.User_key, "Top up from Rob's Phone", senderpaymentobject, receiverpaymentobject);
                sp_UpdatePayments.Execute();
                int payment_key = Convert.ToInt32(sp_UpdatePayments.Command.Parameters[3].ParameterValue.ToString());
                //update payment status to confirmed
                Peerfx_DB.SPs.UpdatePaymentStatus(payment_key, 2).Execute();
                Peerfx_DB.SPs.UpdatePaymentTreasury(payment_key, 1).Execute();

                //calculate proper amounts
                int productid = Convert.ToInt32(ddlembeecatalog.SelectedValue);
                decimal price = 0;
                DataTable dttemp = Peerfx_DB.SPs.ViewEmbeeCatalogByproductid(productid).GetDataSet().Tables[0];
                if (dttemp.Rows.Count > 0)
                {
                    price = Convert.ToDecimal(dttemp.Rows[0]["price_in_dollars"]);
                }

                //send money from user balance to payment object
                Int64 userbalance_payment_object_key = sitetemp.getpaymentobject_UserBalance(currentuser.User_key, 3);
                Int64 payment_payment_object_key = sitetemp.getpaymentobject(6, payment_key);
                Peerfx_DB.SPs.UpdateTransactionsInternal(0, 2, 3, price, userbalance_payment_object_key, payment_payment_object_key, sitetemp.get_ipaddress(), currentuser.User_key, "user balance to payment", 0, 1, payment_key).Execute();

                //instantly convert the payment, because source funding is balance
                //initiate conversion
                sitetemp.payment_initiate(payment_key);

                lblresult.Text = "Top Up Sent";
            }
        }
        
    }
}