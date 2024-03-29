﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IRequisitionCollectionBroker
    {
        int GetRequisitionCollectionId();
        RequisitionCollectionDetail GetRequisitionCollectionDetail(RequisitionCollectionDetail requisitionCollectionDetail);
        List<RequisitionCollectionDetail> GetAllRequisitionCollectionDetail();
        RequisitionCollectionDetail GetAllRequisitionCollectionDetail(string requisitionID);
        Constants.DB_STATUS Insert(RequisitionCollectionDetail newRequisitionCollectionDetail);
        Constants.DB_STATUS Update(RequisitionCollectionDetail requisitionCollectionDetail);
        Constants.DB_STATUS Delete(RequisitionCollectionDetail requisitionCollectionDetail);
        RequisitionCollection GetAllRequisitionCollectionByRequisitionCollectionID(string RCId);
        //Constants.DB_STATUS Insert(RequisitionCollectionDetail newRequisitionCollectionDetail,Boolean isSaved);
        //Constants.DB_STATUS Update(Boolean isSaved);
        //Constants.DB_STATUS Delete(RequisitionCollectionDetail requisitionCollectionDetail,Boolean isSaved);

        int GetRequisitionCollectionDetailId();
        RequisitionCollection GetRequisitionCollection(RequisitionCollection requisitionCollection);
        List<RequisitionCollection> GetAllRequisitionCollection();
        List<RequisitionCollection> GetAllRequisitionCollection(Constants.COLLECTION_STATUS collectionStatus);
        List<RequisitionCollection> GetAllRequisitionCollection(Department department, Constants.COLLECTION_STATUS collectionStatus);
        Constants.DB_STATUS Insert(RequisitionCollection newRequisitionCollection);
        Constants.DB_STATUS Update(RequisitionCollection requisitionCollection);
        Constants.DB_STATUS Delete(RequisitionCollection requisitionCollection);
        //Constants.DB_STATUS Insert(RequisitionCollection newRequisitionCollection,Boolean isSaved);
        //Constants.DB_STATUS Update(Boolean isSaved);
        //Constants.DB_STATUS Delete(RequisitionCollection requisitionCollection,Boolean isSaved);

        RequisitionCollectionDetail GetRequisitionCollectionDetail(Requisition requisition);

        //RequisitionCollectionItem GetRequisitionCollectionItem(RequisitionCollectionItem requisitionCollectionItem);
        //List<RequisitionCollectionItem> GetAllRequisitionCollectionItem();
        //Constants.DB_STATUS Insert(RequisitionCollectionItem newRequisitionCollectionItem);
        //Constants.DB_STATUS Update(RequisitionCollectionItem requisitionCollectionItem);
        //Constants.DB_STATUS Delete(RequisitionCollectionItem requisitionCollectionItem);


    }
}
