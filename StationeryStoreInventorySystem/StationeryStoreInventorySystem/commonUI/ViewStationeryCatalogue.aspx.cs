using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class ViewStationeryCatalogue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ItemNo");
            dt.Columns.Add("Category");
            dt.Columns.Add("ItemDescription");
            dt.Columns.Add("UnitOfMeasure");            

            DataRow dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "1we2we12321";
            dr[2] = "1213sadsad";
            dr[3] = "1ssdsfdf";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "1we2we12321";
            dr[2] = "1213sadsad";
            dr[3] = "1ssdsfdf";
            dt.Rows.Add(dr);

            dgvStationeryList.DataSource = dt;
            dgvStationeryList.DataBind();
        }
    }
}