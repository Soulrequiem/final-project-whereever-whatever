using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IItemPriceBroker
    {
        ItemPrice GetItemPrice(ItemPrice itemPrice);
        List<ItemPrice> GetAllItemPrice();
        Constants.DB_STATUS Insert(ItemPrice newItemPrice);
        Constants.DB_STATUS Update(ItemPrice itemPrice);
        Constants.DB_STATUS Delete(ItemPrice itemPrice);
    }
}
