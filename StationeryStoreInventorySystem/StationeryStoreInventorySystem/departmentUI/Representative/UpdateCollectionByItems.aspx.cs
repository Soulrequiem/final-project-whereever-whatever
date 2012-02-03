﻿/***************************************************************************/
/*  File Name       : UpdateCollectionByItems.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : UpdateCollectionByItems
/*  Details         : Form for Update Collection By Items
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
    public partial class UpdateCollectionByItems : System.Web.UI.Page
    {
        private static readonly string sessionKey = "UpdateCollectionByItems";

        private UpdateCollectionDetailsByRequisitionItemControl ucdbriControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            commonUI.MasterPage.setCurrentPage(this);

            if (!IsPostBack)
            {
                if (Request.QueryString["CollectionIdIndex"] == null)
                {
                    ucdbriControl = new StationeryStoreInventorySystemController.departmentController.UpdateCollectionDetailsByRequisitionItemControl();

                    StationeryStoreInventorySystemController.Util.PutSession(sessionKey, ucdbriControl);
                }
                else
                {
                    ucdbriControl = (UpdateCollectionDetailsByRequisitionItemControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);

                    if (ucdbriControl.SelectCollection(SystemStoreInventorySystemUtil.Converter.objToInt(Request.QueryString["CollectionIdIndex"])) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
                    {
                        FillItemDetails(ucdbriControl.ItemDetail);

                        lblCollectionID.Text = ucdbriControl.RequestDetailCollectionId;
                        lblDateTime.Text = ucdbriControl.RequestDetailCollectionDateTime;
                        lblCollectionPoint.Text = ucdbriControl.RequestDetailCollectionPoint;
                    }
                    else
                    {
                        // print message not found
                    }
                }

            }
            else
            {
                ucdbriControl = (UpdateCollectionDetailsByRequisitionItemControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            FillCollectionDetails(ucdbriControl.CollectionList);
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
        private void FillItemDetails(DataTable dtItemDetails)
        {
            try
            {
                dgvItems.DataSource = dtItemDetails;
                dgvItems.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        protected void dgvCollectionList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("CollectionID").FindControl("TripIDLink");
            link.NavigateUrl = "~/departmentUI/Representative/UpdateCollectionByItems.aspx?CollectionIdIndex=" + link.Text;
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/