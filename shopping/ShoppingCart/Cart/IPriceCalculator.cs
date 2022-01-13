namespace ShoppingCart.Cart
{
    public interface IPriceCalculator
    {
        void Calculate(CartItem cart);
        void Reset();

        decimal getProductPrice();
        decimal getTaxPrice();

    }
}
