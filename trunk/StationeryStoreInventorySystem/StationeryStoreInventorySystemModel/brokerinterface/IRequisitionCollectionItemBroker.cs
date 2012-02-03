using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IRequisitionCollectionItemBroker
    {
        int GetRequisitionCollectionItemId();
        RequisitionCollectionItem GetRequisitionCollectionItem(RequisitionCollectionItem requisitionCollectionItem);
        List<RequisitionCollectionItem> GetAllRequisitionCollectionItem();
        Constants.DB_STATUS Insert(RequisitionCollectionItem newRequisitionCollectionItem);
        Constants.DB_STATUS Update(RequisitionCollectionItem requisitionCollectionItem);
        Constants.DB_STATUS Delete(RequisitionCollectionItem requisitionCollectionItem);

    }
}
