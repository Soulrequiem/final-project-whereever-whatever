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
using SystemStoreInventorySystemUtil;

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
            // click add to table
            if (Request.QueryString["itemCode"] != null)
            {
                resCtrl = (RequestStationeryControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);

                if (resCtrl == null)
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
                }

                if (!IsPostBack)
                {
                    if (resCtrl.AddToTable(Request.QueryString["itemCode"]) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.FAIL)
                    {
                        // print error message
                    }
                    else
                    {
                        FillItemList();
                    }
                    lblRequisitionDate.Text = SystemStoreInventorySystemUtil.Converter.dateTimeToString(SystemStoreInventorySystemUtil.Converter.DATE_CONVERTER.DATETIME, DateTime.Now);
                    lblRequisitionID.Text = resCtrl.RequisitionId;
                    lblDepartmentCode.Text = resCtrl.DepartmentCode;
                    lblDepartmentName.Text = resCtrl.DepartmentName;
                    lblEmployeeName.Text = resCtrl.EmployeeName;
                    lblEmployeeID.Text = resCtrl.EmployeeId;
                    lblEmployeeEmailID.Text = resCtrl.EmployeeEmail;

                    FillItems();
                }

                
            }
            else
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
                }
                else
                {
                    resCtrl = (RequestStationeryControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
                }
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
                    //dgvStationeryList.ClearDataSource();
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
                
                //dgvStationeryDetailsList.ClearDataSource();
                //DataTable dt = resCtrl.RequisitionDetailList;
                dgvStationeryDetailsList.DataSource = resCtrl.RequisitionDetailList;
                dgvStationeryDetailsList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        private RequestStationeryControl GetControl()
        {
            if (resCtrl == null)
                resCtrl = new RequestStationeryControl();
            return resCtrl;
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
        }

        protected void btnGetItem_Click(object sender, EventArgs e)
        {
            if (drdItemList.CurrentValue != null)
            {
                string sItem = drdItemList.CurrentValue.ToString();
                FillDetails(sItem);
            }
        }

        protected void dgvStationeryList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("AddToTable").FindControl("AddToTable");
            link.NavigateUrl = "~/departmentUI/Employee/RequestStationery.aspx?action=add&itemCode=" + e.Row.DataKey[0];
            //Response.Redirect("~/departmentUI/Employee/RequestStationery.aspx?action=add&itemCode=" + e.Row.DataKey[0]);
        }

        protected void btnReset_Click1(object sender, EventArgs e)
        {
            resCtrl.SelectRemoveAll();
            FillItemList();
        }

        protected void btnRemove_Click1(object sender, EventArgs e)
        {
            List<int> indexList = new List<int>();

            for (int i = 0; i < dgvStationeryDetailsList.Rows.Count; i++)
            {
                if (SystemStoreInventorySystemUtil.Converter.objToBool(dgvStationeryDetailsList.Rows[i].Items.FindItemByKey("RequestStationeryCheckBox").Value) == true)
                {
                    indexList.Add(i);
                    dgvStationeryDetailsList.Rows[i].Items.FindItemByKey("RequestStationeryCheckBox").Value = false;
                }
            }

            if (resCtrl.SelectRemove(indexList) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.FAIL)
            {
                // print error message
            }
            else
            {
                FillItemList();
            }
        }

        private bool ValidateScreen()
        {
            //bool isChecked = true;
            decimal isNumber = 0;
            for (int i = 0; i < dgvStationeryDetailsList.Rows.Count; i++)
            {
                //if ((bool)dgvStationeryDetailsList.Rows[i].Items.FindItemByKey("RequestStationeryCheckBox").Value == false)
                //    isChecked = false;
                //else
                //    isChecked = true;


                    if (decimal.TryParse(dgvStationeryDetailsList.Rows[i].Items[3].Text, out isNumber) == false ||
                        Convert.ToInt16(dgvStationeryDetailsList.Rows[i].Items[3].Text) <= 0)
                    {
                        lblStatusMessage.Text = "Invalid quantity.";
                        return false;
                    }
            }
            //if (isChecked == false)
            //{
            //    lblStatusMessage.Text = "Please select items.";
            //    return false;
            //}

            return true;
        }

        protected void btnRequest_Click1(object sender, EventArgs e)
        {
            if(ValidateScreen())
            {
                Dictionary<string, int> quantity = new Dictionary<string, int>();

                for (int i = 0; i < dgvStationeryDetailsList.Rows.Count; i++)
                {
                    //if (SystemStoreInventorySystemUtil.Converter.objToBool(dgvStationeryDetailsList.Rows[i].Items.FindItemByKey("RequestStationeryCheckBox").Value) == true)
                    //{
                        decimal number = 0;
                        if (decimal.TryParse(dgvStationeryDetailsList.Rows[i].Items[3].Text, out number))
                        {
                            if(number > 1000)
                            {
                                lblStatusMessage.Text = "Invalid quantity!";
                                return;
                            }
                        }
                        dgvStationeryDetailsList.Rows[i].Items.FindItemByKey("RequestStationeryCheckBox").Value = false;
                        //quantity.Add(dgvStationeryDetailsList.Rows[i].DataKey[0].ToString(), SystemStoreInventorySystemUtil.Converter.objToInt(((Infragistics.Web.UI.EditorControls.WebTextEditor)dgvStationeryDetailsList.Rows[i].Items.FindItemByKey("RequiredQty").FindControl("RequiredQty")).Text));
                        quantity.Add(dgvStationeryDetailsList.Rows[i].DataKey[0].ToString(),
                            SystemStoreInventorySystemUtil.Converter.objToInt(dgvStationeryDetailsList.Rows[i].Items[3].Text));
                    //}
                }

                if (resCtrl.SelectRequest(quantity) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.FAIL)
                {
                    lblStatusMessage.Text = "Requisition failed!";
                }
                else
                {
                    FillItemList();
                }
                Infragistics.Web.UI.NavigationControls.WebExplorerBar wbar = (Infragistics.Web.UI.NavigationControls.WebExplorerBar)(this.Master.FindControl("NavigationBar"));
                Session["SelectedIndex"] = 3;
                Session["SelectedGroup"] = 0;
                wbar.Groups[0].Items[3].Selected = true;
                Response.Redirect("~/departmentUI/Employee/CheckRequisition.aspx");
            }
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