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
        private Employee employee;
        private Requisition requisition;
        IRequisitionBroker requisitionBroker;
        List<RequisitionDetail> requisitionDetailList;
        IItemBroker itemBroker;

        public RequestStationeryControl()
        {
            employee = Util.GetEmployee();
            requisition = new Requisition();
            requisition.Employee = employee;
            requisitionBroker = new RequisitionBroker();
            requisitionDetailList = new List<RequisitionDetail>();
            itemBroker = new ItemBroker();

        }

        public Requisition Requisition
        {
            get { return requisition; }
            set { requisition = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
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


        public DataTable EnterItemDescription(String itemDescription)
        {
            IItemBroker itemBroker = new ItemBroker();
            Item item = new Item();
            item.Description = itemDescription;
            Item resultItem = itemBroker.GetItem(item);
            DataTable dt = new DataTable();
            DataRow dr;
            dt.NewRow();
            dr = new DataRow();
            dr["itemNo"] = item.Id;
            dr["itemDescription"] = item.Description;
            dt.Rows.Add(dr);
            return dt;
            
        }

        public Constants.ACTION_STATUS AddToTable(String itemId){
            RequisitionDetail requisitionDetail = new RequisitionDetail();
            Item item = new Item();
            item.Id = itemId;
            item = itemBroker.GetItem(item);
            requisitionDetail.Id = requisitionBroker.GetRequisitionDetailId();
            requisitionDetail.Item = item;
            requisitionDetailList.Add(requisitionDetail);
            return Constants.ACTION_STATUS.SUCCESS;

        }

        public Constants.ACTION_STATUS SelectRequest(){
            Requisition requisition = new Requisition();
            requisition.Id = requisitionBroker.GetRequisitionId();
            requisition.RequisitionDetails = requisitionDetailList;
            requisitionBroker.Insert(requisition);
            return Constants.ACTION_STATUS.SUCCESS;
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
