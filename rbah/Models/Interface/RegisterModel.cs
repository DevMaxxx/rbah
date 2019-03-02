using System.ComponentModel.DataAnnotations;

namespace rbah.Models
{
    public class RegisterModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string passwordConfirm { get; set; }
    }
}