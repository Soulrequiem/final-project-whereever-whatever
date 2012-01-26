using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Employee
{
    public partial class CheckRequisition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CheckRequisitionCheckBox");
            dt.Columns.Add("RequisitionID");
            dt.Columns.Add("RequisitionDate/Time");
            dt.Columns.Add("status");
            dt.Columns.Add("RemainingQty");
            dt.Columns.Add("Remarks");

            DataRow dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "1";
            dr[2] = "1we2we12321";
            dr[3] = "1213sadsad";
            dr[4] = "1ssdsfdf";
            
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "1";
            dr[2] = "1we2we12321";
            dr[3] = "1213sadsad";
            dr[4] = "1ssdsfdf";
           
            dt.Rows.Add(dr);

            dgvRequisitionList.DataSource = dt;
            dgvRequisitionList.DataBind();


            DataTable dtt = new DataTable();
            dtt.Columns.Add("ItemNo");
            dtt.Columns.Add("ItemDescription");
            dtt.Columns.Add("RequiredQty");
            dtt.Columns.Add("ReceivedQty");
            dtt.Columns.Add("RemainingQty");
            //dtt.Columns.Add("Remarks");

            DataRow drr = dtt.NewRow();
            drr[0] = "1";
            drr[1] = "1";
            drr[2] = "1we2we12321";
            drr[3] = "1213sadsad";
            //drr[4] = "1ssdsfdf";

            dtt.Rows.Add(drr);

            drr = dtt.NewRow();
            drr[0] = "1";
            drr[1] = "1";
            drr[2] = "1we2we12321";
            drr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";

            dtt.Rows.Add(drr);

            dgvRequisitionDetails.DataSource = dtt;
            dgvRequisitionDetails.DataBind();
        }
    }
}