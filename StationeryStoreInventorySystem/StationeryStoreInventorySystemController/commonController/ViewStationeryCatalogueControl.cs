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
        Employee employee;
        
        public ViewStationeryCatalogueControl()
        {
            employee = Util.ValidateUser();
            itemBroker = new ItemBroker();
        }

        public DataTable GetAllItem()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            List<Item> itemList = itemBroker.GetAllItem();

            foreach (Item item in itemList)
            {
                // only for employee, need to add the one for clerk
                dt.NewRow();
                dr = new DataRow();
                dr["itemNo"] = item.Id;
                dr["category"] = Converter.GetItemCategoryText(Converter.objToItemCategory(item.ItemCategoryId));
                dr["itemDescription"] = item.Description;
                dr["unitOfMeasure"] = Converter.GetUnitOfMeasureText(Converter.objToUnitOfMeasure(item.UnitOfMeasureId));
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public List<Item> SelectItemDescription(string itemDescription)
        {
            return Util.GetItems(itemDescription);
        }
    }
}
