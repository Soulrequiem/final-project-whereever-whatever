﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemModel.broker
{
    public class RequisitionCollectionItemBroker : IRequisitionCollectionItemBroker
    {
        #region IRequisitionCollectionItemsBroker Members
        private InventoryEntities inventory;
        private RequisitionCollectionItem reqCollectionItem = null;
        private List<RequisitionCollectionItem> reqCollectionList = null;

        public RequisitionCollectionItemBroker(InventoryEntities inventory)
        {
            this.inventory=inventory;
        }

        public int GetRequisitionCollectionItemId()
        {
            return inventory.RequisitionCollectionItems.Count() > 0 ? inventory.RequisitionCollectionItems.Max(xObj => xObj.Id) + 1 : 1;
        }

        public RequisitionCollectionItem GetRequisitionCollectionItem(RequisitionCollectionItem requisitionCollectionItem)
        {

            reqCollectionItem = inventory.RequisitionCollectionItems.Where(r => r.Id == requisitionCollectionItem.Id).First();

            if (!reqCollectionItem.Equals(null))
            {
                Item item = inventory.Items.Where(i => i.Id == reqCollectionItem.Item.Id).First();
                // int i=Convert.ToInt32(inventory.Items.Last().Id) + 1;
                reqCollectionItem.Item = item;
                return reqCollectionItem;
            }
            return null;
        }

        public List<RequisitionCollectionItem> GetAllRequisitionCollectionItem()
        {
            reqCollectionList = inventory.RequisitionCollectionItems.ToList();
            if (reqCollectionList != null)
                return reqCollectionList;
            return null;
        }

        public Constants.DB_STATUS Insert(RequisitionCollectionItem newRequisitionCollectionItem)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {

                inventory.AddToRequisitionCollectionItems(newRequisitionCollectionItem);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

        public Constants.DB_STATUS Update(RequisitionCollectionItem requisitionCollectionItem)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {

                reqCollectionItem = inventory.RequisitionCollectionItems.Where(r => r.Id == requisitionCollectionItem.Id).First();
                reqCollectionItem.RequisitionCollection = requisitionCollectionItem.RequisitionCollection;
                reqCollectionItem.Item = requisitionCollectionItem.Item;
                reqCollectionItem.CreatedDate = requisitionCollectionItem.CreatedDate;
                reqCollectionItem.CreatedBy = requisitionCollectionItem.CreatedBy;
                reqCollectionItem.Qty = requisitionCollectionItem.Qty;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

        public Constants.DB_STATUS Delete(RequisitionCollectionItem requisitionCollectionItem)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {

                reqCollectionItem = inventory.RequisitionCollectionItems.Where(r => r.Id == requisitionCollectionItem.Id).First();
                reqCollectionItem.Status = 2;
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
