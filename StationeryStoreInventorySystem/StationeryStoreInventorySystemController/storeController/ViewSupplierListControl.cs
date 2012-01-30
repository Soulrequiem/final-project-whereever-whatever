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
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.storeController
{
    public class ViewSupplierListControl
    {
        private ISupplierBroker supplierBroker;

        private Employee currentEmployee;

        private List<Supplier> supplierList;

        private DataTable dt;
        private DataRow dr;

        private DataColumn[] dataColumn;

        public ViewSupplierListControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.STORE_CLERK);
            InventoryEntities inventory = new InventoryEntities();

            supplierBroker = new SupplierBroker(inventory);

            supplierList = supplierBroker.GetAllSupplier();

            dataColumn = new DataColumn[] { new DataColumn("supplierCode"),
                                            new DataColumn("gstRegistrationNo"),
                                            new DataColumn("supplierName"),
                                            new DataColumn("contactName"),
                                            new DataColumn("phoneNo"),
                                            new DataColumn("faxNo"),
                                            new DataColumn("address")};
        }

        public DataTable SupplierList
        {
            get 
            {
                dt = new DataTable();

                dt.Columns.AddRange(dataColumn);

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

        public void SelectPrint()
        {
        }
      
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
        //public DataTable GetSupplierList()
        //{
        //    dt = new DataTable();
            
        //    supplierList = supplierBroker.GetAllSupplier();
        //    foreach (Supplier temp in supplierList)
        //    {
        //        dr = dt.NewRow();
        //        dr["supplierCode"] = temp.Id;
        //        dr["gstRegistrationNo"] = temp.GstRegistrationNumber;
        //        dr["supplierName"] = temp.Name;
        //        dr["contactName"] = temp.ContactName;
        //        dr["phoneNo"] = temp.PhoneNumber;
        //        dr["faxNo"] = temp.FaxNumber;
        //        dr["address"] = temp.Address;
        //        dt.Rows.Add(dr);
        //    }
        //    return dt;
        //}
    }   
}
/****************************************/
/********* End of the Class *****************/
/****************************************/