using System;
using System.Collections.Generic;
using CheckoutKata;
using CheckoutKata.Models;
using Xunit;

namespace CheckoutKataContractTests
{
    public class CheckoutKataTests
    {
        private Checkout checkout = new Checkout();

        [Fact]
        public void NoItems_ReturnsNull()
        {
            IList<Item> bag = null;
            var ex = Assert.Throws<ArgumentNullException>(() => checkout.CalculateTotal(bag));
            Assert.Contains("Value cannot be null. ", ex.Message);
        }

        [Fact]
        public void OneItem()
        {
            var bag = new List<Item> { new Item { Name = "A", Price = 50 } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(50, total);
        }

        [Fact]
        public void DuplicateItems_DuplicateBs()
        {
            var bag = new List<Item> {
                new Item { Name = "B", Price = 30 },
                new Item { Name = "B", Price = 30 } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(45, total);
        }

        [Fact]
        public void DuplicateItems_TripleBs()
        {
            var bag = new List<Item> {
                new Item { Name = "B", Price = 30 },
                new Item { Name = "B", Price = 30 },
                new Item { Name = "B", Price = 30 } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(75, total);
        }
    }
}