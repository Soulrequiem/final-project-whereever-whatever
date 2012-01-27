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
    class ViewStationeryCatalogueControl
    {
        ItemBroker itembroker;
        DataTable dt;
        DataRow dr;

        
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
        public ViewStationeryCatalogueControl() 
        {
            
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
        public DataTable GetAllItems()
        {
            dt = new DataTable();
            dr = null;
                        
            itembroker = new ItemBroker();
            List<Item> itemList= itembroker.GetAllItem();
            foreach (Item i in itemList)
            {
                dt.NewRow();
                dr = new DataRow();

                dr["itemNo"] = i.Id;
                dr["category"] =Converter.GetItemCategoryText(Converter.objToItemCategory(i.ItemCategoryId));
                dr["itemDescription"] = i.Description;
                dr["reorderLevel"] = i.ReorderLevel;
                dr["reorderQty"] = i.ReorderQty;
                dr["unitOfMeasure"] =Converter.GetUnitOfMeasureText(Converter.objToUnitOfMeasure(i.UnitOfMeasureId));
                dt.Rows.Add(dr);
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
        public Item SelectItemDescription(string itemDescription)
        {            
            itembroker = new ItemBroker();          //Boss will do the google search 
            Item item= new Item();
            item.Description = itemDescription;
           Item i= itembroker.GetItem(item);
           return i;
        }
        
        // The method which created by ZMT
        //public List<Item> SelectItemDescription(string itemDescription)
        //{
        //    return Util.GetItems(itemDescription);
        //}

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