using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.SuperVisor_Manager
{
    public partial class BlackListDepartment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DepartmentName");
            dt.Columns.Add("MissedTime");
            dt.Columns.Add("Status");
            dt.Columns.Add("Remarks");
            dt.Columns.Add("BlackUnblackList");

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

            DgvDepartmentList.ClearDataSource();
            DgvDepartmentList.DataSource = dt;
            DgvDepartmentList.DataBind();
        }
    }
}