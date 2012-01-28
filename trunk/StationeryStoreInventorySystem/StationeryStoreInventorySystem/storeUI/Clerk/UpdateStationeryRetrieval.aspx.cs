/***************************************************************************/
/*  File Name       : UpdateStationeryRetrieval.cs
/*  Module Name     : UI
/*  Owner           : JinChengCheng
/*  class Name      : UpdateStationeryRetrieval
/*  Details         : UI representation of UpdateStationeryRetrievalUI 
/***************************************************************************/
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
        string select_collectionId; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateStationeryRetrievalControl USRobj=new UpdateStationeryRetrievalControl();
                DataTable dt = USRobj.GetCollectionIDList();
                FillCollectionList(dt);
            }
            //DataTable dt = new DataTable();
            //dt.Columns.Add("CollectionID");
            //dt.Columns.Add("CollectionPoint");
            //dt.Columns.Add("CollectionDate/Time");
            //dt.Columns.Add("DeptRepresentativeName");
            //dt.Columns.Add("DepartmentName");
            //dt.Columns.Add("CollectionStatus");

            //DataRow dr = dt.NewRow();
            //dr[0] = "Hello";
            //dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1";
            //dr[4] = "1";
            //dr[5] = "1";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "Hello";
            //dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1";
            //dr[4] = "1";
            //dr[5] = "1";
            //dt.Rows.Add(dr);

            //dgvCollections.ClearDataSource();
            //dgvCollections.DataSource = dt;
            //dgvCollections.DataBind();
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

        protected void btnCollected_Click(object sender, EventArgs e)
        { 
            List<string> collectionIdList=new List<string>();
            collectionIdList.Add(select_collectionId);
            UpdateStationeryRetrievalControl USRobj = new UpdateStationeryRetrievalControl();
            USRobj.SetCollectionStatus(SystemStoreInventorySystemUtil.Constants.COLLECTION_STATUS.UNCOLLECTED,collectionIdList);
        }

        protected void btnNotCollected_Click(object sender, EventArgs e)
        {
            List<string> collectionIdList = new List<string>();
            collectionIdList.Add(select_collectionId);
            UpdateStationeryRetrievalControl USRobj = new UpdateStationeryRetrievalControl();
            USRobj.SetCollectionStatus(SystemStoreInventorySystemUtil.Constants.COLLECTION_STATUS.COLLECTED, collectionIdList);
        }

        protected void dgvCollections_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            select_collectionId = e.CurrentSelectedRows[0].Attributes["collectionId"].ToString();
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
