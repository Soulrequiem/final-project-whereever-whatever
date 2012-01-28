using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class Employee
    {
        public Employee()
            : this(0, null, null, null, " ", 0, " ", DateTime.Now, null, 0)
        {
        }
        public Employee(int id, User userId, Role roleId, Department departmentId, string name, int designation,
            string email, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.User = userId;
            this.Role = roleId;
            this.Department = departmentId;
            this.Name = name;
            this.Designation = designation;
            this.Email = email;
            this.CreatedDate = createdDate;
            this.EmployeeCreatedBy = createdBy;
            this.Status = status;
        }
    }
}
