using System.Collections.Generic;
using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.Services
{
    public interface IEntityRepository<T> where T : class, IEntityBase
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Add(T t);
        void Update(T t);
        void Delete(int id);
    }
}