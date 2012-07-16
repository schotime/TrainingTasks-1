using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks2.OCP
{
    public class ShoppingCart
    {
        private List<CartItem> _items;

        public ShoppingCart()
        {
            _items = new List<CartItem>();
        }

        public decimal GetDiscountPercentage()
        {
            var percentCal = new DiscountCalculator(new List<IDiscount>() {new DiscountRuleTenItems()});
            return percentCal.CalculateDiscountPercentage(_items.Count);
        }

        public void Add(CartItem product)
        {
            _items.Add(product);
        }

        public void Delete(CartItem product)
        {
            _items.Remove(product);
        }
    }

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

    public interface IDiscount
    {
        decimal Ammount { get; }
        bool Match(int itemCount);
    }

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

    public interface IDiscountCalulator
    {
        decimal CalculateDiscountPercentage(int itemCount);
    }
}
