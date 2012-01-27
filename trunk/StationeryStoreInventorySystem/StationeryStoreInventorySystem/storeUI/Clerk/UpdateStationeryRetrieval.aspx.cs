using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.storeController;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class UpdateStationeryRetrieval : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //UpdateStationeryRetrievalControl USRobj=new UpdateStationeryRetrievalControl();
                //DataTable dt = USRobj.GetCollectionList();
                //FillCollectionList();
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("CollectionID");
            dt.Columns.Add("CollectionPoint");
            dt.Columns.Add("CollectionDate/Time");
            dt.Columns.Add("DeptRepresentativeName");
            dt.Columns.Add("DepartmentName");
            dt.Columns.Add("CollectionStatus");

            DataRow dr = dt.NewRow();
            dr[0] = "Hello";
            dr[1] = "1";
            dr[2] = "1";
            dr[3] = "1";
            dr[4] = "1";
            dr[5] = "1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Hello";
            dr[1] = "1";
            dr[2] = "1";
            dr[3] = "1";
            dr[4] = "1";
            dr[5] = "1";
            dt.Rows.Add(dr);

            dgvCollections.ClearDataSource();
            dgvCollections.DataSource = dt;
            dgvCollections.DataBind();
        }

        private void FillCollectionList(DataTable dtCollectionList)
        {
            try
            {
                if (dtCollectionList != null)
                    dgvCollections.DataSource = dtCollectionList;
                    dgvCollections.DataBind();
            }
            catch(Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }
    }
}