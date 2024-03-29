﻿using System;
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
        private IEmployeeBroker employeeBroker;
        
        private Employee currentEmployee;
        private Requisition requisition;
        
        private DataTable dt;
        private DataRow dr;

        private string[] columnName = { "ItemNo", "ItemDescription", "RequiredQty" };

        private DataColumn[] dataColumn;

        private int itemAdded;
        
        public RequestStationeryControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.EMPLOYEE);
            InventoryEntities inventory = new InventoryEntities();

            requisitionBroker = new RequisitionBroker(inventory);
            itemBroker = new ItemBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);

            requisition = new Requisition();
            requisition.CreatedBy = Util.GetEmployee(employeeBroker);
            requisition.Department = requisition.CreatedBy.Department;
            requisition.Status = Converter.objToInt(Constants.REQUISITION_STATUS.PENDING);
            requisition.Id = requisitionBroker.GetRequisitionId(requisition);

            itemAdded = 0;

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
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.AddRange(dataColumn);
                    DataColumn[] keys = new DataColumn[1];
                    DataColumn dc = dataColumn[0];
                    keys[0] = dc;
                    dt.PrimaryKey = keys;
                }
                else
                {
                    dt.Rows.Clear();
                }

                if (requisition.RequisitionDetails.Count > 0)
                {
                    foreach (RequisitionDetail requisitionDetail in requisition.RequisitionDetails)
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
                if (requisition.RequisitionDetails.Where(x=> x.Item.Id == itemId).Count() == 0)
                {
                    requisitionDetail = new RequisitionDetail();
                    requisitionDetail.Id = requisitionBroker.GetRequisitionDetailId() + (itemAdded++);
                    requisitionDetail.Requisition = requisition;
                    requisitionDetail.Item = item;
                    requisitionDetail.Qty = 1;

                    requisition.RequisitionDetails.Add(requisitionDetail);
                    status = Constants.ACTION_STATUS.SUCCESS;
                }
                else
                {
                    status = Constants.ACTION_STATUS.FAIL;
                }
            }
            else
            {
                status = Constants.ACTION_STATUS.FAIL;
            }

            return status;
        }

        public Constants.ACTION_STATUS SelectRequest(Dictionary<string, int> quantity)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            foreach (string itemId in quantity.Keys)
            {
                if (requisition.RequisitionDetails.Where(x => x.Item.Id == itemId).Count() > 0)
                {
                    requisition.RequisitionDetails.Where(x => x.Item.Id == itemId).First().Qty = quantity[itemId];
                }
            }

            //int index = 0;
            //foreach (RequisitionDetail requisitionDetail in requisition.RequisitionDetails)
            //{
            //    requisitionDetail.Qty = Converter.objToInt(requisitionDetailTable.Rows[index++][columnName[2]]);
            //}

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

            if (requisition.RequisitionDetails.Count > 0)
            {

                RequisitionDetail requisitionDetail;
                List<RequisitionDetail> requisitionDetailToBeRemoved = new List<RequisitionDetail>();
                int totalDeleted = 0;

                foreach (int i in index)
                {
                    requisitionDetail = requisition.RequisitionDetails.ElementAt(i - (totalDeleted++));
                    //requisitionDetail = requisition.RequisitionDetails.ElementAt(i);
                    requisition.RequisitionDetails.Remove(requisitionDetail);
                    //if (requisitionDetail != null)
                    //{
                    //    requisitionDetailToBeRemoved.Add(requisitionDetail);
                        status = Constants.ACTION_STATUS.SUCCESS;
                    //}
                    //else
                    //{
                    //    status = Constants.ACTION_STATUS.FAIL;
                    //    break;
                    //}
                }

                //if (status == Constants.ACTION_STATUS.SUCCESS)
                //{
                //    foreach (RequisitionDetail rd in requisitionDetailToBeRemoved)
                //    {
                //        requisition.RequisitionDetails.Remove(rd);
                //    }

                //    itemAdded -= totalDeleted;

                //    requisition.RequisitionDetails.OrderBy(x=> x.Id);
                //}                
            }
            else
            {
                status = Constants.ACTION_STATUS.FAIL;
            }

            return status;            
        }

        public Constants.ACTION_STATUS SelectRemoveAll()
        {
            if (requisition.RequisitionDetails.Count() > 0)
            {
                requisition.RequisitionDetails.Clear();
                itemAdded = 0;
                return Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                return Constants.ACTION_STATUS.FAIL;
            }
        }
    }
}
