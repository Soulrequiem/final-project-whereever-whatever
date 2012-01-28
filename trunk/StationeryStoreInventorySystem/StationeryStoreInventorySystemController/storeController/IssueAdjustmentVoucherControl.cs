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
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class IssueAdjustmentVoucherControl
    {
        IDiscrepancyBroker discrepancyBroker;
        List<Discrepancy> discrepancyList;
        
        public DataTable DiscrepancyList
        {
            get
            {
                DataTable dt = new DataTable();
                DataRow dr = new DataRow();
                foreach (Discrepancy temp in discrepancyList)
                {
                   
                    dt.NewRow();
                    dr = new DataRow();
                    dr["voucherNo"] = null;
                    dr["createdBy"] = temp.CreatedBy.Name;
                    dr["createdDate"] = temp.createddate;
                    int totalQty = 0 ;
                    //List<DiscrepancyDetail> list = (List<DiscrepancyDetail>)temp.DiscrepancyDetails;
                    foreach (DiscrepancyDetail tempDetail in temp.DiscrepancyDetails.ToList())
                    {
                        totalQty += tempDetail.Qty;
                    }
                    dr["totalQty"] = totalQty;
                    dr["status"] = temp.status;
                    dt.Rows.Add(dr);
                }
                return dt; 
            }
           
        }
       
        public IssueAdjustmentVoucherControl()
        {
            InventoryEntities inventoryEntities = new InventoryEntities();
            discrepancyBroker = new DiscrepancyBroker(inventoryEntities);
            discrepancyList = GetDiscrepancyList();
        }

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
        public List<Discrepancy> GetDiscrepancyList()
        {
            List<Discrepancy> list = discrepancyBroker.GetAllDiscrepancy();

            List<Discrepancy> newList = new List<Discrepancy>();
            foreach (Discrepancy discrepancy in list)
            {
                if (discrepancy.status == (int)Constants.VISIBILITY_STATUS.SHOW)
                    newList.Add(discrepancy);
            }
            return newList;
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
            DataTable dt = new DataTable();
            DataRow dr;
            Discrepancy discrepancy = new Discrepancy();
            discrepancy.id = discrepancyId;
            discrepancy = discrepancyBroker.GetDiscrepancy(discrepancy);
            List<DiscrepancyDetail> discrepancyDetailList = (List<DiscrepancyDetail>)discrepancy.DiscrepancyDetails;
          
            foreach (DiscrepancyDetail temp in discrepancyDetailList)
            {
                dt.NewRow();
                dr = new DataRow();
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
            discrepancy.id = discrepancyId;
            discrepancy = discrepancyBroker.GetDiscrepancy(discrepancy);
            DataTable dt = new DataTable();
            DataRow dr ;
            StockAdjustment stockAdjustment = new StockAdjustment();
            stockAdjustment.Discrepancy = discrepancy;
            discrepancyBroker.Insert(stockAdjustment);
          
            List<DiscrepancyDetail> discrepancyDetailList = stockAdjustment.Discrepancy.DiscrepancyDetails.ToList();
            foreach (DiscrepancyDetail temp in discrepancyDetailList)
            {
                dt.NewRow();
                dr = new DataRow();
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
