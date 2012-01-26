using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface ICollectionPointBroker
    {
        CollectionPoint GetCollectionPoint(CollectionPoint collectionPoint);
        List<CollectionPoint> GetAllCollectionPoint();
        Constants.DB_STATUS Insert(CollectionPoint newCollectionPoint);
        Constants.DB_STATUS Update(CollectionPoint collectionPoint);
        Constants.DB_STATUS Delete(CollectionPoint collectionPoint);
    }
}
