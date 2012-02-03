using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StationeryStoreInventorySystemController.commonController;
using SystemStoreInventorySystemUtil;


namespace SA34_Team9_StationeryStoreInventorySystem.commonUI
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        private ChangePasswordControl CPobj;
        protected void Page_Load(object sender, EventArgs e)
        {
            CPobj = CPobjGetControl();
            //txtOldPassword.Text = String.Empty;
            //txtNewPassword.Text = String.Empty;
            //txtConfirmPassword.Text = String.Empty;
        }

        //protected void btnChange_Click(object sender, EventArgs e)
        //{
        //    string oldPassword = txtOldPassword.Text;
        //    string newPassword = txtNewPassword.Text;
        //    string confirmPassword=txtConfirmPassword.Text;
        //    if (newPassword == confirmPassword)
        //    {
        //        if (CPobj.SelectChange(oldPassword, newPassword) == Constants.ACTION_STATUS.SUCCESS)
        //            lblStatusMessage.Text = "Password change successfully";
        //        else
        //            lblStatusMessage.Text = "Password is not correct.Try again.";
        //    }
            
        //}

        protected void btnChange_Click1(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string message = String.Empty;
            if (newPassword.Equals(confirmPassword))
            {
                if (CPobj.SelectChange(oldPassword, newPassword) == Constants.ACTION_STATUS.SUCCESS)
                    message = "Password change successfully";
                else
                    message = "Password is not correct.Try again.";
            }
            else
            {
                message = "You need to fill the same password.";
            }

            lblStatusMessage.Text = message;
        }

        //protected void btnReset_Click(object sender, EventArgs e)
        //{
        //    lblStatusMessage.Text = String.Empty;
        //    txtOldPassword.Text = String.Empty;
        //    txtNewPassword.Text = String.Empty;
        //    txtConfirmPassword.Text = String.Empty;
        //}

        private ChangePasswordControl CPobjGetControl()
        {
            if (CPobj == null)
                CPobj = new ChangePasswordControl();
            return CPobj;
        }

        protected void btnReset_Click1(object sender, EventArgs e)
        {
            lblStatusMessage.Text = String.Empty;
            txtOldPassword.Text = String.Empty;
            txtNewPassword.Text = String.Empty;
            txtConfirmPassword.Text = String.Empty;
        }
    }
}