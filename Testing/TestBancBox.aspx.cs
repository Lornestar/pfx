using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;

namespace Peerfx.Testing
{
    public partial class TestBancBox : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {
            Peerfx.External_APIs.BancBox bb = new External_APIs.BancBox();
            Peerfx.Models.Users user = sitetemp.get_user_info(21);
            //bb.Create_user_account(user);
            Peerfx.Models.Payment paymenttemp = sitetemp.getPayment(47);
            BankAccounts receiverbankaccount = sitetemp.getBankAccounts(0, paymenttemp.Payment_object_receiver);

            
            //bb.SendFunds(user.Bancbox_payment_object_key, receiverbankaccount.ABArouting, receiverbankaccount.Account_number, receiverbankaccount.First_name + " " + receiverbankaccount.Last_name, paymenttemp.Buy_amount,paymenttemp.Payment_description);
            //bb.CollectFunds(user.Bancbox_payment_object_key, receiverbankaccount.ABArouting, receiverbankaccount.Account_number, receiverbankaccount.First_name + " " + receiverbankaccount.Last_name, paymenttemp.Buy_amount);
            //bb.TransferFunds(10, 21, Convert.ToDecimal(5.00));
            bb.SendFunds_Internal(10, 21, Convert.ToDecimal(5),"testing internal", false);
        }
    }
}