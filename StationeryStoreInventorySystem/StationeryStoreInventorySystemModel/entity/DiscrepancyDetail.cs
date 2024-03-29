﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class DiscrepancyDetail
    {

        public DiscrepancyDetail()
            : this(0, null, null, 0, 0, String.Empty)
        {
        }
        public DiscrepancyDetail(int id, Discrepancy disId, Item itemId, int disType, int qty, string remark)
        {
            this.Id = id;
            this.Discrepancy = disId;
            this.Item = itemId;
            this.DiscrepancyType = disType;
            this.Qty = qty;
            this.Remarks = remark;
        }
    }
}
