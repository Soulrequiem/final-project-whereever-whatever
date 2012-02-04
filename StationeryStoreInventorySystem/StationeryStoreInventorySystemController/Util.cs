using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using System.Web;
using System.Data;

namespace StationeryStoreInventorySystemController
{
    public class Util
    {
        public static readonly string employeeSessionKey = "employee";

        public static readonly string itemApplicationKey = "item";
        public static readonly string employeeApplicationKey = "employee";

        public static readonly string loginPage = "~/commonUI/LogIn.aspx";

        public static string EmployeeName()
        {
            if (GetEmployee() == null)
            {
                return null;
            }
            return GetEmployee().Name;
        }

        public static void PutSession(string key, object obj)
        {
            HttpContext.Current.Session[key] = obj;
        }

        /// <summary>
        ///     Return session object from session
        ///     Created By: Taufin Rusli
        ///     Created Date: 25/01/2012
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        ///     Object of the session
        /// </returns>
        public static object GetSession(string obj)
        {
            if (HttpContext.Current.Session == null)
            {
                return new Employee();
            }
            else
            {
                return HttpContext.Current.Session[obj];
            }
        }

        public static void RemoveSession(string key)
        {
            HttpContext.Current.Session[key] = null;
            HttpContext.Current.Session.Remove(key);
        }

        public static void PutApplication(string key, object obj)
        {
            HttpContext.Current.Application[key] = obj;
        }

        /// <summary>
        ///     Return session object from session
        ///     Created By: Taufin Rusli
        ///     Created Date: 25/01/2012
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        ///     Object of the session
        /// </returns>
        public static object GetApplication(string obj)
        {
            return HttpContext.Current.Application[obj];
        }

        public static void RemoveApplication(string key)
        {
            HttpContext.Current.Application[key] = null;
            HttpContext.Current.Application.Remove(key);
        }

        /// <summary>
        ///     Retrieve employee object from session
        ///     Created By: Taufin Rusli
        ///     Created Date: 2012/01/25
        /// </summary>
        /// <returns>
        ///     Employee object
        /// </returns>
        public static Employee GetEmployee()
        {
            return (Employee)GetSession(employeeSessionKey);
        }

        /// <summary>
        ///     Get an employee object from the current employee inside the session using the same context
        /// </summary>
        /// <param name="employeeBroker"></param>
        /// <returns></returns>
        public static Employee GetEmployee(IEmployeeBroker employeeBroker)
        {
            if (GetEmployee() != null)
            {
                Employee employee = new Employee();
                employee.Id = GetEmployee().Id;
                return employeeBroker.GetEmployee(employee);
            }
            return null;
        }

        public static void SetEmployee(Employee employee)
        {
            PutSession(employeeSessionKey, employee);
        }

        public static int GetEmployeeRole()
        {
            return GetEmployee().Role.Id;
        }

        public static Employee ValidateUser()
        {
            Employee employee = GetEmployee();

            if (employee == null)
            {
                GoToPage(loginPage);
            }
            return employee;
        }

        public static Employee ValidateUser(Constants.EMPLOYEE_ROLE allowedRole)
        {
            Employee employee = ValidateUser();

            //if (!CheckPermission(allowedRole, GetRolePermission(Converter.objToEmployeeRole(employee.Role.Id))))
            if (!CheckPermission(Converter.objToEmployeeRole(employee.Role.Id), GetRolePermission(allowedRole)) && !(Converter.objToEmployeeRole(employee.Role.Id) == Constants.EMPLOYEE_ROLE.ADMIN))
            {
                commonController.LogOutControl logOutControl = new commonController.LogOutControl();
            }
            return employee;
        }

