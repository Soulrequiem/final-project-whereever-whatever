using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IDiscrepancyBroker
    {
        Discrepancy GetDiscrepancy(Discrepancy discrepancy);
        List<Discrepancy> GetAllDiscrepancy();
        Constants.DB_STATUS Insert(Discrepancy newDiscrepancy);
        Constants.DB_STATUS Update(Discrepancy discrepancy);
        Constants.DB_STATUS Delete(Discrepancy discrepancy);
        int GetDiscrepancyId();

        DiscrepancyDetail GetDiscrepancyDetail(DiscrepancyDetail discrepancyDetail);
        List<DiscrepancyDetail> GetAllDiscrepancyDetail();
        Constants.DB_STATUS Insert(DiscrepancyDetail newDiscrepancyDetail);
        Constants.DB_STATUS Update(DiscrepancyDetail discrepancyDetail);
        Constants.DB_STATUS Delete(DiscrepancyDetail discrepancyDetail);
        int GetDiscrepancyDetailId();

        StockAdjustment GetStockAdjustment(StockAdjustment stockAdjustment);
        List<StockAdjustment> GetAllStockAdjustment();
        Constants.DB_STATUS Insert(StockAdjustment newStockAdjustment);
        Constants.DB_STATUS Update(StockAdjustment stockAdjustment);
        Constants.DB_STATUS Delete(StockAdjustment stockAdjustment);
        string GetStockAdjustmentId();
    }
}
