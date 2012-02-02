/***************************************************************************/
/*  File Name       : RequisitionCollectionBroker.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : RequisitionCollection and RequistionCollectionDetail
/*  Details         : Model Requisition of RequisitionCollection and RequisitionCollectionDetail table
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
    public class RequisitionCollectionBroker: IRequisitionCollectionBroker
    {
        #region IRequisitionCollectionBroker Members
        private InventoryEntities inventory;
        private RequisitionCollection requisitionCollectionObj = null;
        private RequisitionCollectionDetail requisitionCollectionDetailObj = null;
        private List<RequisitionCollection> requisitionCollectionList = null;
        private List<RequisitionCollectionDetail> requisitionCollectionDetailList = null;

        public RequisitionCollectionBroker(InventoryEntities inventory)
        { 
            this.inventory=inventory;
        }
        /// <summary>
        /// Get the last RequisitionCollectionId from the RequisitionCollection Table
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetRequisitionCollectionId()
        {
            int maxRequistionCollectionId = -1;
            try
            {
                maxRequistionCollectionId = inventory.RequisitionCollections.Max(xObj => xObj.Id) + 1;
            }
            catch (Exception e)
            {
                maxRequistionCollectionId = 1;
            }
            return maxRequistionCollectionId;
        }
        /// <summary>
        /// Get RequisitionCollection Object according to the RequisitionCollection parameter
        /// </summary>
        /// <param name="requisitionCollection"></param>
        /// <returns>
        /// Return RequisitionCollection Object
        /// </returns>
        public RequisitionCollection GetRequisitionCollection(RequisitionCollection requisitionCollection)
        {
            try
            {
                requisitionCollectionObj = inventory.RequisitionCollections.Where(reqObj => reqObj.Id == requisitionCollection.Id).First();
            }
            catch (Exception e)
            {
                requisitionCollectionObj = null;
            }
            return requisitionCollectionObj;
        }
        /// <summary>
        /// Get the list of RequistionCollection Data
        /// </summary>
        /// <returns>
        /// Return RequisitionCollection List
        /// </returns>
        public List<RequisitionCollection> GetAllRequisitionCollection()
        {
            try
            {
                requisitionCollectionList = inventory.RequisitionCollections.ToList();
            }
            catch (Exception e)
            {
                requisitionCollectionList = null;
            }
          
                return requisitionCollectionList;
               
        }
        /// <summary>
        /// Insert the RequistionCollection data to the Requistion Table
        /// </summary>
        /// <param name="newRequisitionCollection"></param>
        /// <returns>
        /// Returns DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Insert(RequisitionCollection newRequisitionCollection)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {

                foreach (RequisitionCollectionDetail rd in newRequisitionCollection.RequisitionCollectionDetails)
                {
                    this.Insert(rd);
                }
                inventory.AddToRequisitionCollections(newRequisitionCollection);
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
        /// Update the Requisition Collection data to the Requisition Collection table
        /// </summary>
        /// <param name="requisitionCollection"></param>
        /// <returns>
        /// Return DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Update(RequisitionCollection requisitionCollection)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                requisitionCollectionObj = inventory.RequisitionCollections.Where(reqObj => reqObj.Id == requisitionCollection.Id).First();
                Department department = inventory.Departments.Where(d => d.Id == requisitionCollection.Department.Id).First();
                CollectionPoint collectionPoint = inventory.CollectionPoints.Where(c => c.Id == requisitionCollection.CollectionPoint.Id).First();
                Employee createdBy = inventory.Employees.Where(e => e.Id == requisitionCollection.CreatedBy.Id).First();
                requisitionCollectionObj.Id = requisitionCollection.Id;
                requisitionCollectionObj.Department = department;
                requisitionCollectionObj.CollectionPoint = collectionPoint;
                requisitionCollectionObj.CreatedDate = requisitionCollection.CreatedDate;
                requisitionCollectionObj.CreatedBy = createdBy;
                foreach (RequisitionCollectionDetail rd in requisitionCollectionObj.RequisitionCollectionDetails)
                {
                    this.Update(rd);
                }
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
        /// Logically Delete teh Requisition Collection Table
        /// </summary>
        /// <param name="requisitionCollection"></param>
        /// <returns>
        /// Return DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Delete(RequisitionCollection requisitionCollection)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                requisitionCollectionObj = inventory.RequisitionCollections.Where(reqObj => reqObj.Id == requisitionCollection.Id).First();
                requisitionCollectionObj.Status = 2;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }

        public int GetRequisitionCollectionDetailId()
        {
            int lastId = -1;
            try
            {
                lastId = inventory.RequisitionCollectionDetails.Max(xObj => xObj.Id) + 1;
            }
            catch (Exception e)
            {
                lastId = 1;
            }
            return lastId;
        }

        /// <summary>
        /// Get the RequisitionCollectionDetail of the RequisitionCollection Table
        /// </summary>
        /// <param name="requisitionCollectionDetail"></param>
        /// <returns>
        /// Return the RequisitionCollectionDetail object
        /// </returns>
        public RequisitionCollectionDetail GetRequisitionCollectionDetail(RequisitionCollectionDetail requisitionCollectionDetail)
        {
            try
            {
                requisitionCollectionDetailObj = inventory.RequisitionCollectionDetails.Where(reqObj => reqObj.Id == requisitionCollectionDetail.Id).First();

            }
            catch (Exception e)
            {
                requisitionCollectionDetailObj = null;
            }
                return requisitionCollectionDetailObj;
       }
        /// <summary>
        /// Get the RequisitionCollectionDetail list from the RequistionCollectionDetail Table
        /// </summary>
        /// <returns>
        /// Return RequisitionCollectionDetail list
        /// </returns>
        public List<RequisitionCollectionDetail> GetAllRequisitionCollectionDetail()
        {
            try
            {
                requisitionCollectionDetailList = inventory.RequisitionCollectionDetails.ToList<RequisitionCollectionDetail>();

            }
            catch (Exception e)
            {
                requisitionCollectionDetailList = null;
            } 
                return requisitionCollectionDetailList;
        }
        /// <summary>
        /// Insert the RequisitionCollectionDetail data from the parameter
        /// </summary>
        /// <param name="newRequisitionCollectionDetail"></param>
        /// <returns>
        /// Returns DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Insert(RequisitionCollectionDetail newRequisitionCollectionDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {

                inventory.AddToRequisitionCollectionDetails(newRequisitionCollectionDetail);
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
        /// Update the REquisitionCollectionDetail from the parameter
        /// </summary>
        /// <param name="requisitionCollectionDetail"></param>
        /// <returns>
        /// Returns DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Update(RequisitionCollectionDetail requisitionCollectionDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                requisitionCollectionDetailObj = inventory.RequisitionCollectionDetails.Where(reqObj => reqObj.Id == requisitionCollectionDetail.Id).First();
                if(!requisitionCollectionDetailObj.Equals(null))
                {
                    Requisition requistionId=inventory.Requisitions.Where(r=>r.Id==requisitionCollectionDetail.Requisition.Id).First();
                    requisitionCollectionObj = inventory.RequisitionCollections.Where(r => r.Id == requisitionCollectionDetail.RequisitionCollection.Id).First();
                    
                    requisitionCollectionDetailObj.Id = requisitionCollectionDetail.Id;
                    requisitionCollectionDetailObj.Requisition=requistionId;
                    requisitionCollectionDetailObj.RequisitionCollection = requisitionCollectionObj;
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

        public Constants.DB_STATUS Delete(RequisitionCollectionDetail requisitionCollectionDetail)
        {
            throw new NotImplementedException();
        }
        /*
        public RequisitionCollectionItem GetRequisitionCollectionItem(RequisitionCollectionItem requisitionCollectionItem)
        {
            throw new NotImplementedException();
        }

        public List<RequisitionCollectionItem> GetAllRequisitionCollectionItem()
        {
            throw new NotImplementedException();
        }

        public Constants.DB_STATUS Insert(RequisitionCollectionItem newRequisitionCollectionItem)
        {
            throw new NotImplementedException();
        }

        public Constants.DB_STATUS Update(RequisitionCollectionItem requisitionCollectionItem)
        {
            throw new NotImplementedException();
        }

        public Constants.DB_STATUS Delete(RequisitionCollectionItem requisitionCollectionItem)
        {
            throw new NotImplementedException();
        }
        */
        #endregion
    }
}
/****************************************/
/********* End of the Class *************/
/****************************************/