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

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Employee
{
    public partial class RequestStationery : System.Web.UI.Page
    {
        private static readonly string sessionKey = "RequestStationery";

        private RequestStationeryControl resCtrl;
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

                FillItems(StationeryStoreInventorySystemController.Util.GetItemTable());
            }
            else
            {
                resCtrl = (RequestStationeryControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ItemNo");
            //dt.Columns.Add("ItemDescription");
            ////dt.Columns.Add("AddToTable");
            ////dt.Columns.Add("status");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            ////dr[2] = "1";
            ////dr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "1";
            //dr[1] = "1";
            ////dr[2] = "1";
            ////dr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dt.Rows.Add(dr);

            //dgvStationeryList.DataSource = dt;
            //dgvStationeryList.DataBind();


            //DataTable dtt = new DataTable();
            //dtt.Columns.Add("RequestStationeryCheckBox");
            //dtt.Columns.Add("ItemNo");
            //dtt.Columns.Add("ItemDescription");
            //dtt.Columns.Add("RequiredQty");
            ////dt.Columns.Add("status");
            ////dt.Columns.Add("RemainingQty");
            ////dt.Columns.Add("Remarks");

            //DataRow drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            ////drr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dtt.Rows.Add(drr);

            //drr = dtt.NewRow();
            //drr[0] = "1";
            //drr[1] = "1";
            //drr[2] = "1we2we12321";
            ////drr[3] = "1213sadsad";
            ////dr[4] = "1ssdsfdf";
            ////dr[5] = "1ssdsfdf";
            //dtt.Rows.Add(drr);

            //dgvStationeryDetailsList.DataSource = dtt;
            //dgvStationeryDetailsList.DataBind();

           
        }

        /// <summary>
        /// Fill selected Item Description into GridView
        /// Method Name: FillDetails()
        /// Modified by: SanLaPyaye
        /// Modified Date: 27/01/2012
        /// </summary>
        /// <param name="dtDetails"></param>
        private void FillDetails(DataTable dtDetails)
        {
            try
            {
                if (dtDetails != null)
                {
                    dgvStationeryList.DataSource = dtDetails;
                    dgvStationeryList.DataBind();
                }
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
        private void FillItems(DataTable items)
        {
            try
            {
                if (items != null)
                {
                    drdItemList.TextField = "ItemDescription";
                    drdItemList.ValueField = "ID";
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
        private void FillItemList(DataTable dtStationeryItem)
        {
            try
            {
                dgvStationeryDetailsList.DataSource = dtStationeryItem;
                dgvStationeryDetailsList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        protected void drdItemList_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                FillDetails(resCtrl.SelectItemDescription(drdItemList.SelectedItem.Text));
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