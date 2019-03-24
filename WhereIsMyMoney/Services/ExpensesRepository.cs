using WhereIsMyMoney.Data;
using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.Services
{
    public class ExpensesRepository : EntityRepository<Expense>, IExpensesRepository
    {
        public ExpensesRepository(WimmDbContext wimmDbContext) : base(wimmDbContext)
        {
        }
    }
}