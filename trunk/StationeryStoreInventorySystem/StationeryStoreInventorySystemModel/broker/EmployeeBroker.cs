using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.entity;
namespace StationeryStoreInventorySystemModel.broker
{
    using StationeryStoreInventorySystemModel.entity;

    public class EmployeeBroker : brokerinterface.IEmployeeBroker
    {

        #region IEmployeeBroker Members
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
        /// Get the last record of the employee table
        /// </summary>
        /// <returns></returns>
        public int GetEmployeeId()
        {

            var maxEmployeeId = inventory.Employees.Max(xObj => xObj.Id) + 1;
            return maxEmployeeId;

        }

        /// <summary>
        /// Retrieve the Employee data from Employee,User and Role Table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Employee GetEmployee(Employee employee)
        {

            empObj = inventory.Employees.Where(eObj => eObj.Name == employee.Name || eObj.Id == employee.Id).First();

            // if (!empObj.Equals(null) && empObj.CreatedBy != employee.Id)
            if (!empObj.Equals(null))
            {
                User userDetail = inventory.Users.Where(uObj => uObj.Id == empObj.User.Id).First();
                Role roleDetail = inventory.Roles.Where(rObj => rObj.Id == empObj.Role.Id).First();
                empObj.User = userDetail;
                empObj.Role = roleDetail;

                return empObj;
            }
            return null;
        }
        /// <summary>
        /// Get all of the Employee record from Employee table
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
        /// Insert the employee infomation to the Employee table
        /// return the Constants.DB_STATUS
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(Employee newEmployee)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {

                //this.Insert(newEmployee.User);
                //this.Insert(newEmployee.Role);
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
        /// Update the Employee information to employee table
        /// Return Constants.DB_STATUS
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(Employee employee)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                empObj = inventory.Employees.Where(eObj => eObj.Id == employee.Id).First();
                User userId = inventory.Users.Where(u => u.Id == empObj.User.Id).First();
                Role roleId = inventory.Roles.Where(r => r.Id == empObj.Role.Id).First();
                Department deptId = inventory.Departments.Where(d => d.Id == empObj.Department.Id).First();
                Employee createdBy = inventory.Employees.Where(e => e.Id == empObj.CreatedBy.Id).First();
                if (empObj != null)
                {
                    empObj.Id = employee.Id;
                    empObj.User = userId;
                    empObj.Role = roleId;
                    empObj.Department = deptId;
                    empObj.Name = employee.Name;
                    empObj.Designation = employee.Designation;
                    empObj.Email = employee.Email;
                    empObj.CreatedDate = employee.CreatedDate;
                    empObj.CreatedBy = createdBy;
                    //this.Update(empObj.User);
                    //this.Update(empObj.Role);
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
        /// Logically delete to the status of Employee table
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
        /// Get Employee Name According to the Employee Name
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeName(Employee employee)
        {

            List<Employee> empObj = inventory.Employees.Where(r => r.Name.Contains(employee.Name)).ToList();

            return empObj;

        }
        /// <summary>
        /// Get user data of ther User table according to the User parameter
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

        public List<User> GetAllUser()
        {
            userList = inventory.Users.ToList<User>();
            if (!userList.Equals(null))
                return userList;
            return null;
        }

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

        public Constants.DB_STATUS Update(User user)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                userObj = inventory.Users.Where(uObj => uObj.Id == user.Id).First();
                if (userObj != null)
                {
                    userObj.Id = user.Id;
                    userObj.UserName = user.UserName;
                    userObj.Password = user.Password;
                    userObj.CreatedDate = user.CreatedDate;
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

        public Role GetRole(Role role)
        {
            roleObj = inventory.Roles.Where(rObj => rObj.Id == role.Id).First();
            if (!roleObj.Equals(null))
                return roleObj;
            return null;
        }

        public List<Role> GetAllRole()
        {
            roleList = inventory.Roles.ToList<Role>();
            if (!roleList.Equals(null))
                return roleList;
            return null;
        }

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

        public Constants.DB_STATUS Update(Role role)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                roleObj = inventory.Roles.Where(rObj => rObj.Id == role.Id).First();
                Employee createdBy = inventory.Employees.Where(e => e.Id == roleObj.CreatedBy.Id).First();
                if (roleObj != null)
                {
                    roleObj.Id = role.Id;
                    roleObj.Name = role.Name;
                    roleObj.CreatedDate = role.CreatedDate;
                    roleObj.CreatedBy = createdBy;
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

        public Constants.DB_STATUS Delete(Role role)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                roleObj = inventory.Roles.Where(rObj => rObj.Id == role.Id).First();
                if (roleObj != null)
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
      
        #endregion
    }
}
