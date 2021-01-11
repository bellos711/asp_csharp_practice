using Microsoft.EntityFrameworkCore;

namespace chefs_n_dishes.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        //DON'T FORGET TO COME BACK TO THIS FOR LOGIC N STUFF
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dishes {get;set;}
    }
}