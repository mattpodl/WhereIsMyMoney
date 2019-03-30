using Microsoft.EntityFrameworkCore;
using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.Data
{
    public class WimmDbContext : DbContext
    {
        public WimmDbContext(DbContextOptions<WimmDbContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(x => x.Expenses).WithOne(y => y.Category);
            
           

        }
    }
}