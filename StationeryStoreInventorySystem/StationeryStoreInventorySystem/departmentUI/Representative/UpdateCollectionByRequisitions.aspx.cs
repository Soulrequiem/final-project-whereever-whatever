/***************************************************************************/
/*  File Name       : UpdateCollectionByRequisitions.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : UpdateCollectionByRequisitions
/*  Details         : Form for Update Collection By Requisitions
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.departmentController;

namespace SA34_Team9_StationeryStoreInventorySystem.departmentUI.Representative
{
    public partial class UpdateCollectionByRequisitions : System.Web.UI.Page
    {
        private static readonly string sessionKey = "UpdateCollectionByRequisitons";

        private UpdateCollectionDetailsByRequisitionControl ucdbrControl;

        /// <summary>
        /// Loads the UpdateCollectionByRequisitions form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            commonUI.MasterPage.setCurrentPage(this);

            if (!IsPostBack)
            {
                if (Request.QueryString["CollectionIdIndex"] == null)
                {
                    ucdbrControl = new StationeryStoreInventorySystemController.departmentController.UpdateCollectionDetailsByRequisitionControl();

                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, ucdbrControl);
                }
                else
                {
                    ucdbrControl = (UpdateCollectionDetailsByRequisitionControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);

                    if (ucdbrControl.SelectCollection(SystemStoreInventorySystemUtil.Converter.objToInt(Request.QueryString["CollectionIdIndex"])) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
                    {
                        FillRequisitionDetails(ucdbrControl.RequestDetail);

                        lblCollectionID.Text = ucdbrControl.RequestDetailCollectionId;
                        lblDateTime.Text = ucdbrControl.RequestDetailCollectionDateTime;
                        lblCollectionPoint.Text = ucdbrControl.RequestDetailCollectionPoint;
                    }
                    else
                    {
                        // print message not found
                    }
                }
                
            }
            else
            {
                ucdbrControl = (UpdateCollectionDetailsByRequisitionControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            FillCollectionDetails(ucdbrControl.CollectionList);
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
        }

        /// <summary>
        /// Fills Collection Details to Datagrid
        /// </summary>
        /// <param name="dtCollectionDetails"></param>
        private void FillCollectionDetails(DataTable dtCollectionDetails)
        {
            try
            {
                dgvCollectionList.DataSource = dtCollectionDetails;
                dgvCollectionList.DataBind();
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
                dgvRequisitions.DataSource = dtCollectionDetails;
                dgvRequisitions.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        protected void dgvCollectionList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("CollectionID").FindControl("TripIDLink");
            link.NavigateUrl = "~/departmentUI/Representative/UpdateCollectionByRequisitions.aspx?CollectionIdIndex=" + link.Text;
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/