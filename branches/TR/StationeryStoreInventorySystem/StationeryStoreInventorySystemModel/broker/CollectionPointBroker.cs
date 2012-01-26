/***************************************************************************/
/*  File Name       : CollectionPointBroker.cs
/*  Module Name     : Models
/*  Owner           : Priyanka
/*  class Name      : CollectionPoint
/*  Details         : Model representation of CollectionPoint table
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.broker
{
    public class CollectionPointBroker : ICollectionPointBroker
    {
        //private InventoryEntities inventory = new InventoryEntities();
        private InventoryEntities inventory;
        private CollectionPoint cop = null;
        private List<CollectionPoint> copList = null;

        public CollectionPointBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }

        /// <summary>
        /// Retrieve the collection point information from CollectionPoint Table according to the collectionPoint Parameter
        /// </summary>
        /// <param name="collectionPoint"></param>
        /// <returns></returns>
        public CollectionPoint GetCollectionPoint(CollectionPoint collectionPoint)
        {
            ///Get the collectionPoint data by collectionPoint ID
            cop = inventory.CollectionPoints.Where(copObj => copObj.Id == collectionPoint.Id).First();
            if (!cop.Equals(null))
                return cop;
            return null;
        }
        /// <summary>
        /// Retrieve All of the collection point information from CollectionPoint Table
        /// </summary>
        /// <returns></returns>
        public List<CollectionPoint> GetAllCollectionPoint()
        {
            copList = inventory.CollectionPoints.ToList<CollectionPoint>();
            if (!copList.Equals(null))
                return copList;
            return null;
        }
        /// <summary>
        /// Insert collectionPoint data to the CollectionPoint Table according to the collectionPoint Parameter
        /// Return Constants.DB_STATUS
        /// </summary>
        /// <param name="collectionPoint"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(CollectionPoint collectionPoint)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;


            try
            {
                inventory.AddToCollectionPoints(collectionPoint);
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
        /// Update collectionPoint data to CollectionPoint Table according to the collecionPoint Parameter
        /// Return Constants.DB_STATUS
        /// </summary>
        /// <param name="collectionPoint"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(CollectionPoint collectionPoint)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
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
        /// Logically delete the CollectionPoint table by setting the status to 2 in the CollectionPoint table
        /// Return Constants.DB_STATUS
        /// </summary>
        /// <param name="collectionPoint"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(CollectionPoint collectionPoint)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
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
/********* End of the Class *****************/
/****************************************/