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
        CheckRequisitionControl checkRequisitionControlObj;
        private DataTable dt;
        private DataRow dr;
        private static readonly string sessionKey = "CheckReq";
        private Dictionary<string, string> remarksList;
        /// <summary>
        /// Loads the CheckRequisition form
        ///     Modified By: SanLaPyaye
        ///     Modified Date: 27/01/2012
        ///     Modification Reason: Bind the data to GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        /// <summary>
        /// Loads the CheckRequisition form
        ///     Modified By: Thazin Win
        ///     Modified Date: 02/02/2012
        ///     Modification Reason: Show the requisition data in GridView/withdraw the requisition process/Show the requsition detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["RequisitionIDIndex"] == null)
                {
                    checkRequisitionControlObj = new CheckRequisitionControl();
                    Util.PutSession(sessionKey, checkRequisitionControlObj);
                    FillRequisitions();
                }
                else
                {
                    checkRequisitionControlObj = (CheckRequisitionControl)Util.GetSession(sessionKey);

                    FillRequisitionDetails(checkRequisitionControlObj.SelectRequisitionID(SystemStoreInventorySystemUtil.Converter.objToString(Request.QueryString["RequisitionIDIndex"])));
                    Util.PutSession(sessionKey, checkRequisitionControlObj);
                    
                    FillRequisitions();
                }
            }
            else
            {
                checkRequisitionControlObj = (CheckRequisitionControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            FillRequisitionList();
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
                dgvRequisitionList.DataSource = checkRequisitionControlObj.GetRequisitionList();
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
                   // drdRequisitionList.DataSource = (DataTable)Util.GetSession(sessionKey);
                    drdRequisitionList.DataSource = checkRequisitionControlObj.GetRequisitionList();
                    drdRequisitionList.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }


        /// <summary>
        /// Fills Items Details to Datagrid
        /// </summary>
        /// <param name="dtItemsDetails"></param>
        private void FillRequisitionDetails(DataTable dtCollectionDetails)
        {
            try
            {
                dgvRequisitionDetails.DataSource = dtCollectionDetails;
                dgvRequisitionDetails.DataBind();
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
        //private void FillRequisitionDetails(DataTable dtDeatilsRequisition)
        //{
        //    try
        //    {
        //        lblRequisitionID.Text = "";//Choose selected record ID;
        //        lblRequistionStatus.Text = "";//Choose selected requisition status;
        //        dgvRequisitionDetails.DataSource = dtDeatilsRequisition;
        //        dgvRequisitionDetails.DataBind();
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.WriteErrorLog(e);
        //    }
        //}
        protected void btnGetItem_Click(object sender, EventArgs e)
        {
            try
            {
                FillSpecificRequisitionList(((DataTable)Session[sessionKey]).Select(" RequisitionID LIKE '" + drdRequisitionList.CurrentValue + "%'").CopyToDataTable());
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        private CheckRequisitionControl getControl()
        {
            if (checkRequisitionControlObj == null)
                checkRequisitionControlObj = new CheckRequisitionControl();
            return checkRequisitionControlObj;
        }

        protected void dgvRequisitionDetails_PageIndexChanged(object sender, Infragistics.Web.UI.GridControls.PagingEventArgs e)
        {
            FillRequisitionList();
        }


        protected void dgvRequisitionDetails_DataFiltering(object sender, Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        {
            FillRequisitionList();
        }

        protected void dgvRequisitionList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("RequisitionID").FindControl("RequisitionID");
            link.NavigateUrl = "~/departmentUI/Employee/CheckRequisition.aspx?RequisitionIDIndex=" + link.Text;
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
         }


        
        /// <summary>
        ///To do the withdraw requisition
        ///     Modified By: Thazin Win
        ///     Modified Date: 02/02/2012
        /// </summary>
        private void prepareData()
        {
            remarksList = new Dictionary<string, string>();
            string requisitionID;
            for (int i = 0; i < dgvRequisitionList.Rows.Count; i++)
            {
                if (SystemStoreInventorySystemUtil.Converter.objToBool(dgvRequisitionList.Rows[i].Items.FindItemByKey("CheckRequisitionCheckBox").Value) == true)
                {
                  // if (dgvRequisitionList.Rows[i].Items.FindItemByKey("remarks").Value != null)
                //   remarksList.Add(i.ToString(), ((Infragistics.Web.UI.EditorControls.WebTextEditor)dgvRequisitionList.Rows[i].Items.FindItemByKey("remarks").FindControl("remarks")).Text);
                //   else
                 //      remarksList.Add(i.ToString(),dgvRequisitionList.Rows[i].Items.FindItemByKey("RequisitionID").Text);
                    requisitionID =dgvRequisitionList.Rows[i].Items.FindItemByKey("RequisitionID").FindControl("RequisitionID").ToString();
                   if( checkRequisitionControlObj.SelectWithdraw(SystemStoreInventorySystemUtil.Converter.objToString(Request.QueryString["RequisitionIDIndex"] ))== SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.FAIL)
                   {
                       break;
                   }
            //{);
                }
            }
        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            prepareData();
            refresh();
            //if (checkRequisitionControlObj.SelectWithdrawRequisition(remarksList) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            //{
            //    refresh();
            //}
        }

        private void refresh()
        {

            dgvRequisitionList.Rows.Clear();
            FillRequisitionList();
        }

        private void chk_changed(object sender, System.EventArgs e)
        {
            string s = string.Empty;
        }

        protected void dgvRequisitionList_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            string s = e.CurrentSelectedRows[0].ToString();
        }

        protected void dgvRequisitionList_CellSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedCellEventArgs e)
        {
            string str = e.CurrentSelectedCells.ToString();
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