using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class Supplier
    {

        public Supplier()
            : this("", "", 0, "", "", "", "", "", DateTime.Now, null, 0)
        {
        }
        public Supplier(string id, string name, int priority, string contactName, string phoneNo, string faxNo, string address, string gstRegistrationNo, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.Name = name;
            this.ContactName = contactName;
            this.PhoneNumber = phoneNo;
            this.FaxNumber = faxNo;
            this.Address = address;
            this.GstRegistrationNumber = gstRegistrationNo;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
