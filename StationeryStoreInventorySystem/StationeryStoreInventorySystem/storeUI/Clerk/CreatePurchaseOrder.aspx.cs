using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.storeController;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class CreatePurchaseOrder : System.Web.UI.Page
    {
        private static readonly string sessionKey = "CreatePurchaseOrder";
        private PurchaseOrderControl purchaseOrderControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                purchaseOrderControl = GetControl();
                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, purchaseOrderControl);

                //FillItemsGridView();

                //FillItems();
                FillSupplier();
                FillItems();
                lblPONumber.Text = purchaseOrderControl.PurchaseOrderId.ToString();
            }
            else
            {
                purchaseOrderControl = (PurchaseOrderControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
            }
            //FillItemsGridView();
            
        }

        private PurchaseOrderControl GetControl()
        {
            if (purchaseOrderControl == null)
                purchaseOrderControl = new PurchaseOrderControl();
            return purchaseOrderControl;
        }
        // <summary>
        // Fills item drop down
        // </summary>
        // <param name="dtItems"></param>
        private void FillItems()
        {
            DataTable dtItems = StationeryStoreInventorySystemController.Util.GetItemTable();
            if (dtItems != null)
            {
                drdItemList.TextField = "ItemDescription";
                drdItemList.ValueField = "ID";
                drdItemList.DataSource = dtItems;
                drdItemList.DataBind();
            }
        }

        // <summary>
        // Fills item drop down
        // </summary>
        // <param name="dtItems"></param>
        private void FillSupplier()
        {
            DataTable dtt = purchaseOrderControl.SupplierList1;
            if (dtt != null)
            {
                DrdSupplier.TextField = "SupplierName";
                DrdSupplier.ValueField = "SupplierID";
                DrdSupplier.DataSource = dtt;
                DrdSupplier.DataBind();
            }
        }

        protected void drdItemList_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string description = drdItemList.SelectedItem.Text;
            lblItemNumber.Text = purchaseOrderControl.SelectItemDescription(description);

        }

        protected void drdItemList_ValueChanged(object sender, Infragistics.Web.UI.ListControls.DropDownValueChangedEventArgs e)
        {
            string description = drdItemList.SelectedItem.Text;
            lblItemNumber.Text = purchaseOrderControl.SelectItemDescription(description);
        }

        // <summary>
         
        // </summary>
        // <param name="sender"></param>
        // <param name="e"></param>
        //protected void drdItemList_SelectionChanged(object sender,
        //Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        //{
        //    String selectedItem = drdItemList.SelectedItem.Text;
        //    Pass to the controller

        //}

        // <summary>
        // Add item in the grid view
        // </summary>
        // <param name="sender"></param>
        // <param name="e"></param>
        //protected void btnApprove_Click(object sender, EventArgs e)
        //{

        //}
    }
}