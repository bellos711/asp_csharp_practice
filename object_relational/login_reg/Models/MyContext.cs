using Microsoft.EntityFrameworkCore;
namespace login_reg.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        //our DBsets gonna be based on models we make
        public DbSet<User> Users {get;set;}
    }//end mycontext class
}//end namespace