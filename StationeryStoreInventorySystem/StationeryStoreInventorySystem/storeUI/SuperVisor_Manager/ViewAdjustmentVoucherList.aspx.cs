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
        private static readonly string sessionKey = "ViewAdjustmentVoucherList";
        private ViewAdjustmentVoucherListControl vavlCtrl;
        private string voucherNo;

        /// <summary>
        /// Loads the ViewAdjustmentVoucherList form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["voucherNo"] == null)
                {
                    vavlCtrl = new ViewAdjustmentVoucherListControl();
                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, vavlCtrl);
                }
                else
                {
                    if (Request.QueryString["action"] != null)
                    {
                        vavlCtrl = new ViewAdjustmentVoucherListControl();
                        StationeryStoreInventorySystemController.Util.PutSession(sessionKey, vavlCtrl);
                    }
                    else
                    {
                        vavlCtrl = (ViewAdjustmentVoucherListControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
                    }
                    voucherNo = Request.QueryString["voucherNo"].ToString();
                    vavlCtrl.SelectStockAdjustmentVoucher(voucherNo);
                    FillAdjustmentDetails(vavlCtrl.StockAdjustmentDetail);
                    WebGroupBox1.Visible = true;
                }
                FillAdjustmentList(vavlCtrl.StockAdjustmentList);
            }
            else
            {
                vavlCtrl = (ViewAdjustmentVoucherListControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
                
        }

        /// <summary>
        /// Fills Adjustment List to Datagrid
        /// </summary>
        /// <param name="dtAdjustmentList"></param>
        private void FillAdjustmentList(DataTable dtAdjustmentList)
        {
            try
            {
                vavlCtrl = GetControl();
                if (dtAdjustmentList != null)
                {
                    DgvAdjustmentVoucherList.DataSource = dtAdjustmentList;
                    DgvAdjustmentVoucherList.DataBind();
                }
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
                lblVoucher.Text = voucherNo;
                lblBy.Text = vavlCtrl.By;
                lblDateIssue.Text = vavlCtrl.DateIssued;
                lblAuthorizedName.Text = vavlCtrl.AuthorizedBy;
                if (dtAdjustmentDetails != null)
                {
                    DgvAdjustmentVoucher.DataSource = dtAdjustmentDetails;
                    DgvAdjustmentVoucher.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        ///// <summary>
        ///// Fills Adjustment Report Data to Datagrid
        ///// </summary>
        ///// <param name="dtAdjustmentReport"></param>
        //private void FillAdjustmentReport()
        //{
        //    try
        //    {
        //        vavlCtrl = GetControl();
        //        DataTable dtAdjustmentReport = vavlCtrl.StockAdjustmentDetail;
        //        DgvAdjustmentVoucher.DataSource = dtAdjustmentReport;
        //        DgvAdjustmentVoucher.DataBind();
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.WriteErrorLog(e);
        //    }
        //}

        private ViewAdjustmentVoucherListControl GetControl()
        {
            if (vavlCtrl == null)
                vavlCtrl = new ViewAdjustmentVoucherListControl();
            return vavlCtrl;
        }

        //protected void DgvAdjustmentVoucherList_RowSelectionChanged(object sender,
        //    Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        //{
        //    voucherNo = e.CurrentSelectedRows[0].Attributes["VoucherNo"].ToString();
        //}

        protected void DgvAdjustmentVoucherList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            try
            {
                //voucherNo = e.Row.DataKey[0].ToString();
                HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("VoucherNo").FindControl("VoucherNo");
                link.NavigateUrl = "~/storeUI/SuperVisor_Manager/ViewAdjustmentVoucherList.aspx?voucherNo=" + e.Row.DataKey[0];
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/