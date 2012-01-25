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
        Employee GetEmployee(Employee employee);
        List<Employee> GetAllEmployee();
        Constants.DB_STATUS Insert(Employee newEmployee);
        Constants.DB_STATUS Update(Employee employee);
        Constants.DB_STATUS Delete(Employee employee);

        User GetUser(User user);
        List<User> GetAllUser();
        Constants.DB_STATUS Insert(User newUser);
        Constants.DB_STATUS Update(User user);
        Constants.DB_STATUS Delete(User user);

        Role GetRole(Role role);
        List<Role> GetAllRole();
        Constants.DB_STATUS Insert(Role newRole);
        Constants.DB_STATUS Update(Role role);
        Constants.DB_STATUS Delete(Role role);
    }
}
