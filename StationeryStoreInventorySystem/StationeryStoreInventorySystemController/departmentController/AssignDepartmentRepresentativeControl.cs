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
    public class AssignDepartmentRepresentativeControl
    {
        private IEmployeeBroker employeeBroker;
        private Employee currentEmployee;
        private Employee departmentRepresentative;
        private Employee temporaryDepartmentRepresentative;
        
        public AssignDepartmentRepresentativeControl()
        {
            currentEmployee = Util.ValidateUser(Constants.EMPLOYEE_ROLE.DEPARTMENT_HEAD);
            departmentRepresentative = currentEmployee.Department.Employee2;
            
            employeeBroker = new EmployeeBroker();

            temporaryDepartmentRepresentative = new Employee();
            temporaryDepartmentRepresentative.Role = new Role();
            temporaryDepartmentRepresentative.Role.Id = Converter.objToInt(Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE);
            temporaryDepartmentRepresentative.Department = currentEmployee.Department;

            temporaryDepartmentRepresentative = employeeBroker.GetEmployee(temporaryDepartmentRepresentative);
        }

        public DataTable DepartmentRepresentative
        {
            get 
            {
                DataTable dt = new DataTable();
                DataRow dr;

                if (departmentRepresentative != null)
                {
                    dr = new DataRow();

                    dt.NewRow();
                    dr["representativeId"] = departmentRepresentative.Id;
                    dr["reprensentativeName"] = departmentRepresentative.Name;
                    dr["actual/temporary"] = "Actual";
                    dt.Rows.Add(dr);
                }

                if (temporaryDepartmentRepresentative != null)
                {
                    dr  = new DataRow();

                    dt.NewRow();
                    dr["representativeId"] = temporaryDepartmentRepresentative.Id;
                    dr["reprensentativeName"] = temporaryDepartmentRepresentative.Name;
                    dr["actual/temporary"] = "Temporary";
                    dt.Rows.Add(dr);
                }

                return dt; 
            }
        }

        //public Employee TemporaryRepresentative
        //{
        //    get { return temporaryRepresentative; }
        //}

        //public Employee GetRepresentative()
        //{
        //    List<Employee> employeeList = employeeBroker.GetAllEmployee();
        //    Employee e = null;
        //    foreach(Employee employee in employeeList){
        //        if(employee.Role.Name.Equals("Representative")){
        //            e = employee;
        //            break;
        //        }
        //    }
        //    return e;
        // }

        //public Employee GetEmployee(Constants.EMPLOYEE_ROLE employeeRole)
        //{
        //    List<Employee> employeeList = employeeBroker.GetAllEmployee();
        //    Employee e = null;
        //    foreach (Employee employee in employeeList)
        //    {
        //        if (employee.Role.Name.Equals("Representative"))
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
                dr["employeeID"] = emp.Id;
                dr["employeeName"] = emp.Name;
                dt.Rows.Add(dr);
            }

            return dt;
        }

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
