/***************************************************************************/
/*  File Name       : ViewStationeryCatalogue.cs
/*  Module Name     : View
/*  Owner           : Wai Yan Ko Ko
/*  class Name      : ViewStationeryCatalogue
/*  Details         : Form for View Stationery Catalogue
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.commonController;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class ViewStationeryCatalogue : System.Web.UI.Page
    {
        private static readonly string sessionKey = "ViewStationeryCatalogueControl";

        private ViewStationeryCatalogueControl vsCtrl;

        /// <summary>
        /// Loads the ViewStationeryCatalogue form
        /// </summary>  
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                MasterPage.setCurrentPage(this);

                vsCtrl = new ViewStationeryCatalogueControl();

                FillStationeryList();
                FillItems();

                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, vsCtrl);
            }
            else
            {
                vsCtrl = (ViewStationeryCatalogueControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
        }

        private ViewStationeryCatalogueControl getControl()
        {
            if (vsCtrl == null)
                vsCtrl = new ViewStationeryCatalogueControl();
            return vsCtrl;
        }

        /// <summary>
        /// Fills data to datagrid
        /// </summary>
        /// <param name="dt"></param>
        private void FillStationeryList()
        {
            try
            {
                DataTable dt = StationeryStoreInventorySystemController.Util.GetItemListTable(drdItemList.CurrentValue);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!vsCtrl.IsStoreOfficer())
                    {
                        dgvStationeryList.DataSource = dt;
                        dgvStationeryList.DataBind();
                        dgvClerkStationeryList.Visible = false;
                        WebGroupBox1.Width = 600;
                    }
                    else
                    {
                        dgvClerkStationeryList.DataSource = dt;
                        dgvClerkStationeryList.DataBind();
                        dgvStationeryList.Visible = false;
                        WebGroupBox1.Width = 720;
                    }
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
        private void FillItems()
        {
            try
            {
                DataTable dtItems = StationeryStoreInventorySystemController.Util.GetItemTable();
                if (dtItems != null)
                {
                    drdItemList.TextField = "ItemDescription";
                    drdItemList.ValueField = "ItemNo";
                    drdItemList.DataSource = dtItems;
                    drdItemList.DataBind();
                }
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FillStationeryList();
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        protected void dgvStationeryList_InitializeRow(object sender, Infragistics.Web.UI.GridControls.RowEventArgs e)
        {
            HyperLink link = (HyperLink)e.Row.Items.FindItemByKey("ItemNo").FindControl("ItemNo");
            link.NavigateUrl = "~/storeUI/Clerk/ViewStockCard.aspx?ItemDescription=" + e.Row.Items[2].Text;
        }

        protected void dgvStationeryList_DataFiltering(object sender,
            Infragistics.Web.UI.GridControls.FilteringEventArgs e)
        {
            FillStationeryList();
        }

        protected void dgvStationeryList_PageIndexChanged(object sender,
            Infragistics.Web.UI.GridControls.PagingEventArgs e)
        {
            FillStationeryList();
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/