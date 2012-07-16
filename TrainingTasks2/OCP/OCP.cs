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
            var percentCal = new DiscountPercentageCalculator();
            return percentCal.CalculateDiscountPercentage(_items);
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

    public class DiscountPercentageCalculator
    {
        public decimal CalculateDiscountPercentage(List<CartItem> _items)
        {
            decimal ammount = 0;

            if (_items.Count >= 5 && _items.Count < 10)
            {
                ammount = 10;
            }
            else if (_items.Count >= 10 && _items.Count < 15)
            {
                ammount = 15;
            }
            else if (_items.Count >= 15)
            {
                ammount = 25;
            }

            return ammount;
        }
    }
}
