using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;

namespace Peerfx.User_Controls
{
    public partial class BankAccountEntry : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            if (!IsPostBack)
            {
                ddlcurrency.DataTextField = "info_currency_code";
                ddlcurrency.DataValueField = "info_currencies_key";
                ddlcurrency.DataSource = sitetemp.view_info_currencies_canbuy();
                ddlcurrency.DataBind();
            }
        }

        public void UpdateRequiredFields()
        {
            CloseAllPanels();
            int currency = Convert.ToInt32(ddlcurrency.SelectedValue);
            if (sitetemp.getCurrency_Allowlocalbankaccount(currency))
            {//Local payment
                DataTable dttemp = sitetemp.getBankAccount_RequiredFields(currency);

                foreach (DataRow dr in dttemp.Rows)
                {
                    switch (dr["bank_account_field_type"].ToString())
                    {
                        case "3":
                            pnlABArouting.Visible = true;
                            break;
                        case "1":
                            pnlAccountNumber.Visible = true;
                            break;
                        case "2":
                            //GBP sort code
                            pnlSortCode.Visible = true;
                            break;
                        case "4"://IBAN
                            pnlIBAN.Visible = true;
                            break;
                        case "5": //BIC swift
                            pnlBankCode.Visible = true;
                            break;
                        case "6":
                            pnlbsb.Visible = true;
                            break;
                        case "7":
                            pnlnzdaccount.Visible = true;
                            break;
                    }
                }
            }
            else
            {//International swift payment
                pnlBankCode.Visible = true;
                pnlAccountNumber.Visible = true;
            }
        }

        private void CloseAllPanels()
        {
            pnlIBAN.Visible = false;
            pnlBankCode.Visible = false;
            pnlABArouting.Visible = false;
            pnlAccountNumber.Visible = false;
            pnlSortCode.Visible = false;
            pnlbsb.Visible = false;
            pnlnzdaccount.Visible = false;
        }

        public void LoadFields(BankAccounts ba)
        {            

            CloseAllPanels();
            if (ba.Currency_key != 0)
            {
                ddlcurrency.SelectedValue = ba.Currency_key.ToString();
                lblcurrencylabels.Text += " " + sitetemp.getcurrencycode(ba.Currency_key);
            }
            UpdateRequiredFields();

            if (ba.First_name != null)
            {
                txtfirstname.Text = ba.First_name;
                lblfullname.Text = ba.First_name;
            }
            if (ba.Last_name != null)
            {
                txtlastname.Text = ba.Last_name;
                lblfullname.Text += " " + ba.Last_name;
            }
            if (ba.Account_number != null)
            {
                if (ba.Currency_key == 5) //NZD
                {
                    if (ba.Account_number.Length >= 2)
                    {
                        txtnzdaccount1.Text = ba.Account_number.Substring(0, 2);
                        lblnzdaccount.Text = ba.Account_number;
                    }
                    if (ba.Account_number.Length >= 6)
                    {
                        txtnzdaccount2.Text = ba.Account_number.Substring(2, 4);
                    }
                    if (ba.Account_number.Length >= 13)
                    {
                        txtnzdaccount3.Text = ba.Account_number.Substring(6, 7);
                    }
                    if (ba.Account_number.Length >= 16)
                    {
                        txtnzdaccount4.Text = ba.Account_number.Substring(13, 3);
                    }                                        
                    
                }
                else
                {
                    txtaccountnumber.Text = ba.Account_number;
                    lblaccountnumber.Text = ba.Account_number;
                }                
            }
            if (ba.IBAN != null)
            {
                txtIbanAccount.Text = ba.IBAN;
                lblIbanAccount.Text = ba.IBAN;
            }
            if (ba.BIC != null)
            {
                txtBankCode.Text = ba.BIC;
                lblBankCode.Text = ba.BIC;
            }
            if (ba.ABArouting != null)
            {
                txtABArouting.Text = ba.ABArouting;
                lblABArouting.Text = ba.ABArouting;
            }            
            if (ba.Sortcode != null)
            {
                if (ba.Sortcode.Length >= 2)
                {
                    txtsortcode1.Text = ba.Sortcode.Substring(0, 2);
                }
                if (ba.Sortcode.Length >= 4)
                {
                    txtsortcode2.Text = ba.Sortcode.Substring(2, 2);
                }
                if (ba.Sortcode.Length >= 6)
                {
                    txtsortcode3.Text = ba.Sortcode.Substring(4, 2);
                }
                lblsortcode.Text = ba.Sortcode;
            }
            if (ba.BSB != null)
            {
                txtbsb.Text = ba.BSB;
                lblbsb.Text = ba.BSB;
            }
            if (ba.Email != null)
            {
                txtemailreceiver.Text = ba.Email;
                lblemailreceiver.Text = ba.Email;
            }
        }

        public void ViewasLabels()
        {
            txtABArouting.Visible = false;
            txtaccountnumber.Visible = false;
            txtBankCode.Visible = false;
            txtbsb.Visible = false;
            txtemailreceiver.Visible = false;
            txtfirstname.Visible = false;
            txtIbanAccount.Visible = false;
            txtlastname.Visible = false;
            txtnzdaccount1.Visible = false;
            txtnzdaccount2.Visible = false;
            txtnzdaccount3.Visible = false;
            txtnzdaccount4.Visible = false;
            txtsortcode1.Visible = false;
            txtsortcode2.Visible = false;
            txtsortcode3.Visible = false;
            ddlcurrency.Visible = false;
            lblABArouting.Visible = true;
            lblaccountnumber.Visible = true;
            lblBankCode.Visible = true;
            lblbsb.Visible = true;
            lblcurrency.Visible = true;
            lblemailreceiver.Visible = true;
            lblfullname.Visible = true;
            lblIbanAccount.Visible = true;
            lblnzdaccount.Visible = true;
            lblsortcode.Visible = true;
            lblcurrency.Visible = false;
            lblcurrencylabels.Visible = true;
        }

        public BankAccounts gettxtfields()
        {
            BankAccounts ba = new BankAccounts();

            ba.First_name = txtfirstname.Text;
            ba.Last_name = txtlastname.Text;
            ba.BIC = txtBankCode.Text;
            ba.Account_number = txtaccountnumber.Text;
            ba.ABArouting = txtABArouting.Text;
            ba.IBAN = txtIbanAccount.Text;
            ba.Sortcode = getSortCode();
            ba.BSB = txtbsb.Text;
            ba.Email = txtemailreceiver.Text;
            ba.Currency_key = Convert.ToInt32(ddlcurrency.SelectedValue);
            if (ba.Currency_key == 5)
            {
                ba.Account_number = txtnzdaccount1.Text + txtnzdaccount2.Text + txtnzdaccount3.Text + txtnzdaccount4.Text;
            }

            return ba;
        }

        public void hidecurrency()
        {
            ddlcurrency.Visible = false;
            lblcurrency.Visible = false;
        }

        public void updatecurrency(int currency)
        {
            ddlcurrency.SelectedValue = currency.ToString();
            UpdateRequiredFields();
        }

        protected void ddlcurrency_changed(object sender, EventArgs e)
        {
            resetaddnew();
            UpdateRequiredFields();
        }

        protected string getSortCode()
        {
            return txtsortcode1.Text + txtsortcode2.Text + txtsortcode3.Text;
        }

        public void resetaddnew()
        {
            pnlIBAN.Visible = true;
            pnlBankCode.Visible = true;
            pnlAccountNumber.Visible = false;
            pnlABArouting.Visible = false;
            pnlbsb.Visible = false;
            pnlnzdaccount.Visible = false;
            txtIbanAccount.Text = "";
            txtBankCode.Text = "";
            txtABArouting.Text = "";
            txtaccountnumber.Text = "";
            txtsortcode1.Text = "";
            txtsortcode2.Text = "";
            txtsortcode3.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtbsb.Text = "";
            txtnzdaccount1.Text = "";
            txtnzdaccount2.Text = "";
            txtnzdaccount3.Text = "";
            txtnzdaccount4.Text = "";
        }

        public Boolean ValidateBankAccount()
        {
            //Validate the bank account with CurrencyCloud
            External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
            string strfullname = txtfirstname.Text + " " + txtlastname.Text;
            Boolean bankaccountisvalid = false;            

            if (sitetemp.isValidateBankAccount(Convert.ToInt32(ddlcurrency.SelectedValue)))
            {
                lblerror.Visible = false;
                string strreturn = cc.Validate_BankAccount(Convert.ToInt32(ddlcurrency.SelectedValue), strfullname, txtABArouting.Text, txtaccountnumber.Text, "", "", txtBankCode.Text, "", txtbsb.Text, txtIbanAccount.Text, getSortCode());
                if (strreturn == "true"){
                    bankaccountisvalid = true;
                }
            }
            else
            {
                bankaccountisvalid = true;                
            }

            if (!bankaccountisvalid)
            {
                lblerror.Visible = true;
            }
            lblerror.Text = "Please enter valid Bank Account info";
            if ((txtfirstname.Text.Length == 0) || (txtlastname.Text.Length == 0))
            {
                lblerror.Text = "Please enter the recipients Full Name";
                bankaccountisvalid = false;
            }
            
            if (!bankaccountisvalid)
            {/*
                switch (strreturn.Contains())
                {
                    case "BIC":
                }
              */
            }

            return bankaccountisvalid;
        }

        public Int64 InsertBankAccount(int userkey)
        {
            Int64 paymentobjectkey = sitetemp.insert_bank_account_returnpaymentobject(0, Convert.ToInt32(ddlcurrency.SelectedValue), 11, null, userkey, txtaccountnumber.Text, txtIbanAccount.Text, txtBankCode.Text, txtABArouting.Text, txtfirstname.Text, txtlastname.Text, null,getSortCode(),txtbsb.Text,txtemailreceiver.Text);
            return paymentobjectkey;
        }

        public void UpdateBankAccount(int bankaccountkey, int userkey)
        {
            Peerfx_DB.SPs.UpdateBankAccounts(bankaccountkey, null, Convert.ToInt32(ddlcurrency.SelectedValue), null, null, userkey, sitetemp.get_ipaddress(), txtaccountnumber.Text, txtIbanAccount.Text, txtBankCode.Text, txtABArouting.Text, txtfirstname.Text, txtlastname.Text, null, 0,getSortCode(),txtbsb.Text,txtemailreceiver.Text).Execute();
        }

    }
}