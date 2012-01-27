/***************************************************************************/
/*  File Name       : EmployeeBroker.cs
/*  Module Name     : Models
/*  Owner           : Thazin
/*  class Name      : EmployeeBroker
/*  Details         : Model Employee of Employee table
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemModel.broker
{
    public class EmployeeBroker : IEmployeeBroker
    {
        #region IEmployeeBroker Members
        //private InventoryEntities inventory = new InventoryEntities();
        private InventoryEntities inventory;
        private Employee empObj = null;
        private User userObj = null;
        private Role roleObj = null;
        private List<Employee> empList = null;
        private List<User> userList = null;
        private List<Role> roleList = null;

        public EmployeeBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        /// <summary>
        /// Retrieve the Employee from Employee Table according to the employee Parameter
        /// Return Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Employee GetEmployee(Employee employee)
        {

            empObj = inventory.Employees.Where(eObj => eObj.Name == employee.Name || eObj.Id == employee.Id).First();
            if (!empObj.Equals(null))
            {
                User userDetail = inventory.Users.Where(uObj => uObj.Id == empObj.User.Id).First();
                Role roleDetail = inventory.Roles.Where(rObj => rObj.Id == empObj.Role.Id).First();
                //empObj.User.Id = userDetail.Id;
                empObj.User = userDetail;
                empObj.Role = roleDetail;
                //empObj.Role.Id = roleDetail.Id;
                return empObj;
            }
            return null;
        }


        /// <summary>
        /// Retrieve All of the Employee information from Employee Table
        /// Return Employee Collection
        /// </summary>
        /// <returns></returns>
        
        public List<Employee> GetAllEmployee()
        {
            empList = inventory.Employees.ToList<Employee>();
            if (!roleList.Equals(null))
                return empList;
            return null;
        }

        /// <summary>
        ///  Insert Employee data to the Employee Table according to the newEmployee Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(Employee newEmployee)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {

                this.Insert(newEmployee.User);
                this.Insert(newEmployee.Role);
                inventory.AddToEmployees(newEmployee);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        /// <summary>
        /// Update Employee data to the employee Table according to the employee Parameter
        /// Return Constans.DB_STATUS
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Update(Employee employee)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                empObj = inventory.Employees.Where(eObj => eObj.Id == employee.Id).First();
                if (empObj != null)
                {
                    empObj.Name = employee.Name;
                    empObj.Email = employee.Email;
                    this.Update(empObj.User);
                    this.Update(empObj.Role);
                    inventory.SaveChanges();
                    status = Constants.DB_STATUS.SUCCESSFULL;
                }
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }
        /// <summary>
        ///  Logically delete the Employee table by setting the status to 2 in the Employee table
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(Employee employee)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                empObj = inventory.Employees.Where(eObj => eObj.Id == employee.Id).First();
                if (empObj != null)
                {
                    empObj.Status = 2;
                    empObj.Role.Status = 2;
                    empObj.User.Status = 2;
                    inventory.SaveChanges();
                    status = Constants.DB_STATUS.SUCCESSFULL;
                }
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }
        /// <summary>
        /// Retrieve the User information  from User Table according to the user Parameter
        /// Return User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User GetUser(User user)
        {
            userObj = inventory.Users.Where(uObj => uObj.Id == user.Id).First();
            if (!userObj.Equals(null))
                return userObj;
            return null;
        }
        /// <summary>
        /// Retrieve All of the User information from User Table
        /// Return User Collection
        /// </summary>
        /// <returns></returns>
        
        public List<User> GetAllUser()
        {
            userList = inventory.Users.ToList<User>();
            if (!userList.Equals(null))
                return userList;
            return null;
        }

        /// <summary>
        ///  Insert User data to the User Table according to the newUser Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Insert(User newUser)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToUsers(newUser);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        /// <summary>
        /// Update User data to the User Table according to the user Parameter
        /// Return Constans.DB_STATUS
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Update(User user)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                userObj = inventory.Users.Where(uObj => uObj.Id == user.Id).First();
                if (userObj != null)
                {
                    userObj.UserName = user.UserName;
                    userObj.Password = user.Password;
                    inventory.SaveChanges();
                    status = Constants.DB_STATUS.SUCCESSFULL;
                }
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        /// <summary>
        ///  Logically delete the User table by setting the status to 2 in the user table
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Delete(User user)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                userObj = inventory.Users.Where(uObj => uObj.Id == user.Id).First();
                if (userObj != null)
                {
                    userObj.Status = 2;
                    inventory.SaveChanges();
                    status = Constants.DB_STATUS.SUCCESSFULL;
                }
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }
        /// <summary>
        /// Retrieve the Role  information  from Role Table according to the role Parameter
        /// Return Role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public Role GetRole(Role role)
        {
            roleObj = inventory.Roles.Where(rObj => rObj.Id == role.Id).First();
            if (!roleObj.Equals(null))
                return roleObj;
            return null;
        }
        /// <summary>
        /// Retrieve All of the Role information from Role Table
        /// Return Role Collection
        /// </summary>
        /// <returns></returns>
        
        public List<Role> GetAllRole()
        {
            roleList = inventory.Roles.ToList<Role>();
            if (!roleList.Equals(null))
                return roleList;
            return null;
        }
        /// <summary>
        ///  Insert Role data to the Role Table according to the newRole Parameter
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(Role newRole)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToRoles(newRole);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        /// <summary>
        /// Update Role data to the Role Table according to the role Parameter
        /// Return Constans.DB_STATUS
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>

        public Constants.DB_STATUS Update(Role role)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                roleObj = inventory.Roles.Where(rObj => rObj.Id == role.Id).First();
                if (roleObj != null)
                {
                    roleObj.Name = role.Name;
                    inventory.SaveChanges();
                    status = Constants.DB_STATUS.SUCCESSFULL;
                }
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        /// <summary>
        ///  Logically delete the Role table by setting the status to 2 in the Role table
        ///  Return Constants.DB_STATUS
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(Role role)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                roleObj = inventory.Roles.Where(rObj => rObj.Id == role.Id).First();
                if (roleObj != null)
                {
                    roleObj.Status = 2;
                    inventory.SaveChanges();
                    status = Constants.DB_STATUS.SUCCESSFULL;
                }
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }
            return status;
        }

        #endregion
    }
}

/****************************************/
/********* End of the Class *****************/
/****************************************/
