using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class PurchaseOrderDetail
    {
     

        public PurchaseOrderDetail():this(0,new PurchaseOrder(),new Item(),0,0,0)
        { 
        }
        public PurchaseOrderDetail(int id, PurchaseOrder purchaseid, Item itemId, decimal price, int qty, int acceptedQty)
        {
            this.Id = id;
            this.PurchaseOrder = purchaseid;
           // this.ItemId = itemId;
            this.Item = itemId;
            this.Price = price;
            this.Qty = qty;
            this.AcceptedQty = acceptedQty;

        }
    }
}
