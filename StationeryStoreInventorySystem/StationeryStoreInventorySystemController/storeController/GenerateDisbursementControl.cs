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
        private IRequisitionBroker requisitionBroker;
        private IRequisitionCollectionBroker requisitionCollectionBroker;
        private IEmployeeBroker employeeBroker;
        
        private Employee currentEmployee;

        private List<Retrieval> retrievalList;
        private Dictionary<RequisitionCollection, DateTime> requisitionCollectionList;
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
            requisitionCollectionBroker = new RequisitionCollectionBroker(inventory);
            requisitionBroker = new RequisitionBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);
            
            retrievalList = retrievalBroker.GetAllRetrieval();
            
            requisitionCollectionList = new Dictionary<RequisitionCollection, DateTime>();
            
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

        public Constants.ACTION_STATUS SetDeliveryDate(int retrievalNo, DateTime deliveryDate)
        {
            Constants.ACTION_STATUS setStatus = Constants.ACTION_STATUS.UNKNOWN;

            Retrieval retrieval = retrievalList.Find(delegate(Retrieval r) { return r.Id == retrievalNo; });

            
            foreach (RetrievalDetail retrievalDetail in retrieval.RetrievalDetails)
            {
                Requisition requisition = new Requisition();
                requisition.Id = retrievalDetail.Requisition.Id;
                requisition = requisitionBroker.GetRequisition(requisition);

                RequisitionCollectionDetail requisitionCollectionDetail = requisitionCollectionBroker.GetRequisitionCollectionDetail(requisition);

                RequisitionCollection requisitionCollection = new RequisitionCollection();
                requisitionCollection.Id = requisitionCollectionDetail.RequisitionCollection.Id;
                requisitionCollection = requisitionCollectionBroker.GetRequisitionCollection(requisitionCollection);
                requisitionCollection.DeliveryDate = DateTime.Now;
                requisitionCollection.DeliveryBy = Util.GetEmployee(employeeBroker);

                requisitionCollectionBroker.Update(requisitionCollection);
            }

            return setStatus;
        }
    }
}
