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
            : this(0, null, 0, null, 0, 0, DateTime.Now, null, -1)
        {

        }
        public StockCardDetail(int id, StockCard stockId, int inputForm, string inputFormID, int qty, int balance, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.StockCard = stockId;
            this.InputFrom = inputForm;
            this.InputFromId = inputFormID;
            this.Qty = qty;
            this.Balance = balance;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
