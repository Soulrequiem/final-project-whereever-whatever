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
        
        private Employee currentEmployee;
        private Requisition requisition;
        private RequisitionDetail requisitionDetail;
        
        private System.Data.Objects.DataClasses.EntityCollection<Requisition> requisitionList;

        private DataTable dt;
        private DataRow dr;
        
        public CheckRequisitionControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.EMPLOYEE);
            InventoryEntities inventory = new InventoryEntities();

            requisitionBroker = new RequisitionBroker(inventory);
            requisitionList = new System.Data.Objects.DataClasses.EntityCollection<Requisition>();
            //requisitionList = requisitionBroker.GetAllRequisition();
        }

        //public List<Requisition> GetRequisitionList()
        //{
        //    return requisitionList;
        //}

        /// <summary>
        ///     Show all requisition.
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name=""></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable GetRequisitionList()
        {
            dt = new DataTable();
            List<Requisition> requisitionList = requisitionBroker.GetAllRequisition();
            foreach (Requisition temp in requisitionList)
            {
                requisitionDetail = new RequisitionDetail();
                requisitionDetail.Requisition.Id = temp.Id;
                RequisitionDetail resultRequisitionDetail= requisitionBroker.GetRequisitionDetail(requisitionDetail);
                dr = dt.NewRow();
                dr["requsitionId"] = temp.Id;
                dr["requisitionDate"] = temp.CreatedDate;
                dr["status"] = temp.Status; 
                dr["remainingQty"] = resultRequisitionDetail.Qty-requisitionDetail.DeliveredQty;
                dr["remarks"] = temp.Remarks;
                dt.Rows.Add(dr);
            }
            return dt;
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
            requisition=new Requisition();
            requisition.Id=requisitionId;
            requisition=requisitionBroker.GetRequisition(requisition);
            requisitionDetail=new RequisitionDetail();
            requisitionDetail.Requisition.Id=requisitionId;
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
        ///     Show requisition detail according to the selected requisition
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
        public DataTable SelectRequisitionID(string requisitionId)
        {
            dt = new DataTable();
            
            requisition =new Requisition();
            requisition.Id=requisitionId;
            requisition=requisitionBroker.GetRequisition(requisition);
            //List<RequisitionDetail> requisitionDetailList=(List<RequisitionDetail>)requisition.RequisitionDetails;
            foreach(RequisitionDetail temp in requisition.RequisitionDetails)
            {
                dr = dt.NewRow();
                dr["itemNo"] = temp.Item.Id;
                dr["itemDescription"] = temp.Item.Description;
                dr["requiredQty"] = temp.Qty;
                dr["receivedQty"] = temp.DeliveredQty;
                dr["remainingQty"] = temp.Qty - temp.DeliveredQty;
                dt.Rows.Add(dr);
            }
            return dt;
        }

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
        public DataTable SelectWithdraw(string requisitionId)
        {
            //Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            Constants.DB_STATUS dbStatus = requisitionBroker.Delete(requisition);
            dbStatus=Constants.DB_STATUS.SUCCESSFULL;
            if (requisitionList.Count == 1)
                return null;
            else
                return GetRequisitionList();
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
