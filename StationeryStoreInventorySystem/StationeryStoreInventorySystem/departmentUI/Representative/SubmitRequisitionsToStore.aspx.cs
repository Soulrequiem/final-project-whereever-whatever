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
                //FillRequsitionData();
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
                    //lblDeptCode.Text = "Department Code";
                    //LblDeptName.Text = "Department Name";
                    //LblDeptName.Text = "Employee Name";
                    //lblEmployeeNumber.Text = "Employee Number";
                    //lblEmpEmailAddress.Text = "Employee EmailAddress";
                    //drdItemList.ValueField = "ID";
                    //drdItemList.DataSource = dtDetails;
                    //drdItemList.DataBind();
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

    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/