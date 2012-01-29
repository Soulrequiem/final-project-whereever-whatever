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
        private IRequisitionBroker requisitionBroker;
        private IItemBroker itemBroker;
        
        private Employee currentEmployee;
        private Requisition requisition;
        
        private System.Data.Objects.DataClasses.EntityCollection<RequisitionDetail> requisitionDetailList;

        private DataTable dt;
        private DataRow dr;
        
        public RequestStationeryControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.EMPLOYEE);
            InventoryEntities inventory = new InventoryEntities();

            requisitionBroker = new RequisitionBroker(inventory);
            itemBroker = new ItemBroker(inventory);
            requisitionDetailList = new System.Data.Objects.DataClasses.EntityCollection<RequisitionDetail>();

            requisition = new Requisition();
            requisition.CreatedBy = currentEmployee;
            requisition.Department = currentEmployee.Department;
            requisition.Id = requisitionBroker.GetRequisitionId(requisition);
        }

        public Requisition Requisition
        {
            get { return requisition; }
        }

        public DataTable RequisitionDetailList
        {
            get
            {
                dt = new DataTable();

                if (requisitionDetailList.Count > 0)
                {
                    foreach (RequisitionDetail requisitionDetail in requisitionDetailList)
                    {
                        dr = dt.NewRow();
                        dr["itemNo"] = requisitionDetail.Item.Id;
                        dr["itemDescription"] = requisitionDetail.Item.Description;
                        dr["requiredQty"] = requisitionDetail.Qty;
                        dt.Rows.Add(dr);
                    }
                }

                return dt;
            }
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
            
            dt = new DataTable();

            if (item != null)
            {
                dr = dt.NewRow();
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

        //----
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

        public Constants.ACTION_STATUS SelectRemove(List<int> requisitionDetailId)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            foreach (int id in requisitionDetailId)
            {
                foreach (RequisitionDetail temp in requisitionDetailList)
                {
                    if (temp.Id == id)
                    {
                        requisitionDetailList.Remove(temp);
                        status = Constants.ACTION_STATUS.SUCCESS;
                    }
                }
            }

            return status;            
        }
    }
}
