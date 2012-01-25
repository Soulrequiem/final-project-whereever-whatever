using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemController.storeController
{
    public class ViewStockCardControl
    {
        IItemBroker itemBroker;
        IStockCardBroker stockCardBroker;
        Employee employee;
        public ViewStockCardControl()
        {
            employee = Util.ValidateUser();
            itemBroker = new ItemBroker();
            stockCardBroker = new StockCardBroker();
        }

        public StockCard GetStockCard(string itemDescription)
        {
            Item item = new Item();
            item.Description = itemDescription;
            
            item = itemBroker.GetItem(item);
            
            StockCard stockCard = null;
            if (item != null)
            {
                stockCard = new StockCard();
                stockCard.Item = item;

                stockCard = stockCardBroker.GetStockCard(stockCard);

            }
            
            return stockCard;
        }
        

    }
}
