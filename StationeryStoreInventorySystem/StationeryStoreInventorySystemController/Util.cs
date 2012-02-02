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

            if (!CheckPermission(allowedRole, GetRolePermission(Converter.objToEmployeeRole(employee.Role.Id))))
            {
                commonController.LogOutControl logOutControl = new commonController.LogOutControl();
            }
            return employee;
        }

        public static List<Constants.EMPLOYEE_ROLE> GetRolePermission(Constants.EMPLOYEE_ROLE employeeType)
        {
            List<Constants.EMPLOYEE_ROLE> permission = new List<Constants.EMPLOYEE_ROLE>();

            // Department
            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.EMPLOYEE || employeeType == Constants.EMPLOYEE_ROLE.ADMIN)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.EMPLOYEE);
                employeeType = employeeType != Constants.EMPLOYEE_ROLE.ADMIN ? Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE : employeeType;
            }

            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE || employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE || employeeType == Constants.EMPLOYEE_ROLE.ADMIN)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE);
                employeeType = employeeType != Constants.EMPLOYEE_ROLE.ADMIN ? SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD : employeeType;
            }

            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD || employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD || employeeType == Constants.EMPLOYEE_ROLE.ADMIN)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD);
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD);                
            }

            
            // end of Department

            // Store
            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_CLERK || employeeType == Constants.EMPLOYEE_ROLE.ADMIN)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_CLERK);
                employeeType = employeeType != Constants.EMPLOYEE_ROLE.ADMIN ? Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR : employeeType;
            }

            if (employeeType == SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR || employeeType == Constants.EMPLOYEE_ROLE.ADMIN)
            {
                permission.Add(SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_SUPERVISOR);
                employeeType = employeeType != Constants.EMPLOYEE_ROLE.ADMIN ? SystemStoreInventorySystemUtil.Constants.EMPLOYEE_ROLE.STORE_MANAGER : employeeType;
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

        public static DataTable GetItemListTable(IItemBroker itemBroker, string itemDescription)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("ItemNo"), 
                                                   new DataColumn("Category"), 
                                                   new DataColumn("ItemDescription"),
                                                   new DataColumn("ReorderLevel"),
                                                   new DataColumn("ReorderQty"),
                                                   new DataColumn("UnitOfMeasure") });
            DataRow dr;

            Item it = new Item();
            it.Description = itemDescription;
            it = itemBroker.GetItem(it);

            List<Item> itemList = (new ItemBroker(new InventoryEntities())).GetItemReference(it);

            foreach (Item item in itemList)
            {
                dr = dt.NewRow();
                dr["ItemNo"] = item.Id;
                dr["Category"] = Converter.GetItemCategoryText(Converter.objToItemCategory(item.ItemCategoryId));
                dr["ItemDescription"] = item.Description;
                dr["ReorderLevel"] = item.ReorderLevel;
                dr["ReorderQty"] = item.ReorderQty;
                dr["UnitOfMeasure"] = Converter.GetUnitOfMeasureText(Converter.objToUnitOfMeasure(item.UnitOfMeasureId));
                dt.Rows.Add(dr);
            }


            return dt;
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
            
            return allItem;
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
    }
}
