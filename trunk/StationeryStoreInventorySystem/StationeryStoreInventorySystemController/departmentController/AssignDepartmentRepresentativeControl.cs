/***************************************************************************/
/*  File Name       : AssignDepartmentRepresentativeControl.cs
/*  Module Name     : Controller
/*  Owner           : SanLaPyaye
/*  class Name      : AssignDepartmentRepresentativeControl
/*  Details         : Controller representation of AssignDepartmentRepresentativeControl
/***************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    class AssignDepartmentRepresentativeControl
    {
        DataTable dt;
        DataRow dr;
        EmployeeBroker employeeBroker=new EmployeeBroker();

        /// <summary>
        ///     The usage of this method to call GetEmployee() for show the Current Department Representative
        ///     Created By: SanLaPyaye
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        public AssignDepartmentRepresentativeControl()
        {
            GetEmployee();

        }

        /// <summary>
        ///     The usage of this method is to show the Current Department Representative
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <returns>Return Employee status with "Department Representative" or "Temporary Department Representative" </returns>
        public DataTable GetEmployee()
        {
            dt = new DataTable();
            dr = null;

            string positionStatus = null;
            //List<Employee> emp=null;
            List<Employee> empList=employeeBroker.GetAllEmployee();
                       foreach (Employee employee in empList)
            {
                if(employee.Role.Name.Equals("Department Representative") || employee.Role.Name.Equals("Temporary Department Representative"))
                {
                    Employee e=new Employee();
                    
                    if (employee.Role.Name.Equals("Department Representative"))
                    {
                        e=employee;
                        positionStatus="Actual"; 
                    }
                    else if(employee.Role.Name.Equals("Temporary Department Representative"))
                    {
                        e=employee;
                        positionStatus = "Temporary";
                    }
                    //emp.Add(e);

                    dt.NewRow();
                    dr["representativeId"] = e.Id;
                    dr["representativeName"] = e.Name;
                    dr["actual/Temporary"] = positionStatus;
                    dt.Rows.Add(dr);
                }

            }
                                   
            //return emp;
                       return dt;
        }


        /// <summary>
        ///     The usage of this method is to remove the selected Actual Department Representative
        ///     Created By: SanLaPyaye 
        ///     Created Date: 25/01/2012
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        ///     Modified By:
        ///     Modified Date:
        ///     Modification Reason:
        /// </summary>
        /// <param name="employeeID"> Selected Employee ID from the UI</param>
        /// <returns>Return the status of remove  whether Successful or Fail. </returns>
        public Constants.ACTION_STATUS SelectRemove(int employeeID)
        {
            Constants.ACTION_STATUS status=Constants.ACTION_STATUS.UNKNOWN;
            Employee emp=new Employee();
            emp.Id=employeeID;
            emp.Role.Name="Employee";

            Constants.DB_STATUS dbStatus =employeeBroker.Update(emp);
            
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
            {
                status = Constants.ACTION_STATUS.SUCCESS;
            }

            else
                status = Constants.ACTION_STATUS.FAIL;

            return status;
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
             Employee employee = new Employee();
            employee.Name = employeeName;
            Employee e= employeeBroker.GetEmployee(employee);

            dt = new DataTable();
            dr = null;
            dt.NewRow();
            dr["employeeId"] = e.Id;
            dr["employeeName"] = e.Name;

            dt.Rows.Add(dr);

            return dt;
                        
        }


         /// <summary>
         ///     The usage of this method is to assign the Department Representative from Search Result
        ///     Created By: SanLaPyaye 
         ///     Created Date: 25/01/2012
         ///     Modified By:
         ///     Modified Date:
         ///     Modification Reason:
         ///     Modified By:
         ///     Modified Date:
         ///     Modification Reason:
         /// </summary>
        /// <returns>Return the status of assign  whether Successful or Fail. </returns>
        public DataTable SelectAssign()
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            Employee employee=new Employee();
            employee.Role.Name="Department Representative";
            Constants.DB_STATUS dbStatus= employeeBroker.Update(employee);
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