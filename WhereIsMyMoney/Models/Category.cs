using System.Collections.Generic;

namespace WhereIsMyMoney.Models
{
    public class Category : IEntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }

        public int Id { get; set; }
    }
}