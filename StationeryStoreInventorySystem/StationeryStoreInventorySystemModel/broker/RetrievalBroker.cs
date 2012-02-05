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

        public enum QTY_TYPE
        {
            NEEDED_QTY,
            ACTUAL_QTY
        }

        public RetrievalBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
       
        //public int GetRetrievalId()
        //{
        //    var maxRetrievalId = inventory.Retrievals.Max(xObj => xObj.Id) + 1;
        //    return maxRetrievalId;

        //}

        /// <summary>
        /// Retrieve the Retrieval Detail information  from Retrieval Table according to the Retrieval Parameter
        /// </summary>
        /// <param name="retrieval"></param>
        /// <returns></returns>
        public Retrieval GetRetrieval(Retrieval retrieval)
        {
            try
            {
                retrieval = inventory.Retrievals.Where(robj => robj.Id == retrieval.Id).First();
                //if (!retrieval.Equals(null))
                //{
                //    //var retrievalDetailResult = from rd in inventory.RetrievalDetails
                //    //                            where rd.Retrieval.Id == retrieval.Id
                //    //                            select rd;
                //    //foreach (RetrievalDetail rd in retrievalDetailResult)
                //    //{
                //    //    retrieval.RetrievalDetails.Add(rd);

                //    // }
                //    return retrieval;
                //}
            }
            catch (Exception e)
            {
                retrieval = null;
            }
            return retrieval;
        }
        /// <summary>
        ///   Retrieve All of the Retrieval information from Retrieval Table
        /// </summary>
        /// <returns></returns>
        public List<Retrieval> GetAllRetrieval()
        {
            try
            {
                retrievalList = inventory.Retrievals.OrderByDescending(x=> x.Id).ToList<Retrieval>();
            }
            catch (Exception e)
            {
                retrievalList = null;
            }
        
                return retrievalList;
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
                //foreach (RetrievalDetail retrievalDetail in newRetrieval.RetrievalDetails)
                //{
                //    this.Insert(retrievalDetail);
                //}
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
                Retrieval retrievalObj = inventory.Retrievals.Where(rObj => rObj.Id == retrieval.Id).First();
                Employee createdBy = inventory.Employees.Where(e => e.Id == retrieval.CreatedBy.Id).First();

                retrievalObj.Id = retrieval.Id;
                retrievalObj.CreatedBy = createdBy;
                retrievalObj.CreatedDate = retrieval.CreatedDate;
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

        public int GetSumRetrievalDetailQty(QTY_TYPE quantityType, Retrieval retrieval)
        {
            int? totalQty = 0;
            switch (quantityType)
            {
                case QTY_TYPE.ACTUAL_QTY:
                    totalQty = retrieval.RetrievalDetails.Sum(x => x.ActualQty).Value;
                    break;
                case QTY_TYPE.NEEDED_QTY:
                    totalQty = retrieval.RetrievalDetails.Sum(x => x.NeededQty);
                    break;
            }

            return totalQty.HasValue ? totalQty.Value : 0;
        }

        /// <summary>
        /// Retrieve the RetrievalDetail information  from RetrievalDetail Table according to the RetrievalDetail Parameter
        /// </summary>
        /// <param name="retrievalDetail"></param>
        /// <returns></returns>
        public RetrievalDetail GetRetrievalDetail(RetrievalDetail retrievalDetail)
        {
            try
            {
                retrievalDetail = inventory.RetrievalDetails.Where(rObj => rObj.Id == retrievalDetail.Id).First();
            }
            catch (Exception e)
            {
                retrievalDetail = null;
            }
          
                return retrievalDetail;
        }
        /// <summary>
        /// Retrieve All of the RetrievalDetail information from RetrievalDetail Table
        /// </summary>
        /// <returns></returns>
       public List<RetrievalDetail> GetAllRetrievalDetail()
        {
            try
            {
                retrievalDetailList = inventory.RetrievalDetails.ToList();
            }
            catch (Exception e)
            {
                retrievalDetailList = null;
            }
            return retrievalDetailList;
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
                if (!rDetail.Equals(null))
                {
                    retrieval = inventory.Retrievals.Where(r => r.Id == retrievalDetail.Retrieval.Id).First();
                    Item item = inventory.Items.Where(i => i.Id == retrievalDetail.Item.Id).First();
                    Department department = inventory.Departments.Where(d => d.Id == retrievalDetail.Department.Id).First();

                    rDetail.Retrieval = retrieval;
                    rDetail.Item = item;
                    rDetail.Department = department;
                    rDetail.NeededQty = retrievalDetail.NeededQty;
                    rDetail.ActualQty = retrievalDetail.ActualQty;
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
        /// There is no status in RetrievalTable.
        /// </summary>
        /// <param name="retrievalDetail"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(RetrievalDetail retrievalDetail)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the last RetrievalId from the Retrieval Table
        /// </summary>
        /// <returns></returns>
        public int GetRetrievalId()
        {
            List<Retrieval> list = GetAllRetrieval();
            Retrieval retrieval = list.Last();
            int id = retrieval.Id;
            id++;
            return id;
        }

        public int GetRetrievalDetailId()
        {
            List<RetrievalDetail> list = GetAllRetrievalDetail();
            RetrievalDetail retrievalDetail = list.Last();
            int id = retrievalDetail.Id;
            id++;
            return id;
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/