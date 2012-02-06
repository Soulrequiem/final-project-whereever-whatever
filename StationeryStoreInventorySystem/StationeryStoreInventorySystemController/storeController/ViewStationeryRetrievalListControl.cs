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
    public class ViewStationeryRetrievalListControl
    {
        private IRetrievalBroker retrievalBroker;

        private Employee currentEmployee;
        
        private List<Retrieval> retrievalList;

        private DataTable dt;
        private DataRow dr;

        private string[] columnName = { "retrievalNo", "retrievalDate/Time", "retrievedBy", "neededQty", "actualQty" };

        private DataColumn[] dataColumn;

        public ViewStationeryRetrievalListControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);

            InventoryEntities inventory=new InventoryEntities();
            retrievalBroker=new RetrievalBroker(inventory);

            retrievalList = retrievalBroker.GetAllRetrieval();

            dataColumn = new DataColumn[]{ new DataColumn(columnName[0]), 
                                           new DataColumn(columnName[1]), 
                                           new DataColumn(columnName[2]), 
                                           new DataColumn(columnName[3]), 
                                           new DataColumn(columnName[4]) };
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
        public DataTable RetrievalList
        {
            get
            {
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.AddRange(dataColumn);
                }
                else
                {
                    dt.Rows.Clear();
                }
                
                foreach (Retrieval retrieval in retrievalList)
                {
                    dr = dt.NewRow();
                    dr[columnName[0]] = retrieval.Id;
                    dr[columnName[1]] = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, retrieval.CreatedDate);
                    dr[columnName[2]] = retrieval.CreatedBy.Name;
                    dr[columnName[3]] = retrievalBroker.GetSumRetrievalDetailQty(RetrievalBroker.QTY_TYPE.NEEDED_QTY, retrieval);
                    dr[columnName[4]] = retrievalBroker.GetSumRetrievalDetailQty(RetrievalBroker.QTY_TYPE.ACTUAL_QTY, retrieval);
                    dt.Rows.Add(dr);
                }
                return dt;
            }            
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
