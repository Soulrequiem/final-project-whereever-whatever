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
using StationeryStoreInventorySystemController;
using StationeryStoreInventorySystemController.storeController;
using SystemStoreInventorySystemUtil;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.SuperVisor_Manager
{
    public partial class IssueAdjustmentVoucher : System.Web.UI.Page
    {
        private static readonly string sessionKey = "IssueAdjustmentVoucher";
        IssueAdjustmentVoucherControl iavCtrl;
        
       
        /// <summary>
        /// Loads the IssueAdjustmentVoucher form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            //Response.Write(Util.CheckAdjustment());
            if (!IsPostBack)
            {
                if (Request.QueryString["discrepancyId"] == null)
                {
                 
                    iavCtrl = new IssueAdjustmentVoucherControl();
                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, iavCtrl);
                }
                else
                {
                    iavCtrl = (IssueAdjustmentVoucherControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
                    int id = Converter.objToInt(Request.QueryString["discrepancyId"]);
                    WebGroupBox1.Visible = true;
                    DgvDiscrepancyReport.DataSource = iavCtrl.SelectDiscrepancy(id);
                    DgvDiscrepancyReport.DataBind();
                  
                    lblDateIssue.Text = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATE, DateTime.Now);
                    string[] array = iavCtrl.IssueAdjustment();
                     lblVoucher.Text = array[0];
                     lblAuthorizedName.Text = array[1];
                     lblBy.Text = array[2];
                }
            }
            else
            {
                
                iavCtrl = (IssueAdjustmentVoucherControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }

            FillDiscrepancy();
        }

        /// <summary>
        /// Fills Discrepancy Reports to Datagrid
        /// </summary>
        /// <param name="dtDiscrepancy"></param>
        private void FillDiscrepancy()
        {
            //try
            //{
            iavCtrl = GetControl();
          
            DgvDiscrepancyReportList.DataSource = iavCtrl.DiscrepancyList;
            DgvDiscrepancyReportList.DataBind();
            //}
            //catch (Exception e)
            //{
            //    Logger.WriteErrorLog(e);
            //}
        }


        /// <summary>
        /// Fills Report Details to Label
        /// </summary>
        /// <param name="dtReportDetails"></param>
        //private void FillReportDetails()//DataTable dtReportDetails)
        //{
        //    try
        //    {
        //        lblVoucher.Text = "Text";
        //        lblBy.Text = "By";
        //        lblDateIssue.Text = "Date";
        //        //drdItemList.ValueField = "ID";
        //        //drdItemList.DataSource = dtDetails;
        //        //drdItemList.DataBind();
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.WriteErrorLog(e);
        //    }
        //}

        /// <summary>
        /// Fills Report Data to Datagrid
        /// </summary>
        /// <param name="dtReport"></param>
        //private void FillReport()
        //{
        //    try
        //    {
        //        iavCtrl = GetControl();
        //        DataTable dtReport = iavCtrl.SelectDiscrepancy(Convert.ToInt16(voucherNo));
        //        DgvDiscrepancyReport.DataSource = dtReport;
        //        DgvDiscrepancyReport.DataBind();
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.WriteErrorLog(e);
        //    }
        //}

        private IssueAdjustmentVoucherControl GetControl()
        {
            if (iavCtrl == null)
                iavCtrl = new IssueAdjustmentVoucherControl();
            return iavCtrl;
        }

        //protected void DgvDiscrepancyReportList_RowSelectionChanged(object sender,
        //    Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        //{
        //    try
        //    {
        //        HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("id").FindControl("id");
        //        link.NavigateUrl = "~/storeUI/SuperVisor_Manager/IssueAdjustmentVoucher.aspx?discrepancyId=" + e.Row.DataKey[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        Response.Write(ex.Message);
        //    }
        //}

        //protected void DgvDiscrepancyReportList_RowSelectionChanged(object sender, 
        //    Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        //{
        //    voucherNo = e.CurrentSelectedRows[0].Attributes["VoucherNo"].ToString();
        //}


        //protected void DgvDiscrepancyReportList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        //{
        //    try
        //    {
        //        HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("id").FindControl("id");                
        //        link.NavigateUrl = "~/storeUI/SuperVisor_Manager/IssueAdjustmentVoucher.aspx?discrepancyId=" + e.Row.DataKey[0];
        //        iavCtrl = GetControl();
        //        DataTable dt = iavCtrl.SelectDiscrepancy(Convert.ToInt16(e.Row.Items.FindItemByKey("id").FindControl("id")));
        //        DgvDiscrepancyReportList.DataSource = dt;
        //        DgvDiscrepancyReportList.DataBind();
        //    }
        //    catch (Exception e)
        //    {
        //        //do something
        //    }
        //}

        protected void DgvDiscrepancyReportList_DataFiltering(object sender,
            Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        {
            FillDiscrepancy();
        }

        protected void DgvDiscrepancyReportList_PageIndexChanged(object sender,
            Infragistics.Web.UI.GridControls.PagingEventArgs e)
        {
            FillDiscrepancy();
        }

        //protected void DgvDiscrepancyReport_DataFiltering(object sender,
        //    Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        //{
        //    FillReport();
        //}

        //protected void DgvDiscrepancyReport_PageIndexChanged(object sender,
        //    Infragistics.Web.UI.GridControls.PagingEventArgs e)
        //{
        //    FillReport();
        //}

        protected void DgvDiscrepancyReportList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            try
            {
                HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("DiscrepancyId").FindControl("DiscrepancyId");
                link.NavigateUrl = "~/storeUI/SuperVisor_Manager/IssueAdjustmentVoucher.aspx?discrepancyId=" + e.Row.DataKey[0];
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnIssue_Click(object sender, EventArgs e)
        {
            
            if (iavCtrl.CreateAdjustment() == Constants.ACTION_STATUS.SUCCESS)
            {
                StationeryStoreInventorySystemController.Util.GoToPage("ViewAdjustmentVoucherList.aspx?action=add&voucherNo=" + lblVoucher.Text);
            }
            else
            {
                Response.Write("Fail....");
                //error message
            }
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/