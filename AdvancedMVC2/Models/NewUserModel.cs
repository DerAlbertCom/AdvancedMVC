using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AdvancedMVC2.Validation;

namespace AdvancedMVC2.Models
{
    public class NewUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Kennwort")]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Kennwort Bestätigung")]
        [PropertyMustMatch("Password", ErrorMessage = "Das '{0}' und die  '{1}' stimmen nicht überein")]
        public string ConfirmPassword { get; set; }
    }
}