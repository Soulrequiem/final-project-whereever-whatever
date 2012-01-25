using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IRequisitionCollectionBroker
    {
        RequisitionCollectionDetail GetRequisitionCollectionDetail(RequisitionCollectionDetail requisitionCollectionDetail);
        List<RequisitionCollectionDetail> GetAllRequisitionCollectionDetail();
        Constants.DB_STATUS Insert(RequisitionCollectionDetail newRequisitionCollectionDetail);
        Constants.DB_STATUS Update(RequisitionCollectionDetail requisitionCollectionDetail);
        Constants.DB_STATUS Delete(RequisitionCollectionDetail requisitionCollectionDetail);

        User GetRequisitionCollection(RequisitionCollection requisitionCollection);
        List<RequisitionCollection> GetAllRequisitionCollection();
        Constants.DB_STATUS Insert(RequisitionCollection newRequisitionCollection);
        Constants.DB_STATUS Update(RequisitionCollection requisitionCollection);
        Constants.DB_STATUS Delete(RequisitionCollection requisitionCollection);

        User GetRequisitionCollectionItem(RequisitionCollectionItem requisitionCollectionItem);
        List<RequisitionCollectionItem> GetAllRequisitionCollectionItem();
        Constants.DB_STATUS Insert(RequisitionCollectionItem newRequisitionCollectionItem);
        Constants.DB_STATUS Update(RequisitionCollectionItem requisitionCollectionItem);
        Constants.DB_STATUS Delete(RequisitionCollectionItem requisitionCollectionItem);


    }
}
