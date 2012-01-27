/***************************************************************************/
/*  File Name       : AssignTemporaryDepartmentHeadControl.cs
/*  Module Name     : Controller
/*  Owner           : SanLaPyaye
/*  class Name      : AssignTemporaryDepartmentHeadControl
/*  Details         : Controller representation of AssignTemporaryDepartmentHeadControl
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
    class AssignTemporaryDepartmentHeadControl
    {
        EmployeeBroker employeeBroker = new EmployeeBroker();
        DataTable dt;
        DataRow dr;

        /// <summary>
        ///     The usage of this method to call GetHead() for show the Current Temporary Department Head
        ///     Created By: SanLaPyaye
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        
        public AssignTemporaryDepartmentHeadControl()
        {
        }

        /// <summary>
        ///     The usage of this method is to show the Current Temporary Department Head.
        ///     Created By: SanLaPyaye
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <returns>Return Employee status with "Temporary Department Head"</returns>
        public DataTable GetHead()
        {
            dt = new DataTable();
            dr = null;

            //Employee emp = null;
            List<Employee> empList = employeeBroker.GetAllEmployee();
            foreach(Employee employee in empList )
            {
                if (employee.Role.Name.Equals("Temporary Department Head"))
                {
                    dt.NewRow();
                    dr = new DataRow();
                    dr["employeeId"] = employee.Id;
                    dr["employeeName"] = employee.Name;
                    dr["designation"] = employee.Designation;
                    dr["joiningDate"] = employee.CreatedDate;
                    dt.Rows.Add(dr);
                    //emp = employee;
                    //break;
                }

            }
                 
            return dt;         

        }

        /// <summary>
        ///     The usage of this method is to remove the selected Current Temporary Department Head
        ///     Created By: SanLaPyaye
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="employee"> Selected Employee from the UI</param>
        /// <returns>Return the status of remove  whether Successful or Fail. </returns>
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
            return GetHead();
        }


        /// <summary>
        ///     The usage of this method is to search the Employee by enter the Employee Name
        ///     Created By: SanLaPyaye
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="employeeName"> Employee name which type from UI.</param>
        /// <returns>Return the Employee which search by employee name.</returns>
        public DataTable EnterEmployeeName(string employeeName)
        {
            dt = new DataTable();
            dr = null;
            
            Employee emp = null;
            Employee employee = new Employee();
            employee.Name = employeeName;
            emp= employeeBroker.GetEmployee(employee);

            dt.NewRow();
            dr = new DataRow();
            dr["employeeId"] = emp.Id;
            dr["employeeName"] = emp.Name;
            dr["designation"] = emp.Designation;
            dr["joiningDate"] = emp.CreatedDate;
            dt.Rows.Add(dr);

            return dt;         
                        
        }


        /// <summary>
        ///     The usage of this method is to assign the selected Department Head from Search Result
        ///     Created By: SanLaPyaye
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="remarks"> Remark to update the employee.</param>
        /// <returns>Return the status of assign  whether Successful or Fail. </returns>
        public DataTable SelectAssign(string remarks)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            Employee employee=new Employee();
            employee.Role.Name="Temporary Department Head";
            // employee. = remarks; //There is no field in database to store remarks.
            Constants.DB_STATUS dbStatus= employeeBroker.Update(employee);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;

            //return status;
            return GetHead();
        }

        
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
