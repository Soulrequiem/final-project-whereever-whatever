using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IItemBroker
    {
        Item GetItem(Item item);
        List<Item> GetAllItem();
        Constants.DB_STATUS Insert(Item newItem);
        Constants.DB_STATUS Update(Item item);
        Constants.DB_STATUS Delete(Item item);
    }
}
