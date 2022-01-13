using ShoppingCart.Models;
using System;

namespace ShoppingCart.Cart
{
    public class CartItem
    {
        private readonly Product _product;
        public short Quantity { get; set; }
        public Decimal ItemPrice => Decimal.Round(_product.Price, 2);
        public long ItemId => _product.Id;

        public CartItem(Product product, short quantity)
        {
            this._product = product;
            Quantity = quantity;
        }

        public void calculate(IPriceCalculator priceCalculator)
        {
            priceCalculator.Calculate(this);
        }
    }
}
