using CheckoutKata.Models;

namespace CheckoutKata
{
    public class Checkout
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

                var groupedByItem = itemsInBag.GroupBy(x => x.Name);

                var totalCost = itemsInBag.Sum(x => x.Price);

                foreach (var item in groupedByItem)
                {
                    var groupedSum = item.Sum(i => i.Price);
                    var itemCount = item.Count();

                    // calculate discount 
                    if (item.Key == "A")
                    {
                        // Item A 20% off if you buy 3 products
                    }
                    else if(item.Key == "B" && itemCount >= 2)
                    {
                        // Item B 25% off if you buy 2 products
                        if (itemCount % 2 == 0)
                        {
                            totalCost = groupedSum - (groupedSum * 0.25);
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