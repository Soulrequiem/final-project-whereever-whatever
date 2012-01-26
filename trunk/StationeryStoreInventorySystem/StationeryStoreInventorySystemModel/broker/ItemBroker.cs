/***************************************************************************/
/*  File Name       : Item.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : ItemBroker
/*  Details         : Model representation of Item tabletable
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemModel.broker
{
    public class ItemBroker: IItemBroker
    {
        #region IItemBroker Members
        private InventoryEntities inventory = new InventoryEntities();
        private Item itemObj = null;
        private List<Item> itemList = null;


        public Item GetItem(Item item)
        {
            itemObj = inventory.Items.Where(iObj => iObj.Description == item.Description || iObj.Id == item.Id).First();
            if (!itemObj.Equals(null))
                return itemObj;
            return null;
        }

        public List<Item> GetAllItem()
        {
            itemList = inventory.Items.ToList<Item>();
            if (!itemList.Equals(null))
                return itemList;
            return null;
        }

        public Constants.DB_STATUS Insert(Item newItem)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToItems(newItem);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

        public Constants.DB_STATUS Update(Item item)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                itemObj = inventory.Items.Where(iObj => iObj.Id == item.Id).First();
                itemObj.Description = item.Description;
                itemObj.ReorderLevel = item.ReorderLevel;
                itemObj.ReorderQty = item.ReorderQty;
                itemObj.Cost = item.Cost;
                itemObj.UnitOfMeasureId = item.UnitOfMeasureId;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

        public Constants.DB_STATUS Delete(Item item)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                itemObj = inventory.Items.Where(iObj => iObj.Id == item.Id).First();
                itemObj.Status = 2;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }

        #endregion
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/