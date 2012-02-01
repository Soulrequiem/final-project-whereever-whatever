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
            try
            {
                //Get the collectionMissed Object by collectionMissed Parameter's Id
                collectionMissedObj = inventory.CollectionMisseds.Where(c => c.Id == collectionMissed.Id).First();
            }
            catch (Exception e)
            {
                collectionMissedObj = null;
            }
            return collectionMissedObj;
        }
        /// <summary>
        /// Get the list of collecionMissed according the Department Id in CollectionMissed table
        /// </summary>
        /// <param name="department"></param>
        /// <returns>
        /// List of collecionMissed
        /// </returns>
        public List<CollectionMissed> GetAllCollectionMissed(Department department)
        {
            try
            {
                //get the list of collectionMissed by checking Department Id
                collectionMissedList = inventory.CollectionMisseds.Where(c => c.Department.Id == department.Id).ToList();
            }
            catch (Exception e)
            {
                collectionMissedList = null;
            }
                return collectionMissedList;
            
        }
        /// <summary>
        /// Get the list of CollectionMissed by department Id and status
        /// </summary>
        /// <param name="department"></param>
        /// <param name="status"></param>
        /// <returns>
        /// List of CollectionMissed
        /// </returns>
        public List<CollectionMissed> GetAllCollectionMissed(Department department, Constants.VISIBILITY_STATUS status)
        {
            try
            {
                //get the collectionMissed List by checking department Id of collecion Missed Table and check the Visibility Status
                collectionMissedList = inventory.CollectionMisseds.Where(c => c.Department.Id == department.Id || status.Equals("SHOW")).ToList();
            }
            catch (Exception e)
            {
                collectionMissedList = null;
            }
                return collectionMissedList;
        }
        /// <summary>
        /// Insert the collectionMissed data to the CollectionMissed Table
        /// </summary>
        /// <param name="newCollectionMissed"></param>
        /// <returns>
        /// Return DB_STATUS
        /// </returns>
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
        /// <summary>
        /// Update the collectionMissed data to the CollectionMissed Table
        /// </summary>
        /// <param name="collectionMissed"></param>
        /// <returns>
        /// Return DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Update(CollectionMissed collectionMissed)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;


            try
            {
                collectionMissedObj = inventory.CollectionMisseds.Where(c => c.Id == collectionMissed.Id).First();
                if (collectionMissedObj != null)
                {
                    //get the department and employee object by checking Id from collectionMissed table
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
        /// <summary>
        /// Logically delete the status of collectionMissed table
        /// </summary>
        /// <param name="collectionMissed"></param>
        /// <returns>
        /// Return the DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Delete(CollectionMissed collectionMissed)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                collectionMissedObj = inventory.CollectionMisseds.Where(c => c.Id == collectionMissed.Id).First();
                collectionMissedObj.Status = 2;
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
