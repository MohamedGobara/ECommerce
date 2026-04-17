using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.ViewModel
{
    public class LoginVM
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
