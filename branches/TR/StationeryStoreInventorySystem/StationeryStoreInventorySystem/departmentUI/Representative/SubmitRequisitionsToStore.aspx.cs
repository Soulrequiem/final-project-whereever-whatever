﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative
{
    public partial class SubmitRequisitionsToStore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("EmployeeID");
            dt.Columns.Add("RequisitionID");
            dt.Columns.Add("RequisitionDateTime");
            dt.Columns.Add("RequisitionBy");
            dt.Columns.Add("RequisitionStatus");
            //dt.Columns.Add("RemainingQty");
            //dt.Columns.Add("Remarks");

            DataRow dr = dt.NewRow();
            dr[0] = "1vdvd";
            dr[1] = "1dvd";
            dr[2] = "1dvdv";
            dr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            //dr[5] = "1ssdsfdf";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "1dafd";
            dr[1] = "1vdv";
            dr[2] = "1vdvd";
            dr[3] = "1213sadsad";
            //dr[4] = "1ssdsfdf";
            //dr[5] = "1ssdsfdf";
            dt.Rows.Add(dr);

            dgvRequisitions.DataSource = dt;
            dgvRequisitions.DataBind();
        }
    }
}