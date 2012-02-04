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
                MailMessage msg = new MailMessage("waiyaniad@gmail.com", email, "hello", "How are you?");
                //msg.From = new MailAddress("waiyaniad@gmail.com");
                //msg.To = new MailMessage(
                //msg.Subject = "Hello";
                //msg.Body = "nay kg lar?";
                smtpclient.Send(msg);
                smtpclient.Dispose();
                return true;
           
        }
    }
}
