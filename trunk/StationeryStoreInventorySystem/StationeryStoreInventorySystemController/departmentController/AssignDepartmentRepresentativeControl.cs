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
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using System.Data;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class AssignDepartmentRepresentativeControl
    {
        private IEmployeeBroker employeeBroker;

        private Employee currentEmployee;
        private Employee departmentRepresentative;
        private Employee temporaryDepartmentRepresentative;

        private DataTable dt;
        private DataRow dr;

        private string[] columnName = { "RepresentativeID", "RepresentativeName", "Actual/Temporary" };
        private string[] employeeColumnName = { "EmployeeID", "EmployeeName" };

        private DataColumn[] dataColumn;
        private DataColumn[] employeeDataColumn;

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
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD);
            InventoryEntities inventory = new InventoryEntities();

            employeeBroker = new EmployeeBroker(inventory);

            departmentRepresentative = currentEmployee.Department.Representative;

            temporaryDepartmentRepresentative = new Employee();
            temporaryDepartmentRepresentative.Role = new Role();
            temporaryDepartmentRepresentative.Role.Id = Converter.objToInt(Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE);
            temporaryDepartmentRepresentative.Department = currentEmployee.Department;

            temporaryDepartmentRepresentative = employeeBroker.GetEmployee(temporaryDepartmentRepresentative);

            dataColumn = new DataColumn[] { new DataColumn(columnName[0]),
                                            new DataColumn(columnName[1]),
                                            new DataColumn(columnName[2]) };

            employeeDataColumn = new DataColumn[] { new DataColumn(employeeColumnName[0]),
                                                    new DataColumn(employeeColumnName[1]) };
        }

        public DataTable DepartmentRepresentative
        {
            get
            {
                dt = new DataTable();
                dt.Columns.AddRange(dataColumn);
                
                if (departmentRepresentative != null)
                {
                    dr = dt.NewRow();
                    dr[columnName[0]] = departmentRepresentative.Id;
                    dr[columnName[1]] = departmentRepresentative.Name;
                    dr[columnName[2]] = "Actual";
                    dt.Rows.Add(dr);
                }

                if (temporaryDepartmentRepresentative != null)
                {
                    dr = dt.NewRow();
                    dr[columnName[0]] = temporaryDepartmentRepresentative.Id;
                    dr[columnName[1]] = temporaryDepartmentRepresentative.Name;
                    dr[columnName[2]] = "Temporary";
                    dt.Rows.Add(dr);
                }

                return dt;
            }
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
        /// <parm>employee Name to search the Employee</parm>
        /// <returns>Return the Data Table of Employee  </returns>
        public DataTable SelectEmployeeName(string employeeName)
        {
            Employee emp = new Employee();
            emp.Name = employeeName;
            emp = employeeBroker.GetEmployee(emp);

            dt = new DataTable();
            dt.Columns.AddRange(employeeDataColumn);

            if (emp != null)
            {
                dr = dt.NewRow();
                dr[employeeColumnName[0]] = emp.Id;
                dr[employeeColumnName[1]] = emp.Name;
                dt.Rows.Add(dr);
            }

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
        public Constants.ACTION_STATUS SelectAssign(int employeeId)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            if (Util.Assign(employeeBroker, employeeId, Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE) == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;

        }
    }
}

/****************************************/
/********* End of the Class *****************/
/****************************************/