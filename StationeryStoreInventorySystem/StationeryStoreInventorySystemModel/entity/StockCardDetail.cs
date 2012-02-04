using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class StockCardDetail
    {
        StockCardDetail stockDetial = new StockCardDetail();
        public StockCardDetail()
            : this(0, null, String.Empty, 0, 0, DateTime.Now, null, 0)
        {

        }
        public StockCardDetail(int id, Item itemId, string description, int qty, int balance, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.Item = itemId;
            this.Description = description;
            this.Qty = qty;
            this.Balance = balance;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
