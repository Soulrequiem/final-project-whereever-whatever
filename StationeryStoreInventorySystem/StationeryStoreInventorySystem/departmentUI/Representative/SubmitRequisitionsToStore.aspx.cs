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
        SubmitRequestToStoreControl srtsCtrl;

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
                DataTable dt = GetsrtsControl().GetApprovedRequisition();
                FillRequisitionList(dt);
            }
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
        private void FillRequisitionList(DataTable dtRequisition)
        {
            try
            {
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
                GetsrtsControl().SelectSubmit();
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/