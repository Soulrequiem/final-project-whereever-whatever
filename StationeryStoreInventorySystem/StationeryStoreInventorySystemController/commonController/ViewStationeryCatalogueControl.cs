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

        IItemBroker itemBroker;
        Employee currentEmployee;

        public ViewStationeryCatalogueControl()
        {
            currentEmployee = Util.ValidateUser();
            itemBroker = new ItemBroker();
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
        public DataTable GetAllItem()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            List<Item> itemList = itemBroker.GetAllItem();

            // for store
            if (Util.CheckPermission(Converter.objToEmployeeRole(employee.Role.Id), Util.GetRolePermission(Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD)))
            {
                foreach (Item item in itemList)
                {
                    dt.NewRow();
                    dr = new DataRow();
                    dr["itemNo"] = item.Id;
                    dr["category"] = Converter.GetItemCategoryText(Converter.objToItemCategory(item.ItemCategoryId));
                    dr["itemDescription"] = item.Description;
                    dr["reorderLevel"] = item.ReorderLevel;
                    dr["reorderQty"] = item.ReorderQty;
                    dr["unitOfMeasure"] = Converter.GetUnitOfMeasureText(Converter.objToUnitOfMeasure(item.UnitOfMeasureId));
                    dt.Rows.Add(dr);
                }
            }
            // for department
            else
            {
                foreach (Item item in itemList)
                {
                    dt.NewRow();
                    dr = new DataRow();
                    dr["itemNo"] = item.Id;
                    dr["category"] = Converter.GetItemCategoryText(Converter.objToItemCategory(item.ItemCategoryId));
                    dr["itemDescription"] = item.Description;
                    dr["unitOfMeasure"] = Converter.GetUnitOfMeasureText(Converter.objToUnitOfMeasure(item.UnitOfMeasureId));
                    dt.Rows.Add(dr);
                }
            }

            return dt;
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
            return Util.GetItem(itemDescription);
        }

        //public Item GetItem(Item item)
        //{
        //    ItemBroker itembroker = new ItemBroker();
        //    return itembroker.GetItem(item);
        //}


    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/