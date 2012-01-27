using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class StockAdjustment
    {

        public StockAdjustment()
            : this(null, null, DateTime.Now, null, -1)
        {
        }
        public StockAdjustment(string id, Discrepancy disId, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.Discrepancy = disId;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;

        }
    }
}
