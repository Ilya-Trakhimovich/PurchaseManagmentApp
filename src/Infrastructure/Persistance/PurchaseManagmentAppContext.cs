using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class PurchaseManagmentAppContext : IdentityDbContext
    {
        public PurchaseManagmentAppContext(DbContextOptions<PurchaseManagmentAppContext> options)
       : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
