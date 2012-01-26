using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Employee
{
    public partial class RequestStationery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemNo");
            dt.Columns.Add("ItemDescription");
            //dt.Columns.Add("AddToTable");
            //dt.Columns.Add("status");
            //dt.Columns.Add("RemainingQty");
            //dt.Columns.Add("Remarks");

            DataRow dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            //dr[5] = "1ssdsfdf";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            //dr[5] = "1ssdsfdf";
            dt.Rows.Add(dr);

            dgvStationeryList.DataSource = dt;
            dgvStationeryList.DataBind();


            DataTable dtt = new DataTable();
            dtt.Columns.Add("RequestStationeryCheckBox");
            dtt.Columns.Add("ItemNo");
            dtt.Columns.Add("ItemDescription");
            dtt.Columns.Add("RequiredQty");
            //dt.Columns.Add("status");
            //dt.Columns.Add("RemainingQty");
            //dt.Columns.Add("Remarks");

            DataRow drr = dtt.NewRow();
            drr[0] = "1";
            drr[1] = "1";
            drr[2] = "1we2we12321";
            //drr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            //dr[5] = "1ssdsfdf";
            dtt.Rows.Add(drr);

            drr = dtt.NewRow();
            drr[0] = "1";
            drr[1] = "1";
            drr[2] = "1we2we12321";
            //drr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            //dr[5] = "1ssdsfdf";
            dtt.Rows.Add(drr);

            dgvStationeryDetailsList.DataSource = dtt;
            dgvStationeryDetailsList.DataBind();
        }
    }
}