using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController;
using StationeryStoreInventorySystemController.storeController;

namespace SA34_Team9_StationeryStoreInventorySystem.storeUI.Clerk
{
    public partial class CreatePurchaseOrder : System.Web.UI.Page
    {
        private static readonly string sessionKey = "CreatePurchaseOrder";
        private static readonly string selectedSessionKey = "CreatePurchaseOrderSelectedIndex";        

        PurchaseOrderControl poCtrl;
        private List<int> selectedIndexList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillItems();
                FillSupplier();
                poCtrl = GetControl();
                lblPONumber.Text = poCtrl.purchaseOrderId.ToString();

                selectedIndexList = new List<int>();

                StationeryStoreInventorySystemController.Util.PutSession(sessionKey, poCtrl);
                StationeryStoreInventorySystemController.Util.PutSession(selectedSessionKey, selectedIndexList);

                
            }
            else
            {
                poCtrl = (PurchaseOrderControl)StationeryStoreInventorySystemController.Util.GetSession(sessionKey);
                selectedIndexList = (List<int>)StationeryStoreInventorySystemController.Util.GetSession(selectedSessionKey);

                DgvPurchaseOrderInput.DataSource = (DataTable)Session["PurchaseOrder"];
                DgvPurchaseOrderInput.DataBind();
            }
        }

        public static void removeSession()
        {
            StationeryStoreInventorySystemController.Util.RemoveSession(sessionKey);
            StationeryStoreInventorySystemController.Util.RemoveSession(selectedSessionKey);
        }

        private void refresh()
        {
            selectedIndexList = new List<int>();
            DgvPurchaseOrderInput.Rows.Clear();
            DgvPurchaseOrderInput.ClearDataSource();
        }


        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillOrder()
        {
            DataTable dt = (DataTable)Session["PurchaseOrder"];

            DataRow dr = dt.NewRow();
            //dr[0] = ;
            dr[1] = lblItemNumber.Text;
            dr[2] = drdItemList.SelectedItem.Text.Trim();
            dr[3] = txtQuantity.Text;
            dr[4] = txtPrice.Text;
            dr[5] = (Convert.ToInt16(txtQuantity.Text) * Convert.ToInt16(txtPrice.Text)).ToString();
            dt.Rows.Add(dr);

            //poCtrl = GetControl();
            //DataTable dt = poCtrl.PurchaseOrderDetailList;
            DgvPurchaseOrderInput.DataSource = dt;
            DgvPurchaseOrderInput.DataBind();
            //poCtrl = GetControl();
            //DataTable dtPurchaseOrder = poCtrl.PurchaseOrderDetailList;
            //DgvPurchaseOrderInput.DataSource = dtPurchaseOrder;
            //DgvPurchaseOrderInput.DataBind();

            Session["PurchaseOrder"] = dt;
        }

        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillItems()
        {
            DataTable items = StationeryStoreInventorySystemController.Util.GetItemTable();
            if (items != null)
            {
                drdItemList.TextField = "ItemDescription";
                drdItemList.ValueField = "ItemNo";
                drdItemList.DataSource = items;
                drdItemList.DataBind();
            }
        }

        /// <summary>
        /// Fills item drop down
        /// </summary>
        /// <param name="dtItems"></param>
        private void FillSupplier()
        {
            ViewSupplierListControl vslCtrl = new ViewSupplierListControl();
            DataTable dt = vslCtrl.SupplierList;
            if (dt != null)
            {
                DrdSupplier.TextField = "supplierName";
                DrdSupplier.ValueField = "supplierCode";
                DrdSupplier.DataSource = dt;
                DrdSupplier.DataBind();
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
            //String selectedItem = drdItemList.CurrentValue.ToString();
            //DataTable dt = StationeryStoreInventorySystemController.Util.GetItemListTable(selectedItem);
            //lblItemNumber.Text = dt.Columns[0].ToString();
            //String selectedItem = drdItemList.CurrentValue.ToString();
            //lblItemNumber.Text = selectedItem;            
        }

        /// <summary>
        /// Add item in the grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnApprove_Click(object sender, EventArgs e)
        {

            //DataTable dt = (DataTable)Session["PurchaseOrder"];


            //DataRow dr = dt.NewRow();
            ////dr[0] = ;
            //dr[1] = lblItemNumber.Text;
            //dr[2] = drdItemList.SelectedItem.Text.Trim();
            //dr[3] = txtQuantity.Text;
            //dr[4] = txtPrice.Text;
            //dr[5] = (Convert.ToInt16(txtQuantity.Text) * Convert.ToInt16(txtPrice.Text)).ToString();
            //dt.Rows.Add(dr);

            //poCtrl = GetControl();
            //DataTable dt = poCtrl.PurchaseOrderDetailList;
            //DgvPurchaseOrderInput.DataSource = dt;
            //DgvPurchaseOrderInput.DataBind();
           
            //Session["PurchaseOrder"] = dt;
            try
            {
                if (drdItemList.SelectedItem != null || txtQuantity.Text != "" || txtPrice.Text != "")
                {
                    FillOrder();
                }
            }
            catch (Exception ex)
            {
                //print something
            }
        }

        private PurchaseOrderControl GetControl()
        {
            if (poCtrl == null)
                poCtrl = new PurchaseOrderControl();
            return poCtrl;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (drdItemList.SelectedItem != null)
                {
                    String selectedItem = drdItemList.SelectedItem.Value;
                    lblItemNumber.Text = selectedItem;
                }
            }
            catch (Exception exp)
            {
                //print something
            }
        }

        

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (poCtrl.SelectRemove(selectedIndexList) == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            {
                refresh();
            }
            
            //poCtrl.SelectRemove(selectedIndexList);
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            //if (poCtrl.SelectCreate() == SystemStoreInventorySystemUtil.Constants.ACTION_STATUS.SUCCESS)
            //{
            //    refresh();
            //}
            poCtrl.SelectAdd(selectedIndexList.ToString());
            refresh();
        }

        protected void DgvPurchaseOrderInput_CellSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedCellEventArgs e)
        {
            try
            {
                if (e != null)
                {
                    if (e.CurrentSelectedCells[0].Index == 0)
                    {
                        //((Infragistics.Web.UI.EditorControls.WebTextEditor)e.CurrentSelectedCells[0].FindControl("Remarks")).ID;
                        int currentPageIndex = DgvPurchaseOrderInput.Behaviors.Paging.PageIndex * DgvPurchaseOrderInput.Behaviors.Paging.PageSize;
                        int currentRow = e.CurrentSelectedCells[0].Row.Index;
                        if (selectedIndexList.Contains(currentRow + currentPageIndex))
                        {
                            selectedIndexList.Remove(currentRow + currentPageIndex);
                        }
                        else
                        {
                            selectedIndexList.Add(currentRow + currentPageIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // do something here later
            }
        }   
    }
}
