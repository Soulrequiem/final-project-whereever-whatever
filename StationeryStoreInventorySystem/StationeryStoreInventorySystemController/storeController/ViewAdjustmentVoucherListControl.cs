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
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class ViewAdjustmentVoucherListControl
    {
        private IDiscrepancyBroker discrepancyBroker;
        private DataTable stockAdjustmentList;
        private StockAdjustment stockAdjustment;
        private Discrepancy discrepancy;
        private Employee currentEmployee;
      


        public ViewAdjustmentVoucherListControl()
        {
            Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR);
            InventoryEntities inventoryEntities = new InventoryEntities();
            discrepancyBroker = new DiscrepancyBroker(inventoryEntities);
            List<StockAdjustment> list = GetStockAdjustment();
            stockAdjustmentList = ListToDataTable(list);
        }

        public DataTable StockAdjustmentList
        {
            get { return stockAdjustmentList; }
           
        }
        
        //List<Discrepancy> discrepancyList;
     

        public List<StockAdjustment> GetStockAdjustment()
        {
            return discrepancyBroker.GetAllStockAdjustment();
        }

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
        public DataTable ListToDataTable(List<StockAdjustment> list)
        {
            DataTable dt = new DataTable();
            DataRow dr;

            foreach(StockAdjustment temp in list)
            {
                int totalQty = 0;
                foreach (DiscrepancyDetail detail in temp.Discrepancy.DiscrepancyDetails.ToList())
                {
                    totalQty += detail.Qty;
                }
                dr = dt.NewRow();
                dr = new DataRow();
                dr["voucherNo"] = null;
                dr["createdBy"] = temp.CreatedBy.Name;
                dr["createdDate"] = temp.CreatedDate;
               
                dr["totalQty"] = totalQty;
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
        //public DataTable SelectAdjustmentVoucher(string stockAdjustmentId)
        //{
        //    dt = new DataTable();

        //    stockAdjustment.Id = stockAdjustmentId;
        //    List<DiscrepancyDetail> discrepancyDetailList;
        //    List<DiscrepancyDetail> discrepancyDetailList = (List<DiscrepancyDetail>)discrepancy.DiscrepancyDetails;
        //    discrepancyDetailList = stockAdjustment.Discrepancy.DiscrepancyDetails.ToList();
        //    foreach (DiscrepancyDetail temp in discrepancyDetailList)
        //    {
        //        dr = dt.NewRow();
        //        dr["itemNo"] = temp.Item.Id;
        //        dr["quantityAdjusted"] = temp.Qty;
        //        dr["reason"] = temp.Remarks;
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
