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
    public class RequestStationeryControl
    {
        private Employee currentEmployee;
        private Requisition requisition;
        private IRequisitionBroker requisitionBroker;
        private List<RequisitionDetail> requisitionDetailList;
        private IItemBroker itemBroker;

        public RequestStationeryControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.EMPLOYEE);
            requisitionBroker = new RequisitionBroker();
            itemBroker = new ItemBroker();
            requisitionDetailList = new List<RequisitionDetail>();

            requisition = new Requisition();
            requisition.Employee = currentEmployee;
            requisition.Department = currentEmployee.Department;
            requisition.Id = requisitionBroker.GetRequisitionId(requisition);
        }

        public Requisition Requisition
        {
            get { return requisition; }
            set { requisition = value; }
        }

        //public DataTable TypeItemDescription(String itemDescription)
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr;
        //    List<Item> itemList = Util.GetItems(itemDescription);
        //    foreach (Item item in itemList)
        //    {
        //        dt.NewRow();
        //        dr = new DataRow();
        //        dr["id"] = item.Id;
        //        dr["description"] = item.Description;
        //    }
        //    return dt;
        //}


        public DataTable SelectItemDescription(string itemDescription)
        {
            Item item = new Item();
            item.Description = itemDescription;
            item = itemBroker.GetItem(item);
            
            DataTable dt = new DataTable();

            if (item != null)
            {
                DataRow dr = new DataRow();
                
                dt.NewRow();
                dr["itemNo"] = item.Id;
                dr["itemDescription"] = item.Description;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public Constants.ACTION_STATUS AddToTable(string itemId){
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            RequisitionDetail requisitionDetail = new RequisitionDetail();
            
            Item item = new Item();
            item.Id = itemId;
            item = itemBroker.GetItem(item);

            if (item != null)
            {
                requisitionDetail.Id = requisitionBroker.GetRequisitionDetailId();
                requisitionDetail.Item = item;
                requisitionDetailList.Add(requisitionDetail);

                status = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                status = Constants.ACTION_STATUS.FAIL;
            }

            return status;
        }

        public DataTable RequisitionDetailList
        {
            get 
            {
                DataTable dt = new DataTable();

                if (requisitionDetailList.Count > 0)
                {
                    DataRow dr;

                    foreach (RequisitionDetail requisitionDetail in requisitionDetailList)
                    {
                        dr = new DataRow();
                        
                        dt.NewRow();
                        dr["itemNo"] = requisitionDetail.Item.Id;
                        dr["itemDescription"] = requisitionDetail.Item.Description;
                        dr["requiredQty"] = requisitionDetail.Qty;
                        dt.Rows.Add(dr);
                    }
                }

                return dt;
            }
        }
        ----
        public Constants.ACTION_STATUS SelectRequest(){
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            requisition.RequisitionDetails = requisitionDetailList;
            if (requisitionBroker.Insert(requisition) == Constants.DB_STATUS.SUCCESSFULL)
            {
                status = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                status = Constants.ACTION_STATUS.FAIL;
            }

            return status;
        }

        public Constants.ACTION_STATUS SelectRemove(int requisitionDetailId)
        {
            foreach (RequisitionDetail temp in requisitionDetailList)
            {
                if (temp.Id == requisitionDetailId)
                {
                    requisitionDetailList.Remove(temp);
                    return Constants.ACTION_STATUS.SUCCESS;
                    
                }
            }
            return Constants.ACTION_STATUS.FAIL;
            
        }
    }
}
