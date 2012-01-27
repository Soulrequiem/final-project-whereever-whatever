/***************************************************************************/
/*  File Name       : ViewAdjustmentVoucherListControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : ViewAdjustmentVoucherListControl
/*  Details         : Controller representation of ViewAdjustmentVoucherList 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class ViewAdjustmentVoucherListControl
    {
        IDiscrepancyBroker discrepancyBroker;
        List<StockAdjustment> stockAdjustmentList;
        StockAdjustment stockAdjustment;
        Discrepancy discrepancy;
        //List<Discrepancy> discrepancyList;
        //public ViewAdjustmentVoucherListControl()
        //{
        //    discrepancyBroker = new DiscrepancyBroker();
        //    stockAdjustmentList = discrepancyBroker.GetAllStockAdjustment();
        //}

        //public List<StockAdjustment> GetStockAdjustment()
        //{
        //    return stockAdjustmentList;
        //}

        /// <summary>
        ///     The usage of this method
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
        public DataTable GetStockAdjustment()
        {
            DataTable dt = new DataTable();
            DataRow dr = new DataRow();
            stockAdjustmentList = discrepancyBroker.GetAllStockAdjustment();
            foreach(StockAdjustment temp in stockAdjustmentList)
            {
                dt.NewRow();
                dr["voucherNo"] = null;
                dr["createdBy"] = temp.Employee.Name;
                dr["createdDate"] = temp.createddate;
                dr["totalqty"] = temp.Discrepancy.DiscrepancyDetails.Qty;
                dt.Rows.Add(dr);
            }
            return dt;
        }


        //public StockAdjustment SelectAdjustmentVoucherList(String id)
        //{
        //    StockAdjustment stockAdjustment = new StockAdjustment();
        //    stockAdjustment.id = id;
        //    StockAdjustment resultStockAdjustment = discrepancyBroker.GetStockAdjustment(stockAdjustment);
        //    return resultStockAdjustment;

        //}


        /// <summary>
        ///     The usage of this method
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="stockAdjustmentId"></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable SelectAdjustmentVoucherList(string stockAdjustmentId)
        {
            DataTable dt = new DataTable();
            DataRow dr = new DataRow();
            stockAdjustment.id = stockAdjustmentId;
            List<DiscrepancyDetail> discrepancyDetailList;
            //List<DiscrepancyDetail> discrepancyDetailList = (List<DiscrepancyDetail>)discrepancy.DiscrepancyDetails;
            discrepancyDetailList = stockAdjustment.Discrepancy.DiscrepancyDetails.ToList();
            foreach (DiscrepancyDetail temp in discrepancyDetailList)
            {
                dt.NewRow();
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
