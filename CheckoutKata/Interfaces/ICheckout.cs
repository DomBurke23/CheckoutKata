using CheckoutKata.Models;

namespace CheckoutKata.Interfaces
{
    public interface ICheckout
    {
        public double CalculateTotal(IList<Item> itemsInBag);
    }
}
