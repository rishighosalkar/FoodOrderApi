using Microsoft.EntityFrameworkCore;
using WebAPi6.Models;

namespace WebAPi6.Context
{
    public class FoodOrderDBContext : DbContext
    {
        public FoodOrderDBContext(DbContextOptions<FoodOrderDBContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantAddress> RestaurantAddresses{ get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Meal> Meals { get; set; }   
        public DbSet<Category> Category { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderConfirmation> OrderConfirmation { get; set; }
    }
}
