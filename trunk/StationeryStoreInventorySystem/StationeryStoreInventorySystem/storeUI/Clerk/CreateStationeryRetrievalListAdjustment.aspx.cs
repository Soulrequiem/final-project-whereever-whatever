using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class CreateStationeryRetrievalListAdjustment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DepartmentCode");
            dt.Columns.Add("Needed");
            dt.Columns.Add("Actual");

            DataRow dr = dt.NewRow();
            dr[0] = "Hello";
            dr[1] = "1";
            dt.Rows.Add(dr);

            dgvItemList.ClearDataSource();
            dgvItemList.DataSource = dt;
            dgvItemList.DataBind();
        }
    }
}