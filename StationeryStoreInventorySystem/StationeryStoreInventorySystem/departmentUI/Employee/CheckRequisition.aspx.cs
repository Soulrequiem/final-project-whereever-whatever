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
                //DataTable dtRequsitions =  crctrl.GetRequisitionList();

                DataTable dt = new DataTable();
                dt.Columns.Add("CheckRequisitionCheckBox");
                dt.Columns.Add("RequisitionID");
                dt.Columns.Add("RequisitionDate/Time");
                dt.Columns.Add("status");
                dt.Columns.Add("RemainingQty");
                dt.Columns.Add("Remarks");

                DataRow dr = dt.NewRow();
                dr[0] = "100";
                dr[1] = "1fgg";
                dr[2] = "uoiuo";
                dr[3] = "xzcnbkjh";
                dr[4] = "d09f8sdkf";

                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr[0] = "101";
                dr[1] = "134";
                dr[2] = "2342r";
                dr[3] = "xcv";
                dr[4] = "121";

                dt.Rows.Add(dr);

                FillRequisitionList(dt);
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
        private void FillRequisitions()
        {
            try
            {
                //Fill all requisitionsIDs made by current user
                //crctrl = new CheckRequisitionControl();
                //crctrl.
                DataTable dtItems = new DataTable();

                if (dtItems != null)
                {
                    drdRequisitionList.TextField = "Requisitions";
                    drdRequisitionList.ValueField = "ID";
                    drdRequisitionList.DataSource = dtItems;
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

        protected void drdRequisitionList_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                String selectedRequisition = drdRequisitionList.SelectedItem.Text;
                crctrl = new CheckRequisitionControl();
                DataTable dtReqDetails = crctrl.SelectRequisitionID(selectedRequisition);
                FillRequisitionList(dtReqDetails);
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
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