using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;
namespace StationeryStoreInventorySystemModel.brokerinterface
{
    interface IRequisitionCollectionItemsBroker
    {
        RequisitionCollectionItem GetRequisitionCollectionItem(RequisitionCollectionItem requisitionCollectionItem);
        List<RequisitionCollectionItem> GetAllRequisitionCollectionItem();
        Constants.DB_STATUS Insert(RequisitionCollectionItem newRequisitionCollectionItem);
        Constants.DB_STATUS Update(RequisitionCollectionItem requisitionCollectionItem);
        Constants.DB_STATUS Delete(RequisitionCollectionItem requisitionCollectionItem);
        //Constants.DB_STATUS Insert(RequisitionCollectionItem newRequisitionCollectionItem,Boolean isSaved);
        //Constants.DB_STATUS Update(Boolean isSaved);
        //Constants.DB_STATUS Delete(RequisitionCollectionItem requisitionCollectionItem,Boolean isSaved);
    }
}
