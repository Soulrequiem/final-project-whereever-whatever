/***************************************************************************/
/*  File Name       : IssueAdjustmentVoucher.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : IssueAdjustmentVoucher
/*  Details         : Form for Issue Adjustment Voucher
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
    public partial class IssueAdjustmentVoucher : System.Web.UI.Page
    {
        IssueAdjustmentVoucherControl iavCtrl;
        String voucherNo;
        /// <summary>
        /// Loads the IssueAdjustmentVoucher form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDiscrepancy();
                //FillReportDetails();
                //FillReport();
            }
        }

        /// <summary>
        /// Fills Discrepancy Reports to Datagrid
        /// </summary>
        /// <param name="dtDiscrepancy"></param>
        private void FillDiscrepancy()
        {
            try
            {
                iavCtrl = GetControl();
                DataTable dtDiscrepancy = iavCtrl.GetDiscrepancyList();
                DgvDiscrepancyReportList.DataSource = dtDiscrepancy;
                DgvDiscrepancyReportList.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        /// <summary>
        /// Fills Report Details to Label
        /// </summary>
        /// <param name="dtReportDetails"></param>
        private void FillReportDetails(DataTable dtReportDetails)
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
        /// Fills Report Data to Datagrid
        /// </summary>
        /// <param name="dtReport"></param>
        private void FillReport()
        {
            try
            {
                iavCtrl = GetControl();
                DataTable dtReport = iavCtrl.SelectDiscrepancy(Convert.ToInt16(voucherNo));
                DgvDiscrepancyReport.DataSource = dtReport;
                DgvDiscrepancyReport.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        private IssueAdjustmentVoucherControl GetControl()
        {
            if (iavCtrl == null)
                iavCtrl = new IssueAdjustmentVoucherControl();
            return iavCtrl;
        }

        protected void DgvDiscrepancyReportList_RowSelectionChanged(object sender, 
            Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            voucherNo = e.CurrentSelectedRows[0].Attributes["VoucherNo"].ToString();
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/