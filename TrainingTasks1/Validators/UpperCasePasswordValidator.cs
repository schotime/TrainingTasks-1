using System.Text.RegularExpressions;

namespace TrainingTasks1
{
    public class UpperCasePasswordValidator : IPasswordValidator 
    {
        public string Message
        {
            get { return "You must have 1 upper case character"; }
        }

        public bool IsValid(string password)
        {
            return Regex.IsMatch(password, "[A-Z]+");
        }
    }
}