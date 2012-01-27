using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;


namespace StationeryStoreInventorySystemController.storeController
{
    public class ReceiveOrderControl
    {
        IPurchaseOrderBroker purchaseOrderBroker;

        public ReceiveOrderControl()
        {
            purchaseOrderBroker = new PurchaseOrderBroker();
        }

        public PurchaseOrder GetOrder(int purchaseOrderId)
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            purchaseOrder.Id = purchaseOrderId;
            return purchaseOrderBroker.GetPurchaseOrder(purchaseOrder);
        }

        public Constants.ACTION_STATUS SelectReceive()
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            //update which one in purchase order table????
            return status;
        }
    }
}
