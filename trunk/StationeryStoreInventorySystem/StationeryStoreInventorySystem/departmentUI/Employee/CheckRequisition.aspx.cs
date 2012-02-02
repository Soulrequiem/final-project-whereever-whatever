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
using StationeryStoreInventorySystemController;
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
                Util.PutSession("CheckReq", crctrl.GetRequisitionList());
                FillRequisitionList();
                FillRequisitions();
            }
        }

        /// <summary>
        /// Fills Requisition to Datagrid
        /// </summary>
        /// <param name="dt"></param>
        private void FillSpecificRequisitionList(DataTable dtReq)
        {
            try
            {
                dgvRequisitionList.DataSource = dtReq;
                dgvRequisitionList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills Requisition to Datagrid
        /// </summary>
        /// <param name="dt"></param>
        private void FillRequisitionList()
        {
            try
            {
                dgvRequisitionList.DataSource = (DataTable)Util.GetSession("CheckReq");
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
        private void FillRequisitions()
        {
            try
            {
                //Fill all requisitionsIDs made by current user
                //crctrl = new CheckRequisitionControl();
                //crctrl.
                if ((DataTable)Util.GetSession("CheckReq") != null)
                {
                    drdRequisitionList.TextField = "RequisitionID";
                    drdRequisitionList.ValueField = "RequisitionID";
                    drdRequisitionList.DataSource = (DataTable)Util.GetSession("CheckReq");
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
                FillSpecificRequisitionList(((DataTable)Session["CheckReq"]).Select(" RequisitionID LIKE '" + drdRequisitionList.CurrentValue + "%'").CopyToDataTable());
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

        protected void dgvRequisitionDetails_PageIndexChanged(object sender, Infragistics.Web.UI.GridControls.PagingEventArgs e)
        {
            FillRequisitionList();
        }


        protected void dgvRequisitionDetails_DataFiltering(object sender, Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        {
            FillRequisitionList();
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