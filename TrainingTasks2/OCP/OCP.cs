using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingTasks2.OCP
{
    public class ShoppingCart
    {
        private readonly IDiscountCalulator _discountCalulator;
        private List<CartItem> _items;

        public ShoppingCart(IDiscountCalulator discountCalulator)
        {
            _discountCalulator = discountCalulator;
            _items = new List<CartItem>();
        }

        public decimal GetDiscountPercentage()
        {
            return _discountCalulator.CalculateDiscountPercentage(_items.Count);
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
}
