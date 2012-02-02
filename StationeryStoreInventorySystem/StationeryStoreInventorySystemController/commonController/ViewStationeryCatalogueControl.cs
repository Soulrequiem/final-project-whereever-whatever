/***************************************************************************/
/*  File Name       : ViewStationeryCatalogueControl.cs
/*  Module Name     : Controller
/*  Owner           : SanLaPyaye
/*  class Name      : ViewStationeryCatalogueControl
/*  Details         : Controller representation ViewStationeryCatalogueControl 
/***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using System.Data;


namespace StationeryStoreInventorySystemController.commonController
{
    public class ViewStationeryCatalogueControl
    {

        ///     The usage of this method is to call GetAllItems() for show the all stationery catalogue
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>

        private IItemBroker itemBroker;
        private Employee currentEmployee;
		private List<Item> itemList;

        private DataTable dt;
        private DataRow dr;

        private DataColumn[] storeDataColumn;
        private DataColumn[] departmentDataColumn;

        public ViewStationeryCatalogueControl()
        {
            currentEmployee = Util.ValidateUser();
            //InventoryEntities inventory = new InventoryEntities();

            //itemBroker = new ItemBroker(inventory);
            //itemList = itemBroker.GetAllItem();

            //storeDataColumn = new DataColumn[] { new DataColumn("ItemNo"), 
            //                                     new DataColumn("Category"), 
            //                                     new DataColumn("ItemDescription"),
            //                                     new DataColumn("ReorderLevel"),
            //                                     new DataColumn("ReorderQty"),
            //                                     new DataColumn("UnitOfMeasure") };

            //departmentDataColumn = new DataColumn[] { new DataColumn("ItemNo"), 
            //                                          new DataColumn("Category"), 
            //                                          new DataColumn("ItemDescription"), 
            //                                          new DataColumn("UnitOfMeasure") };
        }

        ///     The usage of this method is to show the all stationery catalogue
        ///     Created By: SanLaPyaye
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <returns>Return the list of stationery catalogue. </returns>
        public DataTable AllItemList
        {
            get
            {
                return Util.GetItemTable();
                //dt = new DataTable();

                //// for store
                //if (Util.CheckPermission(Constants.EMPLOYEE_ROLE.STORE_CLERK, Util.GetRolePermission(Converter.objToEmployeeRole(currentEmployee.Role.Id))))
                //{
                //    dt.Columns.AddRange(storeDataColumn);

                //    foreach (Item item in itemList)
                //    {
                //        dr = dt.NewRow();
                //        dr[storeDataColumn[0]] = item.Id;
                //        dr[storeDataColumn[1]] = Converter.GetItemCategoryText(Converter.objToItemCategory(item.ItemCategoryId));
                //        dr[storeDataColumn[2]] = item.Description;
                //        dr[storeDataColumn[3]] = item.ReorderLevel;
                //        dr[storeDataColumn[4]] = item.ReorderQty;
                //        dr[storeDataColumn[5]] = Converter.GetUnitOfMeasureText(Converter.objToUnitOfMeasure(item.UnitOfMeasureId));
                //        dt.Rows.Add(dr);
                //    }
                //}
                //// for department
                //else
                //{
                //    dt.Columns.AddRange(departmentDataColumn);

                //    foreach (Item item in itemList)
                //    {
                //        dr = dt.NewRow();
                //        dr[departmentDataColumn[0]] = item.Id;
                //        dr[departmentDataColumn[1]] = Converter.GetItemCategoryText(Converter.objToItemCategory(item.ItemCategoryId));
                //        dr[departmentDataColumn[2]] = item.Description;
                //        dr[departmentDataColumn[3]] = Converter.GetUnitOfMeasureText(Converter.objToUnitOfMeasure(item.UnitOfMeasureId));
                //        dt.Rows.Add(dr);
                //    }
                //}
                //return dt;
            }
        }
        public DataTable ItemList(string itemDescription)
        {
            return Util.GetItemListTable(itemDescription);
        }

        ///     The usage of this method is to assign the selected Department Head from Search Result
        ///     Created By: SanLaPyaye
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="remarks"> Remark to update the employee.</param>
        /// <returns>Return the status of assign  whether Successful or Fail. </returns>
        //public Item SelectItemDescription(string itemDescription)
        //{            
        //    itembroker = new ItemBroker();          //Boss will do the google search 
        //    Item item= new Item();
        //    item.Description = itemDescription;
        //   Item i= itembroker.GetItem(item);
        //   return i;
        //}
        public Item SelectItemDescription(string itemDescription)
        {
            return Util.GetItem(itemBroker, itemDescription);
        }


        public void SelectPrint()
        {
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/