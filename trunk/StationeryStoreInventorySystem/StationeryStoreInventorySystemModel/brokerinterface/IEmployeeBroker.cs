using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IEmployeeBroker
    {
        int GetEmployeeId();
        Employee GetEmployee(Employee employee);
        List<Employee> GetAllEmployee();
        Constants.DB_STATUS Insert(Employee newEmployee,Boolean isSaved);
        Constants.DB_STATUS Update(Boolean isSaved);
        Constants.DB_STATUS Delete(Employee employee,Boolean isSaved);
        List<Employee> GetEmployeeName(Employee employee);

        User GetUser(User user);
        List<User> GetAllUser();
        Constants.DB_STATUS Insert(User newUser,Boolean isSaved);
        Constants.DB_STATUS Update(Boolean isSaved);
        Constants.DB_STATUS Delete(User user,Boolean isSaved);

        Role GetRole(Role role);
        List<Role> GetAllRole();
        Constants.DB_STATUS Insert(Role newRole,Boolean isSaved);
        Constants.DB_STATUS Update(Boolean isSaved);
        Constants.DB_STATUS Delete(Role role,Boolean isSaved);
    }
}
