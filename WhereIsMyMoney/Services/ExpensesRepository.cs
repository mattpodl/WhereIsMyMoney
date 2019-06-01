using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhereIsMyMoney.Data;
using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.Services
{
    public class ExpensesRepository : EntityRepository<Expense>, IExpensesRepository
    {
        public ExpensesRepository(WimmDbContext wimmDbContext) : base(wimmDbContext)
        {
        }

        public override IEnumerable<Expense> Get()
        {
            return _wimmDbContext.Set<Expense>().Include(e => e.Category).AsEnumerable();
        }

        public override Expense Get(int id)
        {
            return _wimmDbContext.Set<Expense>().Include(e => e.Category).SingleOrDefault(e => e.Id.Equals(id));
        }

    }
}