using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.broker
{
    public class CollectionMissedBroker : StationeryStoreInventorySystemModel.brokerinterface.ICollectionMissedBroker
    {

        public entity.CollectionMissed GetCollectionMissed(entity.CollectionMissed collectionMissed)
        {
            throw new NotImplementedException();
        }

        public List<entity.CollectionMissed> GetAllCollectionMissed(entity.Department department)
        {
            throw new NotImplementedException();
        }

        public List<entity.CollectionMissed> GetAllCollectionMissed(entity.Department department, SystemStoreInventorySystemUtil.Constants.VISIBILITY_STATUS status)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Insert(entity.CollectionMissed newCollectionMissed)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Update(entity.CollectionMissed collectionMissed)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Delete(entity.CollectionMissed collectionMissed)
        {
            throw new NotImplementedException();
        }
    }
}
