/***************************************************************************/
/*  File Name       : Department.cs
/*  Module Name     : Models
/*  Owner           : Su Lai Naing
/*  class Name      : Department
/*  Details         : Model representation of Department table
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
    public class DepartmentBroker : IDepartmentBroker
    {
        #region IDepartmentBroker Members


        private InventoryEntities inventory = new InventoryEntities();
        private Department departmentObj = null;
        private List<Department> departmentList = null;
        /// <summary>
        ///  Retrieve the Department information  from Department Table according to the department Parameter
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Department GetDepartment(Department department)
        {
            ////Get the Department data by Department ID
            departmentObj = inventory.Departments.Where(iObj => iObj.Id == department.Id).First();
            if (!departmentObj.Equals(null))
                return departmentObj;
            return null;
        }
        /// <summary>
        /// Retrieve All of the department information from Department Table
        /// Return Department Collecion List
        /// </summary>
        /// <returns></returns>
        public List<Department> GetAllDepartment()
        {
            departmentList = inventory.Departments.ToList<Department>();
            if (!departmentList.Equals(null))
                return departmentList;
            return null;
        }
        /// <summary>
        /// Insert Department data to the Department Table according to the department Parameter
        /// Return Constants.DB_STATUS
        /// </summary>
        /// <param name="newDepartment"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Insert(Department newDepartment)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                inventory.AddToDepartments(newDepartment);
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
        ///  Update Department data to Department Table according to the department Parameter
        /// Return Constants.DB_STATUS
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Update(Department department)
        {

            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                departmentObj = inventory.Departments.Where(iObj => iObj.Id == department.Id).First();
                departmentObj.Id = department.Id;
                departmentObj.Name = department.Name;
                departmentObj.PhoneNumber = department.PhoneNumber;
                departmentObj.FaxNumber = department.FaxNumber;
                departmentObj.CreatedDate = department.CreatedDate;


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
        /// Logically delete the Department table by setting the status to 2 in the Department table
        /// Return Constants.DB_STATUS
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Constants.DB_STATUS Delete(Department department)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                departmentObj = inventory.Departments.Where(iObj => iObj.Id == department.Id).First();
                departmentObj.Status = 2;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
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