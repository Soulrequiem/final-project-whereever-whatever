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
        private RequisitionCollection reqCollection = null;
        private RequisitionCollectionDetail reqCollectionDetail = null;
        private List<RequisitionCollection> reqList = null;
        private List<RequisitionCollectionDetail> reqDetailList = null;

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
            var maxRequistionCollectionId = inventory.RequisitionCollections.Max(xObj => xObj.Id) + 1;
            return maxRequistionCollectionId;

        }

        public RequisitionCollection GetRequisitionCollection(RequisitionCollection requisitionCollection)
        {
          reqCollection = inventory.RequisitionCollections.Where(reqObj => reqObj.Id == requisitionCollection.Id).First();
          if (!reqCollection.Equals(null))
           {
                //var reqCollectionDetailsResult = from rd in inventory.RequisitionCollectionDetails
                //                                 where rd.RequisitionCollection.Id==reqCollection.Id
                //                                 select rd;
                //foreach (RequisitionCollectionDetail rd in reqCollectionDetailsResult)
                //{
                //    reqCollection.RequisitionCollectionDetails.Add(rd);
                //}
                return reqCollection;
            }


          return null;
        }

        public List<RequisitionCollection> GetAllRequisitionCollection()
        {
            reqList = inventory.RequisitionCollections.ToList();
            if (reqList != null)
                return reqList;
            return null;
               
        }

        public Constants.DB_STATUS Insert(RequisitionCollection newRequisitionCollection)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            //  try
            // {

            foreach (RequisitionCollectionDetail rd in newRequisitionCollection.RequisitionCollectionDetails)
            {
                this.Insert(rd);
            }
            inventory.AddToRequisitionCollections(newRequisitionCollection);
            inventory.SaveChanges();
            status = Constants.DB_STATUS.SUCCESSFULL;
            //}
            //catch (Exception e)
            //{
            //  status = Constants.DB_STATUS.FAILED;
            //}

            return status;
        }

        public Constants.DB_STATUS Update(RequisitionCollection requisitionCollection)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                reqCollection = inventory.RequisitionCollections.Where(reqObj => reqObj.Id == requisitionCollection.Id).First();
                Department dept = inventory.Departments.Where(d => d.Id == requisitionCollection.Department.Id).First();
                CollectionPoint collectionPoint = inventory.CollectionPoints.Where(c => c.Id == requisitionCollection.CollectionPoint.Id).First();
                Employee createdBy = inventory.Employees.Where(e => e.Id == requisitionCollection.CreatedBy.Id).First();
                reqCollection.Id = requisitionCollection.Id;
                reqCollection.Department = dept;
                reqCollection.CollectionPoint = collectionPoint;
                reqCollection.CreatedDate = requisitionCollection.CreatedDate;
                reqCollection.CreatedBy = createdBy;
                foreach (RequisitionCollectionDetail rd in reqCollection.RequisitionCollectionDetails)
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

        public Constants.DB_STATUS Delete(RequisitionCollection requisitionCollection)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                reqCollection = inventory.RequisitionCollections.Where(reqObj => reqObj.Id == requisitionCollection.Id).First();
                reqCollection.Status = 2;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }
        public RequisitionCollectionDetail GetRequisitionCollectionDetail(RequisitionCollectionDetail requisitionCollectionDetail)
        {

            reqCollectionDetail = inventory.RequisitionCollectionDetails.Where(reqObj => reqObj.Id == requisitionCollectionDetail.Id).First();
            if (!reqCollectionDetail.Equals(null))
            {
                return reqCollectionDetail;
            }
            return null;
        }

        public List<RequisitionCollectionDetail> GetAllRequisitionCollectionDetail()
        {
            reqDetailList = inventory.RequisitionCollectionDetails.ToList<RequisitionCollectionDetail>();
            if (!reqDetailList.Equals(null))
                return reqDetailList;
            return null;
        }

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

        public Constants.DB_STATUS Update(RequisitionCollectionDetail requisitionCollectionDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                reqCollectionDetail = inventory.RequisitionCollectionDetails.Where(reqObj => reqObj.Id == requisitionCollectionDetail.Id).First();
                if(!reqCollectionDetail.Equals(null))
                {
                    Requisition requistionId=inventory.Requisitions.Where(r=>r.Id==requisitionCollectionDetail.Requisition.Id).First();
                    reqCollection = inventory.RequisitionCollections.Where(r => r.Id == requisitionCollectionDetail.RequisitionCollection.Id).First();
                    
                    reqCollectionDetail.Id = requisitionCollectionDetail.Id;
                    reqCollectionDetail.Requisition=requistionId;
                    reqCollectionDetail.RequisitionCollection = reqCollection;
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
