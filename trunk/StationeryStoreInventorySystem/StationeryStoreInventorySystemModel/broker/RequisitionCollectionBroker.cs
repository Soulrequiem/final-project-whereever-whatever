using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;

namespace StationeryStoreInventorySystemModel.broker
{
    public class RequisitionCollectionBroker: IRequisitionCollectionBroker
    {

        #region IRequisitionCollectionBroker Members

        public entity.RequisitionCollectionDetail GetRequisitionCollectionDetail(entity.RequisitionCollectionDetail requisitionCollectionDetail)
        {
            throw new NotImplementedException();
        }

        public List<entity.RequisitionCollectionDetail> GetAllRequisitionCollectionDetail()
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Insert(entity.RequisitionCollectionDetail newRequisitionCollectionDetail)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Update(entity.RequisitionCollectionDetail requisitionCollectionDetail)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Delete(entity.RequisitionCollectionDetail requisitionCollectionDetail)
        {
            throw new NotImplementedException();
        }

        public entity.User GetRequisitionCollection(entity.RequisitionCollection requisitionCollection)
        {
            throw new NotImplementedException();
        }

        public List<entity.RequisitionCollection> GetAllRequisitionCollection()
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Insert(entity.RequisitionCollection newRequisitionCollection)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Update(entity.RequisitionCollection requisitionCollection)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Delete(entity.RequisitionCollection requisitionCollection)
        {
            throw new NotImplementedException();
        }

        public entity.User GetRequisitionCollectionItem(entity.RequisitionCollectionItem requisitionCollectionItem)
        {
            throw new NotImplementedException();
        }

        public List<entity.RequisitionCollectionItem> GetAllRequisitionCollectionItem()
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Insert(entity.RequisitionCollectionItem newRequisitionCollectionItem)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Update(entity.RequisitionCollectionItem requisitionCollectionItem)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Delete(entity.RequisitionCollectionItem requisitionCollectionItem)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
