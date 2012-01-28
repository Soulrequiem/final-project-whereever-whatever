using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;
using System.Data;


namespace StationeryStoreInventorySystemController.storeController
{
    public class ReceiveOrderControl
    {
        IPurchaseOrderBroker purchaseOrderBroker;
        PurchaseOrder purchaseOrder;
        Supplier supplier;
        public ReceiveOrderControl()
        {
            purchaseOrderBroker = new PurchaseOrderBroker();
        }

        public void SelectAllPurchaseOrderDetails(string purchaseOrderNumber)
        {
            purchaseOrder = new purchaseOrder();
            purchaseOrder.Id = purchaseOrderNumber;
            purchaseOrder = purchaseOrderBroker.GetPurchaseOrder(purchaseOrder);
        }

        public DataTable PurchaseOrder()
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            purchaseOrder.Id = purchaseOrderId;
            purchaseOrder = purchaseOrderBroker.GetPurchaseOrder(purchaseOrder);
            List<PurchaseOrderDetail> list = purchaseOrder.PurchaseOrderDetails.ToList();
            DataTable dt = new DataTable();
            DataRow dr = null;
            foreach (PurchaseOrderDetail temp in list)
            {
                dt.NewRow();
                dr = new DataRow();
                dr["itemNo"] = temp.Item.Id;
                dr["itemDescription"] = temp.Item.Description;
                dr["quantity"] = temp.Qty;
                dt.Rows.Add(dr);
               
            }
            return dt;
        }

        public Constants.ACTION_STATUS SelectReceive(string purchaseOrderNumber)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            //update which one in purchase order table????
            return status;
        }
    }
}
