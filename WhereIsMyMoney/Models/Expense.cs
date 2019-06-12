using System.ComponentModel.DataAnnotations;

namespace WhereIsMyMoney.Models
{
    public class Expense : IEntityBase
    {
        [Required]
        public double Amount { get; set; }
        [StringLength(50, ErrorMessage = "Description can be max 50 characters long")]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"((?:19|20)\d\d)-(0?[1-9]|1[012])-([12][0-9]|3[01]|0?[1-9])", ErrorMessage = "Date should be in format YYYY-MM-DD")]
        public string Date { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int Id { get; set; }
        
        //TODO change type of Date to Date
    }
}