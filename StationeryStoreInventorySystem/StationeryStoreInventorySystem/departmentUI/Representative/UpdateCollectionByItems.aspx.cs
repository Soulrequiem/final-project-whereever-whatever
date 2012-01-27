/***************************************************************************/
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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillCollectionDetails();
                //FillItems();
                //FillItemsDetails();
            }
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
        /// Fills the Item Details to Label
        /// </summary>
        /// <param name="dtItemDetails"></param>
        private void FillItems(DataTable dtItem)
        {
            try
            {
                lblCollectionID.Text = "ID";
                lblDateTime.Text = "Date/Time";
                lblCollectionPoint.Text = "Point";
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
        /// Fills Items Details to Datagrid
        /// </summary>
        /// <param name="dtItemsDetails"></param>
        private void FillItemsDetails(DataTable dtItemsDetails)
        {
            try
            {
                dgvItems.DataSource = dtItemsDetails;
                dgvItems.DataBind();
            }
            catch (Exception e)
            {
                Logger.WriteErrorLog(e);
            }
        }
    }
}
/********************************************/
/********* End of the Class *****************/
/********************************************/