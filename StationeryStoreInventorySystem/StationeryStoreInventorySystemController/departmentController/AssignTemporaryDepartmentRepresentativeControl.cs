/***************************************************************************/
/*  File Name       : AssignTemporaryDepartmentRepresentativeControl.cs
/*  Module Name     : Controller
/*  Owner           : SanLaPyaye
/*  class Name      : AssignTemporaryDepartmentRepresentativeControl
/*  Details         : Controller representation of AssignTemporaryDepartmentRepresentativeControl
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class AssignTemporaryDepartmentRepresentativeControl
    {
        private IEmployeeBroker employeeBroker;

        private Employee currentEmployee;
        private Employee temporaryDepartmentRepresentative;

        private DataTable dt;
        private DataRow dr;

        /// <summary>
        ///     To get all the Employee with role name as "Temporary Department Representative"
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        public AssignTemporaryDepartmentRepresentativeControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);
            InventoryEntities inventory = new InventoryEntities();

            employeeBroker = new EmployeeBroker(inventory);

            temporaryDepartmentRepresentative = new Employee();
            temporaryDepartmentRepresentative.Role = new Role();
            temporaryDepartmentRepresentative.Role.Id = Converter.objToInt(Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE);
            temporaryDepartmentRepresentative.Department = currentEmployee.Department;

            temporaryDepartmentRepresentative = employeeBroker.GetEmployee(temporaryDepartmentRepresentative);
        }

        public DataTable TemporaryDepartmentRepresentative
        {
            get
            {
               dt = new DataTable();

                if (temporaryDepartmentRepresentative != null)
                {
                    dr = dt.NewRow();
                    dr["employeeId"] = temporaryDepartmentRepresentative.Id;
                    dr["employeeName"] = temporaryDepartmentRepresentative.Name;
                    //dr["designation"] = Converter.GetDesignationText(Converter.objToDesignation(temporaryDepartmentHead.Designation));
                    dr["joiningDate"] = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, temporaryDepartmentRepresentative.CreatedDate);
                    dt.Rows.Add(dr);
                }

                return dt;
            }
        }

        //public Employee GetTemporaryDepartmentRepresentative()
        //{
        //    List<Employee> employeeList = employeeBroker.GetAllEmployee();
        //    Employee e = null;
        //    foreach (Employee employee in employeeList)
        //    {
        //        if (employee.Role.Name.Equals("TemporaryDepartmentRepresentative"))
        //        {
        //            e = employee;
        //            break;
        //        }
        //    }
        //    return e;
        //}

        /// <summary>
        ///     The usage of this method is to remove the selected Employee
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="employeeId"> Employee Id which selected from UI.</param>
        /// <returns>Return the Employee list to show</returns>
        public Constants.ACTION_STATUS SelectRemove(int employeeId)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            
            if (Util.Assign(employeeBroker, employeeId, Constants.EMPLOYEE_ROLE.EMPLOYEE) == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }

        /// <summary>
        ///     The usage of this method is to search the Employee by EmployeeName
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="employeeName"> Employee Name which enter from UI.</param>
        /// <returns>Return the Employee to show.</returns>
        public DataTable SelectEmployeeName(string employeeName)
        {
            Employee emp = new Employee();
            emp.Name = employeeName;
            emp = employeeBroker.GetEmployee(emp);

            dt = new DataTable();

            if (emp != null)
            {
                dr = dt.NewRow();
                dr["employeeId"] = emp.Id;
                dr["employeeName"] = emp.Name;
                //dr["designation"] = Converter.GetDesignationText(Converter.objToDesignation(emp.Designation));
                dr["joiningDate"] = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, emp.CreatedDate);
                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        ///     The usage of this method is to assign the selected Employee as a "Temporary Department Head"
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="employeeId"> Employee Id which selected from UI</param>
        /// <returns>Return the Employee list to show</returns>
        public Constants.ACTION_STATUS SelectAssign(int employeeId)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            
            if (Util.Assign(employeeBroker, employeeId, Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE) == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;

        }
    }
}
