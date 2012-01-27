using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class ItemPrice
    {
        public ItemPrice()
            : this("", "", 0, DateTime.Now, null, 0)
        {
        }
        public ItemPrice(string id, string supplierId, decimal money, DateTime createdDate, Employee createdBy, int status)
        {
            this.ItemId = id;
            this.SupplierId = supplierId;
            this.Price = money;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
