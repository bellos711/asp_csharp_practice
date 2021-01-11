using Microsoft.EntityFrameworkCore;
namespace crudelicious.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        //our DBsets gonna be based on models we make
        public DbSet<Dish> Dishes {get;set;}
    }//end mycontext class
}//end namespace