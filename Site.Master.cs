using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;

namespace Peerfx
{
    public partial class Site : System.Web.UI.MasterPage
    {        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Users getcurrentuser()
        {
            Users user = new Users();
            //Check if logged in
            if (HttpContext.Current.Session["currentuser"] != null)
            {
                //User logged in
                user = (Users)HttpContext.Current.Session["currentuser"];
            }
            else
            {
                //Redirect to login page
                Response.Redirect("Login.aspx");
            }
            return user;
        }

        public bool isloggedin()
        {
            bool isloggedin = false;

            if (HttpContext.Current.Session["currentuser"] != null)
            {
                isloggedin = true;
            }

            return isloggedin;
        }

        public DataTable populateyear()
        {
            DataTable dttemp = new DataTable();
            dttemp.Columns.Add("text", typeof(string));
            dttemp.Columns.Add("value", typeof(string));

            for (int i = 1994; i >= 1910; i--)
            {
                DataRow dr = dttemp.NewRow();
                dr["text"] = i.ToString();
                dr["value"] = i.ToString();
                dttemp.Rows.Add(dr);
            }

            return dttemp;
        }

        public DataTable populateday()
        {
            DataTable dttemp = new DataTable();
            dttemp.Columns.Add("text", typeof(string));
            dttemp.Columns.Add("value", typeof(string));

            for (int i = 1; i <= 31; i++)
            {
                DataRow dr = dttemp.NewRow();
                dr["text"] = i.ToString();
                dr["value"] = i.ToString();
                dttemp.Rows.Add(dr);
            }

            return dttemp;
        }

        public DataTable populatecountrylist()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCountryList().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable populatecountrycodelist()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCountryCodeList().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable populatephonetype()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoPhoneType().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable populatesecurityquestions()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoSecurityQuestions().GetDataSet();
            return dstemp.Tables[0];
        }

        public Users view_users_info(int userkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersInfo(userkey).GetDataSet();
            Users users = view_users_info_getdbinfo(dstemp);
            users.User_key = userkey;                                   
            return users;
        }

        public DataTable view_users_info_dt(int userkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersInfo(userkey).GetDataSet();            
            return dstemp.Tables[0];
        }

        public Users view_users_info_email(string useremail)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersEmail(useremail).GetDataSet();
            Users users = view_users_info_getdbinfo(dstemp);
            users.Email = useremail;
            return users;
        }

        private Users view_users_info_getdbinfo(DataSet dstemp)
        {
            Users users = new Users();
            users.User_key = 0;
            if (dstemp.Tables[0].Rows[0]["user_key"] != DBNull.Value)
            {
                users.User_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["user_key"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["account_number"] != DBNull.Value)
            {
                users.Account_number = dstemp.Tables[0].Rows[0]["account_number"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["title"] != DBNull.Value)
            {
                users.Title = dstemp.Tables[0].Rows[0]["title"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["first_name"] != DBNull.Value)
            {
                users.First_name = dstemp.Tables[0].Rows[0]["first_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["middle_name"] != DBNull.Value)
            {
                users.Middle_name = dstemp.Tables[0].Rows[0]["middle_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["last_name"] != DBNull.Value)
            {
                users.Last_name = dstemp.Tables[0].Rows[0]["last_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["dob"] != DBNull.Value)
            {
                users.Dob = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["dob"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["country_residence"] != DBNull.Value)
            {
                users.Country_residence = Convert.ToInt32(dstemp.Tables[0].Rows[0]["country_residence"].ToString());
            } if (dstemp.Tables[0].Rows[0]["email"] != DBNull.Value)
            {
                users.Email = dstemp.Tables[0].Rows[0]["email"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["ip_address"] != DBNull.Value)
            {
                users.Ip_address = dstemp.Tables[0].Rows[0]["ip_address"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["last_changed"] != DBNull.Value)
            {
                users.Last_changed = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["last_changed"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["signed_up"] != DBNull.Value)
            {
                users.Signed_up = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["signed_up"].ToString());
            } if (dstemp.Tables[0].Rows[0]["user_status"] != DBNull.Value)
            {
                users.User_status = Convert.ToInt32(dstemp.Tables[0].Rows[0]["user_status"].ToString());
            } if (dstemp.Tables[0].Rows[0]["isadmin"] != DBNull.Value)
            {
                users.Isadmin = Convert.ToBoolean(dstemp.Tables[0].Rows[0]["isadmin"].ToString());
            } if (dstemp.Tables[0].Rows[0]["address1"] != DBNull.Value)
            {
                users.Address1 = dstemp.Tables[0].Rows[0]["address1"].ToString();
            } if (dstemp.Tables[0].Rows[0]["address2"] != DBNull.Value)
            {
                users.Address2 = dstemp.Tables[0].Rows[0]["address2"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["city"] != DBNull.Value)
            {
                users.City = dstemp.Tables[0].Rows[0]["city"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["state"] != DBNull.Value)
            {
                users.State = dstemp.Tables[0].Rows[0]["state"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["country"] != DBNull.Value)
            {
                users.Country = Convert.ToInt32(dstemp.Tables[0].Rows[0]["country"].ToString());
            } if (dstemp.Tables[0].Rows[0]["postalcode"] != DBNull.Value)
            {
                users.Postalcode = dstemp.Tables[0].Rows[0]["postalcode"].ToString();
            } if (dstemp.Tables[0].Rows[0]["phonecountrycode1"] != DBNull.Value)
            {
                users.Phonecountrycode1 = dstemp.Tables[0].Rows[0]["phonecountrycode1"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["phonetype1"] != DBNull.Value)
            {
                users.Phonetype1 = Convert.ToInt32(dstemp.Tables[0].Rows[0]["phonetype1"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["phonenumber1"] != DBNull.Value)
            {
                users.Phonenumber1 = dstemp.Tables[0].Rows[0]["phonenumber1"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["phonecountrycode2"] != DBNull.Value)
            {
                users.Phonecountrycode2 = dstemp.Tables[0].Rows[0]["phonecountrycode2"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["phonetype2"] != DBNull.Value)
            {
                users.Phonetype2 = Convert.ToInt32(dstemp.Tables[0].Rows[0]["phonetype2"].ToString());
            } if (dstemp.Tables[0].Rows[0]["phonenumber2"] != DBNull.Value)
            {
                users.Phonenumber2 = dstemp.Tables[0].Rows[0]["phonenumber2"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["identitynationality"] != DBNull.Value)
            {
                users.Identitynationality = Convert.ToInt32(dstemp.Tables[0].Rows[0]["identitynationality"].ToString());
            }
            return users;
        }

        public DataTable view_info_banks()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoBanks().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_info_currencies()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrencies().GetDataSet();
            return dstemp.Tables[0];
        }

        public string get_ipaddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        public DataTable view_system_bank_accounts()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewSystemBankAccounts().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_users_all()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersAll().GetDataSet();
            return dstemp.Tables[0];
        }
    }
}