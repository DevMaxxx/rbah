using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace rbah.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public User()
        {

        }
        public User(string name)
        {
            this.name = name;
        }
    }
}