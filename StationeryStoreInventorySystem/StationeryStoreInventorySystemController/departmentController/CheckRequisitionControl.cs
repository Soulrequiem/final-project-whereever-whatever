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
    public class CheckRequisitionControl
    {
        IRequisitionBroker requisitionBroker = new RequisitionBroker();
        public CheckRequisitionControl()
        {
        }

        public List<Requisition> GetAllRequisitions()
        {
            return requisitionBroker.GetAllRequisition();
        }

        public Requisition EnterRequisitionID(String requisitionID)
        {
            Requisition requisition = new Requisition();
            requisition.Id = requisitionID;
            Requisition resultRequisition = requisitionBroker.GetRequisition(requisition);
            return resultRequisition;
        }

        public Constants.ACTION_STATUS SelectWithdraw(Requisition requisition){
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            Constants.DB_STATUS dbStatus = requisitionBroker.Delete(requisition);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }

    }
}
