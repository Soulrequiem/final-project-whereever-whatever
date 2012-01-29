/***************************************************************************/
/*  File Name       : ApproveRejectRequisitionControl.cs
/*  Module Name     : Controller
/*  Owner           : SanLaPyaye
/*  class Name      : ApproveRejectRequisitionControl
/*  Details         : Controller representation of ApproveRejectRequisitionControl
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemModel.brokerinterface;
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class ApproveRejectRequisitionControl
    {
        private commonController.RequisitionDetailsControl requisitionDetailsControl;
        
        private IRequisitionBroker requisitionBroker;
        
        private Employee currentEmployee;

        private List<Requisition> pendingRequisitionList;
        
        private DataTable dt;
        private DataRow dr;


        /// <summary>
        ///     The usage of this method is to show the Requisitions List.
        ///     Created By: SanLaPyaye
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>

        public ApproveRejectRequisitionControl() 
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD);
            requisitionDetailsControl = new commonController.RequisitionDetailsControl();
            InventoryEntities inventory = new InventoryEntities();

            requisitionBroker = new RequisitionBroker(inventory);

            pendingRequisitionList = requisitionBroker.GetAllRequisition(Constants.REQUISITION_STATUS.PENDING);

                     
        }

        /// <summary>
        ///     The usage of this method is to show the requisitions list  
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <returns>Return the list of requisitions. </returns>

        //***********
        //public List<Requisition> GetRequisition()
        //{            
        //    return requisitionBroker.GetAllRequisition();
        //}
        //***********

        public DataTable PendingRequisitionList
        {
            get
            {
                dt = new DataTable();
                List<Requisition> requisitionList = requisitionBroker.GetAllRequisition();

                int qty;
                foreach (Requisition r in requisitionList)
                {
                    qty = 0;
                    dr = dt.NewRow();
                    dr["requisitionId"] = r.Id;
                    dr["requisitionDate/Time"] = Convert.ToDateTime(r.CreatedDate);
                    dr["requisitionBy"] = r.CreatedBy.Name;


                    //List<RequisitionDetail> requisitionDetailList=requisitionBroker.GetRequisitionDetail(r.RequisitionDetails);
                    foreach (RequisitionDetail reqDetail in r.RequisitionDetails)
                    {
                        qty += reqDetail.Qty;
                    }
                    dr["requiredQty"] = qty;
                    dr["remarks"] = r.Remarks;

                    dt.Rows.Add(dr);

                }

                return dt;
            }
        }

        /// <summary>
        ///     The usage of this method is to show the "Requisition Details"
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="requisitionID">Get the "Requisition ID" when user click "Requisition ID" link. </param>
        public void SelectRequisition(string requisitionId)
        {
            requisitionDetailsControl = new commonController.RequisitionDetailsControl();
            requisitionDetailsControl.SelectRequisition(pendingRequisitionList.Find(delegate(Requisition req) { return requisitionId == req.Id; }));
        }
        
        /// <summary>
        ///     The usage of this method is to approve the selected "Requisition ID" 
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="requisitionID">Get the "Requisition ID" when user click "Requisition ID" link. </param>
        public Constants.DB_STATUS SelectApproveRequisition(string requisitionID)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;
            Requisition requisition = new Requisition();
            requisition.Id = requisitionID;
            requisitionBroker.Update(requisition);
            return status;
            
        }
       
       
      
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/