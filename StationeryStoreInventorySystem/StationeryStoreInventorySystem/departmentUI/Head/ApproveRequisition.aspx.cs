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
        public static readonly string sessionKey = "ApproveRequisition";
        //private static readonly string selectedSessionKey = "ApproveRequisitionSelectedIndex";
        //private static readonly string remarksSessionKey = "ApproveRequisitionRemarks";

        private ApproveRejectRequisitionControl aprCtrl;
        //private List<int> selectedIndexList;
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
                //selectedIndexList = new List<int>();

                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, aprCtrl);
                //StationeryStoreInventorySystemController.Util.PutSession(selectedSessionKey, selectedIndexList);
                //StationeryStoreInventorySystemController.Util.PutSession(remarksSessionKey, remarksList);
            }
            else
            {
                aprCtrl = (ApproveRejectRequisitionControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
                //selectedIndexList = (List<int>)StationeryStoreInventorySystemController.Util.GetSession(selectedSessionKey);
                //remarksList = (Dictionary<string, string>)StationeryStoreInventorySystemController.Util.GetSession(remarksSessionKey);
            }
            FillRequisitionList();
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
            //StationeryStoreInventorySystemController.Util.RemoveSession(selectedSessionKey);
            //StationeryStoreInventorySystemController.Util.RemoveSession(remarksSessionKey);
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
            //selectedIndexList = new List<int>();
            DgvRequisitionList.Rows.Clear();
            FillRequisitionList();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            prepareData();

            if (aprCtrl.SelectApproveRequisition(remarksList) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            {
                refresh();
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            prepareData();

            if (aprCtrl.SelectRejectRequisition(remarksList) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            {
                refresh();
            }
        }

        private void prepareData()
        {
            remarksList = new Dictionary<string, string>();

            for (int i = 0; i < DgvRequisitionList.Rows.Count; i++)
            {
                if (SystemStoreInventorySystemUtil.Converter.objToBool(DgvRequisitionList.Rows[i].Items.FindItemByKey("ApproveRequisitionCheckBox").Value) == true)
                {
                    remarksList.Add(i.ToString(), ((Infragistics.Web.UI.EditorControls.WebTextEditor)DgvRequisitionList.Rows[i].Items.FindItemByKey("Remarks").FindControl("Remarks")).Text);
                    DgvRequisitionList.Rows[i].Items.FindItemByKey("ApproveRequisitionCheckBox").Value = false;
                }
            }
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/