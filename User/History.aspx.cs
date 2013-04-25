using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Peerfx.Models;
using Telerik.Web.UI;


namespace Peerfx.User
{
    public partial class History : System.Web.UI.Page
    {

        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentuser = sitetemp.getcurrentuser(false);
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentsRequestedbyuser(currentuser.User_key).GetDataSet();
            RadGrid1.DataSource = dstemp.Tables[0];

            GridSortExpression expression = new GridSortExpression();
            expression.FieldName = "date_created";
            expression.SortOrder = GridSortOrder.Descending;
            RadGrid1.MasterTableView.SortExpressions.AddSortExpression(expression);
        }


        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = (GridDataItem)e.Item;
                DataRowView row = (DataRowView)e.Item.DataItem;
                string paymentkey = row["payments_key"].ToString();
                HyperLink hyppayment = (HyperLink)item.FindControl("hyppayment");
                hyppayment.NavigateUrl = "/User/Payment.aspx?paymentkey=" + paymentkey;

                                
                DateTime datecreated = (DateTime)row["date_created"];
                item["datecreated"].Text = datecreated.AddHours(sitetemp.getTimezoneOffset(currentuser.Timezoneid)).ToString();
 
            }
        }

    }
}