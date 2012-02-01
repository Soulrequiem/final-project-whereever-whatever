/***************************************************************************/
/*  File Name       : ItemPriceBroker.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : ItemPrice
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
        private List<Supplier> supplierList = null;
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
            try
            {
                itemPriceObj = inventory.ItemPrices.Where(iObj => iObj.ItemId == itemPrice.ItemId).First();
            }
            catch (Exception e)
            {
                itemPriceObj = null;
            }
            return itemPriceObj;
        }
        /// <summary>
        ///  Retrieve All of the ItemPrice information from ItemPrice Table
        /// </summary>
        /// <returns>
        /// List of Item Price
        /// </returns>
        public List<ItemPrice> GetAllItemPrice()
        {
            try
            {
                itemPriceList = inventory.ItemPrices.ToList<ItemPrice>();
            }
            catch (Exception e)
            {
                itemPriceList = null;
            }
                return itemPriceList;
        }
        /// <summary>
        /// Get the Suppliert List according to the Item
        /// </summary>
        /// <param name="item"></param>
        /// <returns>
        /// List of supplier list
        /// </returns>
        public List<Supplier> GetPrioritySupplier(Item item)
        {
            try
            {
                supplierList = new List<Supplier>();
                SupplierBroker supplierBroker = new SupplierBroker(this.inventory);

                itemPriceList = inventory.ItemPrices.Where(itemPrice => itemPrice.ItemId == item.Id).ToList<ItemPrice>();

                Supplier supplier;

                foreach (ItemPrice itemPrice in itemPriceList)
                {
                    supplier = new Supplier();
                    supplier.Id = itemPrice.SupplierId;
                    supplier = supplierBroker.GetSupplier(supplier);

                    supplierList.Add(supplier);
                }

                supplierList.Sort();

            }
            catch (Exception e)
            {
                supplierList = null;
            }
            return supplierList;
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