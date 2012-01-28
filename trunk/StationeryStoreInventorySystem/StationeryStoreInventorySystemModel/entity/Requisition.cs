﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
   public partial  class Requisition
    {
       public Requisition()
           : this("", new Department(), new Employee(), "", new Employee(), DateTime.Now, 0)
       {
       }
       public Requisition(string id,Department departmentId,Employee employeeId,string remarks,Employee approvedBy,
           DateTime createDate,int status)
       {
           this.Id = id;
           this.Department = departmentId;
           this.EmployeeId = employeeId;
           this.Remarks = remarks;
           this.Employee1 = approvedBy;
           this.CreatedDate = createDate;
           this.Status = status;
       }
    }
}
