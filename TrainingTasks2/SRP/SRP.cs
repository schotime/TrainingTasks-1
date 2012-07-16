namespace TrainingTasks2.SRP
{
    public class UserService
    {
        public void Register(string email, string password)
        {
            var emailService = new EmailService();
            emailService.ValidateEmail(email);

            var user = new User(email, password);
            SaveUser(user);

            emailService.SendEmail(email);
        }

        private static void SaveUser(User user)
        {
            var db = new FakeDatabase();
            db.Save(user);
        }
    }
}
