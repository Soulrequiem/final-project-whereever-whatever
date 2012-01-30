using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IRetrievalBroker
    {
        int GetRetrievalId();
        Retrieval GetRetrieval(Retrieval retrieval);
        List<Retrieval> GetAllRetrieval();
        Constants.DB_STATUS Insert(Retrieval newRetrieval);
        Constants.DB_STATUS Update(Retrieval retrieval);
        Constants.DB_STATUS Delete(Retrieval retrieval);

        int GetRetrievalDetailId();
        RetrievalDetail GetRetrievalDetail(RetrievalDetail retrievalDetail);
        List<RetrievalDetail> GetAllRetrievalDetail();
        Constants.DB_STATUS Insert(RetrievalDetail newRetrievalDetail);
        Constants.DB_STATUS Update(RetrievalDetail retrievalDetail);
        Constants.DB_STATUS Delete(RetrievalDetail retrievalDetail);
    }
}
