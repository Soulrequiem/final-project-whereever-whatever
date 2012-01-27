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
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using System.Data;


namespace StationeryStoreInventorySystemController.departmentController
{
    class AssignTemporaryDepartmentRepresentativeControl
    {
        DataTable dt;
        DataRow dr;

        EmployeeBroker employeeBroker;
        public AssignTemporaryDepartmentRepresentativeControl()
        {
 
        }

        /// <summary>
        ///     The usage of this method is to get all the Employee with role name "Temporary Department Representative"
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        
        public DataTable GetEmployee()
        {
            //Employee emp=null;
           employeeBroker=new EmployeeBroker();
            List<Employee> employeeList=employeeBroker.GetAllEmployee();
            foreach(Employee e in employeeList)
            {
                if(e.Role.Name.Equals("Temporary Department Representative"))
                {
                    dt.NewRow();
                    dr=null;
                    dr["employeeId"]=e.Id;
                    dr["employeeName"]=e.Name;
                    //dr["designation"]=e.Designation;

                    dt.Rows.Add(dr);
                    
                }
            }

            return dt;
        }

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
        /// <param name="employee"> Employee which select from UI.</param>
        /// <returns>Return the Employee list to show</returns>
        public DataTable SelectRemove(Employee employee)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            Role role = new Role();
            role.Name = "Employee";

            Constants.DB_STATUS dbStatus = employeeBroker.Update(employee);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
            {
                status = Constants.ACTION_STATUS.SUCCESS;
            }

            else
                status = Constants.ACTION_STATUS.FAIL;

            //return status;
            return GetEmployee();
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
        /// <param name="employee"> Employee Name which enter from UI.</param>
        /// <returns>Return the Employee to show.</returns>
        public DataTable EnterEmployeeName(string employeeName)
        {
            dt = new DataTable();
            dr = null;

            Employee emp = null;
            Employee employee = new Employee();
            employee.Name = employeeName;
            emp = employeeBroker.GetEmployee(employee);

            dt.NewRow();
            dr = new DataRow();
            dr["employeeId"] = emp.Id;
            dr["employeeName"] = emp.Name;
            dr["designation"] = emp.Role.Name;
            dr["joiningDate"] = emp.CreatedDate;
            dt.Rows.Add(dr);

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
        /// <param name="employee"> Employee Name which enter from UI</param>
        /// <returns>Return the Employee list to show</returns>
        public DataTable SelectAssign(string remarks)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            Employee employee = new Employee();
            employee.Role.Name = "Temporary Department Head";
           // employee. = remarks; //There is no field in database to store remarks.
            Constants.DB_STATUS dbStatus = employeeBroker.Update(employee);

            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;

            //return status;
            return GetEmployee();
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/