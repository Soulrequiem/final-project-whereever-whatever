using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class Item
    {
        public Item()
            : this(" ", 0, " ", 0, 0, 0, 0, DateTime.Now, new Employee(), 0)
        {
        }
        public Item(string id, int categoryId, string description, int reorderLevel, int reorderQty, decimal money,
            int UOM, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.ItemCategoryId = categoryId;
            this.Description = description;
            this.ReorderLevel = reorderLevel;
            this.ReorderQty = reorderQty;
            this.Cost = money;
            this.UnitOfMeasureId = UOM;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
