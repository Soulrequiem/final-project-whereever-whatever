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

        private DataColumn[] dataColumn;

        public ViewStockCardControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);

            InventoryEntities inventory = new InventoryEntities();
            
            itemBroker = new ItemBroker(inventory);
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
        public DataTable GetStockCardDetails(string itemDescription)
        {
            dt = new DataTable();

            item = Util.GetItem(itemBroker, itemDescription);
            supplierList = itemPriceBroker.GetPrioritySupplier(item);

            foreach (StockCardDetail stockCardDetail in item.StockCardDetails)
            {
                dr = dt.NewRow();
                dr["date"] = stockCardDetail.CreatedDate;
                dr["dept/supplier"] = stockCardDetail.Description;
                dr["qty"] = stockCardDetail.Qty;
                dr["balance"] = stockCardDetail.Balance;
                dt.Rows.Add(dr);
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
