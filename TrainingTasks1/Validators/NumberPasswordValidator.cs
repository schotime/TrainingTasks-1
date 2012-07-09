using System.Text.RegularExpressions;

namespace TrainingTasks1
{
    public class NumberPasswordValidator : IPasswordValidator
    {
        public string Message
        {
            get { return "You must have 1 number"; }
        }

        public bool IsValid(string password)
        {
            return Regex.IsMatch(password, "[0-9]+");
        }
    }
}