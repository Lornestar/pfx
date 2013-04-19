using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using Peerfx.Models;


namespace Peerfx.User_Controls
{
    public partial class Admin_ScheduledTask_CurrencyCloud : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();

        protected void Page_Load(object sender, EventArgs e)
        {
            LastUpdated();
        }

        public void LastUpdated()
        {
            DataTable dttemp = Peerfx_DB.SPs.ViewScheduledTask(2).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0]["date_changed"] != DBNull.Value)
                {
                    lblrun1lasttime.Text = dttemp.Rows[0]["date_changed"].ToString();
                }
            }

            dttemp = Peerfx_DB.SPs.ViewScheduledTask(3).GetDataSet().Tables[0];
            if (dttemp.Rows.Count > 0)
            {
                if (dttemp.Rows[0]["date_changed"] != DBNull.Value)
                {
                    lblrun2lasttime.Text = dttemp.Rows[0]["date_changed"].ToString();
                }
            }

            DataTable dttrades = Peerfx_DB.SPs.ViewCurrencyCloudTradesAwaitingSettlement(1).GetDataSet().Tables[0];
            lblpendingtrades1.Text = dttrades.Rows.Count.ToString();

            dttrades = Peerfx_DB.SPs.ViewCurrencyCloudTradesAwaitingSettlement(2).GetDataSet().Tables[0];
            lblpendingtrades2.Text = dttrades.Rows.Count.ToString();
        }

        protected void btndorun1_Click(object sender, EventArgs e)
        {
            ScheduledTasks.CurrencyCloud_Settlements ccs = new ScheduledTasks.CurrencyCloud_Settlements();
            ccs.dorun(1);
            LastUpdated();
        }

        protected void btndorun2_Click(object sender, EventArgs e)
        {
            ScheduledTasks.CurrencyCloud_Settlements ccs = new ScheduledTasks.CurrencyCloud_Settlements();
            ccs.dorun(2);
            LastUpdated();
        }

        protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //show all trades 
            RadGrid1.DataSource = Peerfx_DB.SPs.ViewCurrencyCloudTradesAwaitingSettlementAll().GetDataSet().Tables[0];
        }

        protected void RadGrid2_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            //show all trade errors
            RadGrid2.DataSource = Peerfx_DB.SPs.ViewCurrencyCloudTradesErrors().GetDataSet();
        }

        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "btntradedetails")
            {
                GridDataItem item = (GridDataItem)e.Item;
                int paymentkey = Convert.ToInt32(item["payments_key"].Text);
                LoadTradeDetails(paymentkey);
                pnltradedetails.Visible = true;
            }
        }

        protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            //default values

        }

        protected void RadGrid2_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
        }

        protected void LoadTradeDetails(int paymentskey)
        {
            Paymentdetails1.LoadInfo(paymentskey);
            Payment paymenttemp = sitetemp.getPayment(paymentskey);
            CCTradeDetails1.LoadInfo(paymenttemp.Currencycloudtradeid);
        }

        protected void btnretryTrades_Click(object sender, EventArgs e)
        {
            External_APIs.CurrencyCloud cc = new External_APIs.CurrencyCloud();
            DataTable dttemp = Peerfx_DB.SPs.ViewCurrencyCloudTradesErrors().GetDataSet().Tables[0];
            foreach (DataRow dr in dttemp.Rows)
            {
                cc.Trade_Execute(Convert.ToInt32(dr["payments_key"]));
            }
            RadGrid1.Rebind();
            RadGrid2.Rebind();
        }

    }
}