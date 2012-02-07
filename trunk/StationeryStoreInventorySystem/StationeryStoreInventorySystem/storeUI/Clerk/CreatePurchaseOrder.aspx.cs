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
                //FillDataGrid();
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
            
            if (purchaseOrderControl.SelectItemDescription(description, DrdSupplier.SelectedItem.Text) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            {
                lblItemNumber.Text = purchaseOrderControl.ItemCode;
                txtPrice.Text = purchaseOrderControl.Price;
            }

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (lblItemNumber.Text != String.Empty && txtQuantity.Text != String.Empty && txtPrice.Text != String.Empty)
            {
                if (purchaseOrderControl.AddItem(lblItemNumber.Text, SystemStoreInventorySystemUtil.Converter.objToInt(txtQuantity.Text), SystemStoreInventorySystemUtil.Converter.objToDouble(txtPrice.Text)) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
                {
                    FillDataGrid();
                    txtQuantity.Text = "";
                    txtPrice.Text = "";
                    lblItemNumber.Text = "";
                    drdItemList.CurrentValue = "";
                }
            }
            else
            {
                // print message
            }

            //purchaseOrderControl.SelectAdd();
        }

        private void FillDataGrid()
        {
            DataTable dtable = purchaseOrderControl.PurchaseOrderDetailList;
            DgvPurchaseOrderInput.DataSource = dtable;
            DgvPurchaseOrderInput.DataBind();
        }

        protected void btnGetItem_Click(object sender, EventArgs e)
        {
            string sItem = drdItemList.CurrentValue.ToString();

            if (DrdSupplier.SelectedItem == null)
            {
                // print error message
            }
            else if (purchaseOrderControl.SelectItemDescription(sItem, DrdSupplier.SelectedItem.Value) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            {
                lblItemNumber.Text = purchaseOrderControl.ItemCode;
                txtPrice.Text = purchaseOrderControl.Price;
            }
        }

        protected void DrdSupplier_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            purchaseOrderControl.SetSupplier(DrdSupplier.SelectedItem.Value);
            FillDataGrid();
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            if (DrdSupplier.SelectedItem.Value != String.Empty && txtaDeliverTo.Text != String.Empty && txtAttn.Text != String.Empty && txtSupplyDate.Text != String.Empty)
            {
                string[] supplyDate = txtSupplyDate.Text.Split('/');
                if (purchaseOrderControl.SelectSave(DrdSupplier.SelectedItem.Value, txtaDeliverTo.Text, txtAttn.Text, new DateTime(SystemStoreInventorySystemUtil.Converter.objToInt(supplyDate[2]), SystemStoreInventorySystemUtil.Converter.objToInt(supplyDate[1]), SystemStoreInventorySystemUtil.Converter.objToInt(supplyDate[0]))) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
                {
                    // print success message
                }
                else
                {
                    // print error message
                }
            }
            else
            {
                // print error message
            }
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