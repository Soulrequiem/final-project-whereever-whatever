/***************************************************************************/
/*  File Name       : AdjustmentVoucher.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : AdjustmentVoucher
/*  Details         : Form for Adjustment Voucher
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.SuperVisor_Manager
{
    public partial class AdjustmentVoucher : System.Web.UI.Page
    {
        /// <summary>
        /// Loads the AdjustmentVoucher form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillVoucherDetails();
                //FillVoucher();
            }
        }

        /// <summary>
        /// Fills Voucher Details to Label
        /// </summary>
        /// <param name="dtVoucher"></param>
        private void FillVoucherDetails(DataTable dtVoucherDetails)
        {
            try
            {
                lblVoucher.Text = "Voucher";
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
        /// Fills Voucher in the Datagrid
        /// </summary>
        /// <param name="dtVoucher"></param>
        private void FillVoucher(DataTable dtVoucher)
        {
            try
            {
                DgvAdjustmentVoucherDetails.DataSource = dtVoucher;
                DgvAdjustmentVoucherDetails.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        protected void DgvAdjustmentVoucherDetails_DataFiltering(object sender,
            Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        {

        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/