        public static List<Constants.EMPLOYEE_ROLE> GetRolePermission(Constants.EMPLOYEE_ROLE employeeType)
        {
            List<Constants.EMPLOYEE_ROLE> permission = new List<Constants.EMPLOYEE_ROLE>();

            // Department
            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.EMPLOYEE)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.EMPLOYEE);
                employeeType = Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE;
            }

            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE || employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE);
                employeeType = SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD;
            }

            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD || employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD);
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD);                
            }

            
            // end of Department

            // Store
            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_CLERK)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_CLERK);
                employeeType = Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR;
            }

            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR);
                employeeType = SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_MANAGER;
            }

            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_MANAGER || employeeType == Constants.EMPLOYEE_ROLE.ADMIN)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_MANAGER);
            }
            // end of Store

            return permission;
        }

        public static bool CheckPermission(Constants.EMPLOYEE_ROLE employeeType, List<Constants.EMPLOYEE_ROLE> permission)
        {
            return permission.Contains(employeeType);
        }

        public static Item GetItem(IItemBroker itemBroker, string itemDescription)
        {
            Item item = new Item();
            item.Description = itemDescription;
            
            item = itemBroker.GetItem(item); // need to add a method to return list of item in broker
            return item;
        }

        //CC
       

        public static DataTable GetItemTable(IItemBroker itemBroker, string itemDescription)
        {
            Item item = GetItem(itemBroker, itemDescription);

            DataTable dt = new DataTable();
            dt.Columns.Add("ItemNo");
            dt.Columns.Add("ItemDescription");

            DataRow dr;

            if (item != null)
            {
                dr = dt.NewRow();
                dr["ItemNo"] = item.Id;
                dr["ItemDescription"] = item.Description;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static DataTable GetItemListTable( string itemDescription)
        {
            return GetItemTable().Select("ItemDescription LIKE '" + itemDescription + "%'").CopyToDataTable();
        }

        private static DataTable allItem;
        public static DataTable GetItemTable()
        {
            if (allItem == null)
            {
                allItem = new DataTable();
                allItem.Columns.AddRange(new DataColumn[] { new DataColumn("ItemNo"), 
                                         new DataColumn("Category"), 
                                         new DataColumn("ItemDescription"),
                                         new DataColumn("ReorderLevel"),
                                         new DataColumn("ReorderQty"),
                                         new DataColumn("UnitOfMeasure") });
                DataRow dr;

                List<Item> itemList = (new ItemBroker(new InventoryEntities())).GetAllItem();

                foreach (Item item in itemList)
                {
                    dr = allItem.NewRow();
                    dr["ItemNo"] = item.Id;
                    dr["Category"] = Converter.GetItemCategoryText(Converter.objToItemCategory(item.ItemCategoryId));
                    dr["ItemDescription"] = item.Description;
                    dr["ReorderLevel"] = item.ReorderLevel;
                    dr["ReorderQty"] = item.ReorderQty;
                    dr["UnitOfMeasure"] = Converter.GetUnitOfMeasureText(Converter.objToUnitOfMeasure(item.UnitOfMeasureId));
                    allItem.Rows.Add(dr);
                }
            }
            
            return allItem.Copy();
        }

        private static DataTable employeeTable;
        public static DataTable GetEmployeeTable()
        {
            if (employeeTable == null)
            {
                employeeTable = new DataTable();
                employeeTable.Columns.AddRange(new DataColumn[]{ new DataColumn("EmployeeID"),
                                                                 new DataColumn("EmployeeName"),
                                                                new DataColumn("Designation"),
                                                                new DataColumn("JoiningDate"),
                                                                new DataColumn("DepartmentID")});

                DataRow dr;

                List<Employee> employeeList = (new EmployeeBroker(new InventoryEntities())).GetAllEmployee();

                foreach (Employee employee in employeeList)
                {
                    dr = employeeTable.NewRow();
                    dr["EmployeeID"] = employee.Id;
                    dr["EmployeeName"] = employee.Name;
                    dr["Designation"] = employee.Designation;
                    dr["JoiningDate"] = employee.CreatedDate;
                    dr["DepartmentID"] = employee.Department.Id;
                    employeeTable.Rows.Add(dr);
                }
            }

            return employeeTable.Copy();
        }

        public static void GoToPage(string page)
        {
            HttpContext.Current.Response.Redirect(page, true);
        }

        public static Constants.DB_STATUS Assign(IEmployeeBroker employeeBroker, int employeeId, Constants.EMPLOYEE_ROLE role)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            Employee employee = new Employee();
            employee.Id = employeeId;
            employee = employeeBroker.GetEmployee(employee);
            employee.Role.Id = Converter.objToInt(Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);

            status = employeeBroker.Update(employee);

            return status;
        }

        public static string SetAsLink(string linkText, string page, string attribute)
        {
            return "<a href='~/" + page + (attribute != String.Empty ? "?" + attribute : "") + "'>" + linkText + "</a>";
        }

        public static DataTable GetEmployeesByDepartments()
        {
            InventoryEntities inventory = new InventoryEntities();

            IEmployeeBroker employeeBroker = new EmployeeBroker(inventory);
            List<Employee> lEmployee = employeeBroker.GetEmployeeByDepartments(Util.GetEmployee());
            DataTable dtEmployee = new DataTable();
            dtEmployee.Columns.Add("employeeID");
            dtEmployee.Columns.Add("employeeName");
            foreach (Employee emp in lEmployee)
            {
                DataRow dr = dtEmployee.NewRow();
                dr[0] = emp.Id;
                dr[1] = emp.Name;
                dtEmployee.Rows.Add(dr);
            }
            return dtEmployee;
        }

        public static DataTable GetCurrentTemporaryRepresentative()
        {
            InventoryEntities inventory = new InventoryEntities();

            IEmployeeBroker employeeBroker = new EmployeeBroker(inventory);
            Employee lEmployee = employeeBroker.GetCurrentTempRep(Util.GetEmployee());
            DataTable dtEmployee = new DataTable();
            dtEmployee.Columns.Add("EmployeeID");
            dtEmployee.Columns.Add("EmployeeName");
            dtEmployee.Columns.Add("Designation");
            dtEmployee.Columns.Add("JoiningDate");
            //foreach (Employee emp in lEmployee)
            //{
                DataRow dr = dtEmployee.NewRow();
                dr[0] = lEmployee.Id;
                dr[1] = lEmployee.Name;
                dtEmployee.Rows.Add(dr);
            //}
            return dtEmployee;
        }

        public static DataTable GetCurrentRepresentative()
        {
            InventoryEntities inventory = new InventoryEntities();

            IEmployeeBroker employeeBroker = new EmployeeBroker(inventory);
            List<Employee> lEmployee = employeeBroker.GetRepresentative(Util.GetEmployee());
            DataTable dtEmployee = new DataTable();
            dtEmployee.Columns.Add("RepresentativeID");
            dtEmployee.Columns.Add("RepresentativeName");
            dtEmployee.Columns.Add("Actual/Temporary");
            foreach (Employee emp in lEmployee)
            {
                DataRow dr = dtEmployee.NewRow();
                dr[0] = emp.Id;
                dr[1] = emp.Name;
                dr[2] = emp.Role.Id == (int)Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE ? "Actual" : "Temporary";
                dtEmployee.Rows.Add(dr);
            }
            return dtEmployee;
        }

        public static DataTable GetCurrentTemporaryHead()
        {
            InventoryEntities inventory = new InventoryEntities();

            IEmployeeBroker employeeBroker = new EmployeeBroker(inventory);
            Employee lEmployee = employeeBroker.GetCurrentTemporaryDeptHead(Util.GetEmployee());
            DataTable dtEmployee = new DataTable();
            dtEmployee.Columns.Add("EmployeeID");
            dtEmployee.Columns.Add("EmployeeName");
            dtEmployee.Columns.Add("Designation");
            dtEmployee.Columns.Add("JoiningDate");
            //foreach (Employee emp in lEmployee)
            //{
                DataRow dr = dtEmployee.NewRow();
                dr[0] = lEmployee.Id;
                dr[1] = lEmployee.Name;
                dr[2] = lEmployee.Designation;
                dr[2] = lEmployee.CreatedDate;
                dtEmployee.Rows.Add(dr);
            //}
            return dtEmployee;
        }

        public static DataTable GetEmployeeDetails(string employeeName)
        {
            if (employeeTable == null)
            {
                employeeTable = GetEmployeeTable();
            }

            return employeeTable.Select("EmployeeName LIKE '" + employeeName + "%' AND DepartmentID = '"+GetEmployee().Department.Id+"'").CopyToDataTable();
            //DataTable dtEmployee = new DataTable();
            //dtEmployee.Columns.Add("EmployeeID");
            //dtEmployee.Columns.Add("EmployeeName");
            //dtEmployee.Columns.Add("Designation");
            //dtEmployee.Columns.Add("JoiningDate");
            //for (int i = 0; i < dr.Length; i++)
            //{
            //    DataRow dr = dtEmployee.NewRow();
            //    dr[0] = dr[0];
            //    dr[1] = dr[1];
            //    dr[2] = dr[2];
            //    dr[2] = dr[3];
            //    dtEmployee.Rows.Add(dr);
            //}
            //return dtEmployee;
        }
    }
}
