using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class RequisitionCollection
    {
        public RequisitionCollection():this(0,new Department(),new CollectionPoint(),DateTime.Now,new Employee(),0)
        {
        }
        public RequisitionCollection(int id, Department departmentId, CollectionPoint collectionPointId, DateTime createdDate,
            Employee createdBy, int status)
        {
            this.Id = id;
            this.Department = departmentId;
            this.CollectionPoint = collectionPointId;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
