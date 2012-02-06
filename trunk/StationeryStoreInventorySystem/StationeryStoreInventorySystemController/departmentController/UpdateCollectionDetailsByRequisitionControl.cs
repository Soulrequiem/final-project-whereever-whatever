using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class UpdateCollectionDetailsByRequisitionControl
    {
        private InventoryEntities inventory;

        private IRequisitionCollectionBroker requisitionCollectionBroker;

        private commonController.RequisitionDetailsControl requisitionDetailsControl;

        private Employee currentEmployee;
        private RequisitionCollection requisitionCollection;

        private List<RequisitionCollection> requisitionCollectionList;
        private List<RequisitionCollection> collectedRequisitionCollectionList;

        private DataTable dtCollectionList;
        private DataTable dtRequisitionDetailList;
        private DataRow dr;

        private string[] collectionListColumnName = { "CollectionID", "CollectionPoint", "CollectionDay", "CollectionDateTime", "CollectionStatus" };
        private string[] requisitionDetailColumnName = { "RequisitionID", "RequisitionDateTime", "RequisitionBy", "RequisitionStatus" };

        private DataColumn[] collectionListDataColumn;
        private DataColumn[] requisitionDetailDataColumn;
        
        public UpdateCollectionDetailsByRequisitionControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);
            inventory = new InventoryEntities();

            requisitionCollectionBroker = new RequisitionCollectionBroker(inventory);

            requisitionCollectionList = requisitionCollectionBroker.GetAllRequisitionCollection(currentEmployee.Department, Constants.COLLECTION_STATUS.NEED_TO_COLLECT);
            collectedRequisitionCollectionList = requisitionCollectionBroker.GetAllRequisitionCollection(currentEmployee.Department, Constants.COLLECTION_STATUS.COLLECTED);

            collectionListDataColumn = new DataColumn[] { new DataColumn(collectionListColumnName[0]),
                                                          new DataColumn(collectionListColumnName[1]),
                                                          new DataColumn(collectionListColumnName[2]),
                                                          new DataColumn(collectionListColumnName[3]),
                                                          new DataColumn(collectionListColumnName[4]) };

            requisitionDetailDataColumn = new DataColumn[] { new DataColumn(requisitionDetailColumnName[0]),
                                                             new DataColumn(requisitionDetailColumnName[1]),
                                                             new DataColumn(requisitionDetailColumnName[2]),
                                                             new DataColumn(requisitionDetailColumnName[3]) };
        }

        public DataTable CollectionList
        {
            get 
            {
                if (dtCollectionList == null)
                {
                    dtCollectionList = new DataTable();
                    dtCollectionList.Columns.AddRange(collectionListDataColumn);
                }
                else
                {
                    dtCollectionList.Rows.Clear();
                }

                if (requisitionCollectionList != null)
                {
                    setCollectionList(requisitionCollectionList);
                }

                if (collectedRequisitionCollectionList != null)
                {
                    setCollectionList(collectedRequisitionCollectionList);
                }

                return dtCollectionList;
            }
        }

        private void setCollectionList(List<RequisitionCollection> requisitionCollectionList)
        {
            foreach (RequisitionCollection requisitionCollection in requisitionCollectionList)
            {
                dr = dtCollectionList.NewRow();
                dr[collectionListColumnName[0]] = requisitionCollection.Id;
                dr[collectionListColumnName[1]] = requisitionCollection.CollectionPoint.Name;
                dr[collectionListColumnName[2]] = "Monday";
                dr[collectionListColumnName[3]] = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, requisitionCollection.CreatedDate);
                dr[collectionListColumnName[4]] = Converter.GetCollectionStatusText(Converter.objToCollectionStatus(requisitionCollection.Status));
                dtCollectionList.Rows.Add(dr);
            }
        }

        public string RequestDetailCollectionId { get { return requisitionCollection != null ? requisitionCollection.Id.ToString() : String.Empty; } }
        public string RequestDetailCollectionDateTime { get { return String.Empty; } }//return RequestDetail != null && requisitionCollection.CollectionDate != null ? Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, requisitionCollection.CollectionDate) : String.Empty; } }
        public string RequestDetailCollectionPoint { get { return requisitionCollection != null ? requisitionCollection.CollectionPoint.Name : String.Empty; } }

        public DataTable RequestDetail
        {
            get 
            {
                if (requisitionCollection != null)
                {
                    if (dtRequisitionDetailList == null)
                    {
                        dtRequisitionDetailList = new DataTable();
                        dtRequisitionDetailList.Columns.AddRange(requisitionDetailDataColumn);
                    }
                    else
                    {
                        dtRequisitionDetailList.Rows.Clear();
                    }

                    foreach (RequisitionCollectionDetail requisitionCollectionDetail in requisitionCollection.RequisitionCollectionDetails)
                    {
                        if (requisitionCollectionDetail.Requisition.Status == (int)Constants.REQUISITION_STATUS.SUBMITTED)
                        {
                            dr = dtRequisitionDetailList.NewRow();
                            dr[requisitionDetailColumnName[0]] = requisitionCollectionDetail.Requisition.Id;
                            dr[requisitionDetailColumnName[1]] = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, requisitionCollectionDetail.Requisition.CreatedDate);
                            dr[requisitionDetailColumnName[2]] = requisitionCollectionDetail.Requisition.CreatedBy.Name;
                            dr[requisitionDetailColumnName[3]] = Converter.GetRequisitionStatusText(Converter.objToRequisitionStatus(requisitionCollectionDetail.Requisition.Status));
                            dtRequisitionDetailList.Rows.Add(dr);
                        }
                    }
                }

                return dtRequisitionDetailList;
            }
        }

        public Constants.ACTION_STATUS SelectCollection(int collectionId)
        {
            Constants.ACTION_STATUS selectStatus = Constants.ACTION_STATUS.UNKNOWN;

            this.requisitionCollection = null;

            setRequisitionCollection(collectionId, requisitionCollectionList);
            
            if (this.requisitionCollection == null)
            {
                setRequisitionCollection(collectionId, collectedRequisitionCollectionList);    
            }

            if (this.requisitionCollection != null)
            {
                selectStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                selectStatus = Constants.ACTION_STATUS.FAIL;
            }

            return selectStatus;
        }

        private void setRequisitionCollection(int collectionId, List<RequisitionCollection> requisitionCollectionList)
        {
            foreach (RequisitionCollection requisitionCollection in requisitionCollectionList)
            {
                if (requisitionCollection.Id == collectionId)
                {
                    this.requisitionCollection = requisitionCollection;
                    break;
                }
            }
        }

        public void SelectModifyDeliveredQuantity(int index)
        {
        }
    }
}
