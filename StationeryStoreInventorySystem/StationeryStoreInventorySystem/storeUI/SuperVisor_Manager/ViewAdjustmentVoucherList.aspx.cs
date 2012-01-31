/***************************************************************************/
/*  File Name       : ViewAdjustmentVoucherList.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : ViewAdjustmentVoucherList
/*  Details         : Form for View Adjustment Voucher List
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.storeController;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.SuperVisor_Manager
{
    public partial class ViewAdjustmentVoucherList : System.Web.UI.Page
    {
        ViewAdjustmentVoucherListControl vavlCtrl;
        String voucherNo;
        /// <summary>
        /// Loads the ViewAdjustmentVoucherList form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAdjustmentList();
                //FillAdjustmentDetails();
                FillAdjustmentReport();
            }
        }

        /// <summary>
        /// Fills Adjustment List to Datagrid
        /// </summary>
        /// <param name="dtAdjustmentList"></param>
        private void FillAdjustmentList()
        {
            try
            {
                vavlCtrl = GetControl();
                DataTable dtAdjustmentList = vavlCtrl.GetStockAdjustmentList();
                DgvAdjustmentVoucherList.DataSource = dtAdjustmentList;
                DgvAdjustmentVoucherList.DataBind();
            }
            catch(Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        private void FillAdjustmentDetails(DataTable dtAdjustmentDetails)
        {
            try
            {
                lblVoucher.Text = "Text";
                lblBy.Text = "By";
                lblDateIssue.Text = "Date";
                //drdItemList.ValueField = "ID";
                //drdItemList.DataSource = dtDetails;
                //drdItemList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills Adjustment Report Data to Datagrid
        /// </summary>
        /// <param name="dtAdjustmentReport"></param>
        private void FillAdjustmentReport()
        {
            try
            {
                vavlCtrl = GetControl();
                DataTable dtAdjustmentReport = vavlCtrl.SelectAdjustmentVoucher(voucherNo);
                DgvAdjustmentVoucher.DataSource = dtAdjustmentReport;
                DgvAdjustmentVoucher.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        private ViewAdjustmentVoucherListControl GetControl()
        {
            if (vavlCtrl == null)
                vavlCtrl = new ViewAdjustmentVoucherListControl();
            return vavlCtrl;
        }

        protected void DgvAdjustmentVoucherList_RowSelectionChanged(object sender,
            Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            voucherNo = e.CurrentSelectedRows[0].Attributes["VoucherNo"].ToString();
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/