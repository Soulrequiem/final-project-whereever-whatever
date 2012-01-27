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
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    class ApproveRejectRequisitionControl
    {
        commonController.RequisitionDetailsControl requisitionDetailsControl;
        RequisitionBroker requisitionBroker = new RequisitionBroker();
        DataTable dt;
        DataRow dr;


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
             requisitionDetailsControl = new commonController.RequisitionDetailsControl();
                     
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

        public DataTable GetRequisition()
        {
            dt = new DataTable();
            dr = null;

            List<Requisition> requisitionList = requisitionBroker.GetAllRequisition();

            int qty;
            foreach (Requisition r in requisitionList)
            {
                qty=0;
                dt.NewRow();
                dr = new DataRow();
                dr["requisitionId"] = r.Id;
                dr["requisitionDate/Time"] = Convert.ToDateTime(r.CreatedDate);
                dr["requisitionBy"] = r.Employee.Name;

                
            //List<RequisitionDetail> requisitionDetailList=requisitionBroker.GetRequisitionDetail(r.RequisitionDetails);
            foreach(RequisitionDetail reqDetail in r.RequisitionDetails.ToList())
            {
               qty += reqDetail.Qty;
            }
                dr["requiredQty"] = qty;
                dr["remarks"] = r.Remarks;

                dt.Rows.Add(dr);

            }

            return dt;
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
        public void SelectRequisitionID(string requisitionID)
        {
            Requisition requisition=new Requisition();
            requisition.Id = requisitionID;
            requisitionDetailsControl=new commonController.RequisitionDetailsControl();
            requisitionDetailsControl.SelectRequisitionID(requisition);
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