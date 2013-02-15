using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.External_APIs;

namespace Peerfx
{
    public partial class CustomError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewErrorsLastone().GetDataSet();
            string strEventTime = "Time";
            if (dstemp.Tables[0].Rows[0]["EventTime"] != DBNull.Value)
            {
                strEventTime = dstemp.Tables[0].Rows[0]["EventTime"].ToString();
            }
            string strRequestURL = "URL";
            if (dstemp.Tables[0].Rows[0]["RequestURL"] != DBNull.Value)
            {
                strRequestURL = dstemp.Tables[0].Rows[0]["RequestURL"].ToString();
            }
            string strDetails = "Details";
            if (dstemp.Tables[0].Rows[0]["Details"] != DBNull.Value)
            {
                strDetails = dstemp.Tables[0].Rows[0]["Details"].ToString();
            }

            string thebody = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Emails/ErrorEmail.txt"));
            thebody = thebody.Replace("TIMEERROR", strEventTime);
            thebody = thebody.Replace("URLERROR", strRequestURL);
            thebody = thebody.Replace("DETAILSERROR", strDetails);
            string Toemail = System.Configuration.ConfigurationSettings.AppSettings.Get("ErrorToEmail").ToString();

            SendGrid sg = new SendGrid();
            sg.SimpleEmail("Lorne", "Peerfx Error", Toemail, "Error@peerfx.com", thebody, "Peerfx Error");
        }
    }
}