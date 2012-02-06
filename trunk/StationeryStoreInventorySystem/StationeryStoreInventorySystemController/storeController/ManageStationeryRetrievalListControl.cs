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

        private Employee currentEmployee;
        private Retrieval retrieval;

        private Dictionary<string, List<object>> retrievalList;
        private Dictionary<string, List<object>> unfulfilledRetrievalList;

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
        }

        public ManageStationeryRetrievalListControl(int retrievalId)
        {
            init();

            retrieval = new Retrieval();
            retrieval.Id = retrievalId;
            retrieval = retrievalBroker.GetRetrieval(retrieval);
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

                List<object> retrievalInfo;

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
                                ((RetrievalTable)retrievalInfo[4]).Add(requisitionCollectionDetail.Requisition.Department.Name, requisitionDetail.Qty, 0);

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
                                retrievalInfo.Add(new RetrievalTable(requisitionCollectionDetail.Requisition.Department.Name, requisitionDetail.Qty, 0));

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
            }
        }
    }

    class RetrievalTable : DataTable
    {
        public RetrievalTable()
        {
            this.Columns.AddRange(new DataColumn[] { new DataColumn("Department"), new DataColumn("NeededQty"), new DataColumn("ActualQty") });
        }

        public RetrievalTable(string departmentName, int neededQty, int actualQty)
            : this()
        {
            this.Add(departmentName, neededQty, actualQty);
        }

        public void Add(string departmentName, int neededQty, int actualQty)
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
