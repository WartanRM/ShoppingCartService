using Microsoft.EntityFrameworkCore;
using ShoppingCartService.Models.DTO;

namespace ShoppingCartService.Models
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and other model options here
        }
    }
}