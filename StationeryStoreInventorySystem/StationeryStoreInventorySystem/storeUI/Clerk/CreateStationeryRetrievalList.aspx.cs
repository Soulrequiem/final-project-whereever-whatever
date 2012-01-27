using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class CreateStationeryRetrievalList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CreateStationeryRetrievalListControl CSRobj = new CreateStationeryRetrievalListControl();
            //DataTable dt = CSRobj.GetStationerRetrivalList();
            //FillStationeryRetrievalList();

            DataTable dt = new DataTable();
            dt.Columns.Add("CreateStationeryRetrievalListCheckBox");
            dt.Columns.Add("CollectionID");
            dt.Columns.Add("CollectionDate/Time");
            dt.Columns.Add("Department");
            dt.Columns.Add("DepartmentStatus");

            DataRow dr = dt.NewRow();
            dr[0] = "1";
            dr[1] = "1";
            dr[2] = "1";
            dr[3] = "1";
            dr[4] = "1";
            dt.Rows.Add(dr);
            DgvCreateStationeryRetrievalList.ClearDataSource();
            DgvCreateStationeryRetrievalList.DataSource = dt;
            DgvCreateStationeryRetrievalList.DataBind();
        }
        private void FillStationeryRetrievalList(DataTable dtStationeryRetrivealList)
        {
            try
            {
                if (dtStationeryRetrivealList != null)
                    DgvCreateStationeryRetrievalList.DataSource = dtStationeryRetrivealList;
                    DgvCreateStationeryRetrievalList.DataBind();
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }

        }

    }
}