using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;


namespace StationeryStoreInventorySystemController.departmentController
{
    class ManageCollectionPointControl
    {
        CollectionPointBroker collectionPointBroker = new CollectionPointBroker();
     

        public ManageCollectionPointControl()
        {
            collectionPointBroker = new CollectionPointBroker();
        }

        public List<Collectionpoint> GetAllCollectionPoint()
        {
            

            return collectionPointBroker.GetAllCollectionPoint();
        }

        public Constants.DB_STATUS SelectSave(int collectionPointId)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            Collectionpoint collectionPoint = new Collectionpoint();
            
        }

        public Collectionpoint GetCurrentCollectionPoint(User user)
        {
           
            
        }
    }
}
