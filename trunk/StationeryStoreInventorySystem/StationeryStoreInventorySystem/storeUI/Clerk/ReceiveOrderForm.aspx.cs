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
    public partial class ReceiveOrderForm : System.Web.UI.Page
    {
        ReceiveOrderControl ROobj;
        PurchaseOrderControl purchaseOrderControl;
        ReceiveOrderControl receiveOrderControl;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillPOList();
                
            }
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ItemNo");
            //dt.Columns.Add("ItemDescription");
            //dt.Columns.Add("Quantity");
            //dt.Columns.Add("Remarks");

            //DataRow dr = dt.NewRow();
            //dr[0] = "Hello";
            //dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1";
            //dt.Rows.Add(dr);

            //dr = dt.NewRow();
            //dr[0] = "Hello";
            //dr[1] = "1";
            //dr[2] = "1";
            //dr[3] = "1";
            //dt.Rows.Add(dr);

            //DgvStationeryOrder.ClearDataSource();
            //DgvStationeryOrder.DataSource = dt;
            //DgvStationeryOrder.DataBind();
        }

        /// <summary>
        /// Selected item from item drop down list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DrdPONo_SelectionChanged(object sender,
        Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            try
            {
                string selectedItem = DrdPONo.SelectedItem.Value;
                ROobj = new ReceiveOrderControl();
                //********Plz check this
                //DataTable dt = ROobj.SelectPurchaseOrderDetails(Convert.ToInt32(selectedItem));
                //FillStationeryOrder(dt);

                //********get supplier name by PONumber
                //Label1.Text = ReceiveOrderControl.GetSupplierName(selectedItem);
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }

        }

        private void FillStationeryOrder(DataTable dtOrders)
        {
            try
            {
                if(dtOrders!=null)
                    DgvStationeryOrder.DataSource = dtOrders;
                    DgvStationeryOrder.DataBind();
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        private void FillPOList()
        {
            try
            {
                //ROobj = new ReceiveOrderControl();
                //***********Get all purchase order list
                //DataTable dt = ROobj.GetPO();
                //DrdPONo.TextField = "PONumber";
                //DrdPONo.ValueField  = "PONumber";
                //DrdPONo.DataSource = dt;
                //DrdPONo.DataBind();
            }
            catch (Exception ex)
            {
                Logger.WriteErrorLog(ex);
            }
        }

        protected void btnReceived_Click(object sender, EventArgs e)
        {
            //*********update purchase order
            //purchaseOrderControl.SelectCreate(selectedItem);
            //*********insert stock card details in stock card
            receiveOrderControl.SelectReceive();//pass the datatable to broker
        } 
    }
}