using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemController.storeController
{
    public class ViewAdjustmentVoucherListControl
    {
        IDiscrepancyBroker discrepancyBroker = new DiscrepancyBroker();
        public ViewAdjustmentVoucherListControl()
        {
        }

        public List<StockAdjustment> GetStockAdjustment(StockAdjustment stockAdjustment)
        {
            
            List<StockAdjustment> stockAdjustmentList = discrepancyBroker.GetAllStockAdjustment();
            return stockAdjustmentList;
        }

        public StockAdjustment SelectAdjustmentVoucherList(String id)
        {
            StockAdjustment stockAdjustment = new StockAdjustment();
            stockAdjustment.id = id;
            StockAdjustment resultStockAdjustment = discrepancyBroker.GetStockAdjustment(stockAdjustment);
            return resultStockAdjustment;

        }
    }
}
