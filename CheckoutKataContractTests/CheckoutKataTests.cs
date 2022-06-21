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

        [Theory]
        [InlineData("A", 50)]
        [InlineData("B", 30)]
        [InlineData("C", 20)]
        [InlineData("D", 15)]
        public void OneItem(string itemName, int itemPrice)
        {
            var bag = new List<Item> { new Item { Name = itemName, Price = itemPrice } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(itemPrice, total);
        }

        [Theory]
        [InlineData("A", 50, 100)]
        [InlineData("B", 30, 45)]
        [InlineData("C", 20, 40)]
        [InlineData("D", 15, 30)]
        public void TwoIdenticalItems(string itemName, int itemPrice, int expectedTotal)
        {
            var bag = new List<Item> {
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(expectedTotal, total);
        }

        [Theory]
        [InlineData("A", "B", 50, 30, 80)]
        public void TwoDifferentItems(string itemName1, string itemName2,
            int itemPriceofItem1, int itemPriceofItem2,
            int expectedTotal)
        {
            var bag = new List<Item> {
                new Item { Name = itemName1, Price = itemPriceofItem1 },
                new Item { Name = itemName2, Price = itemPriceofItem2 } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(expectedTotal, total);
        }

        [Theory]
        [InlineData("A", 50, 130)]
        [InlineData("B", 30, 75)]
        [InlineData("C", 20, 60)]
        [InlineData("D", 15, 45)]
        public void ThreeIdenticalItems(string itemName, int itemPrice, int expectedTotal)
        {
            var bag = new List<Item> {
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(expectedTotal, total);
        }

        [Theory]
        [InlineData("A", 50, 180)]
        [InlineData("B", 30, 90)]
        [InlineData("C", 20, 80)]
        [InlineData("D", 15, 60)]
        public void FourIdenticalItems(string itemName, int itemPrice, int expectedTotal)
        {
            var bag = new List<Item> {
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(expectedTotal, total);
        }

        [Theory]
        [InlineData("A", 50, 230)]
        [InlineData("B", 30, 120)]
        [InlineData("C", 20, 100)]
        [InlineData("D", 15, 75)]
        public void FiveIdenticalItems(string itemName, int itemPrice, int expectedTotal)
        {
            var bag = new List<Item> {
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(expectedTotal, total);
        }
    }
}