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
    public class UpdateCollectionDetailsByRequisitionItemControl
    {
        private InventoryEntities inventory;

        private IRequisitionCollectionBroker requisitionCollectionBroker;

        private commonController.RequisitionDetailsControl requisitionDetailsControl;

        private Employee currentEmployee;
        private RequisitionCollection requisitionCollection;

        private List<RequisitionCollection> requisitionCollectionList;
        private List<RequisitionCollection> collectedRequisitionCollectionList;

        private DataTable dtCollectionList;
        private DataTable dtItemDetailList;
        private DataRow dr;

        private string[] collectionListColumnName = { "CollectionID", "CollectionPoint", "CollectionDay", "CollectionDateTime", "CollectionStatus" };
        private string[] itemDetailColumnName = { "ItemNo", "ItemDescription", "RequiredQty", "ActualQty" };

        private DataColumn[] collectionListDataColumn;
        private DataColumn[] itemDetailDataColumn;

        public UpdateCollectionDetailsByRequisitionItemControl()
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

            itemDetailDataColumn = new DataColumn[] { new DataColumn(itemDetailColumnName[0]),
                                                             new DataColumn(itemDetailColumnName[1]),
                                                             new DataColumn(itemDetailColumnName[2]),
                                                             new DataColumn(itemDetailColumnName[3]) };
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

        public DataTable ItemDetail
        {
            get 
            {
                if (requisitionCollection != null)
                {
                    if (dtItemDetailList == null)
                    {
                        dtItemDetailList = new DataTable();
                        dtItemDetailList.Columns.AddRange(itemDetailDataColumn);
                    }
                    else
                    {
                        dtItemDetailList.Rows.Clear();
                    }

                    Dictionary<Item, List<int>> items = new Dictionary<Item, List<int>>();

                    foreach (RequisitionCollectionDetail requisitionCollectionDetail in requisitionCollection.RequisitionCollectionDetails)
                    {
                        foreach (RequisitionDetail requisitionDetail in requisitionCollectionDetail.Requisition.RequisitionDetails)
                        {
                            if (items.ContainsKey(requisitionDetail.Item))
                            {
                                List<int> quantity = items[requisitionDetail.Item];
                                quantity[0] += requisitionDetail.Qty;
                                if (requisitionDetail.DeliveredQty.HasValue)
                                {
                                    quantity[1] += requisitionDetail.DeliveredQty.Value;
                                }
                                else
                                {
                                    quantity[1] += Converter.objToInt(requisitionDetail.DeliveredQty.Value * 0.9);
                                }
                            }
                            else
                            {
                                List<int> quantity = new List<int>();
                                quantity.Add(requisitionDetail.Qty);
                                if (requisitionDetail.DeliveredQty.HasValue)
                                {
                                    quantity.Add(requisitionDetail.DeliveredQty.Value);
                                }
                                else
                                {
                                    quantity.Add(Converter.objToInt(requisitionDetail.Qty * 0.9));
                                }
                                items.Add(requisitionDetail.Item, quantity);

                            }
                        }
                    }

                    foreach (Item key in items.Keys)
                    {
                        dr = dtItemDetailList.NewRow();
                        dr[itemDetailColumnName[0]] = key.Id;
                        dr[itemDetailColumnName[1]] = key.Description;
                        List<int> quantity = items[key];
                        dr[itemDetailColumnName[2]] = quantity[0].ToString();
                        dr[itemDetailColumnName[3]] = quantity[1].ToString();
                        dtItemDetailList.Rows.Add(dr);
                    }
                }

                return dtItemDetailList;
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
