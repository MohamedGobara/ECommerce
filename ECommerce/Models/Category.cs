using ECommerce.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Category : IBaseEntity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }


        [Key]
        public int Id { get; set; }

        [Required,MinLength(2,ErrorMessage ="Category name should be greater than 2 Charcters")]
        public string Name { get; set; }
        public string? Description { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
