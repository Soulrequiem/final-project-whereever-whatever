/***************************************************************************/
/*  File Name       : ApproveRejectRequisitionControl.cs
/*  Module Name     : Controller
/*  Owner           : SanLaPyaye
/*  class Name      : ApproveRejectRequisitionControl
/*  Details         : Controller representation of ApproveRejectRequisitionControl
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemModel.brokerinterface;
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class ApproveRejectRequisitionControl
    {
        private commonController.RequisitionDetailsControl requisitionDetailsControl;
        
        private IRequisitionBroker requisitionBroker;
        private IEmployeeBroker employeeBroker;
        
        private Employee currentEmployee;

        private List<Requisition> pendingRequisitionList;
        private List<Requisition> approvedRequisitionList;
        
        private DataTable dt;
        private DataRow dr;

        private string[] columnName = new string[] { "RequisitionID", "RequisitionDate/Time", "RequisitionBy", "RequisitionQty", "Remarks" };

        private DataColumn[] dataColumn;

        /// <summary>
        ///     The usage of this method is to show the Requisitions List.
        ///     Created By: SanLaPyaye
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>

        public ApproveRejectRequisitionControl() 
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD);
            requisitionDetailsControl = new commonController.RequisitionDetailsControl();
            InventoryEntities inventory = new InventoryEntities();

            requisitionBroker = new RequisitionBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);

            pendingRequisitionList = requisitionBroker.GetAllRequisition(Constants.REQUISITION_STATUS.PENDING, currentEmployee.Department);

            dataColumn = new DataColumn[] { new DataColumn(columnName[0]),
                                            new DataColumn(columnName[1]),
                                            new DataColumn(columnName[2]),
                                            new DataColumn(columnName[3]),
                                            new DataColumn(columnName[4]) };
        }

        /// <summary>
        ///     The usage of this method is to show the requisitions list  
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <returns>Return the list of requisitions. </returns>

        //***********
        //public List<Requisition> GetRequisition()
        //{            
        //    return requisitionBroker.GetAllRequisition();
        //}
        //***********

        public DataTable PendingRequisitionList
        {
            get
            {
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.AddRange(dataColumn);
                }
                else
                {
                    dt.Rows.Clear();
                }
                
                int qty;
                foreach (Requisition r in pendingRequisitionList)
                {
                    qty = 0;
                    dr = dt.NewRow(); 
                    dr[columnName[0]] = r.Id;
                    dr[columnName[1]] = Convert.ToDateTime(r.CreatedDate);
                    dr[columnName[2]] = r.CreatedBy.Name;


                    //List<RequisitionDetail> requisitionDetailList=requisitionBroker.GetRequisitionDetail(r.RequisitionDetails);
                    foreach (RequisitionDetail reqDetail in r.RequisitionDetails)
                    {
                        qty += reqDetail.Qty;
                    }
                    dr[columnName[3]] = qty;
                    dr[columnName[4]] = r.Remarks;

                    dt.Rows.Add(dr);

                }

                return dt;
            }
        }

        /// <summary>
        ///     The usage of this method is to show the "Requisition Details"
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="requisitionID">Get the "Requisition ID" when user click "Requisition ID" link. </param>
        public void SelectRequisition(string requisitionId)
        {
            requisitionDetailsControl = new commonController.RequisitionDetailsControl();
            requisitionDetailsControl.SelectRequisition(pendingRequisitionList.Find(delegate(Requisition req) { return requisitionId == req.Id; }));
        }
        
        /// <summary>
        ///     The usage of this method is to approve the selected "Requisition ID" 
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="requisitionID">Get the "Requisition ID" when user click "Requisition ID" link. </param>
        //public Constants.DB_STATUS SelectApproveRequisition(string requisitionID)
        //{
        //    Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;
        //    Requisition requisition = new Requisition();
        //    requisition.Id = requisitionID;
        //    requisitionBroker.Update(requisition);
        //    return status;
            
        //}

        public Constants.ACTION_STATUS SelectApproveRequisition(Dictionary<string, string> remarks)
        {
            return SelectActionRequisition(remarks, Constants.REQUISITION_STATUS.APPROVED);
        }

        public Constants.ACTION_STATUS SelectRejectRequisition(Dictionary<string, string> remarks)
        {
            return SelectActionRequisition(remarks, Constants.REQUISITION_STATUS.REJECTED);
        }

        private Constants.ACTION_STATUS SelectActionRequisition(Dictionary<string, string> remarks, Constants.REQUISITION_STATUS requisitionStatus)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            if (remarks.Count > 0)
            {
                status = Constants.ACTION_STATUS.SUCCESS;
                Requisition requisition;

                Employee employee = new Employee();
                employee.Id = currentEmployee.Id;
                employee = employeeBroker.GetEmployee(employee);

                foreach (string key in remarks.Keys)
                {
                    requisition = pendingRequisitionList.ElementAt(Converter.objToInt(key));
                    requisition.Status = Converter.objToInt(requisitionStatus);
                    requisition.Remarks = remarks[key];
                    requisition.ApprovedBy = employee;
                    requisition.ApprovedDate = DateTime.Now;

                    pendingRequisitionList.Remove(requisition);

                    if (requisitionBroker.Update(requisition) == Constants.DB_STATUS.FAILED)
                    {
                        status = Constants.ACTION_STATUS.FAIL;
                        break;
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
/****************************************/
/********* End of the Class *****************/
/****************************************/