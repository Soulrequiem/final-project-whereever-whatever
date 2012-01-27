using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class StockCard
    {


        public StockCard()
            : this(0, null, DateTime.Now, null, -1)
        {
        }
        public StockCard(int id, Item itemId, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.Item = itemId;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }

    }
}
