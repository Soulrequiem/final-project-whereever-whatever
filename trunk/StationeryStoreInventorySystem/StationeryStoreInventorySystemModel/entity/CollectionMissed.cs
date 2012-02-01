/***************************************************************************/
/*  File Name       : CollectionMissed.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : CollectionMissed
/*  Details         : Model CollectionMissed of CollectionMissed table
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class CollectionMissed
    {
        public CollectionMissed():this(0,null,null,DateTime.Now,0)
        {
        }
        public CollectionMissed(int id, Department departmentId, Employee createdBy, DateTime createdDate, int status)
        {
            this.Id = id;
            this.Department = departmentId;
            this.CreatedBy = createdBy;
            this.CreatedDate = createdDate;
            this.Status = status;
        }
    }
}
/****************************************/
/********* End of the Class *****************/
/****************************************/
