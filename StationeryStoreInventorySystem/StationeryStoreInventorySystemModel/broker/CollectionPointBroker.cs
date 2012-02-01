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
        private InventoryEntities inventory;
        private CollectionPoint collectionPointObj = null;
        private List<CollectionPoint> collectionPointListObj = null;
       
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
            try
            {
                ///Get the collectionPoint data by collectionPoint ID
                collectionPointObj = inventory.CollectionPoints.Where(copObj => copObj.Id == collectionPoint.Id).First();
            }
            catch (Exception e)
            {
                collectionPointObj = null;
            }
            return collectionPointObj;
        }
        /// <summary>
        /// Retrieve All of the collection point information from CollectionPoint Table
        /// </summary>
        /// <returns></returns>
        public List<CollectionPoint> GetAllCollectionPoint()
        {
            try
            {
                collectionPointListObj = inventory.CollectionPoints.ToList<CollectionPoint>();
            }
            catch (Exception e)
            {
                collectionPointListObj = null;
            }

            return collectionPointListObj;
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
                collectionPointObj = inventory.CollectionPoints.Where(iObj => iObj.Id == collectionPoint.Id).First();
                Employee empId = inventory.Employees.Where(e => e.Id == collectionPoint.Clerk.Id).First();
                collectionPointObj.Id = collectionPoint.Id;
                collectionPointObj.Name = collectionPoint.Name;
                collectionPointObj.Time = collectionPoint.Time;
                collectionPointObj.Clerk = empId;
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
              //  cop = inventory.CollectionPoints.Where(c => c.Id == collectionPoint.Id).First();
                
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