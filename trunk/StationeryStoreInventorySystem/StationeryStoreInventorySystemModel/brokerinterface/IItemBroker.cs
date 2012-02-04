using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;
using System.Data.Objects.DataClasses;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IItemBroker
    {
        Item GetItem(Item item);
        List<Item> GetAllItem();
        List<Item> GetItemReference(Item item);
        Constants.DB_STATUS Insert(Item newItem);
        Constants.DB_STATUS Update(Item item);
        Constants.DB_STATUS Delete(Item item);
        //Constants.DB_STATUS Insert(Item newItem, Boolean isSaved);
        //Constants.DB_STATUS Update(Boolean isSaved);
        //Constants.DB_STATUS Delete(Item item, Boolean isSaved);
        
        StockCardDetail GetStockCardDetail(StockCardDetail stockCardDetail);
        List<StockCardDetail> GetAllStockCardDetail();
        List<StockCardDetail> GetAllStockCardDetail(Item item);
        Constants.DB_STATUS Insert(StockCardDetail newStockCardDetail);
        Constants.DB_STATUS Update(StockCardDetail stockCardDetail);
        Constants.DB_STATUS Delete(StockCardDetail stockCardDetail);
        //Constants.DB_STATUS Insert(StockCardDetail newStockCardDetail,Boolean isSaved);
        //Constants.DB_STATUS Update(Boolean isSaved);
        //Constants.DB_STATUS Delete(StockCardDetail stockCardDetail,Boolean isSaved);
    }
}
