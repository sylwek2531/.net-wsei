using implementsForm.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace implementsForm.Web.Database
{
    public class ExchangesDbContext : DbContext
    {
        public ExchangesDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ItemEntity> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ItemEntity>();
        }
    }
}
