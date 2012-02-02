/***************************************************************************/
/*  File Name       : CheckRequisition.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : CheckRequisition
/*  Details         : Form for Check Requisition
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.departmentController;
namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Employee
{
    public partial class CheckRequisition : System.Web.UI.Page
    {
        CheckRequisitionControl crctrl;
        /// <summary>
        /// Loads the CheckRequisition form
        ///     Modified By: SanLaPyaye
        ///     Modified Date: 27/01/2012
        ///     Modification Reason: Bind the data to GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                crctrl = new CheckRequisitionControl();
                FillRequisitionList(crctrl.GetRequisitionList());
                FillRequisitions(crctrl.GetRequisitionList());
            }
        }

        /// <summary>
        /// Fills Requisition to Datagrid
        /// </summary>
        /// <param name="dt"></param>
        private void FillRequisitionList(DataTable dtRequisition)
        {
            try
            {
                dgvRequisitionList.DataSource = dtRequisition;
                dgvRequisitionList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillRequisitions(DataTable dtRequisition)
        {
            try
            {
                //Fill all requisitionsIDs made by current user
                //crctrl = new CheckRequisitionControl();
                //crctrl.
                if (dtRequisition != null)
                {
                    drdRequisitionList.TextField = "requsitionId";
                    drdRequisitionList.ValueField = "requsitionId";
                    drdRequisitionList.DataSource = dtRequisition;
                    drdRequisitionList.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills Requisition Details to Datagrid
        /// </summary>
        /// <param name="dtDeatilsRequisition"></param>
        private void FillRequisitionDetails(DataTable dtDeatilsRequisition)
        {
            try
            {
                lblRequisitionID.Text = "";//Choose selected record ID;
                lblRequistionStatus.Text = "";//Choose selected requisition status;
                dgvRequisitionDetails.DataSource = dtDeatilsRequisition;
                dgvRequisitionDetails.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }
        protected void btnGetItem_Click(object sender, EventArgs e)
        {
            try
            {
                FillRequisitionList(getControl().GetRequisitionList().Select(" requsitionId LIKE '" + drdRequisitionList.CurrentValue + "%'").CopyToDataTable());
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        private CheckRequisitionControl getControl()
        {
            if (crctrl == null)
                crctrl = new CheckRequisitionControl();
            return crctrl;
        }

        ///// <summary>
        ///// Fills the changed data into Datagrid
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void drdRequisitionList_SelectionChanged(object sender,
        //    Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        String selectedRequisition = drdRequisitionList.SelectedItem.Text;
        //        crctrl = new CheckRequisitionControl();
        //        DataTable dtReqDetails = crctrl.SelectRequisitionID(selectedRequisition);
        //        FillRequisitionList(dtReqDetails);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.WriteErrorLog(ex);
        //    }
        //}
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/