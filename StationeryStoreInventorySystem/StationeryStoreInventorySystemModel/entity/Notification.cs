using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class Notification
    {
        public Notification():this(0,null," ",DateTime.Now,0)
        {
        }
        public Notification(int id, Employee employeeId, string message, DateTime createdDate, int status)
        {
            this.Id = id;
            this.Employee = employeeId;
            this.Message = message;
            this.CreatedDate = createdDate;
            this.Status = status;

        }
    }
}
