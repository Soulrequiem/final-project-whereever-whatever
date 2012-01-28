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
        public ItemPrice(string itemId, string supplierId, decimal price, DateTime createdDate, Employee createdBy, int status)
        {
            this.ItemId = itemId;
            this.SupplierId = supplierId;
            this.Price = price;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
        }
    }
}
