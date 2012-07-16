using System.Collections.Generic;
using System.Linq;

namespace TrainingTasks2.OCP
{
    public class DiscountCalculator : IDiscountCalulator
    {
        private readonly List<IDiscount> _discounts;

        public DiscountCalculator(List<IDiscount> discounts)
        {
            _discounts = discounts;
        }

        public decimal CalculateDiscountPercentage(int itemCount)
        {
            return _discounts
                .First(dr => dr.Match(itemCount))
                .Ammount;
        }
    }
}