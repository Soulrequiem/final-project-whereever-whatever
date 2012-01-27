/***************************************************************************/
/*  File Name       : RetrievalBroker.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : RetrievalBroker
/*  Details         : Model representation of Retrieval table
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
    public class RetrievalBroker : IRetrievalBroker
    {
         private InventoryEntities inventory;
        private Retrieval retrieval = null;
        private RetrievalDetail retrievalDetail = null;
        private List<Retrieval> retrievalList = null;
        private List<RetrievalDetail> retrievalDetailList = null;
        public RetrievalBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        /// <summary>
        /// Get the last RetrievalId from the Retrieval Table
        /// </summary>
        /// <returns></returns>
        public int GetRetrievalId()
        {
            var maxRetrievalId = inventory.Retrievals.Max(xObj => xObj.Id) + 1;
            return maxRetrievalId;

        }

        /// <summary>
        /// Retrieve the Retrieval Detail information  from Retrieval Table according to the Retrieval Parameter
        /// </summary>
        /// <param name="retrieval"></param>
        /// <returns></returns>
        public Retrieval GetRetrieval(Retrieval retrieval)
        {
            retrieval = inventory.Retrievals.Where(robj => robj.Id == retrieval.Id).First();
            if (!retrieval.Equals(null))
            {
                var retrievalDetailResult = from rd in inventory.RetrievalDetails
                                            where rd.Retrieval.Id == retrieval.Id
                                            select rd;
                foreach (RetrievalDetail rd in retrievalDetailResult)
                {
                    retrieval.RetrievalDetails.Add(rd);
               
                 }
                return retrieval;
            }
            return null; 
        }
        /// <summary>
        ///   Retrieve All of the Retrieval information from Retrieval Table
        /// </summary>
        /// <returns></returns>
        public List<Retrieval> GetAllRetrieval()
        {
            retrievalList = inventory.Retrievals.ToList<Retrieval>();
            if (!retrievalList.Equals(null))
                return retrievalList;
            return null;
        }
        /// <summary>
        /// Insert Retrieval data to the Retrieval Table according to the Retrieval Parameter
        ///  Return Constants.DB_STATUS 
        /// </summary>
        /// <param name="newRetrieval"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(Retrieval newRetrieval)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;
            try
            {
                inventory.AddToRetrievals(newRetrieval);
                foreach (RetrievalDetail retrievalDetail in newRetrieval.RetrievalDetails)
                {
                    this.Insert(retrievalDetail);
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
        ///  Update Retrieval data to Retrieval Table according to the Retrieval Parameter
        ///    Return Constants.DB_STATUS 
        /// </summary>
        /// <param name="retrieval"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(Retrieval retrieval)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                retrieval = inventory.Retrievals.Where(rObj => rObj.Id == retrieval.Id).First();

                foreach (RetrievalDetail retrievalDetail in retrieval.RetrievalDetails)
                {
                    this.Update(retrievalDetail);
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
        /// Logically delete the Item table by setting the status to 2 in the Item table
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="retrieval"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(Retrieval retrieval)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                Retrieval retrieve = inventory.Retrievals.Where(rObj => rObj.Id == retrieval.Id).First();
                retrieve.Status = 2;
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
        /// Retrieve the RetrievalDetail information  from RetrievalDetail Table according to the RetrievalDetail Parameter
        /// </summary>
        /// <param name="retrievalDetail"></param>
        /// <returns></returns>
        public RetrievalDetail GetRetrievalDetail(RetrievalDetail retrievalDetail)
        {
            retrievalDetail = inventory.RetrievalDetails.Where(rObj => rObj.Id == retrievalDetail.Id).First();
            if (!retrievalDetail.Equals(null))
                return retrievalDetail;
            return null;
        }
        /// <summary>
        /// Retrieve All of the RetrievalDetail information from RetrievalDetail Table
        /// </summary>
        /// <returns></returns>
       public List<RetrievalDetail> GetAllRetrievalDetail()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
       ///  Insert RetrievalDetail data to the RetrievalDetail Table according to the RetrievalDetail Parameter
       ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="newRetrievalDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(RetrievalDetail newRetrievalDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToRetrievalDetails(newRetrievalDetail);
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
        /// Update RetrievalDetail data to RetrievalDetail Table according to the RetrievalDetail Parameter
        /// Return Constants.DB_STATUS
        /// </summary>
        /// <param name="retrievalDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(RetrievalDetail retrievalDetail)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;
            try
            {
                RetrievalDetail rDetail = inventory.RetrievalDetails.Where(rObj => rObj.Id == retrievalDetail.Id).First();
                rDetail.NeededQty = retrievalDetail.NeededQty;
                rDetail.ActualQty = retrievalDetail.ActualQty;
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
        /// There is no status in RetrievalTable.
        /// </summary>
        /// <param name="retrievalDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(RetrievalDetail retrievalDetail)
        {
            throw new NotImplementedException();
        }
        
        
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/