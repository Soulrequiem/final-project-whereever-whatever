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
        }
    }
}