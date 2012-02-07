using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemStoreInventorySystemUtil;
using StationeryStoreInventorySystemController;

namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MasterPage.setCurrentPage(this);
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (txtemailaddress.Text != "")
            {
                String Email = txtemailaddress.Text.Trim();
                SendEmail.Sending(Email);
            }
            else
                lblStatusMessage.Text = "Enter your email address.";
        }
    }
}