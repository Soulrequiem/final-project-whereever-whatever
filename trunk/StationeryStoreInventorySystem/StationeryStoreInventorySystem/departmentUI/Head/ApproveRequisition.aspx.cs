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
        ApproveRejectRequisitionControl aprCtrl;
        /// <summary>
        /// Loads the ApproveRequisition form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRequisitionList();
            }
        }

        /// <summary>
        /// Fill data to DataGrid
        /// </summary>
        /// <param name="dtApprove"></param>
        private void FillRequisitionList()
        {
            try
            {
                aprCtrl = GetControl();
                DataTable dtApprove = aprCtrl.GetRequisition();
                DgvRequisitionList.DataSource = dtApprove;
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

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            //aprCtrl = GetControl();
            //aprCtrl.SelectApproveRequisition(
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/