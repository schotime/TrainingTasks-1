namespace TrainingTasks1
{
    public interface IPasswordValidator
    {
        string Message { get; }
        bool IsValid(string password);
    }
}