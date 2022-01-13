using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Cart;
using ShoppingCart.Models;
using System;

namespace ShopCartTest
{
    [TestClass]
    public class ShoppingTest
    {
        [TestMethod]
        public void TestWithSingleItemSingleCategory()
        {
            // 
            Tax tax = new Tax(0);
            IPriceCalculator priceCalculator = new PriceCalculator(tax.TaxRate);
            ShopCart sCart = new ShopCart(priceCalculator);

            // When
            Product productDove = new Product() { Id = 100, Name = "Dove", Category = "Soap", Price = 39.9m };
            sCart.AddItem(productDove, 1);

            //Then
            Assert.AreEqual(39.9m, sCart.TotalPrice);
            Assert.AreEqual(1, sCart.TotalItems);
            Assert.AreEqual(1, sCart.getItemCount(100).GetValueOrDefault());
        }

        [TestMethod]
        public void TestWithMultipleItemSingleCategory()
        {
            // 
            Tax tax = new Tax(0);
            IPriceCalculator priceCalculator = new PriceCalculator(tax.TaxRate);
            ShopCart sCart = new ShopCart(priceCalculator);

            // When
            Product productDove = new Product() { Id = 100, Name = "Dove", Category = "Soap", Price = 39.99m };
            sCart.AddItem(productDove, 5);
            sCart.AddItem(productDove, 3);

            //Then
            Assert.AreEqual(319.92m, sCart.TotalPrice);
            Assert.AreEqual(1, sCart.TotalItems);
            Assert.AreEqual(8, sCart.getItemCount(100).GetValueOrDefault());
        }

        [TestMethod]
        public void TestWithMultipleItemMultipleCategory()
        {
            // 
            Tax tax = new Tax(12.5m);
            IPriceCalculator priceCalculator = new PriceCalculator(tax.TaxRate);
            ShopCart sCart = new ShopCart(priceCalculator);

            // When
            Product productDove = new Product() { Id = 100, Name = "Dove", Category = "Soap", Price = 39.99m };
            sCart.AddItem(productDove, 2);
            Product productAxe = new Product() { Id = 200, Name = "Axe", Category = "Dedrant", Price = 99.99m };
            sCart.AddItem(productAxe, 2);


            //Then
            Assert.AreEqual(314.96m, sCart.TotalPrice);
            Assert.AreEqual(35.00m, sCart.getTaxPrice());
            Assert.AreEqual(2, sCart.TotalItems);
            Assert.AreEqual(2, sCart.getItemCount(100).GetValueOrDefault());
            Assert.AreEqual(2, sCart.getItemCount(200).GetValueOrDefault());
        }
    }
}
