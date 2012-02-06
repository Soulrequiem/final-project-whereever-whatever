using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.commonController
{
    public class RequisitionDetailsControl
    {
        private IRequisitionBroker requisitionBroker;
        private List<Requisition> RequisitionList;
        private List<Requisition> submittedRequisitionList;
        private Employee currentEmployee;
        private Requisition requisition;
        private RequisitionDetail requisitionDetail;
        private DataTable dt;
        private DataRow dr;
        private string[] columnName = new string[] { "requisitionID", "requisitionDate", "status", "remainingQty", "remarks" };
        public RequisitionDetailsControl()
        {
            currentEmployee = Util.ValidateUser();
            InventoryEntities inventory = new InventoryEntities();
            requisitionBroker = new RequisitionBroker(inventory);
            RequisitionList = requisitionBroker.GetAllRequisition(currentEmployee.Department);
        }

        public List<RequisitionDetail> GetAllRequisitionDetails()
        {

            List<RequisitionDetail> requisitionDetailList = requisitionBroker.GetAllRequisitionDetail();
            return requisitionDetailList;
        }

        public void SelectRequisition(Requisition requisition)
        {


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
        public DataTable getRequisition(string requisitionId)
        {
            //requisition = new Requisition();
            //requisition.Id = requisitionId;
            //requisition = RequisitionList.Find(delegate(Requisition req) { return requisitionId == req.Id; });
            requisitionDetail = new RequisitionDetail(0, new Requisition(), new Item(), 0, 0);
            requisitionDetail.Requisition.Id = requisitionId;
            requisitionDetail = requisitionBroker.GetRequisitionDetail(requisitionDetail);
            dt = new DataTable();
            dt.Columns.Add("requisitionId");
            dt.Columns.Add("requisitionDate/Time");
            dt.Columns.Add("status");
            dt.Columns.Add("remainingQty");
            dt.Columns.Add("remarks");
            dt.Columns.Add("deptCode");
            dt.Columns.Add("deptName");
            dt.Columns.Add("empName");
            dt.Columns.Add("empNumber");
            dt.Columns.Add("empEmail");
            dr = dt.NewRow();
            dr["requisitionId"] = requisition.Id;
            dr["requisitionDate/Time"] = requisition.CreatedDate;
            dr["status"] = requisition.Status;
            dr["remainingQty"] = requisitionDetail.Qty - requisitionDetail.DeliveredQty;
            dr["remarks"] = requisition.Remarks;
            dr["deptCode"] = requisition.Department.Id;
            dr["deptName"] = requisition.Department.Name;
            dr["empName"] = requisition.CreatedBy.Name;
            dr["empNumber"] = requisition.CreatedBy.Id;
            dr["empEmail"] = requisition.CreatedBy.Email;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        ///     Show requisition detail according to the selected requisition
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:Thazin Win
        ///     Modified Date:02-02-2012
        ///     Modification Reason:To retrieve detail data
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="requisitionId"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public Constants.ACTION_STATUS SelectRequisitionID(string requisitionId)
        {
            Constants.ACTION_STATUS selectStatus = Constants.ACTION_STATUS.UNKNOWN;
            requisition = RequisitionList.Find(delegate(Requisition req) { return req.Id.Contains(requisitionId); });
            if (requisition != null)
            {
                selectStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                selectStatus = Constants.ACTION_STATUS.FAIL;
            }
            return selectStatus;
        }

        public string RequisitionId { get { return requisition != null ? requisition.Id : ""; } }

        public DataTable RequisitionDetail
        {
            get
            {
                dt = new DataTable();
                dt.Columns.Add("itemNo");
                dt.Columns.Add("itemDescription");
                dt.Columns.Add("requiredQty");
                dt.Columns.Add("receivedQty");
                dt.Columns.Add("remainingQty");

                foreach (RequisitionDetail temp in requisition.RequisitionDetails)
                {
                    dr = dt.NewRow();
                    dr["itemNo"] = temp.Item.Id;
                    dr["itemDescription"] = temp.Item.Description;
                    dr["requiredQty"] = temp.Qty;
                    dr["receivedQty"] = temp.DeliveredQty.HasValue ? temp.DeliveredQty.Value : 0;
                    if (temp.DeliveredQty.Equals(null))
                        dr["remainingQty"] = 0;
                    else
                        dr["remainingQty"] = temp.Qty - temp.DeliveredQty;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
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
        public Constants.ACTION_STATUS Setstatus(string requisitionId, Constants.REQUISITION_STATUS Reqstatus, string remarks, DataTable dt)
        {
            Constants.REQUISITION_STATUS requisitionStatus = Reqstatus;
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            requisition = RequisitionList.Find(delegate(Requisition req) { return req.Id.Contains(requisitionId); });

            foreach (RequisitionDetail temp in requisition.RequisitionDetails)
            {
                DataRow[] dr = dt.Select(" ItemCode = '" + temp.Item.Id + "'");
                if(dr != null && dr.Length > 0)
                {
                    temp.Qty = Convert.ToInt16(dr[1]);
                    temp.DeliveredQty = Convert.ToInt16(dr[2]);
                }
            }
            requisitionBroker.Update(requisition);
            return status;
        }
    }
}
