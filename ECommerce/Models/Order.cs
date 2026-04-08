using ECommerce.Data.Base;

namespace ECommerce.Models
{
    public class Order : IBaseEntity
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get ; set; }
        public string UserId { get; set; }

        public double Amount { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
