using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;

namespace Peerfx.User_Controls
{
    public partial class Deposit_Instructions : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadInfo(int userkey, int currency)
        {
            Users treasury = sitetemp.get_treasury_account(1);

            Int64 adminpaymentobject = sitetemp.get_Payment_Object_sendmoneyto_For_Payment(treasury.User_key, currency);
            BankAccounts baadmin = sitetemp.getBankAccounts(0, adminpaymentobject);
            BankAccountEntry1.ViewasLabels();
            BankAccountEntry1.LoadFields(baadmin);
        }

        public void LoadReference(string reference)
        {
            pnlreference.Visible = true;
            lblreference.Text = reference;
        }
    }
}