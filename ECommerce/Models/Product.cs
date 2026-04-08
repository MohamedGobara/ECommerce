using ECommerce.Data.Base;
using ECommerce.Data.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product :IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }

        public ProductColor ProductColor { get; set; }


        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [ValidateNever]
        public Category Category { get; set; }
    }
}
