using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.Services
{
    public interface ICategoriesRepository : IEntityRepository<Category>
    {
    }

    public interface IExpensesRepository : IEntityRepository<Expense>

    {
    }
}