using System.Collections.Generic;
using System.Linq;
using WhereIsMyMoney.Data;
using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.Services
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntityBase, new()
    {
        private readonly WimmDbContext _wimmDbContext;

        public EntityRepository(WimmDbContext wimmDbContext)
        {
            _wimmDbContext = wimmDbContext;
        }

        public IEnumerable<T> Get()
        {
            return _wimmDbContext.Set<T>().AsEnumerable();
        }

        public T Get(int id)
        {
            return _wimmDbContext.Set<T>().SingleOrDefault(e => e.Id.Equals(id));
        }

        public void Add(T entity)
        {
            _wimmDbContext.Set<T>().Add(entity);
            _wimmDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _wimmDbContext.Set<T>().Update(entity);
            _wimmDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _wimmDbContext.Set<T>().Find(id);
            _wimmDbContext.Set<T>().Remove(entity);
            _wimmDbContext.SaveChanges();
        }
    }
}