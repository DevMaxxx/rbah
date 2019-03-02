using System.Data.Entity;

namespace rbah.Models
{
    public class Context : DbContext
    {
        public Context()
            :base("AppDb")
        { }
        public DbSet<User> users { get; set; }
        public DbSet<Post> posts { get; set; }

        public static Context Instance = new Context();
    }
}