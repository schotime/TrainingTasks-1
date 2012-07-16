namespace TrainingTasks2.OCP
{
    public class DiscountRuleTenItems : IDiscount
    {
        public decimal Ammount
        {
            get { return 15; }
        }

        public bool Match(int itemCount)
        {
            return itemCount >= 10 && itemCount < 15;
        }
    }
}