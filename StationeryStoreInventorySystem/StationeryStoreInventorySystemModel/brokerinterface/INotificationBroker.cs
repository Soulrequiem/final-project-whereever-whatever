using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.brokerinterface
{
    public interface INotificationBroker
    {
        Notification GetNotification(Notification notification);
        List<Notification> GetAllNotification(Employee employee);
        List<Notification> GetAllNotification(Employee employee, Constants.NOTIFICATION_STATUS notificationStatus);
        Constants.DB_STATUS Insert(Notification newNotification);
        Constants.DB_STATUS Insert(List<Notification> newNotificationList);
        Constants.DB_STATUS Update(Notification notification);
        Constants.DB_STATUS Delete(Notification notification);
    }
}
