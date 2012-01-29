/***************************************************************************/
/*  File Name       : ViewSupplierListControl.cs
/*  Module Name     : Controller
/*  Owner           : JinChengCheng
/*  class Name      : ViewSupplierListControl
/*  Details         : Controller representation of ViewSupplierList 
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class ViewSupplierListControl
    {
        private ISupplierBroker supplierBroker;
        private List<Supplier> supplierList;

        private DataTable dt;
        private DataRow dr;

        public ViewSupplierListControl()
        {
            supplierList = new List<Supplier>();
        }

        //public List<Supplier> GetSupplierList()
        //{
        //    return supplierList;
        //}

        /// <summary>
        ///     Show all supplier List
        ///     Created By:JinChengCheng
        ///     Created Date:26-01-2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name=""></param>
        /// <returns>The return type of this method is datatable.</returns>
        public DataTable GetSupplierList()
        {
            dt = new DataTable();
            
            supplierList = supplierBroker.GetAllSupplier();
            foreach (Supplier temp in supplierList)
            {
                dr = dt.NewRow();
                dr["supplierCode"] = temp.Id;
                dr["gstRegistrationNo"] = temp.GstRegistrationNumber;
                dr["supplierName"] = temp.Name;
                dr["contactName"] = temp.ContactName;
                dr["phoneNo"] = temp.PhoneNumber;
                dr["faxNo"] = temp.FaxNumber;
                dr["address"] = temp.Address;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }   
}
/****************************************/
/********* End of the Class *****************/
/****************************************/