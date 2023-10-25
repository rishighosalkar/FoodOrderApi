using WebAPi6.Models;

namespace WebAPi6.Helpers
{
    public class CreateOrder
    {
        public Order Order { get; set; }
        public Notification Notification { get; set; }
        public List<Cart> Cart { get; set; }
    }
}
