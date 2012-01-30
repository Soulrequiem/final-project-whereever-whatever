using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemController.storeController
{
    public class ViewSupplierListControl
    {
        public ViewSupplierListControl()
        {
        }

        public List<Supplier> GetAllSuppliers()
        {
            ISupplierBroker supplierBroker = new SupplierBroker();
            List<Supplier> supplierList = supplierBroker.GetAllSupplier();
            return supplierList;
        }
    }
}
