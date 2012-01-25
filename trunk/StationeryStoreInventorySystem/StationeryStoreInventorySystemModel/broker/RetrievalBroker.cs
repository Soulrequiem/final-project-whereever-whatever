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
         private InventoryEntities inventory = new InventoryEntities();
        private Retrieval retrieval = null;
        private RetrievalDetail retrievalDetail = null;
        private List<Retrieval> retrievalList = null;
        private List<RetrievalDetail> retrievalDetailList = null;

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

        public List<entity.Retrieval> GetAllRetrieval()
        {
            retrievalList = inventory.Retrievals.ToList<Retrieval>();
            if (!retrievalList.Equals(null))
                return retrievalList;
            return null;
        }

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

        public RetrievalDetail GetRetrievalDetail(RetrievalDetail retrievalDetail)
        {
            retrievalDetail = inventory.RetrievalDetails.Where(rObj => rObj.Id == retrievalDetail.Id).First();
            if (!retrievalDetail.Equals(null))
                return retrievalDetail;
            return null;
        }

       public List<RetrievalDetail> GetAllRetrievalDetail()
        {
            throw new NotImplementedException();
        }
        

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

        
        public Constants.DB_STATUS Delete(RetrievalDetail retrievalDetail)
        {
            throw new NotImplementedException();
        }
        
        
    }
}
