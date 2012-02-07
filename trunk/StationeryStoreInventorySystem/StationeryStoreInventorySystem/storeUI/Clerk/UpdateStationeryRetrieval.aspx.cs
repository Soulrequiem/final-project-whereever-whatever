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
        private static readonly string sessionKey = "UpdateStationeryRetrieval";
        //string select_collectionId;
        private UpdateStationeryRetrievalControl control;
        //private Dictionary<string, string> remarksList;
        private List<string> checkList;
        private List<string> idList;
        private List<string> idArray; 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                control = new UpdateStationeryRetrievalControl();
                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, control);

            

            }
            else
            {
                control = (UpdateStationeryRetrievalControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            DataTable dt = control.GetCollectionIDList();
            FillCollectionList(dt);
            
          
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
            //prepareData();
            //List<string> collectionIdList=new List<string>();
            //collectionIdList.Add(select_collectionId);
            CheckData();
            
            control.SetCollectionStatus(SystemStoreInventorySystemUtil.Constants.COLLECTION_STATUS.COLLECTED,idList);
            DataTable dt = control.GetCollectionIDList();
            FillCollectionList(dt);
            //Response.Write("Collected");
        }

        protected void btnNotCollected_Click(object sender, EventArgs e)
        {
            //prepareData();
            //List<string> collectionIdList = new List<string>();
            //collectionIdList.Add(select_collectionId);
            CheckData();

            control.SetCollectionStatus(SystemStoreInventorySystemUtil.Constants.COLLECTION_STATUS.UNCOLLECTED, idList);
            DataTable dt = control.GetCollectionIDList();
            FillCollectionList(dt);
            //Response.Write("Not Collected....");
        }

        //protected void dgvCollections_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        //{
        //    select_collectionId = e.CurrentSelectedRows[0].Attributes["collectionId"].ToString();
        //}


        private void prepareData()
        {
            //remarksList = new Dictionary<string, string>();
            checkList = new List<string>();

            for (int i = 0; i < dgvCollections.Rows.Count; i++)
            {
                if (SystemStoreInventorySystemUtil.Converter.objToBool(dgvCollections.Rows[i].Items.FindItemByKey("UpdateStationeryRetrievalCheckBox").Value) == true)
                {
                    //remarksList.Add(i.ToString(), (dgvCollections.Rows[i].Items.FindItemByKey("collectionId")).Text);
                    //checkList.Add((dgvCollections.Rows[i].Items.FindItemByKey("collectionId")).Text);
                }
            }
        }

        private void CheckData()
        {
            //List<int> selectedIndex = new List<int>();
            idList = new List<string>();

            for (int i = 0; i < dgvCollections.Rows.Count; i++)
            {
                if (SystemStoreInventorySystemUtil.Converter.objToBool(dgvCollections.Rows[i].Items.FindItemByKey("UpdateStationeryRetrievalCheckBox").Value) == true)
                {
                    //selectedIndex.Add(i);
                    idList.Add(dgvCollections.Rows[i].Items.FindItemByKey("CollectionID").Text);
                    dgvCollections.Rows[i].Items.FindItemByKey("UpdateStationeryRetrievalCheckBox").Value = false;
                    

                }
            }
        }

        //protected void DgvDepartmentList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        //{
        //    try
        //    {
        //        HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("BlackUnblackList").FindControl("BlackUnblackList");
        //        link.NavigateUrl = "~/storeUI/SuperVisor_Manager/BlackListDepartment.aspx?department=" + e.Row.DataKey[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }

        //}

        protected void dgvCollections_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            try
            {
                idArray = new List<string>();
                object[] array = e.Row.DataKey;
                foreach (object obj in array)
                {
                    idArray.Add(obj.ToString());
                }
                //idArray =(string[]) e.Row.DataKey;
                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
