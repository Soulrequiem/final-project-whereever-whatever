/***************************************************************************/
/*  File Name       : NotificationBroker.cs
/*  Module Name     : Models
/*  Owner           : Thazin Win
/*  class Name      : Notification
/*  Details         : Model representation of Notification table
/***************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StationeryStoreInventorySystemModel.brokerinterface;
using StationeryStoreInventorySystemModel.entity;
using SystemStoreInventorySystemUtil;

namespace StationeryStoreInventorySystemModel.broker
{
    public class NotificationBroker : StationeryStoreInventorySystemModel.brokerinterface.INotificationBroker
    {
        InventoryEntities inventory;
        Notification notificationObj = null;
        List<Notification> notificationList = null;

        public NotificationBroker(InventoryEntities inventory)
        {
            this.inventory = inventory;
        }
        /// <summary>
        /// Get the notification data from the Notification table according to the notification parameter
        /// </summary>
        /// <param name="notification"></param>
        /// <returns>
        /// Notification data
        /// </returns>
        public Notification GetNotification(Notification notification)
        {
            try
            {
                notificationObj = inventory.Notifications.Where(n => n.Id == notification.Id).First();
            }
            catch (Exception e)
            {
                notificationObj = null;
            }
          
                return notificationObj;
        }
        /// <summary>
        /// Get all of the notification data from the Notification Table by checking the employee Id
        /// </summary>
        /// <returns>
        /// Return Lists of the Notification data by Employee Id
        /// </returns>
        public List<Notification> GetAllNotification(Employee employee)
        {
            try
            {
                if (inventory.Notifications.Where(e => e.Employee.Id == employee.Id).OrderByDescending(n => n.CreatedDate).Count() > 0)
                {
                    notificationList = inventory.Notifications.Where(e => e.Employee.Id == employee.Id).OrderByDescending(n => n.CreatedDate).ToList<Notification>();
                }
                else
                {
                    notificationList = null;
                }
            }
            catch (Exception e)
            {
                notificationList = null; 
            }
         return notificationList;
        }
        /// <summary>
        /// Get all of the Notification data by employeeId and NOTIFICATION_STATUS
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="notificationStatus"></param>
        /// <returns>
        /// Return lists of Notifications
        /// </returns>
        public List<Notification> GetAllNotification(Employee employee, Constants.NOTIFICATION_STATUS notificationStatus)
        {
            try
            {
                //get the collectionMissed List by checking department Id of collecion Missed Table and check the Visibility Status
                notificationList = inventory.Notifications.Where(n => n.Employee.Id == employee.Id || notificationStatus.Equals("SHOW")).ToList();

            }
            catch (Exception e)
            {
                notificationList = null;
            }
                return notificationList;
        }
        /// <summary>
        /// Insert Notification data to notification table
        /// </summary>
        /// <param name="newNotification"></param>
        /// <returns>
        /// Returns DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Insert(Notification newNotification)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;


            try
            {
                inventory.AddToNotifications(newNotification);
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        /// <summary>
        /// Insert notification lists to Notification Table
        /// </summary>
        /// <param name="newNotificationList"></param>
        /// <returns>
        /// Return DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Insert(List<Notification> newNotificationList)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                foreach (Notification notification in newNotificationList)
                {
                    inventory.AddToNotifications(notification);
                    inventory.SaveChanges();
                }
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        /// <summary>
        /// Update Notification data to Notification table
        /// </summary>
        /// <param name="notification"></param>
        /// <returns>
        /// Retrun DB_STATUS
        /// </returns>
        public Constants.DB_STATUS Update(Notification notification)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                notificationObj = inventory.Notifications.Where(n => n.Id == notification.Id).First();
                if (notificationObj != null)
                {
                    Employee employeeId = inventory.Employees.Where(e => e.Id == notification.Employee.Id).First();
                    notificationObj.Id = notification.Id;
                    notificationObj.Employee = employeeId;
                    notificationObj.Message = notification.Message;
                    notificationObj.CreatedDate = notification.CreatedDate;
                    inventory.SaveChanges();
                    status = Constants.DB_STATUS.SUCCESSFULL;
                }
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
        /// <summary>
        /// Logically delete to the status of notification table
        /// </summary>
        /// <param name="notification"></param>
        /// <returns>
        /// Return DB_SATUS
        /// </returns>
        public Constants.DB_STATUS Delete(Notification notification)
        {
            Constants.DB_STATUS status = Constants.DB_STATUS.UNKNOWN;

            try
            {
                notificationObj = inventory.Notifications.Where(n => n.Id == notification.Id).First();
                notificationObj.Status = 2;
                inventory.SaveChanges();
                status = Constants.DB_STATUS.SUCCESSFULL;
            }
            catch (Exception e)
            {
                status = Constants.DB_STATUS.FAILED;
            }

            return status;
        }
    }
}
