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

        private string[] columnName = { "ItemNo", "ItemDescription", "RequiredQty" };

        private DataColumn[] dataColumn;
        
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

            dataColumn = new DataColumn[] { new DataColumn(columnName[0]),
                                            new DataColumn(columnName[1]),
                                            new DataColumn(columnName[2]) };
        }

        public Requisition Requisition { get { return requisition; } }

        public string RequisitionId { get { return requisition.Id; } }
        public string DepartmentCode { get { return requisition.Department.Id; } }
        public string DepartmentName { get{ return requisition.Department.Name; } }
        public string EmployeeName { get { return requisition.CreatedBy.Name; } }
        public string EmployeeId { get { return requisition.CreatedBy.Id.ToString(); } }
        public string EmployeeEmail { get { return requisition.CreatedBy.Email; } }

        public DataTable RequisitionDetailList
        {
            get
            {
                dt = new DataTable();
                dt.Columns.AddRange(dataColumn);

                if (requisitionDetailList.Count > 0)
                {
                    foreach (RequisitionDetail requisitionDetail in requisitionDetailList)
                    {
                        dr = dt.NewRow();
                        dr[columnName[0]] = requisitionDetail.Item.Id;
                        dr[columnName[1]] = requisitionDetail.Item.Description;
                        dr[columnName[2]] = requisitionDetail.Qty;
                        dt.Rows.Add(dr);
                    }
                }

                return dt;
            }
        }

        public DataTable SelectItemDescription(string itemDescription)
        {
            return Util.GetItemTable(itemBroker, itemDescription);
        }

        public Constants.ACTION_STATUS AddToTable(string itemId){
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            RequisitionDetail requisitionDetail;
            
            Item item = new Item();
            item.Id = itemId;
            item = itemBroker.GetItem(item);

            if (item != null)
            {
                requisitionDetail = new RequisitionDetail();
                requisitionDetail.Id = requisitionBroker.GetRequisitionDetailId();
                requisitionDetail.Requisition = requisition;
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

        public Constants.ACTION_STATUS SelectRequest(DataTable requisitionDetailTable){
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            int index = 0;
            foreach (RequisitionDetail requisitionDetail in requisitionDetailList)
            {
                requisitionDetail.Qty = Converter.objToInt(requisitionDetailTable.Rows[index++][columnName[2]]);
            }

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

        public Constants.ACTION_STATUS SelectRemove(List<int> index)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            if (requisitionDetailList.Count > 0)
            {

                RequisitionDetail requisitionDetail;

                foreach (int i in index)
                {
                    requisitionDetail = requisitionDetailList.ElementAt(i - 1);

                    if (requisitionDetailList.Contains(requisitionDetail))
                    {
                        requisitionDetailList.Remove(requisitionDetail);
                        status = Constants.ACTION_STATUS.SUCCESS;
                    }
                }
            }
            else
            {
                status = Constants.ACTION_STATUS.FAIL;
            }

            return status;            
        }
    }
}
