using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemModel.broker;
using StationeryStoreInventorySystemModel.entity;
using StationeryStoreInventorySystemModel.brokerinterface;

namespace StationeryStoreInventorySystemController.commonController
{
    public class NotificationControl
    {
        private InventoryEntities inventory;

        private INotificationBroker notificationBroker;

        private List<Notification> notificationList;

        private Employee currentEmployee;

        private DataTable dt;
        private DataRow dr;

        private string[] columnName = { "CreatedDate", "Message" };

        private DataColumn[] dataColumn;

        private static readonly int totalShow = 10;

        public NotificationControl()
        {
            currentEmployee = Util.ValidateUser();
            inventory = new InventoryEntities();

            notificationBroker = new NotificationBroker(inventory);

            notificationList = notificationBroker.GetAllNotification(currentEmployee);

            dataColumn = new DataColumn[] { new DataColumn(columnName[0]), new DataColumn(columnName[1]) };
        }

        public DataTable NotificationList
        {
            get
            {
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.AddRange(dataColumn);
                }
                else
                {
                    dt.Rows.Clear();
                }

                for (int i = 0; i < totalShow && i < notificationList.Count(); i++)
                {
                    dr = dt.NewRow();
                    dr[columnName[0]] = Converter.dateTimeToString(Converter.DATE_CONVERTER.DATETIME, notificationList[i].CreatedDate);
                    dr[columnName[1]] = notificationList[i].Message;
                    dt.Rows.Add(dr);
                }

                return dt;
            }
        }

        public void SetToReadAll()
        {
            int status = Converter.objToInt(Constants.NOTIFICATION_STATUS.UNREAD);
            foreach (Notification notification in notificationList.Where(x => x.Status == status))
            {
                notification.Status = Converter.objToInt(Constants.NOTIFICATION_STATUS.READ);
                notificationBroker.Update(notification);
            }
        }

        public string GetTotalUnread()
        {
            int status = Converter.objToInt(Constants.NOTIFICATION_STATUS.UNREAD);
            int totalUnread = notificationList.Where(x => x.Status == status).Count();
            if (totalUnread > 0)
            {
                return "<span style='font-weight: bold'>Unread [" + totalUnread + "]</span>";
            }
            return "Unread [0]";
        }
    }
}
