/***************************************************************************/
/*  File Name       : ApproveRequisition.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : ApproveRequisition
/*  Details         : Form for Approve Requisition
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.departmentController;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Head
{
    public partial class ApproveRequisition : System.Web.UI.Page
    {
        private static readonly string sessionKey = "ApproveRequisition";
        private static readonly string selectedSessionKey = "ApproveRequisitionSelectedIndex";
        private static readonly string remarksSessionKey = "ApproveRequisitionRemarks";

        private ApproveRejectRequisitionControl aprCtrl;
        private List<int> selectedIndexList;
        private Dictionary<string, string> remarksList;
        /// <summary>
        /// Loads the ApproveRequisition form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                commonUI.MasterPage.setCurrentPage(this);
                aprCtrl = GetControl();
                selectedIndexList = new List<int>();
                remarksList = new Dictionary<string, string>();

                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, aprCtrl);
                StationeryStoreInventorySystemController.Util.PutSession(selectedSessionKey, selectedIndexList);
                StationeryStoreInventorySystemController.Util.PutSession(remarksSessionKey, remarksList);
            }
            else
            {
                aprCtrl = (ApproveRejectRequisitionControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
                selectedIndexList = (List<int>)StationeryStoreInventorySystemController.Util.GetSession(selectedSessionKey);
                remarksList = (Dictionary<string, string>)StationeryStoreInventorySystemController.Util.GetSession(remarksSessionKey);
            }
            FillRequisitionList();
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
            StationeryStoreInventorySystemController.Util.RemoveSession(selectedSessionKey);
            StationeryStoreInventorySystemController.Util.RemoveSession(remarksSessionKey);
        }

        /// <summary>
        /// Fill data to DataGrid
        /// </summary>
        /// <param name="dtApprove"></param>
        private void FillRequisitionList()
        {
            try
            {
                DgvRequisitionList.DataSource = aprCtrl.PendingRequisitionList;
                DgvRequisitionList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        private ApproveRejectRequisitionControl GetControl()
        {
            if (aprCtrl == null)
                aprCtrl = new ApproveRejectRequisitionControl();
            return aprCtrl;
        }

        private void refresh()
        {
            selectedIndexList = new List<int>();
            DgvRequisitionList.Rows.Clear();
            FillRequisitionList();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (aprCtrl.SelectApproveRequisition(selectedIndexList, (DataTable)DgvRequisitionList.DataSource) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            {
                refresh();
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (aprCtrl.SelectRejectRequisition(selectedIndexList, (DataTable)DgvRequisitionList.DataSource) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            {
                refresh();
            }
        }
        //protected void DgvRequisitionList_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e != null)
        //        {
        //            int currentPageIndex = DgvRequisitionList.Behaviors.Paging.PageIndex * DgvRequisitionList.Behaviors.Paging.PageSize;
        //            if (selectedIndexList.Contains(e.CurrentSelectedRows[0].Index + currentPageIndex))
        //            {
        //                selectedIndexList.Remove(e.CurrentSelectedRows[0].Index + currentPageIndex);
        //            }
        //            else
        //            {
        //                selectedIndexList.Add(e.CurrentSelectedRows[0].Index + currentPageIndex);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // do something here later
        //    }
        //}

        protected void DgvRequisitionList_CellSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedCellEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    if (e.CurrentSelectedCells[0].Index == 0)
                    {
                        //((Infragistics.Web.UI.EditorControls.WebTextEditor)e.CurrentSelectedCells[0].FindControl("Remarks")).ID;
                        int currentPageIndex = DgvRequisitionList.Behaviors.Paging.PageIndex * DgvRequisitionList.Behaviors.Paging.PageSize;
                        int currentRow = e.CurrentSelectedCells[0].Row.Index;
                        if (selectedIndexList.Contains(currentRow + currentPageIndex))
                        {
                            selectedIndexList.Remove(currentRow + currentPageIndex);
                        }
                        else
                        {
                            selectedIndexList.Add(currentRow + currentPageIndex);
                        }                        
                    }
                }
            }
            catch (Exception ex)
            {
                // do something here later
            }
        }   
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/