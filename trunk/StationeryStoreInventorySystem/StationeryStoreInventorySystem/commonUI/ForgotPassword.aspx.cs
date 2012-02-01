using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            //if (txtemailaddress.Text == "")
            //    lblStatusMessage.Text = "Enter your Email address.";
        }
    }
}