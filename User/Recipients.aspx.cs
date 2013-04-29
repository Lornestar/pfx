using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;
using System.Collections;

namespace Peerfx.User
{
    public partial class Recipients : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;
        External_APIs.Mixpanel mx = new External_APIs.Mixpanel();

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(false);
            LoadListView();            
            if (!IsPostBack)
            {
                
            }
        }

        protected void LoadListView()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewRecipientsByuser(currentuser.User_key).GetDataSet();
            RadListView1.DataSource = dstemp.Tables[0];
            RadListView1.DataBind();
        }

        protected void btnaddrecipient_Click(object sender, EventArgs e)
        {
            //add new recipient
            pnladdnew.Visible = true;
            resetaddnew();
            BankAccountEntry1.resetname();
        }

        protected void resetaddnew()
        {
            BankAccountEntry1.resetaddnew();
            hdcurrentbankaccountkey.Value = "0";
        }

                        

        protected void btnsavechange_Click(object sender, EventArgs e)
        {
            Boolean bankaccountisvalid = BankAccountEntry1.ValidateBankAccount();
                           
            if (bankaccountisvalid)
            {                
                if (hdcurrentbankaccountkey.Value == "0")
                {
                    //insert new bank account                    
                    Int64 paymentobjectkey = BankAccountEntry1.InsertBankAccount(currentuser.User_key);
                    Peerfx_DB.SPs.UpdateRecipients(0, currentuser.User_key, paymentobjectkey).Execute();

                    mx.TrackEvent("Recipients - Added Recipient", currentuser.User_key, null);
                }
                else
                {
                    //update existing
                    int bankaccountkey = Convert.ToInt32(hdcurrentbankaccountkey.Value);
                    BankAccountEntry1.UpdateBankAccount(bankaccountkey, currentuser.User_key);
                    
                    mx.TrackEvent("Recipients - Updated Recipient", currentuser.User_key, null);
                }
                LoadListView();
                pnladdnew.Visible = false;
            }
          
        }
        

        protected void RadListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Hashtable values = new Hashtable();
            int selectedindex = RadListView1.SelectedItems[0].DataItemIndex;
            RadListView1.SelectedItems[0].ExtractValues(values);
            
            int bankaccountkey = Convert.ToInt32(values["bank_account_key"]);
            hdcurrentbankaccountkey.Value = bankaccountkey.ToString();
            
            //load entry fields with info
            BankAccounts ba = sitetemp.getBankAccounts(bankaccountkey, 0);
            BankAccountEntry1.LoadFields(ba);

            pnladdnew.Visible = true;
        }

        protected void editrow(string bankaccountkey)
        {
            //string strtemp = e.CommandArgument.ToString(); 
            pnladdnew.Visible = true;
        }    
        

    }
}