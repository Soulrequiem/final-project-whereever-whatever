using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class RequisitionCollectionDetail
    {
        public RequisitionCollectionDetail():this(0,null,null)
        {
        }
        public RequisitionCollectionDetail(int id, Requisition requisitionId, RequisitionCollection requisitionCollectionId)
        {
            this.Id = id;
            this.Requisition = requisitionId;
            this.RequisitionCollection = requisitionCollectionId;
        }

    }
}
