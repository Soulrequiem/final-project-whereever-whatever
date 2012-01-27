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
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class AssignTemporaryDepartmentHeadControl
    {
        IEmployeeBroker employeeBroker;
        Employee currentEmployee;
        Employee temporaryDepartmentHead;
        /// <summary>
        ///     To show the Current Temporary Department Head
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
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD);
            
            employeeBroker = new EmployeeBroker();

            temporaryDepartmentHead = new Employee();
            temporaryDepartmentHead.Role = new Role();
            temporaryDepartmentHead.Role.Id = Converter.objToInt(Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD);
            temporaryDepartmentHead.Department = currentEmployee.Department;

            temporaryDepartmentHead = employeeBroker.GetEmployee(temporaryDepartmentHead);
        }

        public DataTable TemporaryDepartmentHead
        {
            get
            {
                DataTable dt = new DataTable();
                
                if (temporaryDepartmentHead != null)
                {
                    DataRow dr = new DataRow();

                    dt.NewRow();
                    dr["employeeId"] = temporaryDepartmentHead.Id;
                    dr["employeeName"] = temporaryDepartmentHead.Name;
                    //dr["designation"] = Converter.GetDesignationText(Converter.objToDesignation(temporaryDepartmentHead.Designation));
                    dr["joiningDate"] = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, temporaryDepartmentHead.CreatedDate);
                    dt.Rows.Add(dr);
                }

                return dt;
            }
        }

        //public Employee GetTemporaryDepartmentHead()
        //{
        //    List<Employee> employeeList = employeeBroker.GetAllEmployee();
        //    Employee e = null;
        //    foreach (Employee employee in employeeList)
        //    {
        //        if (employee.Role.Name.Equals("TemporaryDepartmentHead"))
        //        {
        //            e = employee;
        //            break;
        //        }
        //    }
        //    return e;
        //}

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
        /// <param name="employeeId"> Selected Employee Id from UI</param>
        /// <returns>Return the status of remove  whether Successful or Fail. </returns>
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
        public DataTable SelectEmployeeName(string employeeName)
        {
            Employee emp = new Employee();
            emp.Name = employeeName;
            emp = employeeBroker.GetEmployee(emp);

            DataTable dt = new DataTable();

            if (emp != null)
            {
                DataRow dr = new DataRow();

                dt.NewRow();
                dr["employeeId"] = emp.Id;
                dr["employeeName"] = emp.Name;
                //dr["designation"] = Converter.GetDesignationText(Converter.objToDesignation(emp.Designation));
                dr["joiningDate"] = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, emp.CreatedDate);
                dt.Rows.Add(dr);
            }

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
        /// <param name="employeeId"> To update the selected employeeId</param>
        /// <returns>Return the status of assign  whether Successful or Fail. </returns>

        public Constants.ACTION_STATUS SelectAssign(int employeeId)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            
            if (Util.Assign(employeeBroker, employeeId, Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD) == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;

        }

    }
}
