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
    public class PurchaseOrderControl
    {
        IItemBroker itemBroker;
        IStockCardBroker stockCardBroker;
        List<PurchaseOrderDetail> orderList;
        IPurchaseOrderBroker purchaseOrderBroker;

        public PurchaseOrderControl()
        {
            orderList = new List<PurchaseOrderDetail>();
            itemBroker = new ItemBroker();
            stockCardBroker = new StockCardBroker();
        }

        public List<PurchaseOrderDetail> GetAllOrders()
        {
            List<PurchaseOrderDetail> orderList = new List<PurchaseOrderDetail>();
            List<Item> itemList = itemBroker.GetAllItem();
            foreach (Item item in itemList)
            {
                StockCard stockCard = new StockCard();
                stockCard.Item = item;
                StockCard newStockCard = stockCardBroker.GetStockCard(stockCard);
                if(item.ReorderLevel < 111){// how to get bal from stock card details???
                    PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();
                    purchaseOrderDetail.Item = item;
                    orderList.Add(purchaseOrderDetail);
                }
            }
            return orderList;
        }

        public Item EnterDescription(string itemDescription)
        {
            Item item = new Item();
            item.Description = itemDescription;
            return itemBroker.GetItem(item);

        }

        public Constants.ACTION_STATUS SelectAdd(Item item)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            PurchaseOrderDetail purchaseOrderDetail = new PurchaseOrderDetail();
            purchaseOrderDetail.Item = item;
            orderList.Add(purchaseOrderDetail);
            status = Constants.ACTION_STATUS.SUCCESS;
            return status;
        }

        public Constants.ACTION_STATUS SelectRemove(PurchaseOrderDetail purchaseOrderDetail)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            bool flag =orderList.Remove(purchaseOrderDetail);
            if (flag == true)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }

        public Constants.ACTION_STATUS SelectCreate()
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            purchaseOrder.PurchaseOrderDetails = orderList;
            Constants.DB_STATUS dbStatus = purchaseOrderBroker.Insert(purchaseOrder);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }

        public Constants.ACTION_STATUS SelectCancel()
        {
            orderList = null;
            return Constants.ACTION_STATUS.SUCCESS;
        }

    }
}
