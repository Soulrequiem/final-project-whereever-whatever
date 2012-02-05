/***************************************************************************/
/*  File Name       : CheckRequisitionControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : CheckRequisitionControl
/*  Details         : Controller representation of CheckRequisition 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class CheckRequisitionControl
    {

       
        private IRequisitionBroker requisitionBroker;
        private IItemBroker itemBroker;//addded by thazin win
        private IEmployeeBroker employeeBroker;
       

        private Employee currentEmployee;
        private Requisition requisition;
        private RequisitionDetail requisitionDetail;
        private List<Requisition> pendingRequisitionList;

        private System.Data.Objects.DataClasses.EntityCollection<Requisition> requisitionList;
   
        private DataTable dt;
        private DataRow dr;
        private DataColumn[] dataColumn;
        private string[] columnName = new string[] { "RequisitionID", "requisitionDate", "RequisitionBy", "RequisitionQty", "remarks" };
        //private string[] columnName = new string[] { "RequisitionID", "requisitionDate", "RequisitionBy", "remarks" };

        public CheckRequisitionControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.EMPLOYEE);
            InventoryEntities inventory = new InventoryEntities();

            requisitionBroker = new RequisitionBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);
            itemBroker = new ItemBroker(inventory);

            pendingRequisitionList = requisitionBroker.GetAllRequisition(Constants.REQUISITION_STATUS.PENDING);

            dataColumn = new DataColumn[] { new DataColumn(columnName[0]),
                                            new DataColumn(columnName[1]),
                                            new DataColumn(columnName[2]),
                                            new DataColumn(columnName[3]),
                                            new DataColumn(columnName[4]) };
    
            requisitionList = new System.Data.Objects.DataClasses.EntityCollection<Requisition>();
            //requisitionList = requisitionBroker.GetAllRequisition();
        }

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
                    dr[columnName[3]] = r.Remarks;

                    dt.Rows.Add(dr);

                }

                return dt;
            }
        }
        //public List<Requisition> GetRequisitionList()
        //{
        //    return requisitionList;
        //}

        /// <summary>
        ///     Show all requisition.
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:Thazin Win
        ///     Modified Date:02-02-2012
        ///     Modification Reason:Get requisition list by requistion
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name=""></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable GetRequisitionList()
        {
            dt = new DataTable();
            dt.Columns.Add("RequisitionID");
            dt.Columns.Add("requisitionDate");
            dt.Columns.Add("status");
            dt.Columns.Add("remainingQty");
            dt.Columns.Add("remarks");
            List<Requisition> requisitionList = requisitionBroker.GetAllRequisitionByEmployee(Util.GetEmployee().Id);// GetAllRequisitionByStatus();
            foreach (Requisition temp in requisitionList)
            {
                requisitionDetail = new RequisitionDetail();
                // requisitionDetail.Requisition.Id = temp.Id;
                requisitionDetail.Requisition = temp;
                //Requisition resultRequisition = requisitionBroker.GetRequisition(temp);
                RequisitionDetail resultRequisitionDetail = requisitionBroker.GetRequisitionDetail(requisitionDetail);
                
                    dr = dt.NewRow();
                    dr["RequisitionID"] = temp.Id;
                    dr["requisitionDate"] = temp.CreatedDate;

                    dr["status"] = Enum.GetName(typeof(Constants.REQUISITION_STATUS), temp.Status); 
                    dr["remainingQty"] = resultRequisitionDetail.Qty - requisitionDetail.DeliveredQty;
                    dr["remarks"] = temp.Remarks;
                    dt.Rows.Add(dr);
                //dr["requsitionId"] = temp.Id;
                //dr["requisitionDate"] = temp.CreatedDate;
                //dr["status"] = temp.Status; 
                //dr["remainingQty"] = resultRequisitionDetail.Qty-requisitionDetail.DeliveredQty;
                //dr["remarks"] = temp.Remarks;
              
            }
            return dt;
        }


        /// <summary>
        ///     Show requisition detail according to the selected requisition
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:Thazin Win
        ///     Modified Date:02-02-2012
        ///     Modification Reason:To retrieve detail data
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="requisitionId"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable SelectRequisitionID(string requisitionId)
        {
            dt = new DataTable();
            dt.Columns.Add("itemNo");
            dt.Columns.Add("itemDescription");
            dt.Columns.Add("requiredQty");
            dt.Columns.Add("receivedQty");
            dt.Columns.Add("remainingQty");

            List<RequisitionDetail> requistionDetailList;
            requisition = new Requisition();
            requisition.Id = requisitionId;
            requisitionDetail=new RequisitionDetail();
            requisitionDetail.Requisition=requisition;
            requistionDetailList = requisitionBroker.GetAllRequisitionDetailByObj(requisitionDetail);
           
          foreach (RequisitionDetail temp in requistionDetailList)
            {
                dr = dt.NewRow();

                Item item = new Item();
                item =temp.Item ;
                item = itemBroker.GetItem(item);
                dr["itemNo"] = item.Id;
                dr["itemDescription"] = item.Description;
                dr["requiredQty"] = temp.Qty;
                dr["receivedQty"] = temp.DeliveredQty.HasValue ? temp.DeliveredQty.Value : 0;
                if (temp.DeliveredQty.Equals(null))
                    dr["remainingQty"] = 0;
                else
                    dr["remainingQty"] = temp.Qty - temp.DeliveredQty;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
         ///To withdraw the requisition
        ///     Created By:Thazin Win
        ///     Created Date:03-02-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified Date:
        ///     Modification Reason: 
        /// </summary>
        /// <param name="remarks"></param>
        /// <returns></returns>
        public Constants.ACTION_STATUS SelectWithdrawRequisition(Dictionary<string, string> remarks)
        {
            return SelectActionRequisition(remarks, Constants.REQUISITION_STATUS.WITHDRAW);
        }
        private Constants.ACTION_STATUS SelectActionRequisition(Dictionary<string, string> remarks, Constants.REQUISITION_STATUS requisitionStatus)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
           // employeeBroker = new EmployeeBroker(inventory);
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
        //public Requisition EnterRequisitionID(string requisitionId)
        //{
        //    requisition = new Requisition();
        //    requisition.Id = requisitionId;
        //    requisitionBroker.GetRequisition(requisition);
        //    return requisition;
        //}

        /// <summary>
        ///     Show one requisition according to requisitionId parameter
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="requisitionId"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable EnterRequisitionID(string requisitionId)
        {
            requisition = new Requisition();
            requisition.Id = requisitionId;
            requisition = requisitionBroker.GetRequisition(requisition);
            requisitionDetail = new RequisitionDetail();
            requisitionDetail.Requisition.Id = requisitionId;
            requisitionDetail = requisitionBroker.GetRequisitionDetail(requisitionDetail);
            dt = new DataTable();

            dr = dt.NewRow();
            dr["requisitionId"] = requisition.Id;
            dr["requisitionDate/Time"] = requisition.CreatedDate;
            dr["status"] = requisition.Status;
            dr["remainingQty"] = requisitionDetail.Qty - requisitionDetail.DeliveredQty;
            dr["remarks"] = requisition.Remarks;
            dt.Rows.Add(dr);
            return dt;
        }

        //public RequisitionDetail SelectRequisitionID(string requisitionId)
        //{
        //    //requisition = new Requisition();
        //    RequisitionDetail requisitionDetail = new RequisitionDetail();
        //    requisitionDetail.Id = requisitionId;
        //    RequisitionDetail resultRequisitionDetail=requisitionBroker.GetRequisitionDetail(requisitionDetail);

        //}

     
        /// <summary>
        ///     Refresh requisition list after withdraw one requisition
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="requisitionId"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public Constants.ACTION_STATUS SelectWithdraw(string requisitionId)
        {
            Constants.REQUISITION_STATUS requisitionStatus = Constants.REQUISITION_STATUS.WITHDRAW;
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            requisition = new Requisition();
            requisition.Id = requisitionId;
            requisition.Status = Converter.objToInt(requisitionStatus);
            if (requisitionBroker.Update(requisition) == Constants.DB_STATUS.FAILED)
            {
                status = Constants.ACTION_STATUS.FAIL;
            }
            else
            {
                status = Constants.ACTION_STATUS.SUCCESS;
            }

            return status;
            //Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            //Constants.DB_STATUS dbStatus = requisitionBroker.Delete(requisition);
            //dbStatus = Constants.DB_STATUS.SUCCESSFULL;
            //if (requisitionList.Count == 1)
            //    return null;
            //else
            //    return GetRequisitionList();
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
