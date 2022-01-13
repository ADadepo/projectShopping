using ShoppingCart.Models;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Cart
{
    public class ShopCart
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();
        private readonly IPriceCalculator _priceCalculator;
        public Decimal TotalPrice => Decimal.Round(_productPrice + _taxPrice, 2);
        public Decimal TotalItems => _cartItems.Count;
      

        private Decimal _productPrice;
        private Decimal _taxPrice;

        public ShopCart(IPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

        public void AddItem(Product product, short quantity)
        {
            var cartItem = _cartItems.Find(x => x.ItemId == product.Id);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem(product, quantity));
            }

            CalculateTotal();
        }

        public void RemoveItem(Product product)
        {
            var cartItem = _cartItems.Find(x => x.ItemId == product.Id);
            if (cartItem != null)
            {
                _cartItems.Remove(cartItem);
            }

            CalculateTotal();
        }

        public void CalculateTotal()
        {
            _priceCalculator.Reset();
            _cartItems.ForEach(x => x.calculate(_priceCalculator));
            _productPrice = _priceCalculator.getProductPrice();
            _taxPrice = _priceCalculator.getTaxPrice();
        }

        public void Reset()
        {
            _cartItems.Clear();
            
        }

        public decimal getProductPrice()
        {
            return Decimal.Round(_productPrice, 2);
        }

        public decimal getTaxPrice()
        {
            return Decimal.Round(_taxPrice, 2);
        }

        public short? getItemCount(long productId)
        {
            return _cartItems.Find(x => x.ItemId == productId)?.Quantity;
        }
    }
}
