using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative
{
    public partial class UpdateCollectionByItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CollectionID");
            dt.Columns.Add("CollectionPoint");
            dt.Columns.Add("CollectionDay");
            dt.Columns.Add("CollectionDateTime");
            dt.Columns.Add("CollectionStatus");
            dt.Columns.Add("Status");
            //dt.Columns.Add("Remarks");

            DataRow dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "1";
            dr[2] = "1";
            dr[3] = "1213sadsad";
            dr[4] = "1ssdsfdf";
            dr[5] = "1ssdsfdf";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "1";
            dr[2] = "1";
            dr[3] = "1213sadsad";
            dr[4] = "1ssdsfdf";
            dr[5] = "1ssdsfdf";
            dt.Rows.Add(dr);

            dgvCollectionList.DataSource = dt;
            dgvCollectionList.DataBind();


            DataTable dtt = new DataTable();
            dtt.Columns.Add("ItemNo");
            dtt.Columns.Add("ItemDescription");
            dtt.Columns.Add("RequiredQty");
            dtt.Columns.Add("ActualQty");
            //dtt.Columns.Add("JoiningDate");
            //dt.Columns.Add("RemainingQty");
            //dt.Columns.Add("Remarks");

            DataRow drr = dtt.NewRow();
            drr[0] = "1";
            drr[1] = "1";
            drr[2] = "1we2we12321";
            //drr[3] = "1213sadsad";
            //drr[4] = "1ssdsfdf";
            //dr[5] = "1ssdsfdf";
            dtt.Rows.Add(drr);

            drr = dtt.NewRow();
            drr[0] = "1";
            drr[1] = "1";
            drr[2] = "1we2we12321";
            //drr[3] = "1213sadsad";
            //drr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            dtt.Rows.Add(drr);

            dgvItems.DataSource = dtt;
            dgvItems.DataBind();
        }
    }
}