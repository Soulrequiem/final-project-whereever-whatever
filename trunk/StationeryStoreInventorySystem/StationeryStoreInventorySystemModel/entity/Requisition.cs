using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
   public partial  class Requisition
    {
       public Requisition()
           : this(String.Empty, null, null, String.Empty, null, DateTime.Now, 0)
       {
       }
       public Requisition(string id,Department department,Employee employee,string remarks,Employee approvedBy, DateTime createDate,int status)
       {
           this.Id = id;
           this.Department = department;
           this.CreatedBy = employee;
           this.Remarks = remarks;
           this.ApprovedBy = approvedBy;
           this.CreatedDate = createDate;
           this.Status = status;
       }
    }
}
