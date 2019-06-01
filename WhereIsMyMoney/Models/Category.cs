using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhereIsMyMoney.Models
{
    public class Category : IEntityBase
    {
        [Required, StringLength(10, MinimumLength = 4, ErrorMessage = "Name is required, it have to be 4 to 10 characters long")]
        public string Name { get; set; }

     //   public virtual ICollection<Expense> Expenses { get; set; }

        public int Id { get; set; }
    }
}