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
        private CheckRequisitionControl checkRequisitionControlObj;
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
                    checkRequisitionControlObj = GetControl();
                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, checkRequisitionControlObj);


                    //checkRequisitionControlObj = new CheckRequisitionControl();
                    //Util.PutSession(sessionKey, checkRequisitionControlObj);
                    //FillRequisitions();
                }
                else
                {
                    checkRequisitionControlObj = (CheckRequisitionControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
                    //checkRequisitionControlObj = (CheckRequisitionControl)Util.GetSession(sessionKey);

                    checkRequisitionControlObj.SelectRequisitionID(SystemStoreInventorySystemUtil.Converter.objToString(Request.QueryString["RequisitionIDIndex"]));

                    FillRequisitionDetails(checkRequisitionControlObj.RequisitionDetail);

                    lblRequisitionID.Text = checkRequisitionControlObj.RequisitionId;
                    //FillRequisitions();
                    //lblRequisitionID.Text = Request.QueryString["RequisitionIDIndex"].ToString();
                }
            }
            else
            {
                checkRequisitionControlObj = (CheckRequisitionControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            FillRequisitionList();
        }

        protected void btnGetItem_Click(object sender, EventArgs e)
        {
            try
            {
                FillSpecificRequisitionList(((DataTable)Session["reqData"]).Select(" RequisitionID LIKE '" + drdRequisitionList.CurrentValue + "%'").CopyToDataTable());
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
        }

        private CheckRequisitionControl GetControl()
        {
            if (checkRequisitionControlObj == null)
                checkRequisitionControlObj = new CheckRequisitionControl();
            return checkRequisitionControlObj;
        }


        /// <summary>
        /// Fill data to DataGrid
        /// </summary>
        /// <param name="dtApprove"></param>
        private void FillRequisitionList()
        {
            try
            {
                dgvRequisitionList.DataSource = checkRequisitionControlObj.PendingRequisitionList;
                dgvRequisitionList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            prepareData();
            refresh();
            if (checkRequisitionControlObj.SelectWithdrawRequisition(remarksList) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            {
                refresh();
            }
        }

        /// <summary>
        ///To do the withdraw requisition
        ///     Modified By: Thazin Win
        ///     Modified Date: 02/02/2012
        /// </summary>
        private void prepareData()
        {
            remarksList = new Dictionary<string, string>();
         
            for (int i = 0; i < dgvRequisitionList.Rows.Count; i++)
            {
                if (SystemStoreInventorySystemUtil.Converter.objToBool(dgvRequisitionList.Rows[i].Items.FindItemByKey("CheckRequisitionCheckBox").Value) == true)
                {
                    
                    remarksList.Add(i.ToString(), ((Infragistics.Web.UI.EditorControls.WebTextEditor)dgvRequisitionList.Rows[i].Items.FindItemByKey("remarks").FindControl("remarks")).Text);
                    
                }
            }
        }

        private void refresh()
        {

            dgvRequisitionList.Rows.Clear();
            FillRequisitionList();
        }



        protected void dgvRequisitionList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            if ((SystemStoreInventorySystemUtil.Converter.objToRequisitionStatus(e.Row.Items[3].Text) == SystemStoreInventorySystemUtil.Constants.REQUISITION_STATUS.REJECTED)||
                (SystemStoreInventorySystemUtil.Converter.objToRequisitionStatus(e.Row.Items[3].Text) == SystemStoreInventorySystemUtil.Constants.REQUISITION_STATUS.SUBMITTED)||
                (SystemStoreInventorySystemUtil.Converter.objToRequisitionStatus(e.Row.Items[3].Text) == SystemStoreInventorySystemUtil.Constants.REQUISITION_STATUS.WITHDRAW))
            {
                e.Row.Items[0].CssClass = "hidden";
            }
            e.Row.Items[3].Text = SystemStoreInventorySystemUtil.Converter.GetRequisitionStatusText(SystemStoreInventorySystemUtil.Converter.objToRequisitionStatus(e.Row.Items[3].Text));
            HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("requisitionID").FindControl("requisitionID");
            link.NavigateUrl = "~/departmentUI/Employee/CheckRequisition.aspx?RequisitionIDIndex=" + link.Text;
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
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillRequisitions()
        {
            try
            {
                
                    drdRequisitionList.TextField = "requisitionID";
                    drdRequisitionList.ValueField = "requisitionID";
                   // drdRequisitionList.DataSource = (DataTable)Util.GetSession(sessionKey);
                    Util.PutSession("reqData", checkRequisitionControlObj.GetRequisitionList());
                    drdRequisitionList.DataSource = (DataTable)Session["reqData"];
                    drdRequisitionList.DataBind();
                    
                //}
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
       

        
        protected void dgvRequisitionDetails_PageIndexChanged(object sender, Infragistics.Web.UI.GridControls.PagingEventArgs e)
        {
            FillRequisitionList();
        }


        protected void dgvRequisitionDetails_DataFiltering(object sender, Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        {
            FillRequisitionList();
        }

        private void chk_changed(object sender, System.EventArgs e)
        {
            string s = string.Empty;
        }

        protected void dgvRequisitionList_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            //string s = e.CurrentSelectedRows[0].ToString();
        }

        protected void dgvRequisitionList_CellSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedCellEventArgs e)
        {
            //string str = e.CurrentSelectedCells.ToString();
        }

        protected void dgvRequisitionList_RowUpdating(object sender, Infragistics.Web.UI.GridControls.RowUpdatingEventArgs e)
        {
            //string str = e.Row.Items[0].ToString();
        }       
        
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/