using Microsoft.AspNetCore.Identity;

namespace KNdatabase.Models.User
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
