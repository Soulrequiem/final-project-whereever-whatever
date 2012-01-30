using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;


namespace StationeryStoreInventorySystemController.departmentController
{
    public class RequestStationeryControl
    {
        public RequestStationeryControl()
        {
        }
        public Item EnterItemDescription(String itemDescription)
        {
            IItemBroker itemBroker = new ItemBroker();
            Item item = new Item();
            item.Description = itemDescription;
            Item resultItem = itemBroker.GetItem(item);
            return resultItem;
        }

        public Constants.ACTION_STATUS AddToTable(){

        }

        public Constants.ACTION_STATUS SelectRequest(){

        }
    }
}
