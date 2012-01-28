using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class RequisitionCollectionItem
    {
        public RequisitionCollectionItem()
            : this(0, new RequisitionCollection(), new Item(), 0, DateTime.Now, new Employee(), 0)
        {
        }
        public RequisitionCollectionItem(int id, RequisitionCollection requisition, Item itemId, int qty, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.RequisitionCollection = requisition;
            this.Item = itemId;
            this.Qty = qty;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
