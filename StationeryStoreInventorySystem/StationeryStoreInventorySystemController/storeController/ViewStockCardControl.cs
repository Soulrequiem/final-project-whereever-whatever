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
        IItemBroker itemBroker;
        Employee currentEmployee;
        List<Item> itemList;
       

        public ViewStockCardControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);
            InventoryEntities inventory = new InventoryEntities();
            
            itemBroker = new ItemBroker(inventory);
        }
        public DataTable GetStockCard(string itemDescription)
        {
            Item item = new Item();
            item.Description = itemDescription;
            
            item = itemBroker.GetItem(item);
            
            List<StockCardDetail> list = item.StockCardDetails.ToList();
            DataTable dt = new DataTable();
            DataRow dr;
            foreach(StockCardDetail temp in list){
                dt.NewRow();
                dr = new DataRow();
                 dr["date"] = temp.CreatedDate;
                dr["dept/supplier"] = temp.Description;
                dr["qty"] = temp.Qty;
                dr["balance"] = temp.Balance;
                dt.Rows.Add(dr);
            }

            return dt;
        }


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
            DataTable dt = new DataTable();
            DataRow dr = null;
            //StockCard stockCard;
            //stockCard.Item.Description = itemDescription;
            //stockCard=stockCardBroker.GetStockCard(stockCard);
            //List<StockCardDetail> stockCardDetailList = (List<StockCardDetail>)stockCard.StockCardDetails;
            //string name = null;
            //foreach(StockCardDetail temp in stockCardDetailList){
            //    int type = temp.InputFrom;
            //    string id = temp.InputFromId;
            //    if(type == (int) Constants.INPUT_FROM_TYPE.SUPPLIER){
            //        ISupplierBroker supplierBroker = new SupplierBroker();
            //        Supplier supplier = new Supplier();
            //        supplier.Id = id;
            //        supplier = supplierBroker.GetSupplier(supplier);
            //        name = "Supplier- "+supplier.Name;
            //    }
            //    else if(type == (int) Constants.INPUT_FROM_TYPE.DEPT)
            //    {
            //        IDepartmentBroker departmentBroker = new DepartmentBroker();
            //        Department department = new Department();
            //        department.Id = id;
            //        department = departmentBroker.GetDepartment(department);
            //        name = department.Name;
            //    }
            //    else{
            //        IDiscrepancyBroker discrepancyBroker = new DiscrepancyBroker();
            //        StockAdjustment stockAdjustment = new StockAdjustment();
            //        stockAdjustment.id = id;
            //        stockAdjustment = discrepancyBroker.GetStockAdjustment(stockAdjustment);
            //        name = "Stock Adjustment "+ stockAdjustment.createddate;
            //    }

            //    dt.NewRow();
            //    dr = new DataRow();
            //    dr["date"] = temp.CreatedDate;
            //    dr["dept/supplier"] = name;
            //    dr["qty"] = temp.Qty;
            //    dr["balance"] = temp.Balance;
            //    dt.Rows.Add(dr);
            //}
            return dt;
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
