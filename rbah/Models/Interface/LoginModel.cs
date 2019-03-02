using System.ComponentModel.DataAnnotations;

namespace rbah.Models
{
    public class LoginModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}