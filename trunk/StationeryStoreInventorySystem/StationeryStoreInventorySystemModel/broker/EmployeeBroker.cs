/***************************************************************************/
/*  File Name       : Employee.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : Employee
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
    using StationeryStoreInventorySystemModel.entity;

    public class EmployeeBroker : brokerinterface.IEmployeeBroker
    {

        #region IEmployeeBroker Members
        private InventoryEntities inventory;
        private Employee employeeObj = null;
        private User userObj = null;
        private Role roleObj = null;
        private List<Employee> employeeList = null;
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
             if (maxEmployeeId.Equals(null))
                 return 0;
             return maxEmployeeId;

        }

        /// <summary>
        /// Retrieve the Employee data from Employee,User and Role Table
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Employee GetEmployee(Employee employee)
        {
            try
            {
                if (employee.User != null)
                {
                    employeeObj = inventory.Employees.Where(eObj => eObj.User.Id == employee.User.Id).First();
                }
                else
                {
                    employeeObj = inventory.Employees.Where(eObj => eObj.Name == employee.Name || eObj.Id == employee.Id).First();
                }

                // if (!empObj.Equals(null) && empObj.CreatedBy != employee.Id)
                User userDetail = inventory.Users.Where(uObj => uObj.Id == employeeObj.User.Id).First();
                Role roleDetail = inventory.Roles.Where(rObj => rObj.Id == employeeObj.Role.Id).First();
                employeeObj.User = userDetail;
                employeeObj.Role = roleDetail;
            }
            catch (Exception e)
            {
                employeeObj = null;
            }
            return employeeObj;
        }
        /// <summary>
        /// Get all of the Employee record from Employee table
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployee()
        {
            try
            {
                employeeList = inventory.Employees.ToList<Employee>();
            }
            catch (Exception e)
            {
                employeeList = null;
            }

                return employeeList;
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
                employeeObj = inventory.Employees.Where(eObj => eObj.Id == employee.Id).First();
                User userId = inventory.Users.Where(u => u.Id == employee.User.Id).First();
                Role roleId = inventory.Roles.Where(r => r.Id == employee.Role.Id).First();
                Department deptId = inventory.Departments.Where(d => d.Id == employee.Department.Id).First();
                Employee createdBy = inventory.Employees.Where(e => e.Id == employee.CreatedBy.Id).First();
                if (employeeObj != null)
                {
                    employeeObj.Id = employee.Id;
                    employeeObj.User = userId;
                    employeeObj.Role = roleId;
                    employeeObj.Department = deptId;
                    employeeObj.Name = employee.Name;
                    employeeObj.Designation = employee.Designation;
                    employeeObj.Email = employee.Email;
                    employeeObj.CreatedDate = employee.CreatedDate;
                    employeeObj.CreatedBy = createdBy;
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
                employeeObj = inventory.Employees.Where(eObj => eObj.Id == employee.Id).First();
                if (employeeObj != null)
                {
                    employeeObj.Status = 2;
                    employeeObj.Role.Status = 2;
                    employeeObj.User.Status = 2;
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
            try
            {
                employeeList = inventory.Employees.Where(r => r.Name.Contains(employee.Name)).ToList();
            }
            catch (Exception e)
            {
                employeeList = null;
            }

            return employeeList;

        }

        /// <summary>
        /// Get Employee Name According to the Employee Name
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public List<Employee> GetEmployeeByDepartments(Employee employee)
        {
            try
            {
                employeeList = inventory.Employees.Where(eObj => eObj.Department.Id == employee.Department.Id).ToList();
            }
            catch (Exception e)
            {
                employeeList = null;
            }

            return employeeList;

        }

        public Employee GetCurrentTempRep(Employee employee)
        {
            try
            {
                employeeObj = inventory.Employees.Where(eObj => eObj.Department.Id == employee.Department.Id && 
                    eObj.Role.Id == (int)Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE).ToList().First();
            }
            catch (Exception e)
            {
                employeeObj = null;
            }

            return employeeObj;
         }
        public List<Employee> GetRepresentative(Employee employee)
        {
            try
            {
                employeeList = inventory.Employees.Where(eObj => (eObj.Department.Id == employee.Department.Id && 
                    (eObj.Role.Id == (int)Constants.EMPLOYEE_ROLE.DEPARTMENT_REPRESENTATIVE)) ||
                    (eObj.Department.Id == employee.Department.Id && 
                    (eObj.Role.Id == (int)Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_REPRESENTATIVE))).ToList();
            }
            catch (Exception e)
            {
                employeeList = null;
            }

            return employeeList;
        }
        public Employee GetCurrentTemporaryDeptHead(Employee employee)
        {
            try
            {
                employeeObj = inventory.Employees.Where(eObj => eObj.Department.Id == employee.Department.Id &&
                    eObj.Role.Id == (int)Constants.EMPLOYEE_ROLE.TEMPORARY_DEPARTMENT_HEAD).ToList().First();
            }
            catch (Exception e)
            {
                employeeObj = null;
            }

            return employeeObj;
        }

        /// <summary>
        /// Get user data of ther User table according to the User parameter
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User GetUser(User user)
        {
            try
            {
                userObj = inventory.Users.Where(uObj => uObj.UserName.Equals(user.UserName) && uObj.Password.Equals(user.Password)).First();

            }
            catch (Exception e)
            {
                userObj = null;
            }
                return userObj;
        }
        /// <summary>
        /// Get the lists of User from user table
        /// </summary>
        /// <returns>
        /// Return lists of user
        /// </returns>
        public List<User> GetAllUser()
        {
            try
            {
                userList = inventory.Users.ToList<User>();
            }
            catch (Exception e)
            {
                userList = null;
            } 
                return userList;
        }
        /// <summary>
        /// Insert the use data to the user table from the parameter
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>
        /// Returns DB_STATUS
        /// </returns>
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
        /// Update the user data to the user table
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// Returns DB_STATUS
        /// </returns>
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
        /// <summary>
        /// Logically delete to the status of user table
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// Returns DB_STATUS
        /// </returns>
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
        /// Get the role of Role table
        /// </summary>
        /// <param name="role"></param>
        /// <returns>
        /// Return role data
        /// </returns>
        public Role GetRole(Role role)
        {
            try
            {
                roleObj = inventory.Roles.Where(rObj => rObj.Id == role.Id).First();
            }
            catch (Exception e)
            {
                roleObj = null;
            }
                return roleObj;
        }
        /// <summary>
        /// Get the list of Role for role table
        /// </summary>
        /// <returns>
        /// Returns the list of role
        /// </returns>
        public List<Role> GetAllRole()
        {
            try{
            roleList = inventory.Roles.ToList<Role>();
            }catch(Exception e)
            {
                roleList=null;
            }
                return roleList;
        }
        /// <summary>
        /// Insert the role data to the role table
        /// </summary>
        /// <param name="newRole"></param>
        /// <returns>
        /// Return DB_STATUS
        /// </returns>
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
        /// Update the role data to the role table
        /// </summary>
        /// <param name="role"></param>
        /// <returns>
        /// Returns DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Update(Role role)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                roleObj = inventory.Roles.Where(rObj => rObj.Id == role.Id).First();
                Employee createdBy = inventory.Employees.Where(e => e.Id == role.CreatedBy.Id).First();
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
        /// <summary>
        /// Logically delete to the status of role table
        /// </summary>
        /// <param name="role"></param>
        /// <returns>
        /// Returns DB_STATUS
        /// </returns>
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
/****************************************/
/********* End of the Class *****************/
/****************************************/