/***************************************************************************/
/*  File Name       : CollectionMissed.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : CollectionMissed
/*  Details         : Model representation of CollectionMissed table
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
    public class CollectionMissedBroker : StationeryStoreInventorySystemModel.brokerinterface.ICollectionMissedBroker
    {

        InventoryEntities inventory;
        CollectionMissed collectionMissedObj = null;
        List<CollectionMissed> collectionMissedList = null;
        Department departmentObj = null;

        public CollectionMissedBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        /// <summary>
        /// Get CollectionMissed from CollectionMissed Table
        /// </summary>
        /// <param name="collectionMissed"></param>
        /// <returns>
        /// CollectionMissed Object
        /// </returns>
        public CollectionMissed GetCollectionMissed(CollectionMissed collectionMissed)
        {
            //Get the collectionMissed Object by collectionMissed Parameter's Id
            collectionMissedObj = inventory.CollectionMisseds.Where(c => c.Id == collectionMissed.Id).First();
            if (collectionMissedObj != null)
                return collectionMissedObj;
            return null;
        }

        public List<CollectionMissed> GetAllCollectionMissed(Department department)
        {
            collectionMissedList = inventory.CollectionMisseds.Where(c => c.Department.Id == department.Id).ToList();
            if (collectionMissedList != null)
                return collectionMissedList;
            return null;
        }

        public List<CollectionMissed> GetAllCollectionMissed(Department department, Constants.VISIBILITY_STATUS status)
        {
            collectionMissedList = inventory.CollectionMisseds.Where(c => c.Department.Id == department.Id || status.Equals("SHOW")).ToList();
            if (collectionMissedList != null)
                return collectionMissedList;
            return null;
        }

        public Constants.DB_STATUS Insert(CollectionMissed newCollectionMissed)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;


            try
            {
                inventory.AddToCollectionMisseds(newCollectionMissed);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

        public Constants.DB_STATUS Update(CollectionMissed collectionMissed)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;


            try
            {
                collectionMissedObj = inventory.CollectionMisseds.Where(c => c.Id == collectionMissed.Id).First();
                if (collectionMissedObj != null)
                {
                    departmentObj = inventory.Departments.Where(d => d.Id == collectionMissed.Department.Id).First();
                    Employee createdBy=inventory.Employees.Where(e=>e.Id==collectionMissed.CreatedBy.Id).First();
                    collectionMissedObj.Id = collectionMissed.Id;
                    collectionMissedObj.Department = departmentObj;
                    collectionMissedObj.CreatedBy = createdBy;
                    collectionMissedObj.CreatedDate = collectionMissed.CreatedDate;
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

        public Constants.DB_STATUS Delete(CollectionMissed collectionMissed)
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
