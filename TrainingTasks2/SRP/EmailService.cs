using System;
using System.Net.Mail;

namespace TrainingTasks2.SRP
{
    public class EmailService
    {
        public void ValidateEmail(string email)
        {
            if (!email.Contains("@"))
                throw new Exception("Email is not an email!");
        }

        public void SendEmail(string email)
        {
            var smtpClient = new FakeSmtpClient();
            smtpClient.Send(new MailMessage("mysite@nowhere.com", email) { Subject = "Hello fool!" });
        }
    }
}