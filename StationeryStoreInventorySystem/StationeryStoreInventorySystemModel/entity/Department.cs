﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class Department
    {
        public Department()
            : this(String.Empty, String.Empty, null, String.Empty, String.Empty, null, null, null, DateTime.Now, null, 0)
        {
        }
        public Department(string id, string name, Employee contactId, string phoneNumer, string faxNumer, Employee headId, CollectionPoint collectionPointId,
            Employee representativId, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.Name = name;
            this.Contact = contactId;
            this.PhoneNumber = phoneNumer;
            this.FaxNumber = faxNumer;
            this.Head = headId;
            this.CollectionPoint = collectionPointId;
            this.Representative = representativId;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
