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
        ChangePasswordControl CPobj = new ChangePasswordControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            ChangePasswordControl CPobj = new ChangePasswordControl();

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
            if (newPassword == confirmPassword)
            {
                if (CPobj.SelectChange(oldPassword, newPassword) == Constants.ACTION_STATUS.SUCCESS)
                    lblStatusMessage.Text = "Password change successfully";
                else
                    lblStatusMessage.Text = "Password is not correct.Try again.";
            }
        }
    }
}