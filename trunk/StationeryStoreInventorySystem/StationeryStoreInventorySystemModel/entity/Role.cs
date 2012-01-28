using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class Role
    {
        public Role()
            : this(0, "", DateTime.Now, new Employee(), 0)
        {
        }
        public Role(int id, string name, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.Name = name;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
