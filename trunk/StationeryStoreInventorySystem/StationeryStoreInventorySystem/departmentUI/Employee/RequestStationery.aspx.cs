/***************************************************************************/
/*  File Name       : RequestStationery.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : RequestStationery
/*  Details         : Form for Request Stationery
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.departmentController;
using StationeryStoreInventorySystemController.commonController;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Employee
{
    public partial class RequestStationery : System.Web.UI.Page
    {
        private static readonly string sessionKey = "RequestStationery";

        private RequestStationeryControl resCtrl;
        private ViewStationeryCatalogueControl vsCtrl;
        /// <summary>
        /// Loads the RequestStationery form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                resCtrl = GetControl();

                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, resCtrl);

                lblRequisitionDate.Text = SystemStoreInventorySystemUtil.Converter.dateTimeToString(SystemStoreInventorySystemUtil.Converter.DATE_CONVERTER.DATETIME, DateTime.Now);
                lblRequisitionID.Text = resCtrl.RequisitionId;
                lblDepartmentCode.Text = resCtrl.DepartmentCode;
                lblDepartmentName.Text = resCtrl.DepartmentName;
                lblEmployeeName.Text = resCtrl.EmployeeName;
                lblEmployeeID.Text = resCtrl.EmployeeId;
                lblEmployeeEmailID.Text = resCtrl.EmployeeEmail;

                FillItems();
                //FillDetails("ssfs");
                FillItemList();
            }
            else
            {
                resCtrl = (RequestStationeryControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
        }

        /// <summary>
        /// Fill selected Item Description into GridView
        /// Method Name: FillDetails()
        /// Modified by: SanLaPyaye
        /// Modified Date: 27/01/2012
        /// </summary>
        /// <param name="dtDetails"></param>
        private void FillDetails(string sItem)
        {
            try
            {
                DataTable dt = StationeryStoreInventorySystemController.Util.GetItemListTable(drdItemList.CurrentValue);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvStationeryList.DataSource = dt;
                    dgvStationeryList.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills item drop down list
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillItems()
        {
            try
            {
                DataTable items = StationeryStoreInventorySystemController.Util.GetItemTable();
                if (items != null)
                {
                    drdItemList.TextField = "ItemDescription";
                    drdItemList.ValueField = "ItemNo";
                    drdItemList.DataSource = items;
                    drdItemList.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills Stationery Items to Datagrid
        /// </summary>
        /// <param name="dtStationeryItem"></param>
        private void FillItemList()
        {
            try
            {
                resCtrl = GetControl();
                dgvStationeryDetailsList.DataSource = resCtrl.RequisitionDetailList;
                dgvStationeryDetailsList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        protected void drdItemList_SelectionChanged(object sender,
            Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                
                //resCtrl = GetControl();
                //resCtrl.AddToTable(drdItemList.SelectedValue);
                //FillDetails();
                //FillItemList();
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        private RequestStationeryControl GetControl()
        {
            if (resCtrl == null)
                resCtrl = new RequestStationeryControl();
            return resCtrl;
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            dgvStationeryDetailsList.ClearDataSource();
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
        }

        protected void btnGetItem_Click(object sender, EventArgs e)
        {
            string sItem = drdItemList.CurrentValue.ToString();
            FillDetails(sItem);
        }

        protected void dgvStationeryList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("AddToTable").FindControl("AddToTable");
            link.NavigateUrl = "~/departmentUI/Employee/RequestStationery.aspx?CollectionIdIndex=" + link.Text;
        }

        //protected void drdItemList_ValueChanged(object sender, Infragistics.Web.UI.ListControls.DropDownValueChangedEventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (drdItemList.SelectedItem.Text != string.Empty)
        //    //    {
        //    //        resCtrl = GetControl();
        //    //        resCtrl.AddToTable(drdItemList.SelectedItem.Key);
        //    //        FillDetails();
        //    //        FillItemList();
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Logger.WriteErrorLog(ex);
        //    //}
        //}

        ///// <summary>
        ///// Fills the change Items to Datagrid
        ///// Modified By: SanLaPyaye
        ///// Modified Date: 27/01/2012
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void drdItemList_SelectionChanged(object sender,
        //    Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //            String selectedItem = drdItemList.SelectedItem.Text;
        //            res = new RequestStationeryControl();
        //            DataTable dtItemDescription = res.SelectItemDescription(selectedItem);
        //            FillDetails(dtItemDescription);
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