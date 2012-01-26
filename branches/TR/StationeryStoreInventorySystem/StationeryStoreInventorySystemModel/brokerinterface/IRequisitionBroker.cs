using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IRequisitionBroker
    {
        Requisition GetRequisition(Requisition requisition);
        List<Requisition> GetAllRequisition();
        Constants.DB_STATUS Insert(Requisition requisition);
        Constants.DB_STATUS Update(Requisition requisition);
        Constants.DB_STATUS Delete(Requisition requisiton);

        RequisitionDetail GetRequisitionDetail(RequisitionDetail requisitionDetail);
        List<RequisitionDetail> GetAllRequisitionDetail();
        Constants.DB_STATUS Insert(RequisitionDetail requisitionDetail);
        Constants.DB_STATUS Update(RequisitionDetail requisitionDetail);
        Constants.DB_STATUS Delete(RequisitionDetail requisitionDetail);
    }
}
