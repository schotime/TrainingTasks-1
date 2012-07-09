namespace TrainingTasks1
{
    public class NotNullOrEmptyValidator : IPasswordValidator
    {
        public string Message
        {
            get { return "Password cannot be blank"; }
        }

        public bool IsValid(string password)
        {
            return !string.IsNullOrEmpty(password);
        }
    }
}