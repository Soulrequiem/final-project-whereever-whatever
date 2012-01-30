using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface IDepartmentBroker
    {
        Department GetDepartment(Department department);
        List<Department> GetAllDepartment();
        List<Department> GetAllDepartment(Constants.DEPARTMENT_STATUS departmentStatus);
        Constants.DB_STATUS Insert(Department newDepartment);
        Constants.DB_STATUS Update(Department department);
        Constants.DB_STATUS Delete(Department department);
    }
}
