
/***************************************************************************/
/*  File Name       : PurchaseOrderBroker.cs
/*  Module Name     : Models
/*  Owner           : Su Lai Naing
/*  class Name      : PurchaseOrderBroker
/*  Details         : Model PurchaseOrderBroker of PurchaseOrder and PurchaseOrderDetail table
/***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemModel.broker
{
    public class SupplierBroker : ISupplierBroker
    {
        #region ISupplierBroker Members

        private InventoryEntities inventory = new InventoryEntities();
        private Supplier supplierObj = null;
        private List<Supplier> supplierList = null;

        public Supplier GetSupplier(Supplier supplier)
        {

            supplierObj = inventory.Suppliers.Where(iObj => iObj.Id == supplier.Id).First();
            if (!supplierObj.Equals(null))
                return supplierObj;
            return null;
        }

        public List<Supplier> GetAllSupplier()
        {
            supplierList = inventory.Suppliers.ToList<Supplier>();
            if (!supplierList.Equals(null))
                return supplierList;
            return null;
        }

        public Constants.DB_STATUS Insert(Supplier newSupplier)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToSuppliers(newSupplier);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

        public Constants.DB_STATUS Update(Supplier supplier)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                supplierObj = inventory.Suppliers.Where(iObj => iObj.Id == supplier.Id).First();
                supplierObj.Id = supplier.Id;
                supplierObj.Name = supplier.Name;
                supplierObj.Priority = supplier.Priority;
                supplierObj.ContactName = supplier.ContactName;
                supplierObj.PhoneNumber = supplier.PhoneNumber;
                supplierObj.FaxNumber = supplier.FaxNumber;
                supplierObj.Address = supplier.Address;
                supplierObj.GstRegistrationNumber = supplier.GstRegistrationNumber;
                supplierObj.CreatedDate = supplier.CreatedDate;

                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }

        public Constants.DB_STATUS Delete(Supplier supplier)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                supplierObj = inventory.Suppliers.Where(iObj => iObj.Id == supplier.Id).First();
                supplierObj.Status = 2;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }

        #endregion
    }
}
