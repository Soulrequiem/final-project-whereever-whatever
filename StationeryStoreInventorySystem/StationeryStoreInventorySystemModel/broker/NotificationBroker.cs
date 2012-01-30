using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StationeryStoreInventorySystemModel.broker
{
    public class NotificationBroker : StationeryStoreInventorySystemModel.brokerinterface.INotificationBroker
    {
        public entity.Notification GetNotification(entity.Notification notification)
        {
            throw new NotImplementedException();
        }

        public List<entity.Notification> GetAllNotification()
        {
            throw new NotImplementedException();
        }

        public List<entity.Notification> GetAllNotification(SystemStoreInventorySystemUtil.Constants.NOTIFICATION_STATUS notificationStatus)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Insert(entity.Notification newNotification)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Insert(List<entity.Notification> newNotificationList)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Update(entity.Notification notification)
        {
            throw new NotImplementedException();
        }

        public SystemStoreInventorySystemUtil.Constants.DB_STATUS Delete(entity.Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}
