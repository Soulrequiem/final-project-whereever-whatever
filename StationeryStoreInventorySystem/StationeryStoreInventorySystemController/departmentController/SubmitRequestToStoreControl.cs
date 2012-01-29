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

        private DataTable dt;
        private DataRow dr;

        public SubmitRequestToStoreControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);
            InventoryEntities inventory = new InventoryEntities();

            requisitionBroker = new RequisitionBroker(inventory);
        }

        public DataTable GetApprovedRequisition()
        {
            dt = new DataTable();
            List<Requisition> requisitionList = requisitionBroker.GetAllRequisition();
            List<Requisition> resultList = new List<Requisition>();
            foreach (Requisition requisition in requisitionList)
            {
                if (requisition.Status == (int)Constants.REQUISITION_STATUS.APPROVED)
                {
                    resultList.Add(requisition);
                }
            }
            
            foreach(Requisition requisition in resultList){
                dr = dt.NewRow();
                dr["requisitionId"] = requisition.Id;
                dr["requisitionDateTime"] = requisition.ApprovedDate;
                dr["requisitionBy"] = requisition.CreatedBy.Name;
                dr["requisitionStatus"] = requisition.Status;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public Requisition SelectRequisition(String requisitionID)
        {
            Requisition requisition = new Requisition();
            requisition.Id = requisitionID;
            Requisition resultRequisition = requisitionBroker.GetRequisition(requisition);
            return resultRequisition;
        }

        public Constants.ACTION_STATUS SelectSubmit()
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string requisitionID = dt.Rows[i].ItemArray[0].ToString();
                Requisition requisition = new Requisition();
                requisition.Id = requisitionID;
                Requisition resultRequisition = requisitionBroker.GetRequisition(requisition);
                resultRequisition.Status = (int)Constants.REQUISITION_STATUS.SUBMITTED;
                Constants.DB_STATUS dbStatus = requisitionBroker.Update(resultRequisition);
                if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                    status = Constants.ACTION_STATUS.SUCCESS;
                else
                    status = Constants.ACTION_STATUS.FAIL;
            }
            return status;
        }
    }
}
