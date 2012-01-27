using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemController.commonController
{
    public class LogOutControl
    {
        public LogOutControl()
        {
            Employee employee = Util.ValidateUser();

            Util.RemoveSession(Util.employeeSessionKey);
            Util.GoToPage(Util.loginPage);
        }
    }
}
