using KNdatabase.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KNdatabase.Data
{
    public class AuthenDbContext : IdentityDbContext<User>
    {
        public AuthenDbContext(DbContextOptions<AuthenDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            SeedRoles(Builder);

        }
        private void SeedRoles(ModelBuilder Builder)
        {
            Builder.Entity<IdentityRole>().HasData(
                 new IdentityRole()
                 {
                     Name = "Admin",
                     ConcurrencyStamp = "1",
                     NormalizedName = "ADMIN"
                 },
                 new IdentityRole()
                 {
                     Name = "User",
                     ConcurrencyStamp = "2",
                     NormalizedName = "USER"
                 },
                 new IdentityRole()
                 {
                     Name = "Editor",
                     ConcurrencyStamp = "3",
                     NormalizedName = "EDITOR"
                 }
             );
        }


    }
}
