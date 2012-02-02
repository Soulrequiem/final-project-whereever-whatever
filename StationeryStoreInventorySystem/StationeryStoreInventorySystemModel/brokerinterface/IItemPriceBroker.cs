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
        List<Supplier> GetPrioritySupplier(Item item);
        Constants.DB_STATUS Insert(ItemPrice newItemPrice);
        Constants.DB_STATUS Update(ItemPrice itemPrice);
        Constants.DB_STATUS Delete(ItemPrice itemPrice);
        //Constants.DB_STATUS Insert(ItemPrice newItemPrice,Boolean isSaved);
        //Constants.DB_STATUS Update(Boolean isSaved);
        //Constants.DB_STATUS Delete(ItemPrice itemPrice,Boolean isSaved);

    }
}
