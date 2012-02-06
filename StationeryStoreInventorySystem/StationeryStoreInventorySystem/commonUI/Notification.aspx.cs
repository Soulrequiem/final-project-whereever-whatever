using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StationeryStoreInventorySystemController.commonController;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class Notification : System.Web.UI.Page
    {
        private NotificationControl notificationControl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                notificationControl = new NotificationControl();
                if (Request.Form["check"] == null)
                {
                    notificationRepeater.DataSource = notificationControl.NotificationList;
                    notificationRepeater.DataBind();

                    notificationControl.SetToReadAll();
                }
                else
                {
                    Response.Write(notificationControl.GetTotalUnread());
                }
            }
        }
    }
}