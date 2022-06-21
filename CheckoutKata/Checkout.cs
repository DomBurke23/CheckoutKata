using CheckoutKata.Interfaces;
using CheckoutKata.Models;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public Checkout()
        {
        }

        static public void Main(String[] args)
        {
            Console.WriteLine("Main Method");
        }

        public double CalculateTotal(IList<Item> itemsInBag)
        {
            try
            {
                if (!itemsInBag.Any())
                {
                    return 0;
                }

                //TODO try adding totalCost and quantity into this to make calculation below easier
                var groupedByItem = itemsInBag.GroupBy(x => x.Name);

                var totalCost = itemsInBag.Sum(x => x.Price);

                foreach (var item in groupedByItem)
                {
                    var groupedSum = item.Sum(i => i.Price);
                    var itemCount = item.Count();

                    // calculate discount 
                    if (item.Key == "A" && itemCount >= 3)
                    {
                        // Item A for every 3 products reduce £20 
                        if (itemCount % 3 == 0)
                        {
                            //apply discount 
                            totalCost = groupedSum - 20;
                        }
                        else
                        {
                            // TODO: Refactor 
                            var discount = ( itemCount / 3 ) * 20;
                            var remainder = (itemCount % 3);
                            var additionalItemsNotDiscountedPrice = 50 * remainder;
                            var discountedPrice = (groupedSum - additionalItemsNotDiscountedPrice - discount);
                            totalCost = discountedPrice + additionalItemsNotDiscountedPrice;
                        }
                    }
                    else if(item.Key == "B" && itemCount >= 2)
                    {
                        // Item B 25% off if you buy 2 products
                        if (itemCount % 2 == 0)
                        {
                            totalCost = (int)(groupedSum - (groupedSum * 0.25));
                        }
                        else
                        {
                            // TODO: Refactor 
                            var totalToApplyDiscount = (groupedSum - 30);
                            var discountedCost = totalToApplyDiscount - (totalToApplyDiscount * 0.25);
                            totalCost = (int)(discountedCost + 30);
                        }
                    }
                }
                return totalCost;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}