using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface ICollectionMissedBroker
    {
        CollectionMissed GetCollectionMissed(CollectionMissed collectionMissed);
        List<CollectionMissed> GetAllCollectionMissed(Department department);
        List<CollectionMissed> GetAllCollectionMissed(Department department, Constants.VISIBILITY_STATUS status);
        Constants.DB_STATUS Insert(CollectionMissed newCollectionMissed);
        Constants.DB_STATUS Update(CollectionMissed collectionMissed);
        Constants.DB_STATUS Delete(CollectionMissed collectionMissed);
        int GetCollectionMissedId();
        //Constants.DB_STATUS Insert(CollectionMissed newCollectionMissed, Boolean isSaved);
        //Constants.DB_STATUS Update(Boolean isSaved);
        //Constants.DB_STATUS Delete(CollectionMissed collectionMissed,Boolean isSaved);
    }
}
