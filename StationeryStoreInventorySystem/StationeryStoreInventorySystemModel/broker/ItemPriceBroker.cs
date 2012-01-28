/***************************************************************************/
/*  File Name       : ItemPriceBroker.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : ItemPriceBroker
/*  Details         : Model representation of Item table
/***************************************************************************/
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
        private InventoryEntities inventory;
        private ItemPrice itemPriceObj = null;
        private List<ItemPrice> itemPriceList = null;

        public ItemPriceBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        /// <summary>
        ///  Retrieve the ItemPrice Detail information  from ItemPrice Table according to the ItemPrice Parameter
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <returns></returns>
        public ItemPrice GetItemPrice(ItemPrice itemPrice)
        {
            itemPriceObj = inventory.ItemPrices.Where(iObj => iObj.ItemId == itemPrice.ItemId).First();
            if (!itemPriceObj.Equals(null))
                return itemPriceObj;
            return null;
        }
        /// <summary>
        ///  Retrieve All of the ItemPrice information from ItemPrice Table
        /// </summary>
        /// <returns></returns>
        public List<ItemPrice> GetAllItemPrice()
        {
            itemPriceList = inventory.ItemPrices.ToList<ItemPrice>();
            if (!itemPriceList.Equals(null))
                return itemPriceList;
            return null;
        }
        /// <summary>
        ///  Insert ItemPrice data to the ItemPrice Table according to the ItemPrice Parameter
        ///   Return Constants.DB_STATUS 
        /// </summary>
        /// <param name="newItemPrice"></param>
        /// <returns></returns>
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
        /// <summary>
        ///  Update ItemPrice data to ItemPrice Table according to the ItemPrice Parameter
        ///   Return Constants.DB_STATUS 
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(ItemPrice itemPrice)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                itemPriceObj = inventory.ItemPrices.Where(iObj => iObj.ItemId == itemPrice.ItemId).First();
                if (!itemPriceObj.Equals(null))
                {
                    Employee createdBy = inventory.Employees.Where(eObj => eObj.Id == itemPrice.CreatedBy.Id).First();
                    itemPriceObj.SupplierId = itemPrice.SupplierId;
                    itemPriceObj.Price = itemPrice.Price;
                    itemPriceObj.CreatedDate = itemPrice.CreatedDate;
                    itemPriceObj.CreatedBy = createdBy;
                    inventory.SaveChanges();
                    status = Constants.DB_STATUS.SUCCESSFULL;
                }
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        /// <summary>
        ///  Logically delete the ItemPrice table by setting the status to 2 in the ItemPrice table
        ///   Return Constants.DB_STATUS
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <returns></returns>
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
/****************************************/
/********* End of the Class *****************/
/****************************************/