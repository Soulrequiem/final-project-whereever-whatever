using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IPurchaseOrderBroker
    {
        int GetPurchaseOrderId();
        int GetPurchaseOrderDetailId();
        PurchaseOrder GetPurchaseOrder(PurchaseOrder purchaseOrder);
        List<PurchaseOrder> GetAllPurchaseOrder();
        Constants.DB_STATUS Insert(PurchaseOrder newPurchaseOrder);
        Constants.DB_STATUS Update(PurchaseOrder purchaseOrder);
        Constants.DB_STATUS Delete(PurchaseOrder purchaseOrder);

        PurchaseOrderDetail GetPurchaseOrderDetail(PurchaseOrderDetail purchaseOrderDetail);
        List<PurchaseOrderDetail> GetAllPurchaseOrderDetail();
        Constants.DB_STATUS Insert(PurchaseOrderDetail newPurchaseOrderDetail);
        Constants.DB_STATUS Update(PurchaseOrderDetail purchaseOrderDetail);
        Constants.DB_STATUS Delete(PurchaseOrderDetail purchaseOrderDetail);
    }
}
