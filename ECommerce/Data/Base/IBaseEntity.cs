using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Base
{
    public interface IBaseEntity
    {
        [Required]

        public int Id { get; set; }
    }
}
