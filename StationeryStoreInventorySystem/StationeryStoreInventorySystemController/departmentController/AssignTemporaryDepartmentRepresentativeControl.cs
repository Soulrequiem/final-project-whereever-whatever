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
        IEmployeeBroker employeeBroker;
        Employee currentEmployee;
        Employee temporaryDepartmentRepresentative;

        public AssignTemporaryDepartmentRepresentativeControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE);

            employeeBroker = new EmployeeBroker();

            temporaryDepartmentRepresentative = new Employee();
            temporaryDepartmentRepresentative.Role = new Role();
            temporaryDepartmentRepresentative.Role.Id = Converter.objToInt(Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE);
            temporaryDepartmentRepresentative.Department = currentEmployee.Department;

            temporaryDepartmentRepresentative = employeeBroker.GetEmployee(temporaryDepartmentRepresentative);
        }

        public DataTable TemporaryDepartmentRepresentative()
        {
            DataTable dt = new DataTable();

            if (temporaryDepartmentRepresentative != null)
            {
                DataRow dr = new DataRow();

                dt.NewRow();
                dr["employeeId"] = temporaryDepartmentRepresentative.Id;
                dr["employeeName"] = temporaryDepartmentRepresentative.Name;
                //dr["designation"] = Converter.GetDesignationText(Converter.objToDesignation(temporaryDepartmentHead.Designation));
                dr["joiningDate"] = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, temporaryDepartmentRepresentative.CreatedDate);
                dt.Rows.Add(dr);
            }

            return dt;
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

        public Constants.ACTION_STATUS SelectRemove(int employeeId)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            
            if (Util.Assign(employeeBroker, employeeId, Constants.EMPLOYEE_ROLE.EMPLOYEE) == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }

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
