/***************************************************************************/
/*  File Name       : RequisitionCollectionItemBroker.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : RequisitionCollectionItem
/*  Details         : Model RequisitionCollectionItem of RequisitionCollectionItem table
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
    class RequisitionCollectionItemsBroker:IRequisitionCollectionItemsBroker
    {

        private InventoryEntities inventory;
        private RequisitionCollectionItem requisitionCollectionItemObj = null;
        private List<RequisitionCollectionItem> requisitionCollectionItemList = null;

        public RequisitionCollectionItemsBroker(InventoryEntities inventory)
        {
            this.inventory=inventory;
        }
        /// <summary>
        /// Get the RequisitionCollectionItem from the RequisitionCollectionItem table
        /// </summary>
        /// <param name="requisitionCollectionItem"></param>
        /// <returns>
        /// Returns RequisitionCollectionItem
        /// </returns>
        public RequisitionCollectionItem GetRequisitionCollectionItem(RequisitionCollectionItem requisitionCollectionItem)
        {
            try
            {
                requisitionCollectionItemObj = inventory.RequisitionCollectionItems.Where(r => r.Id == requisitionCollectionItem.Id).First();

                if (!requisitionCollectionItemObj.Equals(null))
                {
                    Item item = inventory.Items.Where(i => i.Id == requisitionCollectionItemObj.Item.Id).First();
                    // int i=Convert.ToInt32(inventory.Items.Last().Id) + 1;
                    requisitionCollectionItemObj.Item = item;
                   
                }
            }
            catch (Exception e)
            {
                requisitionCollectionItemObj = null;
            }
            return requisitionCollectionItemObj;
        }
        /// <summary>
        /// Get the lists of RequisitionCollectionItem data
        /// </summary>
        /// <returns>
        /// Return RequisitionCollectionItem list
        /// </returns>
        public List<RequisitionCollectionItem> GetAllRequisitionCollectionItem()
        {
            try
            {
                requisitionCollectionItemList = inventory.RequisitionCollectionItems.ToList();
            }
            catch (Exception e)
            {
                requisitionCollectionItemList=null;
            }
                return requisitionCollectionItemList;
        }
        /// <summary>
        /// Insert RequisitionCollectionItem data from the parameter
        /// </summary>
        /// <param name="newRequisitionCollectionItem"></param>
        /// <returns>
        /// DB_STATUS
        /// </returns>
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
        /// <summary>
        /// Update the RequisitionCollectionItem data from the parameter
        /// </summary>
        /// <param name="requisitionCollectionItem"></param>
        /// <returns>
        /// Return DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Update(RequisitionCollectionItem requisitionCollectionItem)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {

                requisitionCollectionItemObj = inventory.RequisitionCollectionItems.Where(r => r.Id == requisitionCollectionItem.Id).First();
                if (!requisitionCollectionItemObj.Equals(null))
                {
                    RequisitionCollection requisitionCollectionId = inventory.RequisitionCollections.Where(r => r.Id == requisitionCollectionItem.RequisitionCollection.Id).First();
                    Item item = inventory.Items.Where(i => i.Id == requisitionCollectionItem.Item.Id).First();
                    Employee createdBy = inventory.Employees.Where(e => e.Id == requisitionCollectionItem.CreatedBy.Id).First();

                    requisitionCollectionItemObj.Id = requisitionCollectionItem.Id;
                    requisitionCollectionItemObj.RequisitionCollection = requisitionCollectionId;
                    requisitionCollectionItemObj.Item = item;
                    requisitionCollectionItemObj.CreatedDate = requisitionCollectionItem.CreatedDate;
                    requisitionCollectionItemObj.CreatedBy = createdBy;
                    requisitionCollectionItemObj.Qty = requisitionCollectionItem.Qty;
                    inventory.SaveChanges();
                    status = Constants.DB_STATUS.SUCCESSFULL;
                }
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        /// <summary>
        /// Logically delete to the status of RequisitionCollectionItem table
        /// </summary>
        /// <param name="requisitionCollectionItem"></param>
        /// Returns the DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Delete(RequisitionCollectionItem requisitionCollectionItem)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {

                requisitionCollectionItemObj = inventory.RequisitionCollectionItems.Where(r => r.Id == requisitionCollectionItem.Id).First();
                requisitionCollectionItemObj.Status = 2;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

       
    }
}
/****************************************/
/********* End of the Class *************/
/****************************************/