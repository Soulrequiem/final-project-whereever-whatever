using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.entity
{
    public partial class User
    {
        public User()
            : this(0, "", "", DateTime.Now, null, 0)
        {
        }
        public User(int id, string userName, string password, DateTime createdDate, Employee createdBy, int status)
        {
            this.Id = id;
            this.UserName = userName;
            this.Password = password;
            this.CreatedDate = createdDate;
            this.CreatedBy = createdBy;
            this.Status = status;
        }
    }
}
