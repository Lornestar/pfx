using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Peerfx
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        public DataTable view_users_info(int userkey)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewUsersInfo(userkey).GetDataSet();
            return dstemp.Tables[0];
        }
    }
}