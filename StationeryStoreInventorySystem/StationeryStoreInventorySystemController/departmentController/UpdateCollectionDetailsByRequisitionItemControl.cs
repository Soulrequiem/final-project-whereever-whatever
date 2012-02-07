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
        private IRequisitionCollectionItemBroker requisitionCollectionItemBroker;
        private IItemBroker itemBroker;
        private IEmployeeBroker employeeBroker;

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
            requisitionCollectionItemBroker = new RequisitionCollectionItemBroker(inventory);
            itemBroker = new ItemBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);

            requisitionCollectionList = requisitionCollectionBroker.GetAllRequisitionCollection(currentEmployee.Department, Constants.COLLECTION_STATUS.NEED_TO_COLLECT);
            //collectedRequisitionCollectionList = requisitionCollectionBroker.GetAllRequisitionCollection(currentEmployee.Department, Constants.COLLECTION_STATUS.COLLECTED);

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

                    Dictionary<Item, int> items = new Dictionary<Item, int>();
                    Dictionary<Item, int> collectedItems = new Dictionary<Item, int>();

                    foreach (RequisitionCollectionDetail requisitionCollectionDetail in requisitionCollection.RequisitionCollectionDetails)
                    {
                        foreach (RequisitionDetail requisitionDetail in requisitionCollectionDetail.Requisition.RequisitionDetails)
                        {
                            if (items.ContainsKey(requisitionDetail.Item))
                            {
                                items[requisitionDetail.Item] += requisitionDetail.Qty;
                            }
                            else
                            {
                                items.Add(requisitionDetail.Item, requisitionDetail.Qty);

                            }
                        }
                    }

                    RequisitionCollectionItem requisitionCollectionItem;

                    foreach (Item item in items.Keys)
                    {
                        if (requisitionCollection.RequisitionCollectionItems != null && requisitionCollection.RequisitionCollectionItems.Count() > 0)
                        {
                            if (requisitionCollection.RequisitionCollectionItems.Where(x => x.Item.Id == item.Id).Count() > 0)
                            {
                                requisitionCollectionItem = requisitionCollection.RequisitionCollectionItems.Where(x => x.Item.Id == item.Id).First();
                                if (requisitionCollectionItem != null)
                                {
                                    collectedItems.Add(item, requisitionCollectionItem.Qty.HasValue ? requisitionCollectionItem.Qty.Value : Converter.objToInt(items[item] * 0.9));
                                }
                                else
                                {
                                    collectedItems.Add(item, Converter.objToInt(items[item] * 0.9));
                                }
                            }
                            else
                            {
                                collectedItems.Add(item, Converter.objToInt(items[item] * 0.9));
                            }
                        }
                        else
                        {
                            collectedItems.Add(item, Converter.objToInt(items[item] * 0.9));
                        }
                    }

                    foreach (Item key in items.Keys)
                    {
                        dr = dtItemDetailList.NewRow();
                        dr[itemDetailColumnName[0]] = key.Id;
                        dr[itemDetailColumnName[1]] = key.Description;
                        dr[itemDetailColumnName[2]] = items[key].ToString();
                        dr[itemDetailColumnName[3]] = collectedItems[key];
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

        public Constants.ACTION_STATUS UpdateRequisitionCollection(Dictionary<string, int> itemsCollected)
        {
            Constants.ACTION_STATUS updateStatus = Constants.ACTION_STATUS.UNKNOWN;

            int addedItem = 0;

            foreach (string key in itemsCollected.Keys)
            {
                if (requisitionCollection.RequisitionCollectionItems.Where(x => x.Item.Id == key).Count() > 0)
                {
                    RequisitionCollectionItem requisitionCollectionItem = requisitionCollection.RequisitionCollectionItems.Where(x => x.Item.Id == key).First();
                    requisitionCollectionItem.Qty = itemsCollected[key];
                }
                else
                {
                    Item item = new Item();
                    item.Id = key;
                    item = itemBroker.GetItem(item);

                    Employee employee = new Employee();
                    employee.Id = currentEmployee.Id;
                    employee = employeeBroker.GetEmployee(employee);

                    requisitionCollection.RequisitionCollectionItems.Add(new RequisitionCollectionItem(requisitionCollectionItemBroker.GetRequisitionCollectionItemId() + (addedItem++), requisitionCollection, item, itemsCollected[key], DateTime.Now, employee, Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW)));
                } 
            }

            if (requisitionCollectionBroker.Update(requisitionCollection) == Constants.DB_STATUS.SUCCESSFULL)
            {
                updateStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                updateStatus = Constants.ACTION_STATUS.FAIL;
            }

            return updateStatus;
        }

        public void SelectModifyDeliveredQuantity(int index)
        {
        }
    }
}
