using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Peerfx.Models;
using System.Data;  

namespace Peerfx.Admin
{
    public partial class Admin_Payment_Schedule : System.Web.UI.Page
    {
        Site sitetemp = new Site();
        Users currentuser;

        protected void Page_Load(object sender, EventArgs e)
        {
            //checks if admin
            //currentuser = sitetemp.getcurrentuser(true);
            if (!IsPostBack)
            {

            }
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DataSet dstemp = Peerfx_DB.SPs.ViewPaymentSchedule().GetDataSet();
            RadGrid1.DataSource = dstemp.Tables[0];
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
        }


        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {                
                GridDataItem item = (GridDataItem)e.Item;
                DataRowView row = (DataRowView)e.Item.DataItem;
                item["payment_schedule_key"].Text = row["payment_schedule_key"].ToString();
                item["currency_code_sender"].Text = row["currency_code_sender"].ToString();
                item["currency_code_receiver"].Text = row["currency_code_receiver"].ToString();
            }
            if (e.Item is GridEditableItem && (e.Item as GridEditableItem).IsInEditMode)
            {
                RadComboBox ddlcurrency1 = (RadComboBox)e.Item.FindControl("ddlcurrency1");
                ddlcurrency1.DataTextField = "info_currency_code";
                ddlcurrency1.DataValueField = "info_currencies_key";
                ddlcurrency1.DataSource = sitetemp.view_info_currencies();
                ddlcurrency1.DataBind();
                ddlcurrency1.MarkFirstMatch = true;

                RadComboBox ddlcurrency2 = (RadComboBox)e.Item.FindControl("ddlcurrency2");
                ddlcurrency2.DataTextField = "info_currency_code";
                ddlcurrency2.DataValueField = "info_currencies_key";
                ddlcurrency2.DataSource = sitetemp.view_info_currencies();
                ddlcurrency2.DataBind();
                ddlcurrency2.MarkFirstMatch = true;

                if (e.Item is GridEditFormInsertItem || e.Item is GridDataInsertItem)
                {
                }
                else
                {
                    DataRowView row = (DataRowView)e.Item.DataItem;
                    ddlcurrency1.SelectedValue = row["currency_sender"].ToString();
                    ddlcurrency2.SelectedValue = row["currency_receiver"].ToString();
                }
            }
        }

        protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        {
        }

        protected void RadGrid1_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
        {
            GridEditFormInsertItem insertedItem = (GridEditFormInsertItem)e.Item;
        }

    }
}