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

                foreach (var item in groupedByItem)
                {
                    var groupedSum = item.Sum(i => i.Price);
                }

                return itemsInBag.Sum(x => x.Price);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}