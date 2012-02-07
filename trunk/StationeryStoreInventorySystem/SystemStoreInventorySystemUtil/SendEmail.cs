using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;


namespace SystemStoreInventorySystemUtil
{
    public class SendEmail
    {
        public static Boolean Sending(String email)
        {
                SmtpClient smtpclient = new SmtpClient("lynx.iss.nus.edu.sg");
                MailMessage msg = new MailMessage("waiyaniad@gmail.com", email);
                //msg.From = new MailAddress("waiyaniad@gmail.com");
                //msg.To = new MailMessage(
                msg.IsBodyHtml = true;
                msg.Subject = "Request for reset the password";
                msg.Body = "You recently asked to reset your Facebook password. To complete your request, please follow this link: " +
                            "http://localhost:1189/commonUI/Report.aspx" + "<p>";
                smtpclient.Send(msg);
                smtpclient.Dispose();
                return true;
           
        }
    }
}
