using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class RequisitionDetail
    {
        public RequisitionDetail()
            : this(0, null, null, 0, 0)
        {
        }
        public RequisitionDetail(int id, Requisition requisitionId, Item itemId, int qty, int deliveredQty)
        {
            this.Id = id;
            this.Requisition = requisitionId;
            this.Item = itemId;
            this.Qty = qty;
            this.DeliveredQty = deliveredQty;
        }
    }
}
