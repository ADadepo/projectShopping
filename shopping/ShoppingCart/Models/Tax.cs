using System;

namespace ShoppingCart.Models
{
    public class Tax
    {
        public Decimal TaxRate => _taxRate / 100;
        private readonly Decimal  _taxRate;
        public Tax(decimal taxRate)
        {
            _taxRate = taxRate;
        }
    }
}
