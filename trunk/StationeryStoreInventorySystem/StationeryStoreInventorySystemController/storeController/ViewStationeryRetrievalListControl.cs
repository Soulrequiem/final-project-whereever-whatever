/***************************************************************************/
/*  File Name       : ViewStationeryRetrievalListControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : ViewStationeryRetrievalListControl
/*  Details         : Controller representation of ViewStationeryRetrievalList 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    class ViewStationeryRetrievalListControl
    {
        private IRetrievalBroker retrievalBroker;
        
        private List<RetrievalDetail> retrievalDetailList;

        private DataTable dt;
        private DataRow dr;

        public ViewStationeryRetrievalListControl()
        {
            InventoryEntities inventory=new InventoryEntities();
            retrievalBroker=new RetrievalBroker(inventory);
        }

        /// <summary>
        ///     Show stationery retrieval list
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
        public DataTable GetStationeryRetrievalList()
        {
            dt = new DataTable();
            retrievalDetailList = retrievalBroker.GetAllRetrievalDetail();
            foreach (RetrievalDetail temp in retrievalDetailList)
            {
                dr = dt.NewRow();
                dr["retrievalNo"] = temp.Retrieval.Id;
                dr["retrievalDate/Time"] = temp.Retrieval.CreatedDate;
                dr["retrievedBy"] = temp.Retrieval.CreatedBy;
                dr["neededQty"] = temp.NeededQty;
                dr["actualQty"] = temp.ActualQty;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
