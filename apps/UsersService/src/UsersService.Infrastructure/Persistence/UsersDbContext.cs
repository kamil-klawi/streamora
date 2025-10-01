using Microsoft.EntityFrameworkCore;
using UsersService.Domain.Entities;

namespace UsersService.Infrastructure.Persistence
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(builder =>
            {
                builder.OwnsOne(u => u.Email);
                builder.OwnsOne(u => u.Password);
                builder.OwnsOne(u => u.PersonalData);
                builder.OwnsOne(u => u.Role);
            });
        }
    }
}
