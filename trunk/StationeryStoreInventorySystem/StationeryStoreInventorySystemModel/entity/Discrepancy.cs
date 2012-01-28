using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class Discrepancy
    {

        public Discrepancy()
            : this(0, DateTime.Now, new Employee(), 0)
        {
        }
        public Discrepancy(int id, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;

        }

    }
}
