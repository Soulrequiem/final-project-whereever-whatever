using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemController.departmentController
{
    public class AssignTemporaryDepartmentRepresentativeControl
    {
        IEmployeeBroker employeeBroker = new EmployeeBroker();

        public Employee GetTemporaryDepartmentRepresentative()
        {
            List<Employee> employeeList = employeeBroker.GetAllEmployee();
            Employee e = null;
            foreach (Employee employee in employeeList)
            {
                if (employee.Role.Name.Equals("TemporaryDepartmentRepresentative"))
                {
                    e = employee;
                    break;
                }
            }
            return e;
        }

        public Constants.ACTION_STATUS SelectRemove(Employee employee)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            Role role = new Role();
            role.Name = "employee";
            Role resultRole = employeeBroker.GetRole(role);
            employee.Role = resultRole;
            Constants.DB_STATUS dbStatus = employeeBroker.Update(employee);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;
        }

        public Employee EnterEmployeeName(String employeeName)
        {
            Employee emp = new Employee();
            emp.Name = employeeName;
            Employee resultEmp = employeeBroker.GetEmployee(emp);
            return resultEmp;
        }

        public Constants.ACTION_STATUS SelectAssign(Employee employee)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            Role role = new Role();
            role.Name = " TemporaryDepartmentRepresentative";
            Role resultRole = employeeBroker.GetRole(role);
            employee.Role = resultRole;
            Constants.DB_STATUS dbStatus = employeeBroker.Update(employee);
            if (dbStatus == Constants.DB_STATUS.SUCCESSFULL)
                status = Constants.ACTION_STATUS.SUCCESS;
            else
                status = Constants.ACTION_STATUS.FAIL;
            return status;

        }
    }
}
