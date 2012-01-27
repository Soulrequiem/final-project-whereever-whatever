using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.entity;

namespace StationeryStoreInventorySystemController.commonController
{
    public class ChangePasswordControl
    {
        private Employee currentEmployee;

        public ChangePasswordControl()
        {
            currentEmployee = Util.ValidateUser();
        }

        public Constants.ACTION_STATUS SelectChange(string oldPassword, string newPassword)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;

            if (currentEmployee.User.Password.CompareTo(oldPassword) == 0)
            {
                IEmployeeBroker employeeBroker = new EmployeeBroker();
                currentEmployee.User.Password = newPassword;
                if (employeeBroker.Update(currentEmployee.User) == Constants.DB_STATUS.SUCCESSFULL)
                {
                    status = Constants.ACTION_STATUS.SUCCESS;
                }
                else
                {
                    status = Constants.ACTION_STATUS.FAIL;
                }
            }
            else
            {
                status = Constants.ACTION_STATUS.FAIL;
            }
            return status;
        }

    }
}
