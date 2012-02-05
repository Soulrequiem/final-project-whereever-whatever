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
    public class SubmitRequestToStoreControl
    {
        private InventoryEntities inventory;

        private IRequisitionBroker requisitionBroker;
        private IRequisitionCollectionBroker requisitionCollectionBroker;
        private IEmployeeBroker employeeBroker;

        private Employee currentEmployee;
        private RequisitionCollection requisitionCollection;

        private List<Requisition> approvedRequisitionList;
        
        private DataTable dt;
        private DataRow dr;

        private string[] columnName = { "RequisitionID", "RequisitionDateTime", "RequisitionBy", "RequisitionStatus" };

        private DataColumn[] dataColumn;

        public static readonly string UNKNOWN_COLLECTION_POINT = "Not Yet Set";

        public SubmitRequestToStoreControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);
            inventory = new InventoryEntities();

            requisitionBroker = new RequisitionBroker(inventory);
            requisitionCollectionBroker = new RequisitionCollectionBroker(inventory);
            employeeBroker = new EmployeeBroker(inventory);

            Employee employee = new Employee();
            employee.Id = currentEmployee.Id;
            employee = employeeBroker.GetEmployee(employee);

            requisitionCollection = new RequisitionCollection(requisitionCollectionBroker.GetRequisitionCollectionId(), employee.Department, employee.Department.CollectionPoint, DateTime.Now, employee, Converter.objToInt(Constants.COLLECTION_STATUS.NEED_TO_COLLECT));

            approvedRequisitionList = requisitionBroker.GetAllRequisition(Constants.REQUISITION_STATUS.APPROVED, currentEmployee.Department);

            dataColumn = new DataColumn[] { new DataColumn(columnName[0]),
                                            new DataColumn(columnName[1]),
                                            new DataColumn(columnName[2]),
                                            new DataColumn(columnName[3]) };
        }

        public string CollectionPoint { get { return currentEmployee.Department.CollectionPoint == null ? UNKNOWN_COLLECTION_POINT : currentEmployee.Department.CollectionPoint.Name; } }
        public string CollectionId { get { return requisitionCollection.Id.ToString(); } }

        public DataTable ApprovedRequisitionList
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
                
                foreach (Requisition requisition in approvedRequisitionList)
                {
                    dr = dt.NewRow();
                    dr[columnName[0]] = requisition.Id;
                    dr[columnName[1]] = requisition.ApprovedDate;
                    dr[columnName[2]] = requisition.CreatedBy.Name;
                    dr[columnName[3]] = Converter.GetRequisitionStatusText(Converter.objToRequisitionStatus(requisition.Status));
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }

        public Requisition SelectRequisition(string requisitionId)
        {
            return approvedRequisitionList.Find(delegate(Requisition requisition) { return requisition.Id.Equals(requisitionId); });
        }

        public Constants.ACTION_STATUS SelectSubmit()
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            try
            {

                foreach (Requisition requisition in approvedRequisitionList)
                {
                    requisition.Status = Converter.objToInt(Constants.REQUISITION_STATUS.SUBMITTED);

                    requisitionCollection.RequisitionCollectionDetails.Add(new RequisitionCollectionDetail(requisitionCollectionBroker.GetRequisitionCollectionDetailId(), requisition, requisitionCollection));

                    if (requisitionBroker.Update(requisition) == Constants.DB_STATUS.SUCCESSFULL)
                    {
                        status = Constants.ACTION_STATUS.SUCCESS;
                    }
                    else
                    {
                        status = Constants.ACTION_STATUS.FAIL;
                        break;
                    }
                }

                if (status == Constants.ACTION_STATUS.SUCCESS)
                {
                    approvedRequisitionList = new List<Requisition>();
                    requisitionCollectionBroker.Insert(requisitionCollection);
                    //inventory.SaveChanges();
                }
            }
            catch (Exception e)
            {
                status = Constants.ACTION_STATUS.FAIL;
            }

            return status;
        }
    }
}
