﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class Retrieval
    {

        public Retrieval()
            : this(0, DateTime.Now, null, 0)
        {
        }
        public Retrieval(int id, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
