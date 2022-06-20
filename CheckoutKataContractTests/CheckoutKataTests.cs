using System;
using System.Collections.Generic;
using CheckoutKata;
using CheckoutKata.Models;
using Xunit;

namespace CheckoutKataContractTests
{
    public class CheckoutKataTests
    {
        [Fact]
        public void NoItems_ReturnZero()
        {
            var checkout = new Checkout();
            IList<Item> bag = null;
            var ex = Assert.Throws<ArgumentNullException>(() => checkout.CalculateTotal(bag));
            Assert.Contains("Value cannot be null. ", ex.Message);
        }
    }
}