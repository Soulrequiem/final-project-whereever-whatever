using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using System.Data;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemController.storeController
{
    public class GenerateDisbursementControl
    {
        private InventoryEntities inventory;

        private IRetrievalBroker retrievalBroker;
        private ICollectionPointBroker collectionPointBroker;

        private Employee currentEmployee;

        private List<Retrieval> retrievalList;
        //private List<CollectionPoint> collectionPointList;

        private DataTable dt;//, dtCollectionPoint;
        private DataRow dr;

        private string[] columnName = { "RetrievalNo", "RetrievalDate/Time", "RetrievedQty", "RetrievedBy" };
        //private string[] collectionColumnName = { "CollectionID", "CollectionPoint" };

        private DataColumn[] dataColumn;
        //private DataColumn[] collectionDataColumn; // for drop down list

        public GenerateDisbursementControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);

            inventory = new InventoryEntities();
            retrievalBroker = new RetrievalBroker(inventory);
            collectionPointBroker = new CollectionPointBroker(inventory);

            retrievalList = retrievalBroker.GetAllRetrieval();
            //collectionPointList = collectionPointBroker.GetAllCollectionPoint();

            dataColumn = new DataColumn[]{ new DataColumn(columnName[0]),
                                           new DataColumn(columnName[1]),
                                           new DataColumn(columnName[2]),
                                           new DataColumn(columnName[3]) };

            //collectionDataColumn = new DataColumn[] { new DataColumn(collectionColumnName[0]),
            //                                          new DataColumn(collectionColumnName[1]) };
        }

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
                    dr[columnName[2]] = retrievalBroker.GetSumRetrievalDetailQty(RetrievalBroker.QTY_TYPE.ACTUAL_QTY, retrieval);
                    dr[columnName[3]] = retrieval.CreatedBy.Name;
                    dt.Rows.Add(dr);
                }

                return dt;
            }
        }

        //public DataTable CollectionPointList
        //{
        //    get
        //    {
        //        if (dtCollectionPoint == null)
        //        {
        //            dtCollectionPoint = new DataTable();
        //            dtCollectionPoint.Columns.AddRange(collectionDataColumn);
        //        }
        //        else
        //        {
        //            dtCollectionPoint.Rows.Clear();
        //        }

        //        foreach (CollectionPoint collectionPoint in collectionPointList)
        //        {
        //            dr = dtCollectionPoint.NewRow();
        //            dr[collectionColumnName[0]] = collectionPoint.Id;
        //            dr[collectionColumnName[1]] = collectionPoint.Name;
        //            dtCollectionPoint.Rows.Add(dr);
        //        }

        //        return dtCollectionPoint;
        //    }
        //}
    }
}
