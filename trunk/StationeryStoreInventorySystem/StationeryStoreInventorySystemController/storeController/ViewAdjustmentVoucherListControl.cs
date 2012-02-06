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
        private DataTable dtDetail;
        private DataRow dr;

        private string[] columnName = { "VoucherNo", "CreatedBy", "CreatedDate", "TotalQty" };
        private string[] detailColumnName = { "ItemNo", "QuantityAdjusted", "Reason" };

        private DataColumn[] dataColumn;
        private DataColumn[] detailDataColumn;

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

            detailDataColumn = new DataColumn[] { new DataColumn(detailColumnName[0]),
                                            new DataColumn(detailColumnName[1]),
                                            new DataColumn(detailColumnName[2]) };
        }

        public DataTable StockAdjustmentList
        {
            get 
            {
                if (dt == null)
                {
                    dt = new DataTable();

                    dt.Columns.AddRange(dataColumn);
                }
                else
                {
                    dt.Rows.Clear();
                }

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

        public DataTable StockAdjustmentDetail
        {
            get
            {
                if (dtDetail == null)
                {
                    dtDetail = new DataTable();

                    dtDetail.Columns.AddRange(detailDataColumn);
                }
                else
                {
                    dtDetail.Rows.Clear();
                }

                if (stockAdjustment != null)
                {
                    List<DiscrepancyDetail> showList = GetList(stockAdjustment.Discrepancy.DiscrepancyDetails.ToList());
                    foreach (DiscrepancyDetail discrepancyDetail in showList)
                    {
                        dr = dtDetail.NewRow();
                        dr[detailColumnName[0]] = discrepancyDetail.Item.Id;
                        dr[detailColumnName[1]] = discrepancyDetail.Qty;
                        dr[detailColumnName[2]] = discrepancyDetail.Remarks;
                        dtDetail.Rows.Add(dr);
                    }
                }

                return dtDetail;
            }
        }

        private List<DiscrepancyDetail> GetList(List<DiscrepancyDetail> list)
        {
            List<DiscrepancyDetail> supervisorDetails = new List<DiscrepancyDetail>();
            List<DiscrepancyDetail> managerDetails = new List<DiscrepancyDetail>();

            foreach (DiscrepancyDetail dd in list)
            {
                if (dd.DiscrepancyType == Converter.objToInt(Constants.DISCREPANCY_TYPE.SUPERVISOR))
                {
                    supervisorDetails.Add(dd);
                }
                else
                {
                    managerDetails.Add(dd);
                }
            }

            List<DiscrepancyDetail> currentList;
            if (currentEmployee.Role.Id == Converter.objToInt(Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR))
            {
                currentList = supervisorDetails;
            }
            else
            {
                currentList = managerDetails;
            }

            return currentList;
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
