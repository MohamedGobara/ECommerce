using ECommerce.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class ShoppingCartItem : IBaseEntity
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public string ShoppingCartId { get; set; } 
    }
}
