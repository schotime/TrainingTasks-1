using System;
using System.Net.Mail;

namespace TrainingTasks2.SRP
{
    public class UserService
    {
        public void Register(string email, string password)
        {
            ValidateEmail(email);

            var user = new User(email, password);
            SaveUser(user);

            SendEmail(email);
        }

        private static void SaveUser(User user)
        {
            var db = new FakeDatabase();
            db.Save(user);
        }

        private static void ValidateEmail(string email)
        {
            if (!email.Contains("@"))
                throw new Exception("Email is not an email!");
        }

        private static void SendEmail(string email)
        {
            var smtpClient = new FakeSmtpClient();
            smtpClient.Send(new MailMessage("mysite@nowhere.com", email) {Subject = "Hello fool!"});
        }
    }

}
