namespace TrainingTasks2.OCP
{
    public interface IDiscount
    {
        decimal Ammount { get; }
        bool Match(int itemCount);
    }
}