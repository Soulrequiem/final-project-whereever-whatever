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
    public class ManageStationeryRetrievalListControl
    {
        private InventoryEntities inventory;

        private IRetrievalBroker retrievalBroker;
        private IRequisitionCollectionBroker requisitionCollectionBroker;
        private IEmployeeBroker employeeBroker;
        private IItemBroker itemBroker;
        private IDepartmentBroker departmentBroker;

        private Employee currentEmployee;
        private Retrieval retrieval;

        private Dictionary<string, List<object>> retrievalList;
        private Dictionary<string, List<object>> unfulfilledRetrievalList;
        List<object> retrievalInfo;

        private DataTable dtRetrievalDetail;

        private DataRow dr;

        public static readonly int totalRetrievalToSet = 5;

        private void init()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);
            inventory = new InventoryEntities();

            retrievalBroker = new RetrievalBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);
            itemBroker = new ItemBroker(inventory);
            departmentBroker = new DepartmentBroker(inventory);
        }

        public ManageStationeryRetrievalListControl(int retrievalId)
        {
            init();

            retrieval = new Retrieval();
            retrieval.Id = retrievalId;
            retrieval = retrievalBroker.GetRetrieval(retrieval);

            retrievalList = new Dictionary<string, List<object>>();
            unfulfilledRetrievalList = new Dictionary<string, List<object>>();

            foreach (RetrievalDetail retrievalDetail in retrieval.RetrievalDetails)
            {
                if (unfulfilledRetrievalList.ContainsKey(retrievalDetail.Item.Id.Trim()))
                {
                    retrievalInfo = unfulfilledRetrievalList[retrievalDetail.Item.Id];
                    retrievalInfo[2] = Converter.objToInt(retrievalInfo[2]) + Converter.objToInt(retrievalDetail.NeededQty);
                    ((RetrievalTable)retrievalInfo[4]).Add(retrievalDetail.Department.Name, retrievalDetail.NeededQty, retrievalDetail.ActualQty.HasValue ? retrievalDetail.ActualQty.Value : 0, DateTime.Now);// retrievalDetail.Requisition.CreatedDate);

                    // have the same total with current balance / fulfilled
                    //if (Converter.objToInt(retrievalInfo[2]) <= Converter.objToInt(retrievalInfo[3]))
                    //{
                    //    ((RetrievalTable)retrievalInfo[4]).FullFill();
                    //    retrievalList.Add(requisitionDetail.Item.Id, retrievalInfo);
                    //    unfulfilledRetrievalList.Remove(requisitionDetail.Item.Id);
                    //}
                    //else
                    //{
                    unfulfilledRetrievalList[retrievalDetail.Item.Id] = retrievalInfo;
                    //}
                }
                else
                {
                    retrievalInfo = new List<object>();
                    retrievalInfo.Add(retrievalDetail.Item.Description);
                    retrievalInfo.Add(retrievalDetail.Item.Bin);
                    retrievalInfo.Add(retrievalDetail.NeededQty);
                    int currentItemBalance = itemBroker.GetCurrentBalance(retrievalDetail.Item);
                    retrievalInfo.Add(currentItemBalance);
                    retrievalInfo.Add(new RetrievalTable(retrievalDetail.Department.Name, retrievalDetail.NeededQty, retrievalDetail.ActualQty.HasValue ? retrievalDetail.ActualQty.Value : 0, DateTime.Now));// requisitionCollectionDetail.Requisition.CreatedDate));

                    //if (requisitionDetail.Qty <= currentItemBalance)
                    //{
                    //    retrievalList.Add(requisitionDetail.Item.Id, retrievalInfo);
                    //}
                    //else
                    //{
                    unfulfilledRetrievalList.Add(retrievalDetail.Item.Id.Trim(), retrievalInfo);
                    //}
                }
            }


        }

        public string RetrievalId { get { return retrieval.Id.ToString(); } }

        public Dictionary<string, List<object>> RetrievalList
        {
            get
            {
                return retrievalList;
            }
        }

        public Dictionary<string, List<object>> UnfulfilledRetrievalList
        {
            get
            {
                return unfulfilledRetrievalList;
            }
        }

        public void SetBasedOnRequestSequence(string itemDescription, int totalActualQty)
        {
            ((RetrievalTable)unfulfilledRetrievalList[Util.GetItem(itemBroker, itemDescription).Id][4]).SetBasedOnRequestSequence(totalActualQty);
        }

        public ManageStationeryRetrievalListControl(object obj)
        {
            if (obj is List<RequisitionCollection>)
            {
                init();
                requisitionCollectionBroker = new RequisitionCollectionBroker(inventory);
                List<RequisitionCollection> requisitionCollectionList = (List<RequisitionCollection>)obj;

                retrieval = new Retrieval(retrievalBroker.GetRetrievalId(), DateTime.Now, Util.GetEmployee(employeeBroker), Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW));

                retrievalList = new Dictionary<string, List<object>>();
                unfulfilledRetrievalList = new Dictionary<string, List<object>>();

                foreach (RequisitionCollection requisitionCollection in requisitionCollectionList)
                {
                    foreach (RequisitionCollectionDetail requisitionCollectionDetail in requisitionCollection.RequisitionCollectionDetails)
                    {
                        foreach (RequisitionDetail requisitionDetail in requisitionCollectionDetail.Requisition.RequisitionDetails)
                        {
                            if (unfulfilledRetrievalList.ContainsKey(requisitionDetail.Item.Id.Trim()))
                            {
                                retrievalInfo = unfulfilledRetrievalList[requisitionDetail.Item.Id];
                                retrievalInfo[2] = Converter.objToInt(retrievalInfo[2]) + Converter.objToInt(requisitionDetail.Qty);
                                ((RetrievalTable)retrievalInfo[4]).Add(requisitionCollectionDetail.Requisition.Department.Name, requisitionDetail.Qty, 0, requisitionCollectionDetail.Requisition.CreatedDate);

                                // have the same total with current balance / fulfilled
                                //if (Converter.objToInt(retrievalInfo[2]) <= Converter.objToInt(retrievalInfo[3]))
                                //{
                                //    ((RetrievalTable)retrievalInfo[4]).FullFill();
                                //    retrievalList.Add(requisitionDetail.Item.Id, retrievalInfo);
                                //    unfulfilledRetrievalList.Remove(requisitionDetail.Item.Id);
                                //}
                                //else
                                //{
                                    unfulfilledRetrievalList[requisitionDetail.Item.Id] = retrievalInfo;
                                //}
                            }
                            else
                            {
                                retrievalInfo = new List<object>();
                                retrievalInfo.Add(requisitionDetail.Item.Description);
                                retrievalInfo.Add(requisitionDetail.Item.Bin);
                                retrievalInfo.Add(requisitionDetail.Qty);
                                int currentItemBalance = itemBroker.GetCurrentBalance(requisitionDetail.Item);
                                retrievalInfo.Add(currentItemBalance);
                                retrievalInfo.Add(new RetrievalTable(requisitionCollectionDetail.Requisition.Department.Name, requisitionDetail.Qty, 0, requisitionCollectionDetail.Requisition.CreatedDate));

                                //if (requisitionDetail.Qty <= currentItemBalance)
                                //{
                                //    retrievalList.Add(requisitionDetail.Item.Id, retrievalInfo);
                                //}
                                //else
                                //{
                                    unfulfilledRetrievalList.Add(requisitionDetail.Item.Id.Trim(), retrievalInfo);
                                //}
                            }
                        }
                    }
                    requisitionCollection.Status = Converter.objToInt(Constants.COLLECTION_STATUS.NEED_TO_COLLECT);
                    requisitionCollectionBroker.Update(requisitionCollection);
                }

                List<string> keyToBeRemoved = new List<string>();
                foreach (string key in unfulfilledRetrievalList.Keys)
                {
                    retrievalInfo = unfulfilledRetrievalList[key];
                    if (((RetrievalTable)retrievalInfo[4]).GetTotalQty("NeededQty") <= Converter.objToInt(retrievalInfo[3]))
                    {
                        ((RetrievalTable)retrievalInfo[4]).FullFill();
                        retrievalList.Add(key, retrievalInfo);
                        keyToBeRemoved.Add(key);
                    }
                }

                foreach (string key in keyToBeRemoved)
                {
                    unfulfilledRetrievalList.Remove(key);
                }

                int addedId = 0;

                foreach (string key in retrievalList.Keys)
                {
                    retrievalInfo = retrievalList[key];
                    Item item = new Item();
                    item.Id = key;
                    item = itemBroker.GetItem(item);

                    foreach(DataRow dr in ((RetrievalTable)retrievalInfo[4]).Rows)
                    {
                        RetrievalDetail retrievalDetail = new RetrievalDetail();
                        retrievalDetail.Id = retrievalBroker.GetRetrievalDetailId() + (addedId++);
                        retrievalDetail.Item = item;

                        Department department = new Department();
                        department.Name = dr["Department"].ToString();
                        department = departmentBroker.GetDepartment(department);
                        retrievalDetail.Department = department;

                        retrievalDetail.NeededQty = Converter.objToInt(dr["NeededQty"]);
                        retrievalDetail.ActualQty = Converter.objToInt(dr["ActualQty"]);
                    
                        retrieval.RetrievalDetails.Add(retrievalDetail);
                    }
                }

                foreach (string key in unfulfilledRetrievalList.Keys)
                {
                    retrievalInfo = unfulfilledRetrievalList[key];
                    Item item = new Item();
                    item.Id = key;
                    item = itemBroker.GetItem(item);

                    foreach (DataRow dr in ((RetrievalTable)retrievalInfo[4]).Rows)
                    {
                        RetrievalDetail retrievalDetail = new RetrievalDetail();
                        retrievalDetail.Id = retrievalBroker.GetRetrievalDetailId() + (addedId++);
                        retrievalDetail.Item = item;

                        Department department = new Department();
                        department.Name = dr["Department"].ToString();
                        department = departmentBroker.GetDepartment(department);
                        retrievalDetail.Department = department;

                        retrievalDetail.NeededQty = Converter.objToInt(dr["NeededQty"]);
                        retrievalDetail.ActualQty = Converter.objToInt(dr["ActualQty"]);

                        retrieval.RetrievalDetails.Add(retrievalDetail);
                    }
                }

                if (retrievalBroker.Insert(retrieval) == Constants.DB_STATUS.FAILED)
                {
                    // do something
                }
            }
        }
    }

    class RetrievalTable : DataTable
    {
        public RetrievalTable()
        {
            this.Columns.AddRange(new DataColumn[] { new DataColumn("Department"), new DataColumn("NeededQty"), new DataColumn("ActualQty"), new DataColumn("CreatedDate") });
        }

        public RetrievalTable(string departmentName, int neededQty, int actualQty, DateTime createdDate)
            : this()
        {
            this.Add(departmentName, neededQty, actualQty, createdDate);
        }

        public void Add(string departmentName, int neededQty, int actualQty, DateTime createdDate)
        {
            bool isExist = false;

            foreach (DataRow dr in this.Rows)
            {
                if (dr["Department"].Equals(departmentName))
                {
                    dr["NeededQty"] = Converter.objToInt(dr["NeededQty"]) + neededQty;
                    isExist = true;
                }
            }

            if (!isExist)
            {
                DataRow dr = this.NewRow();
                dr["Department"] = departmentName;
                dr["NeededQty"] = neededQty;
                dr["ActualQty"] = actualQty;
                dr["CreatedDate"] = createdDate;
                this.Rows.Add(dr);
            }
        }

        public void FullFill()
        {
            foreach (DataRow dr in this.Rows)
            {
                dr["ActualQty"] = dr["NeededQty"];
            }
        }

        public void SetBasedOnRequestSequence(int totalActualQty)
        {
            this.Select("Department = Department", "CreatedDate");

            int neededQty = 0;
            
            foreach (DataRow dr in this.Rows)
            {
                neededQty = Converter.objToInt(dr["NeededQty"]);

                if (totalActualQty == neededQty)
                {
                    dr["ActualQty"] = totalActualQty;
                    totalActualQty = 0;
                }
                else if (totalActualQty > neededQty){
                    dr["ActualQty"] = neededQty;
                    totalActualQty -= neededQty;
                }
                else if (totalActualQty < neededQty)
                {
                    dr["ActualQty"] = totalActualQty;
                    totalActualQty = 0;
                }
            }
        }

        public int GetTotalQty(string columnName)
        {
            int totalQty = 0;
            foreach (DataRow dr in this.Rows)
            {
                totalQty += Converter.objToInt(dr[columnName]);
            }

            return totalQty;
        }
    }
}
