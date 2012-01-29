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
    public class PurchaseOrderControl
    {
        private IItemBroker itemBroker;
        private IPurchaseOrderBroker purchaseOrderBroker;
        
        private Employee currentEmployee;
        private PurchaseOrder purchaseOrder;
        
        private System.Data.Objects.DataClasses.EntityCollection<PurchaseOrderDetail> purchaseOrderDetails;

        private DataTable dt;
        private DataRow dr;
        
        public PurchaseOrderControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);
            InventoryEntities inventory = new InventoryEntities();

            itemBroker = new ItemBroker(inventory);
            purchaseOrderBroker = new PurchaseOrderBroker(inventory);

            purchaseOrder = new PurchaseOrder();
            purchaseOrder.Id = purchaseOrderBroker.GetPurchaseOrderId();

            purchaseOrderDetails = new System.Data.Objects.DataClasses.EntityCollection<PurchaseOrderDetail>();
        }

        public DataTable GetAllOrders()
        {
            dt = new DataTable();
            //List<PurchaseOrderDetail> orderList = new List<PurchaseOrderDetail>();
            //List<Item> itemList = itemBroker.GetAllItem();
            //foreach (Item item in itemList)
            //{
            //    StockCard stockCard = new StockCard();
            //    stockCard.Item = item;
            //    StockCard newStockCard = stockCardBroker.GetStockCard(stockCard);
            //    if(item.ReorderLevel < 111){// how to get bal from stock card details???
            //        PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();
            //        purchaseOrderDetail.Item = item;
            //        orderList.Add(purchaseOrderDetail);
            //    }
            //}

            foreach (PurchaseOrderDetail temp in purchaseOrderDetails)
            {
                dr = dt.NewRow();
                dr["itemNo"] = temp.Item.Id;
                dr["description"] = temp.Item.Description;
                dr["quantity"] = temp.Qty;
                dr["price"] = temp.Price;
                dr["amount"] = temp.Qty * temp.Price;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public Item EnterDescription(string itemDescription)
        {
            Item item = new Item();
            item.Description = itemDescription;
            return itemBroker.GetItem(item);

        }

        public DataTable SelectAdd(Item item)
        {
            dt = new DataTable();
            
            PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();
            purchaseOrderDetail.Item = item;
            purchaseOrderDetails.Add(purchaseOrderDetail);
            foreach (PurchaseOrderDetail temp in purchaseOrderDetails)
            {
                dr = dt.NewRow();
                dr["itemNo"] = temp.Item.Id;
                dr["description"] = temp.Item.Description;
                dr["quantity"] = temp.Qty;
                dr["price"] = temp.Price;
                dr["amount"] = temp.Qty * temp.Price;
                dt.Rows.Add(dr);
            }
            return dt;
           
        }

        public DataTable SelectRemove(PurchaseOrderDetail purchaseOrderDetail)
        {
            dt = new DataTable();
            
            purchaseOrderDetails.Remove(purchaseOrderDetail);
            foreach (PurchaseOrderDetail temp in purchaseOrderDetails)
            {
                dr = dt.NewRow();
                dr["itemNo"] = temp.Item.Id;
                dr["description"] = temp.Item.Description;
                dr["quantity"] = temp.Qty;
                dr["price"] = temp.Price;
                dr["amount"] = temp.Qty * temp.Price;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public Constants.ACTION_STATUS SelectCreate()
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            purchaseOrder.PurchaseOrderDetails = purchaseOrderDetails;
            Constants.DB_STATUS dbStatus = purchaseOrderBroker.Insert(purchaseOrder);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }

        public Constants.ACTION_STATUS SelectCancel()
        {
            purchaseOrderDetails = null;
            return Constants.ACTION_STATUS.SUCCESS;
        }

    }
}
