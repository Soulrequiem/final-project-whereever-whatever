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
        
        private StockAdjustment stockAdjustment;
        private Discrepancy discrepancy;
        private Employee currentEmployee;

        private List<StockAdjustment> stockAdjustmentList;

        private DataTable dt;
        private DataRow dr;

        private List<string> columnName = new List<string>() { "VoucherNo", "CreatedBy", "CreatedDate", "TotalQty" };

        private DataColumn[] dataColumn;

        public ViewAdjustmentVoucherListControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR);
            
            InventoryEntities inventory = new InventoryEntities();

            discrepancyBroker = new DiscrepancyBroker(inventory);
            
            stockAdjustmentList = discrepancyBroker.GetAllStockAdjustment();

            dataColumn = new DataColumn[] { new DataColumn(columnName[0]),
                                            new DataColumn(columnName[1]),
                                            new DataColumn(columnName[2]),
                                            new DataColumn(columnName[3]) };
        }

        public DataTable StockAdjustmentList
        {
            get 
            {
                dt = new DataTable();

                foreach (StockAdjustment temp in stockAdjustmentList)
                {
                    int totalQty = 0;
                    foreach (DiscrepancyDetail detail in temp.Discrepancy.DiscrepancyDetails)
                    {
                        totalQty += detail.Qty;
                    }

                    dr = dt.NewRow();
                    dr[columnName[0]] = temp.Id;
                    dr[columnName[1]] = temp.CreatedBy.Name;
                    dr[columnName[2]] = temp.CreatedDate;

                    dr[columnName[3]] = totalQty;
                    dt.Rows.Add(dr);
                }

                return dt;
            }
           
        }

        public string VoucherNo
        {
            get { return stockAdjustment.Id; }
        }

        public string DateIssued
        {
            get { return Converter.dateTimeToString(Converter.DATE_CONVERTER.DATE, stockAdjustment.CreatedDate); }
        }

        public string By
        {
            get { return stockAdjustment.Discrepancy.CreatedBy.Name; }
        }

        public string AuthorizedBy
        {
            get { return stockAdjustment.CreatedBy.Name; }
        }

        public string StockAdjustmentDetail
        {
        }

        public Constants.ACTION_STATUS SelectStockAdjustmentVoucher(string stockAdjustmentId)
        {
            Constants.ACTION_STATUS selectStatus = Constants.ACTION_STATUS.UNKNOWN;

            stockAdjustment = stockAdjustmentList.Find(delegate(StockAdjustment sAdjustment) { return sAdjustment.Id.Equals(stockAdjustmentId); });

            if (stockAdjustment != null)
            {
                selectStatus = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                selectStatus = Constants.ACTION_STATUS.FAIL;
            }

            return selectStatus;
        }
        
        //List<Discrepancy> discrepancyList;
     

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
        //public DataTable ListToDataTable(List<StockAdjustment> list)
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr;

        //    foreach(StockAdjustment temp in list)
        //    {
        //        int totalQty = 0;
        //        foreach (DiscrepancyDetail detail in temp.Discrepancy.DiscrepancyDetails.ToList())
        //        {
        //            totalQty += detail.Qty;
        //        }
        //        dr = dt.NewRow();
        //        dr = new DataRow();
        //        dr["voucherNo"] = null;
        //        dr["createdBy"] = temp.CreatedBy.Name;
        //        dr["createdDate"] = temp.CreatedDate;
               
        //        dr["totalQty"] = totalQty;
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}


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
