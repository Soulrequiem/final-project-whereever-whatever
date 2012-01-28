﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
namespace StationeryStoreInventorySystemModel.entity
{
    public partial class PurchaseOrder
    {

        public PurchaseOrder()
            : this(0, new Supplier(), "", "", DateTime.Now, DateTime.Now, new Employee(), DateTime.Now, new Employee(), 0, "", DateTime.Now, new Employee())
        {
        }

        public PurchaseOrder(int id, Supplier supplier, string deliverAdd, string attn, DateTime expectedDate, DateTime createdDate, Employee createdBy, DateTime approvedDate, Employee approvedBy, int status, string deliveryOrderNo, DateTime deliveryDate, Employee acceptedBy)
        {
            this.Id = id;
            this.Supplier = supplier;
            this.DeliverAddress = deliverAdd;
            this.Attn = attn;
            this.ExpectedDate = expectedDate;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.ApprovedDate = approvedDate;
            this.Employee1 = approvedBy;
            this.Status = status;
            this.DeliveryOrderNumber = deliveryOrderNo;
            this.DeliveryDate = deliveryDate;
            this.Employee2 = acceptedBy;
        }

    }
}
