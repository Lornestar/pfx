using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Peerfx.Models;

namespace Peerfx.User_Controls
{
    public partial class Payment_Details : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadInfo(int paymentkey)
        {
            //Load payment info

            Payment paymenttemp = sitetemp.getPayment(paymentkey);

            int sellcurrency = paymenttemp.Sell_currency;
            int buycurrency = paymenttemp.Buy_currency;
            string Sellfull = paymenttemp.Txt_Sell_full;
            string Buyfull = paymenttemp.Txt_Buy_full;
            string rate = paymenttemp.Rate.ToString();
            string service_fee = sitetemp.GetCurrencySymbol(buycurrency) + " " + paymenttemp.Service_fee.ToString("F") + " " + sitetemp.getcurrencycode(buycurrency);
            if (paymenttemp.Actual_txt_Sell_full != null){
                Sellfull = paymenttemp.Actual_txt_Sell_full;
                Buyfull = paymenttemp.Actual_txt_Buy_full;
                rate = paymenttemp.Actual_rate.ToString();
                service_fee = sitetemp.GetCurrencySymbol(buycurrency) + " " + paymenttemp.Actual_service_fee.ToString("F") + " " + sitetemp.getcurrencycode(buycurrency);
            }

            Users user_sender = sitetemp.get_user_info(paymenttemp.Requestor_user_key);

            lblconfirmquotesendamount.Text = Sellfull;
            lblconfirmquotereceiveamount.Text = Buyfull;
            lblconfirmquoteyouget.Text = Buyfull;
            lblconfirmquoteexchangerate.Text = rate;
            lblconfirmquoteservicefee.Text = service_fee;

            lblsenderfullname.Text = user_sender.Full_name;
            /*
            lblconfirmsenderfullname.Text = user_sender.Full_name;
            //lblconfirmsenderdob.Text = user_sender.Dob.ToString("
            lblconfirmsenderaddress.Text = user_sender.Address1;
            lblconfirmsendercity.Text = user_sender.City;
            lblconfirmsenderpostalcode.Text = user_sender.Postalcode;
            lblconfirmsenderstate.Text = user_sender.State;
            lblconfirmsendercountry.Text = sitetemp.getcountrytext(user_sender.Country);
            lblconfirmsenderemail.Text = user_sender.Email;
            lblconfirmsenderphone.Text = user_sender.Phonenumber1;
            */

            //Check the type of payment
            bool receiverbankaccount = true;
            if (paymenttemp.Payment_object_receiver_type == 1) //going to bank account
            {
                lblType.Text = "To Bank Account";
                BankAccounts bank_receiver = sitetemp.getBankAccounts(0,paymenttemp.Payment_object_receiver);
                lblconfirmreceiverfullname.Text = bank_receiver.First_name + " " + bank_receiver.Last_name;

                if (bank_receiver.Currency_key == 3)//USD account
                {
                    lblconfirmreceiverABArouting.Text = bank_receiver.ABArouting;
                    pnlconfirmreceiverABArouting.Visible = true;
                    pnlconfirmreceiverBankCode.Visible = false;
                    pnlconfirmreceiverIBAN.Visible = false;
                }
                else
                {
                    lblconfirmreceiverIBAN.Text = bank_receiver.IBAN;
                }
                pnlconfirmreceiverAccount.Visible = true;
                lblconfirmreceiverAccount.Text = bank_receiver.Account_number;
                lblconfirmreceiverBankCode.Text = bank_receiver.BIC;
            }
            else if (paymenttemp.Payment_object_receiver_type == 3) //going to user balance
            {
                lblType.Text = "To User Balance";
                receiverbankaccount = false;
                Users user_receiver = sitetemp.get_user_from_paymentobject(paymenttemp.Payment_object_receiver);
                lblreceivinguserbalance.Text = sitetemp.getcurrencycode(buycurrency) + " User Balance: " + user_receiver.Email + " (" + user_receiver.Full_name + ")";
            }
            else if (paymenttemp.Payment_object_receiver_type == 7) //Embee top up
            {
                lblType.Text = "To Phone Top Up";
                receiverbankaccount = false;
                EmbeeObject embee = sitetemp.getEmbeeObject(paymentkey);
                lblreceivinguserbalance.Text = embee.Productname;
            }

            if (!receiverbankaccount)
            {
                pnlreceivinguserbalance.Visible = true;
                pnlreceivingbankaccount.Visible = false;
            }

            lblFundingSource.Text = "Bank Account";
            if (paymenttemp.Payment_object_sender != 0)
            {
                if (sitetemp.IsBankAccount(paymenttemp.Payment_object_sender))
                {
                    lblFundingSource.Text = "Bank Account";
                    lblBankDetails.Text = sitetemp.getBankAccountDescription(paymenttemp.Payment_object_sender);
                }
                else if (sitetemp.IsUserBalance(paymenttemp.Payment_object_sender))
                {
                    lblFundingSource.Text = sitetemp.getcurrencycode(sellcurrency) + " User Balance: " + user_sender.Email + " (" + user_sender.Full_name + ")";
                }
            }            

            
            /*
            bool receiverbankaccount = true;
            if (ddlReceivers.SelectedValue != "0")
            {
                if (ddlReceivers.SelectedValue == "-1")
                {
                    //selected other passport user
                    lblreceivinguserbalance.Text = ddlotherpassportusers.Text;
                    receiverbankaccount = false;
                }
                else if (ddlReceivers.SelectedValue == "-2")
                {
                    //selected embee top up
                    lblreceivinguserbalance.Text = ddlembeecatalog.SelectedItem.Text;
                    receiverbankaccount = false;
                }
                else
                {
                    if (ddlReceivers.SelectedValue != "")
                    {
                        if (sitetemp.IsUserBalance(Convert.ToInt64(ddlReceivers.SelectedValue)))
                        {
                            //it's a user balance, get user balance info
                            lblreceivinguserbalance.Text = ddlReceivers.SelectedItem.Text;
                            receiverbankaccount = false;
                        }
                    }
                }

                if (!receiverbankaccount)
                {
                    pnlreceivinguserbalance.Visible = true;
                    pnlreceivingbankaccount.Visible = false;
                }
            }*/

            lblconfirmreceiverdescription.Text = paymenttemp.Payment_description;
            //lblconfirmreceiveremail.Text = txtemailreceiver.Text;
            lblCreatedDate.Text = paymenttemp.Date_created.ToString();
            lblStatus.Text = paymenttemp.Payment_status_text;
        }
    }
}