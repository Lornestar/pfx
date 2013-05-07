using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web.Security;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using SubSonic;
using System.Net;

namespace Peerfx
{
    public partial class Site : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["msg"] != null)
                {
                    string msg = Request.QueryString["msg"].ToString();
                    NotificationShow(msg);
                }
            }

            if (isloggedin())
            {
                //logged in change navigation links
                pnlloggedin.Visible = true;
                pnlloggedout.Visible = false;
                hdbodyclass.Value = "2";
            }
        }

        public Users getcurrentuser(bool MustbeAdmin)
        {
            Users user = new Users();
            //Check if logged in
            if (HttpContext.Current.Session["currentuser"] != null)
            {
                //User logged in
                user = (Users)HttpContext.Current.Session["currentuser"];
                user = get_user_info(user.User_key);
                HttpContext.Current.Session["currentuser"] = user;
                if ((user.Isadmin == false) && (MustbeAdmin))
                {
                    //Redirect to login page
                    HttpContext.Current.Response.Redirect(ConfigurationSettings.AppSettings["Root_url"] + "Login.aspx");
                }
                Peerfx_DB.SPs.UpdateUsersLastOnline(user.User_key).Execute();
            }
            else
            {
                //Redirect to login page
                HttpContext.Current.Response.Redirect(ConfigurationSettings.AppSettings["Root_url"] + "Login.aspx");
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

        public Users get_user_info(int userkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersInfo(userkey).GetDataSet();
            Users users = view_users_info_getdbinfo(dstemp);
            users.User_key = userkey;                                   
            return users;
        }

        public Users get_user_from_paymentobject(Int64 paymentobjectkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersInfoUserBalancePaymentobjectkey(paymentobjectkey).GetDataSet();
            Users users = view_users_info_getdbinfo(dstemp);

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
            users.Bancbox_client_id = 0;
            users.Bancbox_payment_object_key = 0;
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
                users.Full_name = users.First_name;
            }
            if (dstemp.Tables[0].Rows[0]["middle_name"] != DBNull.Value)
            {
                users.Middle_name = dstemp.Tables[0].Rows[0]["middle_name"].ToString();
                users.Full_name += " " + users.Middle_name;
            }
            if (dstemp.Tables[0].Rows[0]["last_name"] != DBNull.Value)
            {
                users.Last_name = dstemp.Tables[0].Rows[0]["last_name"].ToString();
                users.Full_name += " " + users.Last_name;
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
            if (dstemp.Tables[0].Rows[0]["last_online"] != DBNull.Value)
            {
                users.Last_online = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["last_online"]);
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
            if (dstemp.Tables[0].Rows[0]["user_status_text"] != DBNull.Value)
            {
                users.User_status_text = dstemp.Tables[0].Rows[0]["user_status_text"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["ssn"] != DBNull.Value)
            {
                users.Ssn = dstemp.Tables[0].Rows[0]["ssn"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["passportnumber"] != DBNull.Value)
            {
                users.Passportnumber = dstemp.Tables[0].Rows[0]["passportnumber"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["bancbox_client_id"] != DBNull.Value)
            {
                users.Bancbox_client_id = Convert.ToInt32(dstemp.Tables[0].Rows[0]["bancbox_client_id"]);
            }
            if (dstemp.Tables[0].Rows[0]["bancbox_client_status"] != DBNull.Value)
            {
                users.Bancbox_client_status = dstemp.Tables[0].Rows[0]["bancbox_client_status"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["bancbox_cip_status"] != DBNull.Value)
            {
                users.Bancbox_cipstatus = dstemp.Tables[0].Rows[0]["bancbox_cip_status"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["bancbox_payment_object_key"] != DBNull.Value)
            {
                users.Bancbox_payment_object_key = Convert.ToInt64(dstemp.Tables[0].Rows[0]["bancbox_payment_object_key"]);
            }
            if (dstemp.Tables[0].Rows[0]["default_currency"] != DBNull.Value)
            {
                users.Default_currency = Convert.ToInt32(dstemp.Tables[0].Rows[0]["default_currency"]);
            }

            if (dstemp.Tables[0].Rows[0]["timezone"] != DBNull.Value)
            {
                users.Timezonekey = Convert.ToInt32(dstemp.Tables[0].Rows[0]["timezone"]);
            }
            else
            {
                users.Timezonekey = 2;
            }

            if (dstemp.Tables[0].Rows[0]["timezoneid"] != DBNull.Value)
            {
                users.Timezoneid = dstemp.Tables[0].Rows[0]["timezoneid"].ToString();
            }
            else
            {
                users.Timezoneid = "UTC";
            }

            //check if file exists
            string fullurl = HttpContext.Current.Server.MapPath("/Files/UserImages/") + "\\" + users.User_key.ToString() + ".jpg";
            if (File.Exists(fullurl))
            {
                users.Image_url = ConfigurationSettings.AppSettings["Root_url"].ToString()+ "Files/UserImages/" + users.User_key.ToString() + ".jpg";
            }
            users.Isverified = false;
            if (dstemp.Tables[0].Rows[0]["verification_points"] != DBNull.Value)
            {
                users.Verification_points = Convert.ToInt32(dstemp.Tables[0].Rows[0]["verification_points"]);
                if (users.Verification_points > 100)
                {
                    users.Isverified = true;
                }
            }

            if (dstemp.Tables[0].Rows[0]["referral"] != DBNull.Value)
            {
                users.Referral = dstemp.Tables[0].Rows[0]["referral"].ToString();
            }

            return users;
        }

        public Users_Facebook get_user_Facebook(int userkey)
        {
            Users_Facebook currentuser = new Users_Facebook();
            currentuser.User_key = userkey;
            currentuser.fb_uid = 0;
            DataTable dttemp = Peerfx_DB.SPs.ViewUserFacebook(userkey).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0]["fb_uid"] != DBNull.Value)
                {
                    currentuser.fb_uid = Convert.ToInt64(dttemp.Rows[0]["fb_uid"]);
                }
                if (dttemp.Rows[0]["fb_location"] != DBNull.Value)
                {
                    currentuser.fb_location = dttemp.Rows[0]["fb_location"].ToString();
                }
                if (dttemp.Rows[0]["fb_email"] != DBNull.Value)
                {
                    currentuser.fb_email = dttemp.Rows[0]["fb_email"].ToString();
                }
                if (dttemp.Rows[0]["fb_friends_count"] != DBNull.Value)
                {
                    currentuser.fb_friends_count = Convert.ToInt32(dttemp.Rows[0]["fb_friends_count"]);
                }
                if (dttemp.Rows[0]["fb_access_token"] != DBNull.Value)
                {
                    currentuser.fb_access_token = dttemp.Rows[0]["fb_access_token"].ToString();
                }
                if (dttemp.Rows[0]["date_created"] != DBNull.Value)
                {
                    currentuser.Date_created = Convert.ToDateTime(dttemp.Rows[0]["date_created"]);
                }
                if (dttemp.Rows[0]["last_changed"] != DBNull.Value)
                {
                    currentuser.Last_changed = Convert.ToDateTime(dttemp.Rows[0]["last_changed"]);
                }
                if (dttemp.Rows[0]["fb_ismale"] != DBNull.Value)
                {
                    currentuser.fb_ismale = Convert.ToBoolean(dttemp.Rows[0]["fb_ismale"]);
                }
                if (dttemp.Rows[0]["fb_first_name"] != DBNull.Value)
                {
                    currentuser.fb_first_name = dttemp.Rows[0]["fb_first_name"].ToString();
                }
                if (dttemp.Rows[0]["fb_last_name"] != DBNull.Value)
                {
                    currentuser.fb_last_name = dttemp.Rows[0]["fb_last_name"].ToString();
                }
                if (dttemp.Rows[0]["fb_isverified"] != DBNull.Value)
                {
                    currentuser.fb_isverified = Convert.ToBoolean(dttemp.Rows[0]["fb_isverified"]);
                }                
            }
            return currentuser;
        }

        public EmbeeObject getEmbeeObject(int paymentkey)
        {
            EmbeeObject embeetemp = new EmbeeObject();
            embeetemp.Payment_key = paymentkey;
            DataTable dttemp = Peerfx_DB.SPs.ViewEmbeeObjectsBypaymentkey(paymentkey).GetDataSet().Tables[0];
            if (dttemp.Rows[0]["embee_object_key"] != DBNull.Value)
            {
                embeetemp.Embee_object_key = Convert.ToInt32(dttemp.Rows[0]["embee_object_key"].ToString());
            }
            if (dttemp.Rows[0]["country"] != DBNull.Value)
            {
                embeetemp.Country = Convert.ToInt32(dttemp.Rows[0]["country"].ToString());
            }
            if (dttemp.Rows[0]["carrier"] != DBNull.Value)
            {
                embeetemp.Carrier = dttemp.Rows[0]["carrier"].ToString();
            }
            if (dttemp.Rows[0]["product_id"] != DBNull.Value)
            {
                embeetemp.Productid = Convert.ToInt32(dttemp.Rows[0]["product_id"].ToString());
            }
            if (dttemp.Rows[0]["product_name"] != DBNull.Value)
            {
                embeetemp.Productname = dttemp.Rows[0]["product_name"].ToString();
            }
            if (dttemp.Rows[0]["price_in_dollars"] != DBNull.Value)
            {
                embeetemp.Price = Convert.ToDecimal(dttemp.Rows[0]["price_in_dollars"].ToString());
            }
            if (dttemp.Rows[0]["transstatus"] != DBNull.Value)
            {
                embeetemp.Transstatus = Convert.ToInt32(dttemp.Rows[0]["transstatus"].ToString());
            }
            if (dttemp.Rows[0]["transid"] != DBNull.Value)
            {
                embeetemp.Transid = Convert.ToInt32(dttemp.Rows[0]["transid"].ToString());
            }
            if (dttemp.Rows[0]["date_created"] != DBNull.Value)
            {
                embeetemp.Date_created = Convert.ToDateTime(dttemp.Rows[0]["date_created"].ToString());
            }
            if (dttemp.Rows[0]["phonenumber"] != DBNull.Value)
            {
                embeetemp.Phone = dttemp.Rows[0]["phonenumber"].ToString();
            }
            if (dttemp.Rows[0]["message"] != DBNull.Value)
            {
                embeetemp.Message = dttemp.Rows[0]["message"].ToString();
            }
            if (dttemp.Rows[0]["date_processed"] != DBNull.Value)
            {
                embeetemp.Date_processed = Convert.ToDateTime(dttemp.Rows[0]["date_processed"].ToString());
            }            

            return embeetemp;
        }

        public int getPaymentKey_fromEmbeeobjectkey(int embee_object_key)
        {
            int payment_key = 0;
            //get paymentkey
            DataTable dttemppayment = Peerfx_DB.SPs.ViewPaymentSpecificByembeeobjectkey(embee_object_key).GetDataSet().Tables[0];
            if (dttemppayment.Rows.Count > 0)
            {
                if (dttemppayment.Rows[0]["payments_key"] != DBNull.Value)
                {
                    payment_key = Convert.ToInt32(dttemppayment.Rows[0]["payments_key"]);
                }
            }
            return payment_key;
        }

        public int getPaymentKey_fromEmbeetransid(int transid)
        {
            int payment_key = 0;
            //get paymentkey
            DataTable dttemppayment = Peerfx_DB.SPs.ViewPaymentSpecificByembeetransid(transid).GetDataSet().Tables[0];
            if (dttemppayment.Rows.Count > 0)
            {
                if (dttemppayment.Rows[0]["payments_key"] != DBNull.Value)
                {
                    payment_key = Convert.ToInt32(dttemppayment.Rows[0]["payments_key"]);
                }
            }
            return payment_key;
        }

        public Payment getPayment(int paymentkey)
        {
            Payment paymenttemp = new Payment();
            paymenttemp.Payments_Key = paymentkey;

            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentSpecific(paymentkey).GetDataSet();

            if (dstemp.Tables[0].Rows[0]["quote_key"] != DBNull.Value)
            {
                paymenttemp.Quote_Key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["quote_key"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["quote_key_actual"] != DBNull.Value)
            {
                paymenttemp.Quote_Key_Actual = Convert.ToInt32(dstemp.Tables[0].Rows[0]["quote_key_actual"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["payment_status"] != DBNull.Value)
            {
                paymenttemp.Payment_status = Convert.ToInt32(dstemp.Tables[0].Rows[0]["payment_status"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["date_created"] != DBNull.Value)
            {
                paymenttemp.Date_created = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["date_created"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["payment_object_sender"] != DBNull.Value)
            {
                paymenttemp.Payment_object_sender = Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_sender"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["payment_object_receiver"] != DBNull.Value)
            {
                paymenttemp.Payment_object_receiver = Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_receiver"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["payment_object_receiver_type"] != DBNull.Value)
            {
                paymenttemp.Payment_object_receiver_type = Convert.ToInt32(dstemp.Tables[0].Rows[0]["payment_object_receiver_type"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["payment_description"] != DBNull.Value)
            {
                paymenttemp.Payment_description = dstemp.Tables[0].Rows[0]["payment_description"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["sell_amount"] != DBNull.Value)
            {
                paymenttemp.Sell_amount = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["sell_amount"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["sell_currency"] != DBNull.Value)
            {
                paymenttemp.Sell_currency = Convert.ToInt32(dstemp.Tables[0].Rows[0]["sell_currency"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["buy_amount"] != DBNull.Value)
            {
                paymenttemp.Buy_amount = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["buy_amount"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["buy_currency"] != DBNull.Value)
            {
                paymenttemp.Buy_currency = Convert.ToInt32(dstemp.Tables[0].Rows[0]["buy_currency"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["rate"] != DBNull.Value)
            {
                paymenttemp.Rate = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["rate"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["service_fee"] != DBNull.Value)
            {
                paymenttemp.Service_fee = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["service_fee"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["promised_delivery_date"] != DBNull.Value)
            {
                paymenttemp.Promised_delivery_date = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["promised_delivery_date"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["actual_delivery_date"] != DBNull.Value)
            {
                paymenttemp.Actual_delivery_date = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["actual_delivery_date"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["receiver_name"] != DBNull.Value)
            {
                paymenttemp.Receiver_name = dstemp.Tables[0].Rows[0]["receiver_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["sender_name"] != DBNull.Value)
            {
                paymenttemp.Sender_name = dstemp.Tables[0].Rows[0]["sender_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["sell_currency_text"] != DBNull.Value)
            {
                paymenttemp.Sell_currency_text = dstemp.Tables[0].Rows[0]["sell_currency_text"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["buy_currency_text"] != DBNull.Value)
            {
                paymenttemp.Buy_currency_text = dstemp.Tables[0].Rows[0]["buy_currency_text"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["payment_status_text"] != DBNull.Value)
            {
                paymenttemp.Payment_status_text = dstemp.Tables[0].Rows[0]["payment_status_text"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["internal_only"] != DBNull.Value)
            {
                paymenttemp.Internal_only = Convert.ToBoolean(dstemp.Tables[0].Rows[0]["internal_only"]);
            }
            if (dstemp.Tables[0].Rows[0]["requiresmanualexport"] != DBNull.Value)
            {
                paymenttemp.Requiresmanualexport = Convert.ToBoolean(dstemp.Tables[0].Rows[0]["requiresmanualexport"]);
            }
            if (dstemp.Tables[0].Rows[0]["requestor_user_key"] != DBNull.Value)
            {
                paymenttemp.Requestor_user_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["requestor_user_key"]);
            }
            if (dstemp.Tables[0].Rows[0]["txt_Sell_full"] != DBNull.Value)
            {
                paymenttemp.Txt_Sell_full = dstemp.Tables[0].Rows[0]["txt_Sell_full"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["txt_Buy_full"] != DBNull.Value)
            {
                paymenttemp.Txt_Buy_full = dstemp.Tables[0].Rows[0]["txt_Buy_full"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["actual_rate"] != DBNull.Value)
            {
                paymenttemp.Actual_rate = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["actual_rate"]);
            }
            if (dstemp.Tables[0].Rows[0]["actual_txt_Sell_full"] != DBNull.Value)
            {
                paymenttemp.Actual_txt_Sell_full = dstemp.Tables[0].Rows[0]["actual_txt_Sell_full"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["actual_txt_Buy_full"] != DBNull.Value)
            {
                paymenttemp.Actual_txt_Buy_full = dstemp.Tables[0].Rows[0]["actual_txt_Buy_full"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["actual_service_fee"] != DBNull.Value)
            {
                paymenttemp.Actual_service_fee = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["actual_service_fee"]);
            }
            if (dstemp.Tables[0].Rows[0]["treasury_type"] != DBNull.Value)
            {
                paymenttemp.Treasury_type = Convert.ToInt32(dstemp.Tables[0].Rows[0]["treasury_type"]);
            }
            if (dstemp.Tables[0].Rows[0]["directlyfromcurrencycloud"] != DBNull.Value)
            {
                paymenttemp.Directlyfromcurrencycloud = Convert.ToInt32(dstemp.Tables[0].Rows[0]["directlyfromcurrencycloud"]);
            }
            if (dstemp.Tables[0].Rows[0]["cc_tradeid"] != DBNull.Value)
            {
                paymenttemp.Currencycloudtradeid = dstemp.Tables[0].Rows[0]["cc_tradeid"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["cc_paymentid"] != DBNull.Value)
            {
                paymenttemp.Currencycloudpaymentid = dstemp.Tables[0].Rows[0]["cc_paymentid"].ToString();
            }
            return paymenttemp;
        }

        public BankAccounts getBankAccounts(int bankaccountkey, Int64 paymentkey)
        {
            DataSet dstemp = new DataSet();
            BankAccounts tempbankaccount = new BankAccounts();

            if (bankaccountkey > 0)
            {
                dstemp = Peerfx_DB.SPs.ViewBankAccountsSpecific(bankaccountkey).GetDataSet();
                tempbankaccount.Bank_account_key = bankaccountkey;
                if (dstemp.Tables[0].Rows[0]["payment_object_key"] != DBNull.Value)
                {
                    tempbankaccount.Payment_object_key = Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_key"]);
                }
            }
            else if (paymentkey > 0)
            {
                tempbankaccount.Payment_object_key = paymentkey;
                dstemp = Peerfx_DB.SPs.ViewBankAccountsSpecificPaymentkey(paymentkey).GetDataSet();
                if (dstemp.Tables[0].Rows[0]["bank_account_key"] != DBNull.Value)
                {
                    tempbankaccount.Bank_account_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["bank_account_key"]);
                }
            }

            Boolean islocalpayment = false;

            if (dstemp.Tables[0].Rows[0]["payment_object_type"] != DBNull.Value)
            {
                tempbankaccount.Payment_object_type = Convert.ToInt32(dstemp.Tables[0].Rows[0]["payment_object_type"]);
            }
            if (dstemp.Tables[0].Rows[0]["date_created"] != DBNull.Value)
            {
                tempbankaccount.Date_created = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["date_created"]);
            }
            if (dstemp.Tables[0].Rows[0]["user_key"] != DBNull.Value)
            {
                tempbankaccount.User_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["user_key"]);
            }
            if (dstemp.Tables[0].Rows[0]["organization_key"] != DBNull.Value)
            {
                tempbankaccount.Organization_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["organization_key"]);
            }
            if (dstemp.Tables[0].Rows[0]["bank_account_description"] != DBNull.Value)
            {
                tempbankaccount.Bank_account_description = dstemp.Tables[0].Rows[0]["bank_account_description"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["user_key_updated"] != DBNull.Value)
            {
                tempbankaccount.User_key_updated = Convert.ToInt32(dstemp.Tables[0].Rows[0]["user_key_updated"]);
            }
            if (dstemp.Tables[0].Rows[0]["ip_address"] != DBNull.Value)
            {
                tempbankaccount.Ip_address = dstemp.Tables[0].Rows[0]["ip_address"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["business_name"] != DBNull.Value)
            {
                tempbankaccount.Business_name = dstemp.Tables[0].Rows[0]["business_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["last_changed"] != DBNull.Value)
            {
                tempbankaccount.Last_changed = Convert.ToDateTime(dstemp.Tables[0].Rows[0]["last_changed"]);
            }
            if (dstemp.Tables[0].Rows[0]["bank_account_info"] != DBNull.Value)
            {
                tempbankaccount.Bank_account_info = dstemp.Tables[0].Rows[0]["bank_account_info"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["organization_name"] != DBNull.Value)
            {
                tempbankaccount.Organization_name = dstemp.Tables[0].Rows[0]["organization_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["country_text"] != DBNull.Value)
            {
                tempbankaccount.Country_text = dstemp.Tables[0].Rows[0]["country_text"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["currency_text"] != DBNull.Value)
            {
                tempbankaccount.Currency_text = dstemp.Tables[0].Rows[0]["currency_text"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["first_name"] != DBNull.Value)
            {
                tempbankaccount.First_name = dstemp.Tables[0].Rows[0]["first_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["last_name"] != DBNull.Value)
            {
                tempbankaccount.Last_name = dstemp.Tables[0].Rows[0]["last_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["account_number"] != DBNull.Value)
            {
                tempbankaccount.Account_number = dstemp.Tables[0].Rows[0]["account_number"].ToString();                
            }
            if (dstemp.Tables[0].Rows[0]["IBAN"] != DBNull.Value)
            {
                tempbankaccount.IBAN = dstemp.Tables[0].Rows[0]["IBAN"].ToString();
                islocalpayment = true;
            }
            if (dstemp.Tables[0].Rows[0]["BIC"] != DBNull.Value)
            {
                tempbankaccount.BIC = dstemp.Tables[0].Rows[0]["BIC"].ToString();                
            }
            if (dstemp.Tables[0].Rows[0]["ABArouting"] != DBNull.Value)
            {
                tempbankaccount.ABArouting = dstemp.Tables[0].Rows[0]["ABArouting"].ToString();
                islocalpayment = true;
            }
            if (dstemp.Tables[0].Rows[0]["BSB"] != DBNull.Value)
            {
                tempbankaccount.BSB = dstemp.Tables[0].Rows[0]["BSB"].ToString();
                islocalpayment = true;
            }
            if (dstemp.Tables[0].Rows[0]["SortCode"] != DBNull.Value)
            {
                tempbankaccount.Sortcode = dstemp.Tables[0].Rows[0]["SortCode"].ToString();
                islocalpayment = true;
            }
            if (dstemp.Tables[0].Rows[0]["email"] != DBNull.Value)
            {
                tempbankaccount.Email = dstemp.Tables[0].Rows[0]["email"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["currency_key"] != DBNull.Value)
            {
                tempbankaccount.Currency_key = Convert.ToInt32(dstemp.Tables[0].Rows[0]["currency_key"].ToString());
            }
            if (dstemp.Tables[0].Rows[0]["bank_name"] != DBNull.Value)
            {
                tempbankaccount.Bankname = dstemp.Tables[0].Rows[0]["bank_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["branch_code"] != DBNull.Value)
            {
                tempbankaccount.Branchcode = dstemp.Tables[0].Rows[0]["branch_code"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["institution_number"] != DBNull.Value)
            {
                tempbankaccount.Institutionnumber = dstemp.Tables[0].Rows[0]["institution_number"].ToString();
            }

            tempbankaccount.Islocalpayment = islocalpayment;

            return tempbankaccount;
        }

        public string getBankAccountDescription(Int64 paymentobjectkey)
        {
            //output bank account in html format
            string strtemp = "";
            string strbuffer = "";
            string strbuffer2 = "";

            DataSet dstemp = Peerfx_DB.SPs.ViewBankAccountsSpecificPaymentkey(paymentobjectkey).GetDataSet();
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                
                if (dstemp.Tables[0].Rows[0]["first_name"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["first_name"].ToString();                    
                    if (dstemp.Tables[0].Rows[0]["last_name"] != DBNull.Value)
                    {
                        strbuffer2 = dstemp.Tables[0].Rows[0]["last_name"].ToString();
                    }
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "Name - " + strbuffer + " " + strbuffer2 + "<br/>";
                    }                    
                }
                /*
                if (dstemp.Tables[0].Rows[0]["organization_name"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["organization_name"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "Bank Name - " + strbuffer + "<br/>";
                    }
                }*/
                if (dstemp.Tables[0].Rows[0]["IBAN"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["IBAN"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "IBAN - " + strbuffer + "<br/>";
                    }
                }
                if (dstemp.Tables[0].Rows[0]["BIC"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["BIC"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "BIC - " + strbuffer + "<br/>";
                    }
                }
                if (dstemp.Tables[0].Rows[0]["ABArouting"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["ABArouting"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "ABA Routing - " + strbuffer + "<br/>";
                    }
                }
                if (dstemp.Tables[0].Rows[0]["account_number"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["account_number"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "Account Number - " + strbuffer + "<br/>";
                    }
                }
                if (dstemp.Tables[0].Rows[0]["BSB"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["BSB"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "BSB - " + strbuffer + "<br/>";
                    }
                }

                if (dstemp.Tables[0].Rows[0]["SortCode"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["SortCode"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "SortCode - " + strbuffer + "<br/>";
                    }
                }

                if (dstemp.Tables[0].Rows[0]["institution_number"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["institution_number"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "Institution Number - " + strbuffer + "<br/>";
                    }
                }

                if (dstemp.Tables[0].Rows[0]["branch_code"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["branch_code"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "Branch Code - " + strbuffer + "<br/>";
                    }
                }

                if (dstemp.Tables[0].Rows[0]["country_text"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["country_text"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "Country - " + strbuffer;
                    }
                }
                if (dstemp.Tables[0].Rows[0]["bank_name"] != DBNull.Value)
                {
                    strbuffer = dstemp.Tables[0].Rows[0]["bank_name"].ToString();
                    if (strbuffer.Trim().Length > 0)
                    {
                        strtemp += "Bank Name - " + strbuffer;
                    }
                }
            }
            

            return strtemp;
        }

        public string GetCurrencySymbol(string strtemp)
        {            
            string strsymbol = "$";

            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrencySymbol(strtemp.ToUpper()).GetDataSet();
            strsymbol = dstemp.Tables[0].Rows[0]["info_currency_symbol"].ToString();

            return strsymbol;
        }

        public string GetCurrencySymbol(int currencykey)
        {
            string strsymbol = "$";

            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrenciesSpecific(currencykey).GetDataSet();
            strsymbol = dstemp.Tables[0].Rows[0]["info_currency_symbol"].ToString();
            return strsymbol;
        }

        public int getbankaccountcurrency(int bankaccountkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewBankAccountsSpecific(bankaccountkey).GetDataSet();

            int currencykey = 0;
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                currencykey = Convert.ToInt32(dstemp.Tables[0].Rows[0]["currency_key"]);
            }
            return currencykey;
        }

        public DateTime getcurrencyclouddate(string thedate){
            //"20110218-10:37:11"
            DateTime dttemp;
            if (thedate.Length == 8)
            {
                dttemp = DateTime.ParseExact(thedate,"yyyyMMdd",null);
            }
            else{
                dttemp = DateTime.ParseExact(thedate,"yyyyMMdd-HH:mm:ss",null);
            }
            return dttemp;
        }

        public Quote getQuote(decimal sellamount, int sellcurrency, int buycurrency, Boolean ispremium)
        {
            Quote quotetemp = new Quote();
            External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
            Hashtable hstemp = cc.Exchange_Rate_ccy_pair(sellcurrency,buycurrency);
            quotetemp.Sellcurrency = sellcurrency;
            quotetemp.Buycurrency = buycurrency;

            if (!hstemp.ContainsValue("error")){
                quotetemp.Bid_Price_Timestamp = getcurrencyclouddate(hstemp["bid_price_timestamp"].ToString());
                quotetemp.Bid_Price = Convert.ToDecimal(hstemp["bid_price"]);
                quotetemp.Broker_Bid = Convert.ToDecimal(hstemp["broker_bid"]);
                quotetemp.Offer_Price_Timestamp = getcurrencyclouddate(hstemp["offer_price_timestamp"].ToString());
                quotetemp.Offer_Price = Convert.ToDecimal(hstemp["offer_price"]);
                quotetemp.Broker_Offer = Convert.ToDecimal(hstemp["broker_offer"]);
                quotetemp.Market_Price = Convert.ToDecimal(hstemp["market_price"]);
                quotetemp.Value_Date = getcurrencyclouddate(hstemp["value_date"].ToString());
                quotetemp.Quote_Condition = hstemp["quote_condition"].ToString();
                quotetemp.Real_Market = hstemp["real_market"].ToString();
                quotetemp.Ccy_Pair = hstemp["ccy_pair"].ToString();
                                
                //calculate Peerfx servicefee & rate
                
                if (sellamount > 0)
                {   
                    quotetemp.Sellamount = sellamount;
                    decimal peerfxservicefee = 0;
                    decimal buyamount = 0;
                    decimal peerfxrate = 0;

                    Fees fees = new Fees();
                    //Calculate peerfx service fee
                    if (ispremium)
                    {
                        fees = getFeesPremium(sellcurrency, buycurrency);
                    }
                    else
                    {
                        fees = getFees(sellcurrency, buycurrency);
                    }

                    //peerfxrate
                    peerfxrate = quotetemp.Broker_Bid;
                    if (fees.Fee_Percentage != 0){
                        peerfxservicefee += (fees.Fee_Percentage * (sellamount * peerfxrate));
                    }
                    
                    //peerfx service fee
                    if (fees.Fee_Base != 0)
                    {
                        peerfxservicefee += fees.Fee_Base;
                    }
                    if (fees.Fee_Addon != 0)
                    {
                        peerfxservicefee += fees.Fee_Addon;
                    }
                    if (fees.Fee_Min != 0)
                    {
                        if (fees.Fee_Min > peerfxservicefee){
                            peerfxservicefee = fees.Fee_Min;
                        }
                    }
                    if (fees.Fee_Max != 0)
                    {
                        if (fees.Fee_Max < peerfxservicefee){
                            peerfxservicefee = fees.Fee_Max;
                        }
                    }

                    //calculate buyingamount
                    buyamount = sellamount * peerfxrate;
                    buyamount = buyamount - peerfxservicefee;

                    //assign values
                    quotetemp.Peerfx_Servicefee = decimal.Round(peerfxservicefee,2);
                    quotetemp.Peerfx_Rate = peerfxrate;                    
                    quotetemp.Buyamount = decimal.Round(buyamount,2);
                }                
            }
            return quotetemp;
        }

        public Quote getQuote_reverse(decimal buyamount, int sellcurrency, int buycurrency,Boolean ispremium)
        {
            Quote quotetemp = new Quote();
            External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
            Hashtable hstemp = cc.Exchange_Rate_ccy_pair(sellcurrency, buycurrency);

            if (!hstemp.ContainsValue("error"))
            {
                quotetemp.Bid_Price_Timestamp = getcurrencyclouddate(hstemp["bid_price_timestamp"].ToString());
                quotetemp.Bid_Price = Convert.ToDecimal(hstemp["bid_price"]);
                quotetemp.Broker_Bid = Convert.ToDecimal(hstemp["broker_bid"]);
                quotetemp.Offer_Price_Timestamp = getcurrencyclouddate(hstemp["offer_price_timestamp"].ToString());
                quotetemp.Offer_Price = Convert.ToDecimal(hstemp["offer_price"]);
                quotetemp.Broker_Offer = Convert.ToDecimal(hstemp["broker_offer"]);
                quotetemp.Market_Price = Convert.ToDecimal(hstemp["market_price"]);
                quotetemp.Value_Date = getcurrencyclouddate(hstemp["value_date"].ToString());
                quotetemp.Quote_Condition = hstemp["quote_condition"].ToString();
                quotetemp.Real_Market = hstemp["real_market"].ToString();
                quotetemp.Ccy_Pair = hstemp["ccy_pair"].ToString();
                quotetemp.Buycurrency = buycurrency;
                quotetemp.Sellcurrency = sellcurrency;

                //calculate Peerfx servicefee & rate

                if (buyamount > 0)
                {
                    quotetemp.Buyamount = buyamount;
                    decimal peerfxservicefee = 0;
                    decimal sellamount = 0;
                    decimal peerfxrate = 0;

                    Fees fees = new Fees();
                    //Calculate peerfx service fee
                    if (ispremium)
                    {
                        fees = getFeesPremium(sellcurrency, buycurrency);
                    }
                    else
                    {
                        fees = getFees(sellcurrency, buycurrency);
                    }

                    //peerfxrate
                    peerfxrate = quotetemp.Broker_Bid;
                    if (fees.Fee_Percentage != 0)
                    {
                        peerfxservicefee += (buyamount * fees.Fee_Percentage);
                    }

                    //peerfx service fee
                    if (fees.Fee_Base != 0)
                    {
                        peerfxservicefee += fees.Fee_Base;
                    }
                    if (fees.Fee_Addon != 0)
                    {
                        peerfxservicefee += fees.Fee_Addon;
                    }
                    if (fees.Fee_Min != 0)
                    {
                        if (fees.Fee_Min > peerfxservicefee)
                        {
                            peerfxservicefee = fees.Fee_Min;
                        }
                    }
                    if (fees.Fee_Max != 0)
                    {
                        if (fees.Fee_Max < peerfxservicefee)
                        {
                            peerfxservicefee = fees.Fee_Max;
                        }
                    }

                    //calculate buyingamount
                    sellamount = buyamount / peerfxrate;
                    sellamount = sellamount + peerfxservicefee;

                    //assign values
                    quotetemp.Peerfx_Servicefee = decimal.Round(peerfxservicefee, 2);
                    quotetemp.Peerfx_Rate = peerfxrate;
                    quotetemp.Sellamount = decimal.Round(sellamount, 2);
                }
            }
            return quotetemp;
        }

        /*
        public Quote getQuotePremium(Quote quotetemp)
        {
            if (quotetemp.Sellamount > 0)
            {                
                decimal peerfxservicefee = 0;
                decimal buyamount = 0;
                decimal peerfxrate = 0;

                //Calculate peerfx service fee
                Fees fees = getFeesPremium(quotetemp.Sellcurrency, quotetemp.Buycurrency);

                //peerfxrate
                peerfxrate = quotetemp.Peerfx_Rate;
                if (fees.Fee_Percentage != 0)
                {
                    peerfxservicefee += (fees.Fee_Percentage * (quotetemp.Sellamount * peerfxrate));
                }

                //peerfx service fee                
                if (fees.Fee_Addon != 0)
                {
                    peerfxservicefee += fees.Fee_Addon;
                }
                if (fees.Fee_Min != 0)
                {
                    if (fees.Fee_Min > peerfxservicefee)
                    {
                        peerfxservicefee = fees.Fee_Min;
                    }
                }
                if (fees.Fee_Max != 0)
                {
                    if (fees.Fee_Max < peerfxservicefee)
                    {
                        peerfxservicefee = fees.Fee_Max;
                    }
                }

                quotetemp.Peerfx_Servicefee += peerfxservicefee;
                quotetemp.Buyamount -= peerfxservicefee;
            }            

            return quotetemp;
        }*/

        public Fees getFees(int sellcurrency, int buycurrency)
        {
            Fees fees = new Fees();

            DataSet dstemp = Peerfx_DB.SPs.ViewInfoFeeTypes(sellcurrency, buycurrency).GetDataSet();
            
            if (dstemp.Tables[0].Rows[0]["organization_name"] != DBNull.Value)
            {
                fees.Organization_Name = dstemp.Tables[0].Rows[0]["organization_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["description"] != DBNull.Value)
            {
                fees.Description = dstemp.Tables[0].Rows[0]["description"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["fee_base"] != DBNull.Value)
            {
                fees.Fee_Base = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_base"]);
            }
            if (dstemp.Tables[0].Rows[0]["fee_percentage"] != DBNull.Value)
            {
                fees.Fee_Percentage = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_percentage"]);
            }
            if (dstemp.Tables[0].Rows[0]["fee_addon"] != DBNull.Value)
            {
                fees.Fee_Addon = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_addon"]);
            }
            if (dstemp.Tables[0].Rows[0]["fee_min"] != DBNull.Value)
            {
                fees.Fee_Min = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_min"]);
            }
            if (dstemp.Tables[0].Rows[0]["fee_max"] != DBNull.Value)
            {
                fees.Fee_Max = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_max"]);
            }
            if (sellcurrency > 0)
            {
                fees.Currency1 = sellcurrency;
            }
            if (buycurrency > 0)
            {
                fees.Currency2 = buycurrency;
            }

            return fees;
        }

        public Fees getFeesPremium(int sellcurrency, int buycurrency)
        {
            Fees fees = new Fees();

            DataSet dstemp = Peerfx_DB.SPs.ViewInfoFeeTypes(sellcurrency, buycurrency).GetDataSet();

            if (dstemp.Tables[0].Rows[0]["organization_name"] != DBNull.Value)
            {
                fees.Organization_Name = dstemp.Tables[0].Rows[0]["organization_name"].ToString();
            }
            if (dstemp.Tables[0].Rows[0]["description"] != DBNull.Value)
            {
                fees.Description = dstemp.Tables[0].Rows[0]["description"].ToString();
            }            
            if ((dstemp.Tables[0].Rows[0]["fee_percentage"] != DBNull.Value) && (dstemp.Tables[0].Rows[0]["premium_fee_percentage"] != DBNull.Value))
            {
                fees.Fee_Percentage = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_percentage"]);
                fees.Fee_Percentage += Convert.ToDecimal(dstemp.Tables[0].Rows[0]["premium_fee_percentage"]);
            }
            if ((dstemp.Tables[0].Rows[0]["fee_addon"] != DBNull.Value) && (dstemp.Tables[0].Rows[0]["premium_fee_addon"] != DBNull.Value))
            {
                fees.Fee_Addon = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_addon"]);
                fees.Fee_Addon += Convert.ToDecimal(dstemp.Tables[0].Rows[0]["premium_fee_addon"]);
            }
            if ((dstemp.Tables[0].Rows[0]["fee_min"] != DBNull.Value) && (dstemp.Tables[0].Rows[0]["premium_fee_min"] != DBNull.Value))
            {
                decimal min = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_min"]);
                decimal minpremium = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["premium_fee_min"]);
                if (min < minpremium)
                {
                    fees.Fee_Min = min;
                }
                else
                {
                    fees.Fee_Min = minpremium;
                }                
            }
            if ((dstemp.Tables[0].Rows[0]["fee_max"] != DBNull.Value) && (dstemp.Tables[0].Rows[0]["premium_fee_max"] != DBNull.Value))
            {
                decimal max = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["fee_max"]);
                decimal maxpremium = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["premium_fee_max"]);
                if (max > maxpremium)
                {
                    fees.Fee_Max = max;
                }
                else
                {
                    fees.Fee_Max = maxpremium;
                }                
            }
            if (sellcurrency > 0)
            {
                fees.Currency1 = sellcurrency;
            }
            if (buycurrency > 0)
            {
                fees.Currency2 = buycurrency;
            }

            return fees;
        }

        public string getcountrytext(int country_key)
        {
            DataTable dttemp = Peerfx_DB.SPs.ViewInfoCountrySpecific(country_key).GetDataSet().Tables[0];
            return dttemp.Rows[0]["country_text"].ToString();
        }

        public string getcurrencycode(int currency_key)
        {            
            DataTable dttemp = view_info_currency_specific(currency_key);
            return dttemp.Rows[0]["info_currency_code"].ToString();
        }

        public Int64 getpaymentobject(int bankaccountkey)
        {
            //input bankaccountkey output paymentobjectkey
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentObjectBankAccount(bankaccountkey).GetDataSet();

            Int64 paymentobjectkey = 0;
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                paymentobjectkey = Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_key"]);
            }
            return paymentobjectkey;
        }

        public Int64 getpaymentobject_UserBalance(int userkey, int currency)
        {
            Int64 paymentobjectkey = 0;
            Users user = get_user_info(userkey);
            //if currency = 3 & user has bancbox

            if ((currency == 3) && (user.Bancbox_payment_object_key > 0))
            {
                paymentobjectkey = user.Bancbox_payment_object_key;
            }
            else
            {
                paymentobjectkey = getpaymentobject(3,userkey);
            }


            return paymentobjectkey;
        }

        public Int64 getpaymentobject(int typekey, int objectkey)
        {
            // 1 = Bank Account Real World
            // 2 = Admin Bank Account Real World
            // 3 = User Balance
            // 4 = User Balance Frozen
            // 6 = Payment
            // 7 = Embee
            // 8 = BancBox            

            //input bankaccountkey output paymentobjectkey
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentObjectTypeObjectkey(typekey, objectkey).GetDataSet();

            Int64 paymentobjectkey = 0;
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                paymentobjectkey = Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_key"]);
            }
            return paymentobjectkey;
        }

        public int getpaymentobjecttype(Int64 paymentobjectkey)
        {
            int paymentobjecttype = 0;

            DataTable dttemp = Peerfx_DB.SPs.ViewPaymentObjectSpecific(paymentobjectkey).GetDataSet().Tables[0];
            if (dttemp.Rows[0]["payment_object_type"] != DBNull.Value)
            {
                paymentobjecttype = Convert.ToInt32(dttemp.Rows[0]["payment_object_type"]);
            }

            return paymentobjecttype;
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

        public DataTable view_info_currency_specific(int currency_key)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrenciesSpecific(currency_key).GetDataSet();
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

        public DataTable view_transaction_all_specificpayment(int paymentkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewTransactionAllSpecificPayment(paymentkey).GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_transaction_fees(int tx_type)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewTransactionFees(tx_type).GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_transaction_fees_txkey(int tx_type, int tx_key)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewTransactionFeesTxkey(tx_type, tx_key).GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_info_currencies_cansell()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrenciesCanSell().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_info_currencies_canbuy()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrenciesCanBuy().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_info_currencies_cannhold()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewInfoCurrenciesCanHold().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_payments_confirmed()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentsConfirmed().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_bank_accounts_users()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewBankAccountsUsers().GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable view_payment_status()
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentStatus().GetDataSet();
            return dstemp.Tables[0];
        }

        public Verification view_users_verified(int userkey, int methodkey)
        {
            DataTable dttemp = Peerfx_DB.SPs.ViewUsersVerified(userkey, methodkey).GetDataSet().Tables[0];
            Verification verificationtemp = new Verification();
            verificationtemp.Users_verified_key = 0;
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0]["users_verified_key"] != DBNull.Value)
                {
                    verificationtemp.Users_verified_key = Convert.ToInt32(dttemp.Rows[0]["users_verified_key"]);
                }
                if (dttemp.Rows[0]["user_key"] != DBNull.Value)
                {
                    verificationtemp.User_key = Convert.ToInt32(dttemp.Rows[0]["user_key"]);
                }
                if (dttemp.Rows[0]["verification_methods_key"] != DBNull.Value)
                {
                    verificationtemp.Verification_methods_key = Convert.ToInt32(dttemp.Rows[0]["verification_methods_key"]);
                }
                if (dttemp.Rows[0]["isverified"] != DBNull.Value)
                {
                    verificationtemp.Isverified = Convert.ToBoolean(dttemp.Rows[0]["isverified"]);
                }
                if (dttemp.Rows[0]["last_changed"] != DBNull.Value)
                {
                    verificationtemp.Last_changed = Convert.ToDateTime(dttemp.Rows[0]["last_changed"]);
                }
                if (dttemp.Rows[0]["unique_key"] != DBNull.Value)
                {
                    verificationtemp.Unique_key = Convert.ToString(dttemp.Rows[0]["unique_key"]);
                }
                if (dttemp.Rows[0]["ip_address"] != DBNull.Value)
                {
                    verificationtemp.Ip_address = Convert.ToString(dttemp.Rows[0]["ip_address"]);
                }
                if (dttemp.Rows[0]["verification_method_name"] != DBNull.Value)
                {
                    verificationtemp.Verification_method_name = Convert.ToString(dttemp.Rows[0]["verification_method_name"]);
                }
                if (dttemp.Rows[0]["points"] != DBNull.Value)
                {
                    verificationtemp.Points = Convert.ToInt32(dttemp.Rows[0]["points"]);
                }
                if (dttemp.Rows[0]["ismandatory"] != DBNull.Value)
                {
                    verificationtemp.Ismandatory = Convert.ToBoolean(dttemp.Rows[0]["ismandatory"]);
                }
            }            

            return verificationtemp;
        }

        public Hashtable getusersverified(int userkey)
        {
            Hashtable hstemp = new Hashtable();

            DataTable dttemp = Peerfx_DB.SPs.ViewVerificationMethods().GetDataSet().Tables[0];
            foreach (DataRow dr in dttemp.Rows)
            {
                int i = Convert.ToInt32(dr["verification_method_key"]);
                Verification dtverification = view_users_verified(userkey, i);
                if (dtverification.Users_verified_key > 0)
                {
                    hstemp.Add(i, dtverification);
                }                
            }

            return hstemp;
        }


        public Int64 insert_bank_account_returnpaymentobject(int userkey, int currencykey, int organizationkey, string bankaccountdescription, int userkeyupdated, string accountnumber, string IBAN, string BIC, string ABArouting, string firstname, string lastname, string businessname,string sortcode, string bsb, string email,string bankname, string branchcode,string institutionnumber)
        {
            StoredProcedure sp_UpdateBank_account = Peerfx_DB.SPs.UpdateBankAccounts(0, userkey, currencykey, organizationkey, bankaccountdescription, userkeyupdated, get_ipaddress(), accountnumber, IBAN, BIC, ABArouting, firstname, lastname, businessname, 0,sortcode,bsb,email,bankname,branchcode,institutionnumber);
            sp_UpdateBank_account.Execute();
            int bankaccountkey = Convert.ToInt32(sp_UpdateBank_account.Command.Parameters[14].ParameterValue.ToString());
            StoredProcedure sp_UpdatePaymentObject = Peerfx_DB.SPs.UpdatePaymentObjects(0, 1, bankaccountkey, 0);
            sp_UpdatePaymentObject.Execute();
            Int64 returnpaymentobject = Convert.ToInt64(sp_UpdatePaymentObject.Command.Parameters[3].ParameterValue.ToString());

            return returnpaymentobject;
        }

        public Int64 insert_bancbox_account_returnpaymentobject(int userkey, int currencykey, int organizationkey, string bankaccountdescription, int userkeyupdated, string accountnumber, string IBAN, string BIC, string ABArouting, string firstname, string lastname, string businessname)
        {
            StoredProcedure sp_UpdateBank_account = Peerfx_DB.SPs.UpdateBankAccounts(0, userkey, currencykey, organizationkey, bankaccountdescription, userkeyupdated, get_ipaddress(), accountnumber, IBAN, BIC, ABArouting, firstname, lastname, businessname, 0,"","","","","","");
            sp_UpdateBank_account.Execute();
            int bankaccountkey = Convert.ToInt32(sp_UpdateBank_account.Command.Parameters[14].ParameterValue.ToString());
            StoredProcedure sp_UpdatePaymentObject = Peerfx_DB.SPs.UpdatePaymentObjects(0, 8, bankaccountkey, 0);
            sp_UpdatePaymentObject.Execute();
            Int64 returnpaymentobject = Convert.ToInt64(sp_UpdatePaymentObject.Command.Parameters[3].ParameterValue.ToString());

            return returnpaymentobject;
        }

        public void payment_convert_currency_internal(Payment paymenttemp)
        {
            Int64 payment_payment_object_key = getpaymentobject(6, paymenttemp.Payments_Key);
            
            paymenttemp = getPayment(paymenttemp.Payments_Key);
            //**************This is also where we charge service fees*********************                
            Peerfx_DB.SPs.UpdateConvertCurrency(payment_payment_object_key, paymenttemp.Quote_Key_Actual, get_ipaddress(), paymenttemp.Requestor_user_key, paymenttemp.Payments_Key).Execute();

            //update status to currency converted
            Peerfx_DB.SPs.UpdatePaymentStatus(paymenttemp.Payments_Key, 4).Execute();

            //refill the treasury, by sending a request to currencycloud
            paymenttemp = getPayment(paymenttemp.Payments_Key);
            payment_refill_treasury(paymenttemp);
        }

        public void payment_convert_currency_CC(Payment paymenttemp)
        {            

            //Execute trade with CC
            External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
            cc.Trade_Execute(paymenttemp.Payments_Key);            
        }

        public void payment_insert_actual_quote(Payment paymenttemp)
        {
            int paymentkey = paymenttemp.Payments_Key;
            Quote quotetemp = new Quote();
            //Get & Store actual quote
            if (paymenttemp.Treasury_type == 1)
            {
                quotetemp = getQuote(paymenttemp.Sell_amount, paymenttemp.Sell_currency, paymenttemp.Buy_currency, true);
            }
            else
            {
                quotetemp = getQuote(paymenttemp.Sell_amount, paymenttemp.Sell_currency, paymenttemp.Buy_currency, false);
            }
            
            StoredProcedure sp_UpdateQuotes = Peerfx_DB.SPs.UpdateQuotes(0, quotetemp.Sellamount, paymenttemp.Sell_currency, quotetemp.Buyamount, paymenttemp.Buy_currency, quotetemp.Peerfx_Rate, quotetemp.Peerfx_Servicefee, null, null, 0);
            sp_UpdateQuotes.Execute();
            int quote_key = Convert.ToInt32(sp_UpdateQuotes.Command.Parameters[9].ParameterValue.ToString());
            Peerfx_DB.SPs.UpdatePaymentsActualQuote(paymenttemp.Payments_Key, quote_key).Execute();
        }

        public void payment_complete(Payment paymenttemp)
        {
            int paymentkey = paymenttemp.Payments_Key;
            Int64 payment_payment_object_key = getpaymentobject(6, paymentkey);
            Users user_requestor = get_user_info(paymenttemp.Requestor_user_key);

            //Check if does not require manual export
            if (!paymenttemp.Requiresmanualexport)
            {
                Peerfx.External_APIs.SendGrid sg = new Peerfx.External_APIs.SendGrid();
                //Automatically complete payment

                //If Applicable - Ownership of funds is changing, so need to change ownership of funds in ext bank accounts , eg. bancbox
                AdjustExternalBanks(paymenttemp);

                if (paymenttemp.Payment_object_receiver_type == 3) //going to user balance
                {
                    Peerfx_DB.SPs.UpdateTransactionsInternal(0, 2, paymenttemp.Buy_currency, paymenttemp.Buy_amount, payment_payment_object_key, paymenttemp.Payment_object_receiver, get_ipaddress(), paymenttemp.Requestor_user_key, "From Payment to User Balance", 0, 1, paymentkey).Execute();
                    Peerfx_DB.SPs.UpdatePaymentStatus(paymentkey, 5).Execute(); //payment delivered

                    //payment completed, send email                    
                    sg.Send_Email_Payment_Completed(paymenttemp.Payments_Key, user_requestor);
                }
                else if (paymenttemp.Payment_object_receiver_type == 7) //Embee top up
                {
                    //Send Top Up
                    EmbeeObject embeetemp = getEmbeeObject(paymenttemp.Payments_Key);
                    External_APIs.Embee embeecalls = new External_APIs.Embee();
                    int newtransid = embeecalls.RequestPurchase(embeetemp.Productid.ToString(), embeetemp.Phone, user_requestor.Email, get_ipaddress(), user_requestor.User_key, paymentkey);
                    Peerfx_DB.SPs.UpdateEmbeeNewtransid(newtransid, embeetemp.Embee_object_key).Execute();
                    Peerfx_DB.SPs.UpdatePaymentStatus(paymentkey, 6).Execute();

                    Int64 embee_paymentobjectkey = getpaymentobject(7, embeetemp.Embee_object_key);
                    Peerfx_DB.SPs.UpdateTransactionsExternal(0, 1, paymenttemp.Buy_currency, paymenttemp.Buy_amount, payment_payment_object_key, embee_paymentobjectkey, get_ipaddress(), paymenttemp.Requestor_user_key, "From Payment to Embee Object", "", 0, 1, paymentkey).Execute();                    
                    

                    //send receiver note
                    try
                    {
                        string thebody = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/SMS/payment_confirmed_Embee.txt"));
                        thebody = thebody.Replace("FIRST_NAME", user_requestor.First_name);
                        thebody = thebody.Replace("LAST_NAME", user_requestor.Last_name);
                        thebody = thebody.Replace("TOPUP_NAME", embeetemp.Productname);

                        External_APIs.Twilio twillio = new External_APIs.Twilio();
                        twillio.SendSMS(embeetemp.Phone, thebody, embeetemp.Country);
                    }
                    catch
                    {
                    }
                }
                else if ((paymenttemp.Buy_currency == 3) && (user_requestor.Bancbox_payment_object_key > 0) && (IsBankAccount(paymenttemp.Payment_object_receiver)))
                {
                    //Send out money via Bancbox account                                            
                    External_APIs.BancBox bb = new External_APIs.BancBox();
                    bb.SendFunds_External(user_requestor.User_key, paymenttemp.Payment_object_receiver, paymenttemp.Buy_amount, "External Transfer", false, 1, paymenttemp.Payments_Key);
                    Peerfx_DB.SPs.UpdateTransactionsExternal(0, 1, paymenttemp.Buy_currency, paymenttemp.Buy_amount, payment_payment_object_key, paymenttemp.Payment_object_receiver, get_ipaddress(), paymenttemp.Requestor_user_key, "From Payment to Ext US Bank", "", 0, 1, paymentkey).Execute();

                    //change status to Transaction Complete
                    Peerfx_DB.SPs.UpdatePaymentStatus(paymentkey, 5).Execute();

                    //payment in Payment Sent, send email                                        
                    sg.Send_Email_Payment_Completed(paymenttemp.Payments_Key, user_requestor);
                }
            }
            else
            {
                //notify admin manual export is required

                //change status to processing transaction / awaiting withdrawl
                Peerfx_DB.SPs.UpdatePaymentStatus(paymenttemp.Payments_Key, 10).Execute();
            }
        }

        public void payment_initiate(int paymentkey)
        {
            Payment paymenttemp = getPayment(paymentkey);
            Int64 payment_payment_object_key = getpaymentobject(6, paymentkey);
            Users user_requestor = get_user_info(paymenttemp.Requestor_user_key);                        

            //If different currencies then Convert Currency....User balance with System treasury
            if (paymenttemp.Sell_currency != paymenttemp.Buy_currency)
            {
                //insert actual quote
                payment_insert_actual_quote(paymenttemp);

                if (paymenttemp.Treasury_type == 1) //use internal treasury to convert currency
                {
                    //convert currency internal treasury
                    payment_convert_currency_internal(paymenttemp);

                    //complete payment
                    payment_complete(paymenttemp);
                }
                else
                {
                    //convert currency through currencycloud
                    payment_convert_currency_CC(paymenttemp);
                }
                
            }
            else
            {
                payment_complete(paymenttemp);
            }
            

        }


        public void payment_refill_treasury(Payment paymenttemp)
        {
            Users treasury = get_treasury_account(1);
            Int64 senderpaymentobject = getpaymentobject_UserBalance(treasury.User_key, paymenttemp.Sell_currency);
            Int64 receiverpaymentobject = getpaymentobject_UserBalance(treasury.User_key, paymenttemp.Buy_currency);

            //Save & get Quote       
            Quote quotetemp = getQuote(paymenttemp.Buy_amount, paymenttemp.Buy_currency, paymenttemp.Sell_currency, false);
            StoredProcedure sp_UpdateQuotes = Peerfx_DB.SPs.UpdateQuotes(0, quotetemp.Sellamount, quotetemp.Sellcurrency, quotetemp.Buyamount, quotetemp.Buycurrency, quotetemp.Peerfx_Rate, quotetemp.Peerfx_Rate, null, null, 0);
            sp_UpdateQuotes.Execute();
            int quote_key = Convert.ToInt32(sp_UpdateQuotes.Command.Parameters[9].ParameterValue.ToString());

            //Insert Payment
            StoredProcedure sp_UpdatePayments = Peerfx_DB.SPs.UpdatePayments(0, quote_key, 0, 0, treasury.User_key, "Replenish Treasury, Payment# - " + paymenttemp.Payments_Key.ToString(), senderpaymentobject, receiverpaymentobject);
            sp_UpdatePayments.Execute();
            int newpayment_key = Convert.ToInt32(sp_UpdatePayments.Command.Parameters[3].ParameterValue.ToString());

            //update payment status to confirmed
            Peerfx_DB.SPs.UpdatePaymentStatus(newpayment_key, 2).Execute();

            //make sure newpayment goes through CC treasury
            Peerfx_DB.SPs.UpdatePaymentTreasury(newpayment_key, 2).Execute();

            int newsellcurrency = paymenttemp.Buy_currency;
            decimal newsellamount = paymenttemp.Buy_amount;

            //send money from user balance to payment object            
            Int64 payment_payment_object_key = getpaymentobject(6, newpayment_key);
            Peerfx_DB.SPs.UpdateTransactionsInternal(0, 2, newsellcurrency, newsellamount, senderpaymentobject, payment_payment_object_key, get_ipaddress(), paymenttemp.Requestor_user_key, "treasury balance to payment", 0, 1, newpayment_key).Execute();

            //instantly convert the payment, because source funding is balance
            //initiate conversion
            payment_initiate(newpayment_key);
        }

        public int gettreasurytype(int currency1, int currency2)
        {
            int treasurytype = 2;

            DataTable dttemp = Peerfx_DB.SPs.ViewCurrencyPairingsSpecific(currency1, currency2).GetDataSet().Tables[0];
            if (dttemp.Rows[0]["Treasury_Type"] != DBNull.Value)
            {
                treasurytype = Convert.ToInt32(dttemp.Rows[0]["Treasury_Type"]);
            }

            return treasurytype;
        }

        public void AdjustExternalBanks(Payment paymenttemp)
        {
            Users user_sender = get_user_info(paymenttemp.Requestor_user_key);
            Users user_treasury = get_treasury_account(1);
            External_APIs.BancBox bb = new External_APIs.BancBox();

            //Adjust Sender's ext banks
            if ((paymenttemp.Buy_currency == 3) && (user_sender.Bancbox_payment_object_key > 0) && (paymenttemp.Payment_object_receiver_type != 1)){ //USD & sender has BB
                bb.SendFunds_Internal(user_sender.User_key, user_treasury.User_key, paymenttemp.Buy_amount, "Adjust External Banks", false, 1, paymenttemp.Payments_Key);
            }

            //Adjust Receiver's ext banks
            if (paymenttemp.Payment_object_receiver_type == 3) //going to user's Balance
            {
                Users user_receiver = get_user_from_paymentobject(paymenttemp.Payment_object_receiver);
                if ((paymenttemp.Buy_currency == 3) && (user_receiver.Bancbox_payment_object_key > 0))
                {
                    bb.SendFunds_Internal(user_treasury.User_key, user_receiver.User_key, paymenttemp.Buy_amount, "Adjust External Banks", false, 1, paymenttemp.Payments_Key);
                }
            }

        }

        public void CompleteTopUp(Payment paymenttemp)
        {

        }

        public bool IsUserBalance(Int64 paymentobjectkey)
        {
            bool isuserbalance = false;
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentObjectSpecific(paymentobjectkey).GetDataSet();
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                if (dstemp.Tables[0].Rows[0]["payment_object_type"] != DBNull.Value)
                {
                    int type = Convert.ToInt32(dstemp.Tables[0].Rows[0]["payment_object_type"]);
                    if (type == 3)
                    {
                        isuserbalance = true;
                    }
                }
            }
            return isuserbalance;
        }

        public bool IsBankAccount(Int64 paymentobjectkey)
        {
            bool isbankaccount = false;
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentObjectSpecific(paymentobjectkey).GetDataSet();
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                if (dstemp.Tables[0].Rows[0]["payment_object_type"] != DBNull.Value)
                {
                    int type = Convert.ToInt32(dstemp.Tables[0].Rows[0]["payment_object_type"]);
                    if (type == 1) 
                    {
                        isbankaccount = true;
                    }
                }
            }
            return isbankaccount;
        }

        public bool Isexternal(Int64 paymentobjectkey)
        {
            bool isexternal = false;
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentObjectSpecific(paymentobjectkey).GetDataSet();
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                if (dstemp.Tables[0].Rows[0]["isexternal"] != DBNull.Value)
                {
                    isexternal = Convert.ToBoolean(dstemp.Tables[0].Rows[0]["isexternal"]);                    
                }
            }
            return isexternal;
        }

        public bool Isrequiresmanualexport(Int64 paymentobjectkey)
        {
            bool requiresmanualexport = false;
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentObjectSpecific(paymentobjectkey).GetDataSet();
            if (dstemp.Tables[0].Rows.Count > 0)
            {
                if (dstemp.Tables[0].Rows[0]["requiresmanualexport"] != DBNull.Value)
                {
                    requiresmanualexport = Convert.ToBoolean(dstemp.Tables[0].Rows[0]["requiresmanualexport"]);
                }
            }
            return requiresmanualexport;
        }

        public bool IsNumeric(string strTextEntry)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strTextEntry)
                 && (strTextEntry != "");
        }

        public string RenderUserControl(string path)
        {
            Page pageHolder = new Page();
            Control viewControl = pageHolder.LoadControl(path);

            pageHolder.Controls.Add(viewControl);
            using (StringWriter output = new StringWriter())
            {
                HttpContext.Current.Server.Execute(pageHolder, output, false);
                return output.ToString();
            }
        }

        public decimal getuserbalance(int user_key, int currency)
        {
            //Get user's available balance in specific currency
            decimal userbalance = 0;
            DataSet dstemp = Peerfx_DB.SPs.ViewUserBalanceSpecificCurrency(user_key,currency).GetDataSet();
            if (dstemp.Tables[0].Rows[0]["user_balance"] != DBNull.Value){
                userbalance = Convert.ToDecimal(dstemp.Tables[0].Rows[0]["user_balance"]);
            }
            return userbalance;
        }

        public DataTable getuserbalance_datatable(int user_key, int currency)
        {
            //Get user's available balance in specific currency
            DataSet dstemp = Peerfx_DB.SPs.ViewUserBalanceSpecificCurrency(user_key, currency).GetDataSet();
            return dstemp.Tables[0];
        }

        public DataTable getpossiblefundingsources(int user_key, int currency, decimal amount)
        {
            //Get possible funding sources, that can support the currency & amount specified
            DataSet dstemp = Peerfx_DB.SPs.ViewPossibleFundingSources(user_key, currency, amount).GetDataSet();
            return dstemp.Tables[0];
        }

        public int getBancBoxOrganizationkey()
        {
            int inttemp = 0;
            DataTable dttemp = Peerfx_DB.SPs.ViewInfoOrganizationsByname("Four Oaks Bank").GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0]["info_organizations_key"] != DBNull.Value)
                {
                    inttemp = Convert.ToInt32(dttemp.Rows[0]["info_organizations_key"]);
                }
            }
            return inttemp;
        }

        public Int64 get_Payment_Object_sendmoneyto_For_Payment(int userkey,int currency)
        {
            Int64 sendtopaymentobject = 0;
            Users currentuser = get_user_info(userkey);

            //first check if it should be user's bancbox account or our admin account
            if (currency == 3){
                //sell currency is USD, now check if user has bancbox account                
                if (currentuser.Bancbox_payment_object_key > 0)
                {
                    //they have a bancbox account
                    sendtopaymentobject = currentuser.Bancbox_payment_object_key;
                }
            }
            else{
                //figure out which bank account to receive payment
                DataSet dstemp = Peerfx_DB.SPs.ViewAdminBankAccountCurrencyExchange(currency, currentuser.Country_residence).GetDataSet();
                sendtopaymentobject = Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_key"]);
            }

            return sendtopaymentobject;
        }

        public Int64 get_PaymentObject_AdminBankAccounts(int currency, int country)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewAdminBankAccountCurrencyExchange(currency, country).GetDataSet();
            Int64 sendtopaymentobject = Convert.ToInt64(dstemp.Tables[0].Rows[0]["payment_object_key"]);

            return sendtopaymentobject;
        }

        public Users get_treasury_account(int treasury_type)
        {
            Users currentuser = new Users();
            DataTable dttemp = Peerfx_DB.SPs.ViewTreasuryAccount(treasury_type).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0]["user_key"] != DBNull.Value){
                  currentuser = get_user_info(Convert.ToInt32(dttemp.Rows[0]["user_key"]));
                }                
            }
            return currentuser;
        }

        public string GenerateCode()
        {
            string struniquecode = Membership.GeneratePassword(8, 0);
            struniquecode = Regex.Replace(struniquecode, @"[^a-zA-Z0-9]", m => "9");
            return struniquecode;
        }

        public string GenerateCode_Numbersonly()
        {
            string struniquecode = "";
            Random random = new Random();
            struniquecode += random.Next(1, 9);
            for (int i = 1; i<8; i++){
                struniquecode += random.Next(0, 9);
            }            
            return struniquecode;        
        }

        public DataTable GetImagesinDirectory(String folderName, string urlfolder)
        {
            DataTable dttemp = new DataTable();

            if (Directory.Exists(folderName))
            {
                DirectoryInfo Folder;
                FileInfo[] Images;

                Folder = new DirectoryInfo(folderName);
                Images = Folder.GetFiles();


                dttemp.Columns.Add("imgurl");

                for (int i = 0; i < Images.Length; i++)
                {
                    DataRow dr = dttemp.NewRow();
                    dr["imgurl"] = urlfolder + "/" + Images[i].Name;
                    dttemp.Rows.Add(dr);
                    //imagesList.Add(i, Images[i].Name);
                    // Console.WriteLine(String.Format(@"{0}/{1}", folderName, Images[i].Name));
                }
            }            


            return dttemp;
     }

        public void NotificationShow(string Text)
        {
            RadNotification1.Text = Text;
            RadNotification1.Show();
        }

        public DataTable getBankAccount_RequiredFields(int currency)
        {
            /*External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
            Hashtable hstemp = cc.RequiredFields_BankAccounts(currency);*/
            DataTable dttemp = Peerfx_DB.SPs.ViewBankAccountsRequiredFields(currency).GetDataSet().Tables[0];

            return dttemp;
        }

        public string getCountryValueFromCurrency(int currencykey)
        {
            string strreturn = "GB";

            DataTable dttemp = Peerfx_DB.SPs.ViewInfoCurrenciesSpecific(currencykey).GetDataSet().Tables[0];
            if (dttemp.Rows[0]["country_value"] != DBNull.Value)
            {
                strreturn = dttemp.Rows[0]["country_value"].ToString();
            }

            return strreturn;
        }

        public int getCountryFromCurrency(int currencykey)
        {
            int intreturn = 0;

            DataTable dttemp = Peerfx_DB.SPs.ViewInfoCurrenciesSpecific(currencykey).GetDataSet().Tables[0];
            if (dttemp.Rows[0]["info_country_key"] != DBNull.Value)
            {
                intreturn = Convert.ToInt32(dttemp.Rows[0]["info_country_key"].ToString());
            }

            return intreturn;
        }

        public string getCountryValue(int countrykey)
        {
            string strreturn = "GB";

            DataTable dttemp = Peerfx_DB.SPs.ViewInfoCountrySpecific(countrykey).GetDataSet().Tables[0];
            if (dttemp.Rows[0]["country_value"] != DBNull.Value)
            {
                strreturn = dttemp.Rows[0]["country_value"].ToString();
            }

            return strreturn;
        }

        public int getCountryKeyFromCurrency(int currencykey)
        {
            int intreturn = 0;

            DataTable dttemp = Peerfx_DB.SPs.ViewInfoCurrenciesSpecific(currencykey).GetDataSet().Tables[0];
            if (dttemp.Rows[0]["info_country_key"] != DBNull.Value)
            {
                intreturn = Convert.ToInt32(dttemp.Rows[0]["info_country_key"].ToString());
            }

            return intreturn;
        }

        public Boolean getCurrency_Allowlocalbankaccount(int currency)
        {
            DataTable dttemp = Peerfx_DB.SPs.ViewInfoCurrenciesSpecific(currency).GetDataSet().Tables[0];
            Boolean allowlocalbankaccount = false;

            if (dttemp.Rows[0]["allow_local_bankaccount"] != DBNull.Value)
            {
                allowlocalbankaccount = Convert.ToBoolean(dttemp.Rows[0]["allow_local_bankaccount"]);
            }            

            return allowlocalbankaccount;
        }

        public Boolean isValidateBankAccount(int currency)
        {
            DataTable dttemp = Peerfx_DB.SPs.ViewInfoCurrenciesSpecific(currency).GetDataSet().Tables[0];
            Boolean validatebankaccount = false;

            if (dttemp.Rows[0]["verify_bank_account"] != DBNull.Value)
            {
                validatebankaccount = Convert.ToBoolean(dttemp.Rows[0]["verify_bank_account"]);
            }

            return validatebankaccount;
        }

        public string ConvertHashtabletoString(Hashtable hstemp)
        {            
            StringBuilder requestString = new StringBuilder();

            if (hstemp != null)
            {
                foreach (DictionaryEntry Item in hstemp)
                {
                    if (requestString.Length == 0)
                    {
                        requestString.Append(Item.Key + "=" + Item.Value);
                    }
                    else
                    {
                        requestString.Append("&" + Item.Key + "=" + Item.Value);
                    }
                }
            }

            return requestString.ToString();
        }

        public decimal get_user_balance_specific_currency(int userkey, int currency)
        {
            decimal balance = 0;
            DataTable dttemp = Peerfx_DB.SPs.ViewUserBalanceSpecificCurrency(userkey, currency).GetDataSet().Tables[0];
            if (dttemp.Rows[0]["user_balance"] != DBNull.Value)
            {
                balance = Convert.ToDecimal(dttemp.Rows[0]["user_balance"]);
            }

            return balance;
        }

        public decimal get_treasury_balance_specific_currency(int currency)
        {
            Users treasury = get_treasury_account(1);
            return get_user_balance_specific_currency(treasury.User_key, currency);
        }

        public Boolean Iscanofferpremium(int currency1, int currency2, decimal amount2)
        {
            Boolean offerpremium = true;
            //Check Currency Pairing Treasury Type
            int treasurytype = gettreasurytype(currency1, currency2);
            if (treasurytype != 1)
            {
                offerpremium = false;
            }

            //check if payment is below $1001
            if (amount2 > 1000)
            {
                offerpremium = false;
            }

            //check if enough liquidity in treasury
            decimal treasurybalance = get_treasury_balance_specific_currency(currency2);
            if (amount2 > treasurybalance)
            {
                offerpremium = false;
            }

            return offerpremium;
        }

        public string getPaymentTimingDescription(int typeid)
        {
            DataTable dttemp = Peerfx_DB.SPs.ViewPaymentTimingTypesSpecific(typeid).GetDataSet().Tables[0];
            string strreturn = "";
            if (dttemp.Rows[0]["payment_timing_description"] != DBNull.Value)
            {
                strreturn = dttemp.Rows[0]["payment_timing_description"].ToString();
            }

            return strreturn;
        }

        public Boolean isCurrencyCanhold(int currency)
        {
            Boolean canhold = false;
            DataTable dtcurrencies = Peerfx_DB.SPs.ViewInfoCurrenciesSpecific(currency).GetDataSet().Tables[0];
            if (Convert.ToBoolean(dtcurrencies.Rows[0]["info_currency_canhold"]))
            {
                canhold = true;     
            }
            return canhold;
        }

        public CurrencyCloudTrade getCurrencyCloudTrade(Int64 currencycloud_trade_key)
        {
            CurrencyCloudTrade cctemp = new CurrencyCloudTrade();
            cctemp.Currencycloud_trade_key = currencycloud_trade_key;

            DataTable dttemp = Peerfx_DB.SPs.ViewCurrencyCloudTradesSpecific(currencycloud_trade_key).GetDataSet().Tables[0];
            if (dttemp.Rows[0]["payments_key"] != DBNull.Value)
            {
                cctemp.Payments_key = Convert.ToInt32(dttemp.Rows[0]["payments_key"]);
            }
            if (dttemp.Rows[0]["settlement_key"] != DBNull.Value)
            {
                cctemp.Settlement_key = Convert.ToInt64(dttemp.Rows[0]["settlement_key"]);
            }
            if (dttemp.Rows[0]["initiated_date"] != DBNull.Value)
            {
                cctemp.Initiated_date = Convert.ToDateTime(dttemp.Rows[0]["initiated_date"]);
            }
            if (dttemp.Rows[0]["settlement_date"] != DBNull.Value)
            {
                cctemp.Settlement_date = Convert.ToDateTime(dttemp.Rows[0]["settlement_date"]);
            }
            if (dttemp.Rows[0]["cc_tradeid"] != DBNull.Value)
            {
                cctemp.Cc_tradeid = dttemp.Rows[0]["cc_tradeid"].ToString();
            }
            return cctemp;
        }

        public Int64 getCurrencyCloudSettlementKey_From_ccsettlementid(string ccsettlementid)
        {
            Int64 settlementkey = 0;
            DataTable dttemp = Peerfx_DB.SPs.ViewCurrencyCloudSettlementSpecificCcsettlementid(ccsettlementid).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                settlementkey = Convert.ToInt64(dttemp.Rows[0]["currencycloud_settlement_key"]);
            }
            return settlementkey;
        }


        public Boolean InternalTransaction(int currency, decimal amount, Int64 senderpaymentobject, Int64 receiverpaymentobject, int userkey, string description, int purposetype, int purposeobject)
        {
            Boolean completed = false;
            try
            {
                Peerfx_DB.SPs.UpdateTransactionsInternal(0, 2, currency, amount, senderpaymentobject, receiverpaymentobject, get_ipaddress(), userkey, description, 0, purposetype, purposeobject).Execute();
                completed = true;
            }
            catch
            {
                completed = false;
            }
            return completed;
        }

        public void VerificationReward(int verificationtype, int userkey)
        {
            Users treasury = get_treasury_account(1);
            Int64 senderpaymentobject =  getpaymentobject_UserBalance(treasury.User_key, 2);
            Int64 receiverpaymentobject = getpaymentobject_UserBalance(userkey,2);
            InternalTransaction(2, 50, senderpaymentobject, receiverpaymentobject, userkey, "Verification Reward", 3, 0);
        }

        public bool IsValidEmail(string strIn)
        {
            bool invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper);
            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn,
                   @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                   @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                   RegexOptions.IgnoreCase);
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                 bool invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        public string getTimezoneName(string timezoneid){
            string strreturn = "";
            if (timezoneid == null)
            {
                timezoneid = "UTC";
            }
            TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(timezoneid);
            if (zone.IsDaylightSavingTime(DateTime.Now))
            {
                strreturn = zone.DaylightName;
            }
            else
            {
                strreturn = zone.StandardName;
            }            

            return strreturn;
        }

        /*
        public void inserttimezones()
        {
            var infos = TimeZoneInfo.GetSystemTimeZones();
            foreach (var info in infos)
            {
                Peerfx_DB.SPs.UpdateInfoTimezones(info.Id, info.DisplayName).Execute();
                
            }
        }*/

        public int getTimezoneOffset(string timezoneid)
        {
            if (timezoneid == null)
            {
                timezoneid = "UTC";
            }
            int intreturn = 0;
            TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(timezoneid);
            intreturn = Convert.ToInt32(zone.GetUtcOffset(DateTime.Now).TotalHours);
            return intreturn;
        }

        public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes
                  = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue
                  = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        public void SaveImagefromInternet(string file, string imgurl)
        {            
            byte[] imageBytes;
            HttpWebRequest imageRequest = (HttpWebRequest)WebRequest.Create(imgurl);
            WebResponse imageResponse = imageRequest.GetResponse();

            Stream responseStream = imageResponse.GetResponseStream();

            using (BinaryReader br = new BinaryReader(responseStream))
            {
                imageBytes = br.ReadBytes(500000);
                br.Close();
            }
            responseStream.Close();
            imageResponse.Close();

            FileStream fs = new FileStream(file, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            try
            {
                bw.Write(imageBytes);
            }
            finally
            {
                fs.Close();
                bw.Close();
            }
        }

        public decimal getAmountinOtherCurrency(decimal amount, int currency1, int currency2)
        {
            decimal amount2 = 0;

            StoredProcedure spviewamount = Peerfx_DB.SPs.ViewAmountInOtherCurrency(amount, currency1, currency2,0);
            spviewamount.Execute();
            amount2 = Convert.ToDecimal(spviewamount.Command.Parameters[3].ParameterValue);            

            return amount2;
        }

    }    
}