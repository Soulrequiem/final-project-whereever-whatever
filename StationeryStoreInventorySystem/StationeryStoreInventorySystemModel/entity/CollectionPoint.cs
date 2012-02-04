using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class CollectionPoint
    {
        public CollectionPoint()
            : this(0,String.Empty, new TimeSpan(00, 00, 00),null)
        {
        }
        public CollectionPoint(int id, String name, TimeSpan time, Employee clerk)
        {
            this.Id = id;
            this.Name = name;
            this.Time = time;
            this.Clerk = clerk;
        }
    }
}
