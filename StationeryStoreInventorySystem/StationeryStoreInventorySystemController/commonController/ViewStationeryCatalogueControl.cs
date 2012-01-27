using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.commonController
{
    class ViewStationeryCatalogueControl
    {
        IItemBroker itemBroker;
        Employee currentEmployee;
        
        public ViewStationeryCatalogueControl()
        {
            currentEmployee = Util.ValidateUser();
            itemBroker = new ItemBroker();
        }

        /// <summary>
        ///     Method to return stationery items according to role
        ///     Created By: Taufin Rusli
        ///     Created Date: 2012/01/27
        /// </summary>
        /// <returns>
        ///     Datatable of all the stationery items
        /// </returns>
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

        public Item SelectItemDescription(string itemDescription)
        {
            return Util.GetItem(itemDescription);
        }
    }
}
