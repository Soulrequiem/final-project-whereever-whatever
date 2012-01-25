using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;


namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IStockCardBroker
    {
        StockCard GetStockCard(StockCard stockCard);
        List<StockCard> GetAllStockCard();
        Constants.DB_STATUS Insert(StockCard newStockCard);
        Constants.DB_STATUS Update(StockCard stockCard);
        Constants.DB_STATUS Delete(StockCard stockCard);

        StockCardDetail GetStockCardDetail(StockCardDetail stockCardDetail);
        List<StockCardDetail> GetAllStockCardDetail();
        Constants.DB_STATUS Insert(StockCardDetail newStockCardDetail);
        Constants.DB_STATUS Update(StockCardDetail stockCardDetail);
        Constants.DB_STATUS Delete(StockCardDetail stockCardDetail);
    }
}
