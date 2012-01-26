using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class GenerateDisbursement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("RetrievalNo");
            dt.Columns.Add("RetrievalDate/Time");
            dt.Columns.Add("RetrievedQty");
            dt.Columns.Add("RetrievedBy");

            DataRow dr = dt.NewRow();
            dr[0] = "Hello";
            dr[1] = "1";
            dr[2] = "1";
            dr[3] = "1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Hello";
            dr[1] = "1";
            dr[2] = "1";
            dr[3] = "1";
            dt.Rows.Add(dr);

            DgvGenerateDisbursement.ClearDataSource();
            DgvGenerateDisbursement.DataSource = dt;
            DgvGenerateDisbursement.DataBind();
        }
    }
}