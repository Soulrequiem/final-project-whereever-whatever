/***************************************************************************/
/*  File Name       : Item.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : ItemBroker
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
    public class ItemBroker: IItemBroker
    {
        #region IItemBroker Members
        private InventoryEntities inventory;
        private Item itemObj = null;
        private List<Item> itemList = null;
        private StockCardDetail stcDetail = null;
        private List<StockCardDetail> stcDetailList = null;

        public ItemBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        /// <summary>
        ///  Retrieve the Item Detail information  from Item Table according to the Item Parameter
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Item GetItem(Item item)
        {
            itemObj = inventory.Items.Where(iObj => iObj.Description == item.Description || iObj.Id == item.Id).First();
            if (!itemObj.Equals(null))
                return itemObj;
            return null;
        }
        /// <summary>
        ///  Retrieve All of the item information from Item Table
        /// </summary>
        /// <returns></returns>
        public List<Item> GetAllItem()
        {
            itemList = inventory.Items.ToList<Item>();
            if (!itemList.Equals(null))
                return itemList;
            return null;
        }
        /// <summary>
        /// Insert Item data to the Item Table according to the Item Parameter
        /// Return Constants.DB_STATUS 
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(Item newItem)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToItems(newItem);
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
        /// 
        /// Update Item data to Item Table according to the Item Parameter
        /// Return Constants.DB_STATUS
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(Item item)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                itemObj = inventory.Items.Where(iObj => iObj.Id == item.Id).First();
                if(!itemObj.Equals(null))
                {
                    Employee createdBy = inventory.Employees.Where(eObj => eObj.Id == itemObj.CreatedBy.Id).First();
                    itemObj.ItemCategoryId = item.ItemCategoryId;
                    itemObj.Description = item.Description;
                    itemObj.ReorderLevel = item.ReorderLevel;
                    itemObj.ReorderQty = item.ReorderQty;
                    itemObj.Cost = item.Cost;
                    itemObj.UnitOfMeasureId = item.UnitOfMeasureId;
                    itemObj.CreatedDate = item.CreatedDate;
                    itemObj.CreatedBy = createdBy;
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
        /// Logically delete the Item table by setting the status to 2 in the Item table
        /// Return Constants.DB_STATUS
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(Item item)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                itemObj = inventory.Items.Where(iObj => iObj.Id == item.Id).First();
                itemObj.Status = 2;
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
        /// Get the Item List by Item Description
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<Item> GetItemReference(Item item)
        {
            List<Item> itemObj = inventory.Items.Where(r => r.Description.Contains(item.Description)).ToList();
            return itemObj;

        }
        /// <summary>
        ///  Retrieve the StockCardDetail information according to the stockCardDetail Parameter 
        /// </summary>
        /// <param name="stockCardDetail"></param>
        /// <returns></returns>
        public StockCardDetail GetStockCardDetail(StockCardDetail stockCardDetail)
        {
            stcDetail = inventory.StockCardDetails.Where(stcDetailObj => stcDetailObj.Id == stockCardDetail.Id).First();
            if (!stcDetail.Equals(null))
                return stcDetail;
            return null;
        }
        /// <summary>
        ///  Retrieve StockDetail data to the StockDetail Table according to the StockCardDetail Parameter
        /// </summary>
        /// <returns></returns>
        public List<StockCardDetail> GetAllStockCardDetail()
        {
            stcDetailList = inventory.StockCardDetails.ToList<StockCardDetail>();
            if (!stcDetailList.Equals(null))
                return stcDetailList;
            return null;
        }
        /// <summary>
        /// Insert StockDetail data to StockDetail Table according to the StockDetail Parameter Return Constants.DB_STATUS
        /// </summary>
        /// <param name="stockCardDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(StockCardDetail stockCardDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;


            try
            {
                inventory.AddToStockCardDetails(stockCardDetail);
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
        ///  Update StockDetail data to StockDetail Table according to the StockDetail Parameter
        ///   Return Constants.DB_STATUS
        /// </summary>
        /// <param name="stockCardDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(StockCardDetail stockCardDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
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
        /// Don't need to set the status.There is no status in StockCardDetail Table
        /// </summary>
        /// <param name="stockCardDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(StockCardDetail stockCardDetail)
        {
            throw new NotImplementedException();
        }

    }
        #endregion
    }
/****************************************/
/********* End of the Class *****************/
/****************************************/