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

                foreach (var product in itemsInBag)
                {
                    product.TotalPrice = product.Price;
                }

                return itemsInBag.Sum(x => x.Price);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}