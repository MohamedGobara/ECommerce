using ECommerce.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class OrderItem : IBaseEntity
    {
        public int Id { get; set; }

        public int Quantity { get; set; } 
        public double Price { get; set; }

        public int OrderId {get; set; }
        
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order order { get; set; }


    }
}
