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
        IRequisitionBroker requisitionBroker = new RequisitionBroker();
        public SubmitRequestToStoreControl()
        {
        }

        public DataTable GetApprovedRequisition()
        {
            DataTable dt = new DataTable();
            DataRow dr;
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
                dt.NewRow();
                dr = new DataRow();
                dr["requisitionId"] = requisition.Id;
                dr["requisitionDateTime"] = requisition.ApprovedDate;
                dr["requisitionBy"] = requisition.Employee.Name;
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

        public Constants.ACTION_STATUS SelectSubmit(String requisitionID)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            Requisition requisition = new Requisition();
            requisition.Id = requisitionID;
            Requisition resultRequisition = requisitionBroker.GetRequisition(requisition);
            resultRequisition.Status = (int) Constants.REQUISITION_STATUS.SUBMITTED;
            Constants.DB_STATUS dbStatus = requisitionBroker.Update(resultRequisition);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }
    }
}
