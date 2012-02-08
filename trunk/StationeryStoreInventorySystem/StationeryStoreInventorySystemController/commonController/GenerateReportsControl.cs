using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using StationeryStoreInventorySystemModel.broker;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemController.commonController
{
    public class GenerateReportsControl : IGenerateReportsControl
    {
        ReportBroker RB;
        int roleId ;
        Employee emp;
        public GenerateReportsControl()
        {
            RB = new ReportBroker();
            roleId = Util.GetEmployeeRole();
            emp = Util.GetEmployee();
        }

        public DataTable getItemMovement(string ItemCode)
        {
            string sQuery = "select CreatedDate as  'MovementTime', CONVERT(int, Balance) as 'StockLevel' from StockCardDetails where ItemId = '" + ItemCode + "'";
            return ReturnResultSet(sQuery);
        }

        public DataTable getCollections()
        {
            string sQuery = "select id,name,time from CollectionPoint";
            return ReturnResultSet(sQuery);
        }
        public DataTable getDepartments()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("select D.id as 'DepartmentID', D.Name as 'DepartmentName', ");
            sbQuery.Append(" E.Name as 'DepartmentHead' ");
            sbQuery.Append(" from Department D, Employee E ");
            sbQuery.Append(" where D.HeadId = E.Id ");
            if ((int)Constants.EMPLOYEE_ROLE.STORE_CLERK != roleId &&
                (int)Constants.EMPLOYEE_ROLE.ADMIN != roleId &&
                (int)Constants.EMPLOYEE_ROLE.STORE_MANAGER != roleId &&
                (int)Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR != roleId)
            {
                sbQuery.Append(" AND E.DepartmentId = '" + emp.Department.Id + "'");
            }
            else
            {
                sbQuery.Append(" AND D.Id != 'STR' "); 
            }
            return ReturnResultSet(sbQuery.ToString());
        }
        public DataTable getEmployees()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append(" select E.Name as 'EmployeeName', Designation, R.Name as ");
            sbQuery.Append(" 'Role', D.Name  as 'Department' ");
            sbQuery.Append(" from Employee E, Role R, Department D ");
            sbQuery.Append(" where E.RoleId = R.Id AND D.Id = E.DepartmentId ");

            if ((int)Constants.EMPLOYEE_ROLE.STORE_CLERK != roleId &&
                (int)Constants.EMPLOYEE_ROLE.ADMIN != roleId &&
                (int)Constants.EMPLOYEE_ROLE.STORE_MANAGER != roleId &&
                (int)Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR != roleId )
           {
               sbQuery.Append(" AND E.DepartmentId = '"+emp.Department.Id+"'");
            }
            return ReturnResultSet(sbQuery.ToString());
        }
        public DataTable getItems()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append(" select SCD.ItemId as 'Item Code', I.Description, SCD.Balance as 'Quantity on Hand', I.ReorderLevel as 'Reorder Level' ");
            sbQuery.Append(" from StockCardDetails SCD, Item I ");
            sbQuery.Append(" where I.Id = SCD.ItemId AND SCD.CreatedDate IN (SELECT MAX(CreatedDate)  from StockCardDetails  group by ItemId) ");
            return ReturnResultSet(sbQuery.ToString());
        }

        public DataTable getReorderDetails()
        { 
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append(" select I.Id as 'Item Code', ");
		    sbQuery.Append(" I.Description as 'Description', ");
		    sbQuery.Append(" SCD.Balance as 'Qunatity on Hand', ");
		    sbQuery.Append(" I.ReorderLevel as 'Reorder Level', ");
		    sbQuery.Append(" I.ReorderQty as 'Reorder quantity', ");
		    sbQuery.Append(" POD.PurchaseOrderId as 'PO#', ");
		    sbQuery.Append(" PO.ExpectedDate as 'Expected Delivery' ");
		    sbQuery.Append(" from Item I,  ");
		    sbQuery.Append(" StockCardDetails SCD, ");
		    sbQuery.Append(" PurchaseOrderDetails POD, ");
		    sbQuery.Append(" PurchaseOrder PO ");
            sbQuery.Append(" where I.Id = SCD.ItemId AND  ");
		    sbQuery.Append(" I.ReorderLevel > SCD.Balance AND ");
		    sbQuery.Append(" POD.ItemId = I.Id AND ");
		    sbQuery.Append(" PO.Id = POD.PurchaseOrderId AND ");
		    sbQuery.Append(" SCD.CreatedDate IN (SELECT MAX(CreatedDate)  ");
		    sbQuery.Append(" from StockCardDetails  ");
            sbQuery.Append(" group by ItemId) order by PO.Id asc	");
            return ReturnResultSet(sbQuery.ToString());
        }

        public DataTable getCatalogue()
        {
            //StringBuilder sbQuery = new StringBuilder();
            //sbQuery.Append(" select id as 'Item Code',ItemCategoryId as 'Category' ,Description,ReorderLevel as 'Reorder Level', ");
            //sbQuery.Append(" ReorderQty as 'Reorder Qty',UnitOfMeasureId as 'Unit of Measure' from Item ");

            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append(" select I.id as 'Item Number',C.Name as 'Category' , ");
            sbQuery.Append(" I.Description,I.ReorderLevel as 'Reorder Level',  ");
            sbQuery.Append(" I.ReorderQty as 'Reorder Qty' ");
            sbQuery.Append(" , UM.Name as 'Unit of Measure'  ");
            sbQuery.Append(" from Item I, UnitOfMeasure UM, Category C ");
            sbQuery.Append(" where I. UnitOfMeasureId = UM.Id AND C.Id = I.ItemCategoryId ");
            return ReturnResultSet(sbQuery.ToString());
        }
        public DataTable getPurchaseOrderDetails()
        {
            return null;
        }
        public DataTable getRequisitions()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append(" select	RQ.Id as 'Requisition ID', ");
            sbQuery.Append(" SUM(RD.Qty) as 'Total number of Items consumed' ");
            sbQuery.Append(" , E.Name as 'Employee Name' ");
            sbQuery.Append(" from RequisitionDetails RD, ");
            sbQuery.Append(" Requisition RQ, Employee E, Item I, Department D  ");
            sbQuery.Append(" where RD.ItemId = I.Id AND E.Id = RQ.EmployeeId AND RD.RequisitionId = RQ.Id  ");
            
            if ((int)Constants.EMPLOYEE_ROLE.STORE_CLERK != roleId &&
                (int)Constants.EMPLOYEE_ROLE.ADMIN != roleId &&
                (int)Constants.EMPLOYEE_ROLE.STORE_MANAGER != roleId &&
                (int)Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR != roleId)
            {
                sbQuery.Append(" AND E.DepartmentId = '" + emp.Department.Id + "' AND D.Id = E.DepartmentId ");
            }
            else
            {
                sbQuery.Append(" AND D.Id = E.DepartmentId   ");
            }
            sbQuery.Append(" group by RQ.Id, D.Name, E.Name ");
            return ReturnResultSet(sbQuery.ToString());
        }
        public DataTable getRoles()
        {
            string sQuery = "select Id as 'RoleId', Name as 'RoleName' from Role";
            return ReturnResultSet(sQuery);
        }

        private DataTable ReturnResultSet(string sQuery)
        {
            return RB.ExecuteQuery(sQuery);
        }
        public DataTable getSuppliers()
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append(" select Id as 'SupplierID', Name as 'SupplierName', ContactName as 'ContactPerson', ");
		    sbQuery.Append(" Address as 'SupplierAddress', GstRegistrationNumber as 'RegistrationNumber' ");
            sbQuery.Append(" from Supplier");
            return ReturnResultSet(sbQuery.ToString());
        }
        public DataTable getRetrievalDetails()
        {
            return null;
        }
        public DataTable getUsers()
        {
            return null;
        }

        public DataTable getEmployeesByDepartment(string departmentID)
        {
            string sQuery = string.Empty;
            if(departmentID != string.Empty)
                sQuery = "select Id as 'EmployeeId', Name as 'EmployeeName' from Employee";
            else
                sQuery = "select Id as 'EmployeeId', Name as 'EmployeeName' from Employee ";

            if ((int)Constants.EMPLOYEE_ROLE.STORE_CLERK != roleId &&
                (int)Constants.EMPLOYEE_ROLE.ADMIN != roleId &&
                (int)Constants.EMPLOYEE_ROLE.STORE_MANAGER != roleId &&
                (int)Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR != roleId)
            {
                sQuery = sQuery + " where DepartmentID= '" + emp.Department.Id + "' ";
            }
            return ReturnResultSet(sQuery);
        }

        public DataTable getTenderPrice(string supplierID)
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append(" select I.Description as 'ItemDescription', (CAST(IP.Price AS varchar(5))+'/'+ UM.Name) as 'TenderPrice' ");
            sbQuery.Append(" from itemprice IP, Item I, UnitOfMeasure UM where UM.Id = I.UnitOfMeasureId AND I.Id = IP.ItemId AND IP.SupplierId='" + supplierID + "'");
            return ReturnResultSet(sbQuery.ToString());
        }

        public DataTable defaultResultSet(string fromDate, string toDate)
        { 
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append(" select	D.Name as 'Department Name', ");
		    sbQuery.Append(" SUM(RD.Qty) as 'Total Item Consumption' ");
            sbQuery.Append(" from	RequisitionDetails RD, "); 
		    sbQuery.Append(" Requisition RQ, Employee E, Item I, Department D ");
            sbQuery.Append(" where	RD.ItemId = I.Id AND "); 
		    sbQuery.Append(" E.Id = RQ.EmployeeId AND ");
		    sbQuery.Append(" RD.RequisitionId = RQ.Id AND ");
		    sbQuery.Append(" D.Id = E.DepartmentId ");

            if ((int)Constants.EMPLOYEE_ROLE.STORE_CLERK != roleId &&
                (int)Constants.EMPLOYEE_ROLE.ADMIN != roleId &&
                (int)Constants.EMPLOYEE_ROLE.STORE_MANAGER != roleId &&
                (int)Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR != roleId)
            {
                sbQuery.Append(" AND D.Id = '"+emp.Department.Id+"'");
            }

            //if (fromDate != string.Empty && toDate != string.Empty)
            //    sbQuery.Append(" AND ( RQ.CreatedDate >= '" + fromDate + "' AND RQ.CreatedDate <= '" + toDate + "') ");
            //else if (fromDate != string.Empty && toDate == string.Empty)
            //    sbQuery.Append(" AND RQ.CreatedDate >= '" + fromDate + "' ");
            //else if (fromDate == string.Empty && toDate != string.Empty)
            //    sbQuery.Append(" AND RQ.CreatedDate <= '" + toDate + "' ");
            sbQuery.Append(getDate(fromDate, toDate));
            sbQuery.Append(" group by D.Name ");
            return ReturnResultSet(sbQuery.ToString());
        }

        public DataTable getFilterDepartmentByItems(string departmentID, string employeeID, string items, string fromDate, string toDate)
        {
            departmentID = departmentID == string.Empty ? emp.Department.Id : departmentID;
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append(" select	I.Description as 'Item' , RQ.Id as 'Requisition ID', "); 
		    sbQuery.Append(" RD.Qty as 'Quantity' ");
            if (employeeID == string.Empty)
                sbQuery.Append(" , E.Name  ");
            sbQuery.Append(" , RQ.CreatedDate ");
            if (departmentID == string.Empty)
                sbQuery.Append(" , D.Name as 'Department Name' ");
            sbQuery.Append(" from RequisitionDetails RD,  ");
	        sbQuery.Append(" Requisition RQ, Employee E, Item I, Department D ");
            sbQuery.Append(" where RD.ItemId = I.Id AND E.Id = RQ.EmployeeId AND RD.RequisitionId = RQ.Id  ");
            sbQuery.Append(" AND D.Id = E.DepartmentId ");
            if (departmentID != string.Empty && !departmentID.Contains("STR")) 
                sbQuery.Append(" AND D.Id = '" + departmentID + "' ");
            if (employeeID != string.Empty)
                sbQuery.Append(" AND E.Id = '" + employeeID + "'  ");
            sbQuery.Append(ExpandItems(items));
            //if (fromDate != string.Empty && toDate != string.Empty)
            //    sbQuery.Append(" AND ( RQ.CreatedDate >= '" + fromDate + "' AND RQ.CreatedDate <= '" + toDate + "') ");
            //else if (fromDate != string.Empty && toDate == string.Empty)
            //    sbQuery.Append(" AND RQ.CreatedDate >= '" + fromDate + "' ");
            //else if (fromDate == string.Empty && toDate != string.Empty)
            //    sbQuery.Append(" AND RQ.CreatedDate <= '" + toDate + "' ");
            sbQuery.Append(getDate(fromDate, toDate));
            sbQuery.Append(" order by I.Id ");
            return ReturnResultSet(sbQuery.ToString());
        }

        public DataTable getFilterDepartmentByRequisitions(string departmentID, string employeeID,
            string sRequisitions, string fromDate, string toDate)
        {
            departmentID = departmentID == string.Empty ? emp.Department.Id : departmentID;
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append(" select	RQ.Id as 'Requisition ID', I.Description as 'Item Description', ");
		    sbQuery.Append(" RD.Qty as 'Total number of Items consumed' ");
            if(departmentID == string.Empty)
                sbQuery.Append(" , D.Name as 'Department Name' ");
            sbQuery.Append(" from RequisitionDetails RD,  ");
	        sbQuery.Append(" Requisition RQ, Employee E, Item I, Department D ");
            sbQuery.Append(" where RD.ItemId = I.Id AND E.Id = RQ.EmployeeId AND RD.RequisitionId = RQ.Id  ");
		    sbQuery.Append(" AND D.Id = E.DepartmentId  ");
            if (departmentID != string.Empty && !departmentID.Contains("STR"))
                sbQuery.Append(" AND D.Id = '" + departmentID + "'  ");
            if (employeeID != string.Empty)
                sbQuery.Append(" AND E.Id = '" + employeeID + "'  ");
            sbQuery.Append(sRequisitions);
            //if (fromDate != string.Empty && toDate != string.Empty)
            //    sbQuery.Append(" AND ( RQ.CreatedDate >= '" + fromDate + "' AND RQ.CreatedDate <= '" + toDate + "') ");
            //else if (fromDate != string.Empty && toDate == string.Empty)
            //    sbQuery.Append(" AND RQ.CreatedDate >= '" + fromDate + "' ");
            //else if (fromDate == string.Empty && toDate != string.Empty)
            //    sbQuery.Append(" AND RQ.CreatedDate <= '" + toDate + "' ");
            sbQuery.Append(getDate(fromDate, toDate));
            sbQuery.Append(" order by RQ.Id ");
            //sbQuery.Append(" group by RQ.Id,D.Name ");
            return ReturnResultSet(sbQuery.ToString());
        }

        //public DataTable getFilterDepartmentByItems(string departmentID, string employeeID, string items)
        //{
        //    StringBuilder sbQuery = new StringBuilder();
        //    sbQuery.Append(" select	I.Description as 'Item' , RQ.Id as 'Requisition ID', ");
        //    sbQuery.Append(" RD.Qty as 'Quantity' ");
        //    if (employeeID == string.Empty)
        //        sbQuery.Append(" , E.Name  ");
        //    sbQuery.Append(" , RQ.CreatedDate ");
        //    if (departmentID == string.Empty)
        //        sbQuery.Append(" , D.Name as 'Department Name' ");
        //    sbQuery.Append(" from RequisitionDetails RD,  ");
        //    sbQuery.Append(" Requisition RQ, Employee E, Item I, Department D ");
        //    sbQuery.Append(" where RD.ItemId = I.Id AND E.Id = RQ.EmployeeId AND RD.RequisitionId = RQ.Id  ");
        //    sbQuery.Append(" AND D.Id = E.DepartmentId ");
        //    if (departmentID != string.Empty)
        //        sbQuery.Append(" AND D.Id = '" + departmentID + "' ");
        //    if (employeeID != string.Empty)
        //        sbQuery.Append(" AND E.Id = '" + employeeID + "'  ");
        //    return ReturnResultSet(sbQuery.ToString());
        //}

        private string ExpandItems(string items)
        {
            if (items == null || items == string.Empty)
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            if (items.Contains(","))
            {
                string[] itemArr = items.Split(',');
                for (int i = 0; i < itemArr.Length; i++)
                {
                    string item = itemArr[i].ToString().Trim();
                    if (item != string.Empty)
                    {
                        if (i == 0)
                            sb.Append(" AND ( ");
                        else
                            sb.Append(" OR ");
                        sb.Append(" CAST(I.Description as varchar(200)) = '" + item + "' ");
                    }
                    if (i == itemArr.Length - 1)
                        sb.Append(" ) ");
                }
            }
            else
            {
                sb.Append(" AND I.Id = '" + items + "' ");
            }
            return sb.ToString();
        }

        private string ExpandRequisition(string requisitionID)
        {
            if (requisitionID == null || requisitionID == string.Empty)
                return string.Empty;
            StringBuilder sb = new StringBuilder();
            if (requisitionID.Contains(","))
            {
                string[] requisitions = requisitionID.Split(',');
                for (int i = 0; i < requisitions.Length; i++)
                {
                    string req = requisitions[i].ToString().Trim();
                    if (req != string.Empty)
                    {
                        if (i == 0)
                            sb.Append(" AND ( ");
                        else
                            sb.Append(" OR ");
                        sb.Append(" RQ.Id = '" + req + "' ");
                    }
                    if (i == requisitions.Length - 1)
                        sb.Append(" ) ");
                }
            }
            else
            {
                sb.Append(" AND RQ.Id = '" + requisitionID + "' ");
            }
            return sb.ToString();
        }

        public string[] formatDate(string fromDate, string toDate)
        {
            if (!fromDate.Contains(","))
                return new string[] {toDate+"-"+fromDate+"-01", toDate+"-"+fromDate+"-"+
                    System.DateTime.DaysInMonth(Convert.ToInt16(toDate), Convert.ToInt16(fromDate)).ToString()};
            //else if (fromDate.Contains(","))
            //{
            //    string[] str = fromDate.Split(',');

            //}
            return null;
        }
        public DataTable getFilterDepartmentByRequisitions(string departmentID, string employeeID, 
                            bool flag, string requisitionID, string fromDate, string toDate)
        {
            departmentID = departmentID == string.Empty ? emp.Department.Id : departmentID;
            string sRequisitions = ExpandRequisition(requisitionID);
            if (flag)
            {
                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append(" select	RQ.Id as 'Requisition ID', ");
                sbQuery.Append(" SUM(RD.Qty) as 'Total number of Items consumed' ");
                if (departmentID == string.Empty)
                    sbQuery.Append(" , D.Name as 'Department Name' ");
                if (employeeID == string.Empty)
                    sbQuery.Append(" , E.Name as 'Employee Name' ");
                sbQuery.Append(" from RequisitionDetails RD,  ");
                sbQuery.Append(" Requisition RQ, Employee E, Item I, Department D ");
                sbQuery.Append(" where RD.ItemId = I.Id AND E.Id = RQ.EmployeeId AND RD.RequisitionId = RQ.Id  ");
                sbQuery.Append(" AND D.Id = E.DepartmentId  ");
                if (departmentID != string.Empty && !departmentID.Contains("STR"))
                    sbQuery.Append(" AND D.Id = '" + departmentID + "'  ");
                if (employeeID != string.Empty)
                    sbQuery.Append(" AND E.Id = '" + employeeID + "'  ");
                //if (requisitionID != string.Empty)
                //    sbQuery.Append(" AND RQ.Id = '" + requisitionID + "'  ");
                sbQuery.Append(sRequisitions);

                sbQuery.Append(getDate(fromDate, toDate));
                sbQuery.Append("  group by RQ.Id, D.Name, E.Name ");
                return ReturnResultSet(sbQuery.ToString());
            }
            else
            {
                return getFilterDepartmentByRequisitions(departmentID, employeeID, sRequisitions, fromDate, toDate);
            }
        }

        private string getDate(string fromDate, string toDate)
        {
            StringBuilder sbQuery = new StringBuilder();

            if (!fromDate.Contains(";") && !toDate.Contains(";"))
            {
                
                if (fromDate != string.Empty && toDate != string.Empty)
                    sbQuery.Append(" AND ( RQ.CreatedDate >= '" + fromDate + "' AND RQ.CreatedDate <= '" + toDate + "') ");
                else if (fromDate != string.Empty && toDate == string.Empty)
                    sbQuery.Append(" AND RQ.CreatedDate >= '" + fromDate + "' ");
                else if (fromDate == string.Empty && toDate != string.Empty)
                    sbQuery.Append(" AND RQ.CreatedDate <= '" + toDate + "' ");
            }
            else
            {
                string[] spFrom = fromDate.Split(';');
                string[] spTo = toDate.Split(';');
                sbQuery.Append(" AND ( ");
                for (int i = 0; i < spFrom.Length; i++)
                {
                    if (i != 0)
                        sbQuery.Append(" OR ");
                    sbQuery.Append(" ( RQ.CreatedDate >= '" + spFrom[i] + "' AND RQ.CreatedDate <= '" + spTo[i] + "' ) ");
                }
                sbQuery.Append(" ) ");
            }
            return sbQuery.ToString();
        }

        public DataTable getDisbursment(string date, string retrivalID)
        {
            StringBuilder sbQuery = new StringBuilder();

            sbQuery.Append(" select D.Name as 'Department', CP.Name as 'CollectionPoint', I.Description as 'StationeryDescription' , RD.ActualQty as 'Quantity' ");
            sbQuery.Append(" from RetrievalDetails RD, Item I, Retrieval RT, ");
            sbQuery.Append(" Requisition RQ, RequisitionCollectionDetails RCD, RequisitionCollection RC, CollectionPoint CP, Department D   ");
            sbQuery.Append(" where RD.ItemId = I.Id AND RD.RetrievalId = RT.Id AND RC.Id = RCD.RequisitionCollectionId AND RQ.DepartmentId = D.Id AND ");
            sbQuery.Append(" RD.RequisitionId = RQ.Id AND RCD.RequisitionId = RD.RequisitionId AND RT.Id = '" + retrivalID + "' AND ");
            sbQuery.Append(" RC.CollectionPointId = CP.Id AND RC.DeliveryDate = '" + date + "'");

            return ReturnResultSet(sbQuery.ToString());
        }
    }
}
