using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface ISupplierBroker
    {
        Supplier GetSupplier(Supplier supplier);
        List<Supplier> GetAllSupplier();
        Constants.DB_STATUS Insert(Supplier newSupplier);
        Constants.DB_STATUS Update(Supplier supplier);
        Constants.DB_STATUS Delete(Supplier supplier);
    }
}
