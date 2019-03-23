using Microsoft.EntityFrameworkCore;
using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.Data
{
    public class ExpensesDbContext : DbContext
    {
        public ExpensesDbContext(DbContextOptions<ExpensesDbContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }
}