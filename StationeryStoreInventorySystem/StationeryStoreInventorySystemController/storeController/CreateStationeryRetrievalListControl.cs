using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class CreateStationeryRetrievalListControl
    {
        private InventoryEntities inventory;

        private IRequisitionCollectionBroker requisitionCollectionBroker;
        private IRetrievalBroker retrievalBroker;
        private IItemBroker itemBroker;
        private IEmployeeBroker employeeBroker;

        private Employee currentEmployee;
        private Retrieval retrieval;

        private List<RequisitionCollection> requisitionCollectionList;
        private List<Retrieval> retrievalList;
        private List<RetrievalDetail> retrievalDetail;

        private DataTable collectionDataTable;
        private DataTable retrievalDetailDataTable;

        private DataRow dr;

        private string[] collectionColumnName = { "CollectionID", "CollectionDateTime", "Department", "DepartmentStatus" };
        private string[] retrievalDetailColumnName = { };

        private DataColumn[] collectionDataColumn;
        private DataColumn[] retrievalDetailDataColumn;

        public CreateStationeryRetrievalListControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);
            inventory = new InventoryEntities();

            retrievalBroker = new RetrievalBroker(inventory);
            requisitionCollectionBroker = new RequisitionCollectionBroker(inventory);
            itemBroker = new ItemBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);

            //retrievalList = retrievalBroker.GetAllRetrieval();
            requisitionCollectionList = requisitionCollectionBroker.GetAllRequisitionCollection(Util.GetEmployee(employeeBroker).Department, Constants.COLLECTION_STATUS.NEED_TO_COLLECT);

            collectionDataColumn = new DataColumn[] { new DataColumn(collectionColumnName[0]),
                                                      new DataColumn(collectionColumnName[1]),
                                                      new DataColumn(collectionColumnName[2]),
                                                      new DataColumn(collectionColumnName[3]) };
        }

        public DataTable RequisitionCollectionList
        {
            get 
            {
                if (collectionDataTable == null)
                {
                    collectionDataTable = new DataTable();
                    collectionDataTable.Columns.AddRange(collectionDataColumn);
                }
                else
                {
                    collectionDataTable.Rows.Clear();
                }

                foreach (RequisitionCollection requisitionCollection in requisitionCollectionList)
                {
                    dr = collectionDataTable.NewRow();
                    dr[collectionColumnName[0]] = requisitionCollection.Id;
                    dr[collectionColumnName[1]] = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, requisitionCollection.CreatedDate);
                    dr[collectionColumnName[2]] = requisitionCollection.Department.Name;
                    dr[collectionColumnName[3]] = Converter.GetDepartmentStatusText(Converter.objToDepartmentStatus(requisitionCollection.Department.Status));
                    collectionDataTable.Rows.Add(dr);
                }

                return collectionDataTable;
            }
        }

        //public DataTable RetrievalList
        //{
        //    get 
        //    {
        //        if (retrievalDataTable == null)
        //        {
        //            retrievalDataTable = new DataTable();
        //            retrievalDataTable.Columns.AddRange(retrievalDataColumn);
        //        }
        //        else
        //        {
        //            retrievalDataTable.Rows.Clear();
        //        }

        //        return retrievalDataTable;
        //    }
        //}

        //public Constants.ACTION_STATUS SelectRetrieval(int retrievalId)
        //{
        //    Constants.ACTION_STATUS selectStatus = Constants.ACTION_STATUS.UNKNOWN;

        //    retrieval = retrievalList.Find(delegate(Retrieval r) { return r.Id == retrievalId; });

        //    if (retrieval != null)
        //    {
        //        selectStatus = Constants.ACTION_STATUS.SUCCESS;
        //    }
        //    else
        //    {
        //        selectStatus = Constants.ACTION_STATUS.FAIL;
        //    }

        //    return selectStatus;
        //}

        public DataTable RetrievalDetailList
        {
            get
            {
                if (retrievalDetailDataTable == null)
                {
                    retrievalDetailDataTable = new DataTable();
                    retrievalDetailDataTable.Columns.AddRange(retrievalDetailDataColumn);
                }
                else
                {
                    retrievalDetailDataTable.Rows.Clear();
                }

                if (retrieval != null)
                {
                    // not yet existed
                    if (retrieval.RetrievalDetails.Count() == 0)
                    {

                    }
                }

                return retrievalDetailDataTable;
            }
        }
    }
}
