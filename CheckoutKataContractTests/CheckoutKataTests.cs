using System;
using System.Collections.Generic;
using CheckoutKata;
using CheckoutKata.Constants;
using CheckoutKata.Models;
using Xunit;

namespace CheckoutKataContractTests
{
    public class CheckoutKataTests
    {
        private readonly Checkout checkout = new Checkout();

        [Fact]
        public void NoItems_ReturnsNull()
        {
            IList<Item> bag = null;
            var ex = Assert.Throws<ArgumentNullException>(() => checkout.CalculateTotal(bag));
            Assert.Contains("Value cannot be null. ", ex.Message);
        }

        [Theory]
        [InlineData("A", StockPrices.ItemAPrice)]
        [InlineData("B", StockPrices.ItemBPrice)]
        [InlineData("C", StockPrices.ItemCPrice)]
        [InlineData("D", StockPrices.ItemDPrice)]
        public void OneItem(string itemName, int itemPrice)
        {
            var bag = new List<Item> { new Item { Name = itemName, Price = itemPrice } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(itemPrice, total);
        }

        [Theory]
        [InlineData("A", StockPrices.ItemAPrice, 100)]
        [InlineData("B", StockPrices.ItemBPrice, 45)]
        [InlineData("C", StockPrices.ItemCPrice, 40)]
        [InlineData("D", StockPrices.ItemDPrice, 30)]
        public void TwoIdenticalItems(string itemName, int itemPrice, int expectedTotal)
        {
            var bag = new List<Item> {
                new Item { Name = itemName, Price = itemPrice },
                new Item { Name = itemName, Price = itemPrice } };
            var total = checkout.CalculateTotal(bag);
            Assert.Equal(expectedTotal, total);
        }

        [Theory]
        [InlineData("A", "B", StockPrices.ItemAPrice, StockPrices.ItemBPrice, 80)]
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
        [InlineData("A", StockPrices.ItemAPrice, 130)]
        [InlineData("B", StockPrices.ItemBPrice, 75)]
        [InlineData("C", StockPrices.ItemCPrice, 60)]
        [InlineData("D", StockPrices.ItemDPrice, 45)]
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
        [InlineData("A", StockPrices.ItemAPrice, 180)]
        [InlineData("B", StockPrices.ItemBPrice, 90)]
        [InlineData("C", StockPrices.ItemCPrice, 80)]
        [InlineData("D", StockPrices.ItemDPrice, 60)]
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
        [InlineData("A", StockPrices.ItemAPrice, 230)]
        [InlineData("B", StockPrices.ItemBPrice, 120)]
        [InlineData("C", StockPrices.ItemCPrice, 100)]
        [InlineData("D", StockPrices.ItemDPrice, 75)]
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