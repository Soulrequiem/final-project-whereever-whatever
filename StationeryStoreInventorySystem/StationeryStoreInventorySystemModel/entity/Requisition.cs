using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
   public partial  class Requisition
    {
       public Requisition()
           : this("", null, null, "", null, DateTime.Now, 0)
       {
       }
       public Requisition(string id,Department departmentId,Employee employeeId,string remarks,Employee approvedBy,
           DateTime createDate,int status)
       {
           this.Id = id;
           this.Department = departmentId;
           this.Employee = employeeId;
           this.Remarks = remarks;
           this.ApprovedBy = approvedBy;
           this.CreatedDate = createDate;
           this.Status = status;
       }
    }
}
