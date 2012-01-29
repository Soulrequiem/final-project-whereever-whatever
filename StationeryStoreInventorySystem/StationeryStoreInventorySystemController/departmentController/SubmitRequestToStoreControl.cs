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
        
        private IRequisitionBroker requisitionBroker;

        private Employee currentEmployee;

        private List<Requisition> approvedRequisitionList;

        private DataTable dt;
        private DataRow dr;

        public SubmitRequestToStoreControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);
            InventoryEntities inventory = new InventoryEntities();

            requisitionBroker = new RequisitionBroker(inventory);

            approvedRequisitionList = requisitionBroker.GetAllRequisition(Constants.REQUISITION_STATUS.APPROVED);
        }

        public DataTable ApprovedRequisitionList
        {
            get
            {
                dt = new DataTable();
                
                foreach (Requisition requisition in approvedRequisitionList)
                {
                    dr = dt.NewRow();
                    dr["requisitionId"] = requisition.Id;
                    dr["requisitionDateTime"] = requisition.ApprovedDate;
                    dr["requisitionBy"] = requisition.CreatedBy.Name;
                    dr["requisitionStatus"] = requisition.Status;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
        }

        public Requisition SelectRequisition(string requisitionId)
        {
            return approvedRequisitionList.Find(delegate(Requisition requisition) { return requisition.Id.Equals(requisitionId); });
        }

        public Constants.ACTION_STATUS SelectSubmit(List<string> requisitionIdList)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            Requisition requisition;

            foreach (string requisitionId in requisitionIdList)
            {
                requisition = approvedRequisitionList.Find(delegate(Requisition req) { return req.Id.Equals(requisitionId); });
                requisition.Status = Converter.objToInt(Constants.REQUISITION_STATUS.SUBMITTED);

                if (requisitionBroker.Update(requisition) == Constants.DB_STATUS.SUCCESSFULL)
                    status = Constants.ACTION_STATUS.SUCCESS;
                else
                    status = Constants.ACTION_STATUS.FAIL;
            }

            return status;
        }
    }
}
