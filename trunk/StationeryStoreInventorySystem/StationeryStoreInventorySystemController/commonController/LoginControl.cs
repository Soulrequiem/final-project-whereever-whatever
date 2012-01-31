using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemModel.brokerinterface;

namespace StationeryStoreInventorySystemController.commonController
{
    public class LoginControl
    {
        private IEmployeeBroker employeeBroker;

        public LoginControl()
        {
            InventoryEntities inventory = new InventoryEntities();
            
            employeeBroker = new EmployeeBroker(inventory);
        }

        public Constants.ACTION_STATUS SelectLogin(string username, string password)
        {
            Constants.ACTION_STATUS isLogin = Constants.ACTION_STATUS.UNKNOWN;

            User user = new User();
            user.UserName = username;
            user.Password = password;
            user = employeeBroker.GetUser(user); // get user object
            
            // if user is null means username and password is incorrect
            if (user != null)
            {
                Employee employee = new Employee();
                employee.User = user;
                employee = employeeBroker.GetEmployee(employee);

                Util.PutSession(Util.employeeSessionKey, employee); // put employee object to session for validating user later
                Util.PutSession("Uname", employee.Name);

                isLogin = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                isLogin = Constants.ACTION_STATUS.FAIL;
            }
            return isLogin;
        }
    }
}
