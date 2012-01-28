using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class Department
    {
        public Department()
            : this(" ", " ", new Employee(), " ", " ", new Employee(), new CollectionPoint(), new Employee(), DateTime.Now, new Employee(), 0)
        {
        }
        public Department(string id, string name, Employee contactId, string phoneNumer, string faxNumer, Employee headId, CollectionPoint collectionPointId,
            Employee representativId, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.Name = name;
            this.EmployeeContactId = contactId;
            this.PhoneNumber = phoneNumer;
            this.FaxNumber = faxNumer;
            this.EmployeeHeadId = headId;
            this.CollectionPoint = collectionPointId;
            this.EmployeeRepresentativeId = representativId;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
