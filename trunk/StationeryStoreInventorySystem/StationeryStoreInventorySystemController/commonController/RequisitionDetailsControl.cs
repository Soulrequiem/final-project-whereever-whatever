using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;


namespace StationeryStoreInventorySystemController.commonController
{
    public class RequisitionDetailsControl
    {
        private IRequisitionBroker requisitionBroker = new RequisitionBroker();
        public RequisitionDetailsControl()
        {
        }

        public List<RequisitionDetail> GetAllRequisitionDetails()
        {
            
            List<RequisitionDetail> requisitionDetailList = requisitionBroker.GetAllRequisitionDetail();
            return requisitionDetailList;
        }

        public void SelectRequisitionID(Requisition requisition){
        
            
            RequisitionDetail requisitionDetail = new RequisitionDetail();
            requisitionDetail.Requisition = requisition;
            RequisitionDetail resultRequisitionDetail = requisitionBroker.GetRequisitionDetail(requisitionDetail);
            // show on UI
        }

        public Constants.ACTION_STATUS SelectApproveRequisition(Requisition requisition)
        {
            Constants.ACTION_STATUS status= Constants.ACTION_STATUS.UNKNOWN;
            requisition.Status = (int)Constants.REQUISITION_STATUS.APPROVED;
            requisitionBroker.Update(requisition);
            status = Constants.ACTION_STATUS.SUCCESS;
            return status;
        }

        public Constants.ACTION_STATUS SelectRejectRequisition(Requisition requisition)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            requisition.Status = (int)Constants.REQUISITION_STATUS.REJECTED;
            requisitionBroker.Update(requisition);
            status = Constants.ACTION_STATUS.SUCCESS;
            return status;

        }
    }
}
