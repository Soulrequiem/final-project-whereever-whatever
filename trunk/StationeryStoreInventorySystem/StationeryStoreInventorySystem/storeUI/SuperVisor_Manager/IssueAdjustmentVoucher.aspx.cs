using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.SuperVisor_Manager
{
    public partial class IssueAdjustmentVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VoucherNo");
            dt.Columns.Add("CreatedBy");
            dt.Columns.Add("CreatedDate");
            dt.Columns.Add("TotalQty");
            dt.Columns.Add("Status");

            DataRow dr = dt.NewRow();
            dr[0] = "Hello";
            dr[1] = "1";
            dr[2] = "1";
            dr[3] = "1";
            dr[4] = "1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Hello";
            dr[1] = "1";
            dr[2] = "1";
            dr[3] = "1";
            dr[4] = "1";
            dt.Rows.Add(dr);

            DgvDiscrepancyReportList.ClearDataSource();
            DgvDiscrepancyReportList.DataSource = dt;
            DgvDiscrepancyReportList.DataBind();


            DataTable dtt = new DataTable();
            dtt.Columns.Add("ItemNo");
            dtt.Columns.Add("ItemDescription");
            dtt.Columns.Add("Quantity");
            dtt.Columns.Add("PricePerItem");
            dtt.Columns.Add("Reason");

            DataRow drr = dtt.NewRow();
            drr[0] = "Hello";
            drr[1] = "1";
            drr[2] = "1";
            drr[3] = "1";
            drr[4] = "1";
            dtt.Rows.Add(drr);

            drr = dtt.NewRow();
            drr[0] = "Hello";
            drr[1] = "1";
            drr[2] = "1";
            drr[3] = "1fadf";
            drr[4] = "1fdfd";
            dtt.Rows.Add(drr);

            DgvDiscrepancyReport.ClearDataSource();
            DgvDiscrepancyReport.DataSource = dtt;
            DgvDiscrepancyReport.DataBind();
        }
    }
}