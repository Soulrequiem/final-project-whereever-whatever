using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace StationeryStoreInventorySystemController.commonController
{
    interface IGenerateReportsControl
    {
        DataTable getCollections();
        DataTable getDepartments();
        DataTable getEmployees();
        DataTable getEmployeesByDepartment(string departmentID);
        DataTable getItems();
        DataTable getPurchaseOrderDetails();
        DataTable getRequisitions();
        DataTable getRoles();
        DataTable getSuppliers();
        DataTable getRetrievalDetails();
        DataTable getUsers();
    }
}
