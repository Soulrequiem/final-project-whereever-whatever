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
        public ChangePasswordControl()
        {
        }

        public Constants.ACTION_STATUS SelectChange(string oldPassword, string newPassword)
        {
            Constants.ACTION_STATUS status = Constants.ACTION_STATUS.UNKNOWN;
            IEmployeeBroker broker = new EmployeeBroker();
            User user = new User();
            // get username from session
            user.Password = oldPassword;
            User resultUser = broker.GetUser(user);
            if (resultUser != null)
            {
                resultUser.Password = newPassword;
                broker.Update(resultUser);
                status = Constants.ACTION_STATUS.SUCCESS;
            }
            else
            {
                status = Constants.ACTION_STATUS.FAIL;
            }
            return status;
        }

    }
}
