using Microsoft.EntityFrameworkCore;
using Noted.Models;
namespace Noted.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
        public DbSet<InfoMoney> InfoMonies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InfoMoney>()
                .HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}