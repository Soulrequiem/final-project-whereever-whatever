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
        private IDiscrepancyBroker discrepancyBroker;
        private List<StockAdjustment> stockAdjustmentList;
        private StockAdjustment stockAdjustment;
        private Discrepancy discrepancy;

        private DataTable dt;
        private DataRow dr;

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
        ///     Show adjustment voucher List
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
        public DataTable GetStockAdjustmentList()
        {
            dt = new DataTable();
            stockAdjustmentList = discrepancyBroker.GetAllStockAdjustment();
            foreach(StockAdjustment temp in stockAdjustmentList)
            {
                dr = dt.NewRow();
                dr["voucherNo"] = null;
                dr["createdBy"] = temp.CreatedBy.Name;
                dr["createdDate"] = temp.CreatedDate;
                //dr["totalQty"] = temp.Discrepancy.DiscrepancyDetails;
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
        ///     Show the adjustment voucher detail according to the selected stockAdjustmentId
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
        public DataTable SelectAdjustmentVoucher(string stockAdjustmentId)
        {
            dt = new DataTable();

            stockAdjustment.Id = stockAdjustmentId;
            List<DiscrepancyDetail> discrepancyDetailList;
            //List<DiscrepancyDetail> discrepancyDetailList = (List<DiscrepancyDetail>)discrepancy.DiscrepancyDetails;
            discrepancyDetailList = stockAdjustment.Discrepancy.DiscrepancyDetails.ToList();
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
