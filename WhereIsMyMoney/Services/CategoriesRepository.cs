
using WhereIsMyMoney.Data;
using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.Services
{
    public class CategoriesRepository : EntityRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(WimmDbContext wimmDbContext) : base(wimmDbContext)
        {

        }
    }
}