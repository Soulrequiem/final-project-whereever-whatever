using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class CreatePurchaseOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                
            }
        }

        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillItems()
        {
            DataTable dtItems = (DataTable)Session["Items"];
            if (dtItems != null)
            {
                drdItemList.TextField = "ItemDescription";
                drdItemList.ValueField = "ID";
                drdItemList.DataSource = dtItems;
                drdItemList.DataBind();
            }
        }

        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillSupplier(DataTable dt)
        {
            if (dt != null)
            {
                drdItemList.TextField = "SupplierName";
                drdItemList.ValueField = "SupplierID";
                drdItemList.DataSource = dt;
                drdItemList.DataBind();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drdItemList_SelectionChanged(object sender,
        Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            String selectedItem = drdItemList.SelectedItem.Text;
            //Pass to the controller

        }

        /// <summary>
        /// Add item in the grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApprove_Click(object sender, EventArgs e)
        {

        }
    }
}