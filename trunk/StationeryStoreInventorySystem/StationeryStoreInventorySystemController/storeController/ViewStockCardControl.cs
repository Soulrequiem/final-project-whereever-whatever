/***************************************************************************/
/*  File Name       : ViewStockCardControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : ViewStockCardControl
/*  Details         : Controller representation of ViewStockCard 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using System.Data;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemController.storeController
{
    public class ViewStockCardControl
    {
        private IItemBroker itemBroker;
        private IItemPriceBroker itemPriceBroker;

        private Employee currentEmployee;
        private Item item;

        private List<StockCardDetail> stockCardDetailList;
        private List<Supplier> supplierList;

        private DataTable dt;
        private DataRow dr;

        private string[] columnName = { "date", "dept/supplier", "qty", "balance" };

        private DataColumn[] dataColumn;

        public ViewStockCardControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);

            InventoryEntities inventory = new InventoryEntities();

            itemBroker = new ItemBroker(inventory);
            itemPriceBroker = new ItemPriceBroker(inventory);
            dataColumn = new DataColumn[] { new DataColumn(columnName[0]),
                                            new DataColumn(columnName[1]),
                                            new DataColumn(columnName[2]),
                                            new DataColumn(columnName[3])};
        }


        public DataTable getSupplier()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("supplierName");
            if (supplierList != null && supplierList.Count > 0)
            {
                foreach (Supplier s in supplierList)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = s.Name;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }


        //public DataTable GetStockCard(string itemDescription)
        //{
        //    Item item = new Item();
        //    item.Description = itemDescription;

        //    item = itemBroker.GetItem(item);

        //    List<StockCardDetail> list = item.StockCardDetails.ToList();
        //    DataTable dt = new DataTable();
        //    DataRow dr;
        //    foreach(StockCardDetail temp in list){
        //        dr = dt.NewRow();
        //        dr["date"] = temp.CreatedDate;
        //        dr["dept/supplier"] = temp.Description;
        //        dr["qty"] = temp.Qty;
        //        dr["balance"] = temp.Balance;
        //        dt.Rows.Add(dr);
        //    }

        //    return dt;
        //}


        /// <summary>
        ///     Show stockCardDetail according to the entered itemDescription
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="itemDescription"></param>
        /// <returns>The return type of this method is datatable.</returns>
        //public DataTable GetStockCardDetails(string itemDescription)
        //{
        //    dt = new DataTable();

        //    //item = Util.GetItem(itemBroker, itemDescription);
        //    item = new Item();
        //    item.Description = itemDescription;
        //    item = itemBroker.GetItem(item);
        //    supplierList = itemPriceBroker.GetPrioritySupplier(item);
        //    dt.Columns.AddRange(dataColumn);
        //    stockCardDetailList = itemBroker.GetAllStockCardDetail(item);
        //    if (stockCardDetailList != null)
        //    {
        //        foreach (StockCardDetail stockCardDetail in stockCardDetailList)
        //        {
        //            dr = dt.NewRow();
        //            dr[columnName[0]] = SystemStoreInventorySystemUtil.Converter.dateTimeToString(Converter.DATE_CONVERTER.DATE, stockCardDetail.CreatedDate);
        //            dr[columnName[1]] = stockCardDetail.Description;
        //            dr[columnName[2]] = stockCardDetail.Qty;
        //            dr[columnName[3]] = stockCardDetail.Balance;
        //            dt.Rows.Add(dr);
        //        }
                
        //    }

        //    return dt;
        //}

        public DataTable GetStockCardDetails(string itemDescription)
        {
            dt = new DataTable();

            //item = Util.GetItem(itemBroker, itemDescription);
            item = new Item();
            item.Description = itemDescription;
            item = itemBroker.GetItem(item);
            supplierList = itemPriceBroker.GetPrioritySupplier(item);
            dt.Columns.AddRange(dataColumn);
            stockCardDetailList = itemBroker.GetAllStockCardDetail(item);
            if (stockCardDetailList != null)
            {
                foreach (StockCardDetail stockCardDetail in stockCardDetailList)
                {
                    dr = dt.NewRow();
                    dr[columnName[0]] = SystemStoreInventorySystemUtil.Converter.dateTimeToString(Converter.DATE_CONVERTER.DATE, stockCardDetail.CreatedDate);
                    dr[columnName[1]] = stockCardDetail.Description;
                    dr[columnName[2]] = stockCardDetail.Qty;
                    dr[columnName[3]] = stockCardDetail.Balance;
                    dt.Rows.Add(dr);
                }

            }

            return dt;
        }
        public void SelectPrint(string itemId)
        {
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
