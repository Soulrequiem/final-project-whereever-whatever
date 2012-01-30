using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class RetrievalDetail
    {
        public RetrievalDetail()
            : this(0, null, null, null, 0, 0)
        {
        }
        public RetrievalDetail(int id, Retrieval retrievalId, Item itemId, Department departmentId, int neededQty, int actualQty)
        {
            this.Id = id;
            this.Retrieval = retrievalId;
            this.Item = itemId;
            this.Department = departmentId;
            this.NeededQty = neededQty;
            this.ActualQty = actualQty;
        }
    }
}
