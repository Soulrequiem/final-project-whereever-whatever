/***************************************************************************/
/*  File Name       : Item.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : Item,StockCardDetail
/*  Details         : Model item data and stockdetail representation of Item and StockDetail table
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
        private StockCardDetail stockCardDetailObj = null;
        private List<StockCardDetail> stockCardDetailList = null;

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
            try
            {
                itemObj = inventory.Items.Where(iObj => iObj.Id == item.Id || iObj.Description.Contains(item.Description)).First();
            }
            catch (Exception e)
            {
                itemObj=null;
            }
            return itemObj;
        }

        /// <summary>
        ///  Retrieve All of the item information from Item Table
        /// </summary>
        /// <returns></returns>
        public List<Item> GetAllItem()
        {
            try
            {
                itemList = inventory.Items.ToList<Item>();
            }
            catch (Exception e)
            {
                itemList = null;
            }
            return itemList;
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
                    Employee createdBy = inventory.Employees.Where(eObj => eObj.Id == item.CreatedBy.Id).First();
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
        /// <returns>
        /// Returns the List of Item
        /// </returns>
        public List<Item> GetItemReference(Item item)
        {
            try
            {
                itemList = inventory.Items.Where(r => r.Description.Contains(item.Description)).ToList();
            }
            catch (Exception e)
            {
                itemList = null;
            }
            return itemList;

        }
        /// <summary>
        ///  Retrieve the StockCardDetail information according to the stockCardDetail Parameter 
        /// </summary>
        /// <param name="stockCardDetail"></param>
        /// <returns></returns>
        public StockCardDetail GetStockCardDetail(StockCardDetail stockCardDetail)
        {
            try
            {
                stockCardDetailObj = inventory.StockCardDetails.Where(stcDetailObj => stcDetailObj.Id == stockCardDetail.Id).First();
            }
            catch (Exception e)
            {
                stockCardDetailObj = null;
            }
            return stockCardDetailObj;
        }
        /// <summary>
        ///  Retrieve StockDetail data to the StockDetail Table according to the StockCardDetail Parameter
        /// </summary>
        /// <returns></returns>
        public List<StockCardDetail> GetAllStockCardDetail()
        {
            try
            {
                stockCardDetailList = inventory.StockCardDetails.ToList<StockCardDetail>();
            }
            catch (Exception e)
            {
                stockCardDetailList = null;
            }
            return stockCardDetailList;
        }

        public List<StockCardDetail> GetAllStockCardDetail(Item item)
        {
            try
            {
                stockCardDetailList = inventory.StockCardDetails.Where(x=> x.Item.Id == item.Id).ToList<StockCardDetail>();
            }
            catch (Exception e)
            {
                stockCardDetailList = null;
            }
            return stockCardDetailList;
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
                StockCardDetail stcDetail = inventory.StockCardDetails.Where(s => s.Id == stockCardDetail.Id).First();
                if (!stcDetail.Equals(null))
                {
                    Item item = inventory.Items.Where(i => i.Id == stockCardDetail.Item.Id).First();
                    Employee createdBy = inventory.Employees.Where(e => e.Id == stockCardDetail.CreatedBy.Id).First();
                    stcDetail.Id = stockCardDetail.Id;
                    stcDetail.Item = item;
                    stcDetail.Description = stockCardDetail.Description;
                    stcDetail.Qty = stockCardDetail.Qty;
                    stcDetail.Balance = stockCardDetail.Balance;
                    stcDetail.CreatedDate = stockCardDetail.CreatedDate;
                    stcDetail.CreatedBy = createdBy;
                    inventory.AddToStockCardDetails(stockCardDetail);
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
/********* End of the Class *************/
/****************************************/