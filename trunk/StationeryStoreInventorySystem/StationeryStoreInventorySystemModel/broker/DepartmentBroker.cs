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


        private InventoryEntities inventory;
        private Department departmentObj = null;
       // private List<Department> departmentList = null;
        public DepartmentBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        /// <summary>
        ///  Retrieve the Department information  from Department Table according to the department Parameter
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Department GetDepartment(Department department)
        {
            ////Get the Department data by Department ID
            if (department.Status != 0)
            {
                int status = Converter.objToInt(department.Status);
                departmentObj = inventory.Departments.Where(iObj => iObj.Id == department.Id && department.Status == status).First();
            }
            else
            {
                departmentObj = inventory.Departments.Where(iObj => iObj.Id == department.Id || iObj.Name.Contains(department.Name)).First();
            }
            if (!departmentObj.Equals(null))
            {
                //departmentObj.CreatedBy = inventory.Employees.Where(x => x.Id == departmentObj.CreatedBy.Id).First();
                //departmentObj.EmployeeContactId = inventory.Employees.Where(x => x.Id == departmentObj.EmployeeContactId.Id).First();
                //departmentObj.EmployeeHeadId = inventory.Employees.Where(x => x.Id == departmentObj.EmployeeHeadId.Id).First();
                //departmentObj.EmployeeRepresentativeId = inventory.Employees.Where(x => x.Id == departmentObj.EmployeeRepresentativeId.Id).First();
                //departmentObj.CollectionPoint = inventory.CollectionPoints.Where(x => x.Id == departmentObj.CollectionPoint.Id).First();

                //foreach (Employee e in departmentObj.Employees)
                //{
                //    departmentObj.Employees.Add(e);
                //}


                return departmentObj;
            }
            return null;
        }
        /// <summary>
        /// Retrieve All of the department information from Department Table
        /// Return Department Collecion List
        /// </summary>
        /// <returns></returns>
        public List<Department> GetAllDepartment()
        {
            return inventory.Departments.ToList<Department>();
        }

        public List<Department> GetAllDepartment(Constants.DEPARTMENT_STATUS departmentStatus)
        {
            int status = Converter.objToInt(departmentStatus);
            return inventory.Departments.Where(iObj => iObj.Status == status).ToList<Department>();
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

                if (departmentObj != null)
                {
                    //Employee contactId = inventory.Employees.Where(e => e.Id == departmentObj.EmployeeContactId.Id).First();
                    //Employee headId = inventory.Employees.Where(e => e.Id == departmentObj.EmployeeHeadId.Id).First();
                    //Employee representativeId = inventory.Employees.Where(e => e.Id == departmentObj.EmployeeRepresentativeId.Id).First();
                    //Employee createdBy = inventory.Employees.Where(e => e.Id == departmentObj.CreatedBy.Id).First();
                    //CollectionPoint collectionPId = inventory.CollectionPoints.Where(c => c.Id == departmentObj.CollectionPoint.Id).First();
                    departmentObj.Name = department.Name;
                    departmentObj.Contact = department.Contact;
                    departmentObj.PhoneNumber = department.PhoneNumber;
                    departmentObj.FaxNumber = department.FaxNumber;
                    departmentObj.Head = department.Head;
                    departmentObj.CollectionPoint = department.CollectionPoint;
                    //departmentObj.CollectionPoint.Id = department.CollectionPoint.Id;
                    departmentObj.Representative = department.Representative;
                    departmentObj.CreatedDate = department.CreatedDate;
                    departmentObj.CreatedBy = department.CreatedBy ;

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