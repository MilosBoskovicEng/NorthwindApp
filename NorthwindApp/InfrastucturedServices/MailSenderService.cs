using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfrastucturedServices
{
    public class MailSenderService
    {
        private SmtpClient mailClient = new SmtpClient("smtp.eng.it");
        private MailMessage mailMessage = new MailMessage();
        
        public void sendEmail(string emailFrom, string password, string fullName, string emailTo, string subject, string message)
        {
            mailClient.Port = 25;
            mailClient.EnableSsl = true;
            mailClient.Credentials = new NetworkCredential(emailFrom.Trim(), password.Trim());

            mailMessage.From = new MailAddress(emailFrom.Trim(), fullName);
            mailMessage.To.Add(new MailAddress(emailTo.Trim()));

            mailMessage.Subject = subject;
            mailMessage.Body = message;

            try
            {
                mailClient.Send(mailMessage);
                MessageBox.Show("Sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }        
    }
}
