/***************************************************************************/
/*  File Name       : SubmitRequisitionsToStore.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : SubmitRequisitionsToStore
/*  Details         : Form for Submit Requisitions To Store
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.departmentController;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative
{
    public partial class SubmitRequisitionsToStore : System.Web.UI.Page
    {
        private static readonly string sessionKey = "SubmitRequestToStore";

        private SubmitRequestToStoreControl srtsCtrl;

        private SubmitRequestToStoreControl GetsrtsControl()
        {
            if(srtsCtrl==null)
                srtsCtrl = new SubmitRequestToStoreControl();
            return srtsCtrl;
        }
        /// <summary>
        /// Loads the SubmitRequisitionsToStore form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                commonUI.MasterPage.setCurrentPage(this);
                srtsCtrl = GetsrtsControl();
                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, srtsCtrl);
                
                if (srtsCtrl.CollectionPoint.Equals(SubmitRequestToStoreControl.UNKNOWN_COLLECTION_POINT))
                {
                    btnSave.Enabled = false;
                }
                lblCollectionPoint.Text = srtsCtrl.CollectionPoint;
                lblCollectionID.Text = srtsCtrl.CollectionId;
            }
            else
            {
                srtsCtrl = (SubmitRequestToStoreControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            FillRequisitionList();
        }

        /// <summary>
        /// Fill Data of Labels
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FillRequsitionData(DataTable dtData)
        {
            try
            {
                if (dtData != null)
                {
                    lblCollectionID.Text = "ID";
                    lblCollectionPoint.Text = "Point";
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills Requisition list to DataGrid
        /// </summary>
        /// <param name="dtCollection"></param>
        private void FillRequisitionList()
        {
            try
            {
                srtsCtrl = GetsrtsControl();
                DataTable dtRequisition = srtsCtrl.ApprovedRequisitionList;
                dgvRequisitions.DataSource = dtRequisition;
                dgvRequisitions.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (srtsCtrl.SelectSubmit() == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
                {
                    // print success message
                    FillRequisitionList();
                }
                else
                {
                    // print error message
                }
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        protected void dgvRequisitions_DataFiltering(object sender,
            Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        {
            FillRequisitionList();
        }

        protected void dgvRequisitions_PageIndexChanged(object sender,
            Infragistics.Web.UI.GridControls.PagingEventArgs e)
        {
            FillRequisitionList();
        }

    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/