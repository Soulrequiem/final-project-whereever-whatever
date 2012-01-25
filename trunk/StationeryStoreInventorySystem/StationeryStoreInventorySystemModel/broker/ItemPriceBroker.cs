using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemModel.broker
{
    public class ItemPriceBroker : IItemPriceBroker
    {
        #region IItemPriceBroker Members
        private InventoryEntities inventory = new InventoryEntities();
        private ItemPrice itemPriceObj = null;
        private List<ItemPrice> itemPriceList = null;

        public ItemPrice GetItemPrice(ItemPrice itemPrice)
        {
            itemPriceObj = inventory.ItemPrices.Where(iObj => iObj.ItemId == itemPrice.ItemId).First();
            if (!itemPriceObj.Equals(null))
                return itemPriceObj;
            return null;
        }

        public List<ItemPrice> GetAllItemPrice()
        {
            itemPriceList = inventory.ItemPrices.ToList<ItemPrice>();
            if (!itemPriceList.Equals(null))
                return itemPriceList;
            return null;
        }

        public Constants.DB_STATUS Insert(ItemPrice newItemPrice)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToItemPrices(newItemPrice);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

        public Constants.DB_STATUS Update(ItemPrice itemPrice)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                itemPriceObj = inventory.ItemPrices.Where(iObj => iObj.ItemId == itemPrice.ItemId).First();

                itemPriceObj.Price = itemPrice.Price;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

        public Constants.DB_STATUS Delete(ItemPrice itemPrice)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                itemPriceObj = inventory.ItemPrices.Where(iObj => iObj.ItemId == itemPrice.ItemId).First();
                itemPriceObj.Status = 2;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }

        #endregion
    }
}
