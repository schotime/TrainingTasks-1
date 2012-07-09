namespace TrainingTasks1
{
    public class MinLengthPasswordValidator : IPasswordValidator
    {
        public string Message
        {
            get { return "You must enter 10 or more characters"; }
        }

        public bool IsValid(string password)
        {
            return password.Length >= 10;
        }
    }
}