using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace rbah.Models
{
    public class AccountManager : UserManager<Account>
    {
        AccountManager() 
            : base(new UserStore<Account>(new IdentityDbContext<Account>("AuthDb")))
        { }
        public static AccountManager Instance = new AccountManager();
    }
}