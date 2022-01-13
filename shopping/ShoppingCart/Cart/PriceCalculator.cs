using System;

namespace ShoppingCart.Cart
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly Decimal _taxRate;
        private Decimal _productPrice;
        private Decimal _taxPrice;



        public PriceCalculator(Decimal taxRate)
        {
            _taxRate = taxRate;
        }

        public void Calculate(CartItem cartItem)
        {
            var itemPrice = cartItem.Quantity * cartItem.ItemPrice;
            _productPrice += itemPrice;
            _taxPrice += itemPrice * _taxRate;
        }

        public void Reset()
        {
            _productPrice = 0;
            _taxPrice = 0;
        }

        public decimal getProductPrice()
        {
            return _productPrice;
        }

        public decimal getTaxPrice()
        {
            return _taxPrice;
        }

    }
}
