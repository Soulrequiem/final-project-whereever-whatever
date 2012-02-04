/***************************************************************************/
/*  File Name       : IssueAdjustmentVoucherControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : IssueAdjustmentVoucherControl
/*  Details         : Controller representation of IssueAdjustmentVoucher 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class IssueAdjustmentVoucherControl
    {
        private IDiscrepancyBroker discrepancyBroker;

        private System.Data.Objects.DataClasses.EntityCollection<Discrepancy> discrepancyList;

        private DataTable dt;
        private DataRow dr;

        private string[] discrepancyListColumnName = { "Id", "CreatedBy", "CreatedDate", "TotalQty", "Status" };
        private string[] discrepancyItemListColumnName = { "ItemNo", "ItemDescription", "Quantity", "PricePerItem", "Reason" };

        private DataColumn[] discrepancyListColumn;
      //  private DataColumn[] discrepancyItemListColumn;

        public IssueAdjustmentVoucherControl()
        {
            InventoryEntities inventoryEntities = new InventoryEntities();
            discrepancyBroker = new DiscrepancyBroker(inventoryEntities);
            discrepancyList = new System.Data.Objects.DataClasses.EntityCollection<Discrepancy>();
            discrepancyListColumn = new DataColumn[]{new DataColumn(discrepancyListColumnName[0]),new DataColumn(discrepancyListColumnName[1]),new DataColumn(discrepancyListColumnName[2]),new DataColumn(discrepancyListColumnName[3]),new DataColumn(discrepancyListColumnName[4])
            };
        }

        
        //public DataTable DiscrepancyList
        //{
        //    get
        //    {
        //        DataTable dt = new DataTable();
                
        //        if (discrepancyList.Count > 0)
        //        {
        //            DataRow dr;
        //            foreach (Discrepancy temp in discrepancyList)
        //            {
        //                dr = dt.NewRow();
        //                dr["voucherNo"] = null;
        //                dr["createdBy"] = temp.CreatedBy.Name;
        //                dr["createdDate"] = temp.CreatedDate;
        //                int totalQty = 0;
        //                //List<DiscrepancyDetail> list = (List<DiscrepancyDetail>)temp.DiscrepancyDetails;
        //                foreach (DiscrepancyDetail tempDetail in temp.DiscrepancyDetails.ToList())
        //                {
        //                    totalQty += tempDetail.Qty;
        //                }
        //                dr["totalQty"] = totalQty;
        //                dr["status"] = temp.Status;
        //                dt.Rows.Add(dr);
        //            }
        //        }
        //        return dt; 
        //    }
        //}
       
        /// <summary>
        ///     Show all discrepancy list which status is show
        ///     Created By:Zin Mar Thwin
        ///     Created Date:28-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="itemDescription"></param>
        /// <returns>The return value of this method is resultItem.</returns>
        public DataTable GetDiscrepancyList()
        {

            dt = new DataTable();
            dt.Columns.AddRange(discrepancyListColumn);
            List<Discrepancy> list = discrepancyBroker.GetAllDiscrepancy();
            foreach (Discrepancy temp in list)
            {
                DataRow dr;
          //      requisitionDetail = new RequisitionDetail();
                if (temp.Status == Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW))
                {
                    //      RequisitionDetail resultRequisitionDetail = requisitionBroker.GetRequisitionDetail(requisitionDetail);
                  
                    dr = dt.NewRow();
                    dr["id"] = temp.Id;
                    dr["createdBy"] = temp.CreatedBy.Name;
                    dr["createdDate"] = temp.CreatedDate;
                    int totalQty = 0;
                    foreach (DiscrepancyDetail tempDetail in temp.DiscrepancyDetails.ToList())
                    {
                        totalQty += tempDetail.Qty;
                    }
                    dr["totalQty"] = totalQty;
                    dr["status"] = temp.Status;
                    dt.Rows.Add(dr);
                }
            }
       
            

            //List<Discrepancy> newList = new List<Discrepancy>();
            //foreach (Discrepancy discrepancy in list)
            //{
            //    if (discrepancy.Status == Converter.objToInt(Constants.VISIBILITY_STATUS.SHOW))
            //        newList.Add(discrepancy);
            //}
            return dt;
        }

        /// <summary>
        ///     Show all discrepancies
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
        //public DataTable GetDiscrepancyList()
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr = new DataRow();
        //    discrepancyList = new List<Discrepancy>();
        //    List<Discrepancy> newDiscrepancyDetailList = new List<Discrepancy>();
        //    discrepancyList = discrepancyBroker.GetAllDiscrepancy();
        //    foreach (Discrepancy temp in discrepancyList)
        //    {
        //        if (discrepancy.status == (int)Constants.VISIBILITY_STATUS.SHOW)
        //            newDiscrepancyDetailList.Add(discrepancy);
        //        dt.NewRow();
        //        dr["voucherNo"] = null;
        //        dr["createdBy"] = temp.Employee.Name;
        //        dr["createdDate"] = temp.createddate;
        //        int totalQty;
        //       //List<DiscrepancyDetail> list = (List<DiscrepancyDetail>)temp.DiscrepancyDetails;
        //        foreach (DiscrepancyDetail tempDetail in temp.DiscrepancyDetails.list)
        //        {
        //            totalQty+=tempDetail.Qty;
        //        }
        //        dr["totalQty"] = totalQty;
        //        dr["status"] = temp.status;
        //        dt.Rows.Add(dt);
        //    }
        //}

        //public Discrepancy SelectDiscrepancy(int discrepancyId)
        //{
        //    Discrepancy discrepancy = new Discrepancy();
        //    discrepancy.id = discrepancyId;
        //    return discrepancyBroker.GetDiscrepancy(discrepancy);
        //}


        /// <summary>
        ///     Show one discrepancy detail according the discrepancyId selected
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="discrepancyId"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable SelectDiscrepancy(int discrepancyId)
        {
            dt = new DataTable();
            
            Discrepancy discrepancy = new Discrepancy();
            discrepancy.Id = discrepancyId;
            discrepancy = discrepancyBroker.GetDiscrepancy(discrepancy);
            //List<DiscrepancyDetail> discrepancyDetailList = (List<DiscrepancyDetail>)discrepancy.DiscrepancyDetails;
          
            foreach (DiscrepancyDetail temp in discrepancy.DiscrepancyDetails)
            {
                dr = dt.NewRow();
                dr["itemNo"] = temp.Item.Id;
                dr["itemDescription"] = temp.Item.Description;
                dr["quantity"] = temp.Qty;
                dr["pricePerItem"] = temp.Item.Cost;
                dr["reason"] = temp.Remarks;
                dt.Rows.Add(dr);
            }
            return dt;
        }


        //public Constants.ACTION_STATUS SelectDiscrepancyIssue(Discrepancy discrepancy)
        //{
        //    Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
        //    StockAdjustment stockAdjustment = new StockAdjustment();
        //    stockAdjustment.Discrepancy = discrepancy;
        //    Constants.DB_STATUS dbStatus = discrepancyBroker.Insert(stockAdjustment);
        //    if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
        //        status = Constants.ACTION_STATUS.SUCCESS;
        //    else
        //        status = Constants.ACTION_STATUS.FAIL;
        //    return status;
        //}


        /// <summary>
        ///     Show the discrepancy detail after issueing the selected discrepancy
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="discrepancy"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable SelectIssue(int discrepancyId)
        {
            Discrepancy discrepancy = new Discrepancy();
            discrepancy.Id = discrepancyId;
            discrepancy = discrepancyBroker.GetDiscrepancy(discrepancy);
            dt = new DataTable();
            
            StockAdjustment stockAdjustment = new StockAdjustment();
            stockAdjustment.Discrepancy = discrepancy;
            discrepancyBroker.Insert(stockAdjustment);
          
            List<DiscrepancyDetail> discrepancyDetailList = stockAdjustment.Discrepancy.DiscrepancyDetails.ToList();
            foreach (DiscrepancyDetail temp in discrepancyDetailList)
            {
                dr = dt.NewRow();
                dr["itemNo"] = temp.Item.Id;
                dr["quantityAdjusted"] = temp.Qty;
                dr["reason"] = temp.Remarks;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
