using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class ApproveRejectRequisitionControl
    {
        IRequisitionBroker requisitionBroker = new RequisitionBroker();
        public ApproveRejectRequisitionControl()
        {
        }

        public List<Requisition> GetAllRequisitions(){
            
            List<Requisition> requisitionList = requisitionBroker.GetAllRequisition();

            return requisitionList;
        }

        public void SelectRequisitionID(String requisitionID)
        {
            Requisition requisition = new Requisition();
            requisition.Id = requisitionID;
            RequisitionDetailsControl requisitionDetailsControl = new RequisitionDetailsControl();
            requisitionDetailsControl.SelectRequisitionID(requisition);
        }

        public Constants.ACTION_STATUS SelectApproveRequisition(Requisition requisition)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            requisition.Status = (int) Constants.REQUISITION_STATUS.APPROVED;
            requisitionBroker.Update(requisition);
            status = Constants.ACTION_STATUS.SUCCESS;
            return status;
        }

        public Constants.ACTION_STATUS SelectRejectRequisition(Requisition requisition)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            requisition.Status = (int)Constants.REQUISITION_STATUS.REJECTED;
            Constants.DB_STATUS dbStatus = requisitionBroker.Update(requisition);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;

        }

    }
}
