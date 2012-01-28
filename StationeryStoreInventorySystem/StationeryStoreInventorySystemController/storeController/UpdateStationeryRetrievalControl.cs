/***************************************************************************/
/*  File Name       : UpdateStationeryRetrievalControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : UpdateStationeryRetrievalControl
/*  Details         : Control representation of UpdateStationeryRetrievalControl 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemController.storeController;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class UpdateStationeryRetrievalControl
    {
        private IRetrievalBroker retrievalBroker;
        private InventoryEntities inventory;
        private IRequisitionCollectionBroker requisitionCollectionBroker;

        public UpdateStationeryRetrievalControl()
        {
            inventory = new InventoryEntities();
            retrievalBroker = new RetrievalBroker(inventory);
        }
        /// <summary>
        ///     Update stationery retrieval by collection point
        ///     Created By:JinChengCheng
        ///     Created Date:28-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name=""></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable GetCollectionIDList()
        {
            DataTable dt = new DataTable();
            DataRow dr = new DataRow();
            requisitionCollectionBroker = new RequisitionCollectionBroker(inventory);
            List<RequisitionCollection> collectionList = requisitionCollectionBroker.GetAllRequisitionCollection();
            foreach (RequisitionCollection temp in collectionList)
            {
                dt.NewRow();
                dr["collectionId"]=temp.Id;
                dr["collectionPoint"] = temp.CollectionPoint.Name;
                dr["collectionDate/Time"] = temp.CollectionPoint.Time;
                dr["departmentRepresentativeName"] = temp.Department.Representative.Name;
                dr["departmentName"] = temp.Department.Name;
                dr["collectionStatus"] = Constants.COLLECTION_STATUS.NEED_TO_COLLECT;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public Constants.ACTION_STATUS SetCollectionStatus(Constants.COLLECTION_STATUS collectionStatus, List<string> collectionIdList)
        {
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/

