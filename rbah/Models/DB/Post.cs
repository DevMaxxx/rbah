using System.ComponentModel.DataAnnotations;

namespace rbah.Models
{
    public class Post
    {
        [Key]
        public int id { get; set; }
        public int autorId { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public Post()
        {

        }

        public Post(int autorId,string title,string body)
        {
            this.autorId = autorId;
            this.title = title;
            this.body = body;
        }
    }
}