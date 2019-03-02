using System.ComponentModel.DataAnnotations;

namespace rbah.Models
{
    public class PostModel
    {
        [Required]
        public string postHead { get; set; }
        [Required]
        public string postBody { get; set; }
    }
}