namespace WhereIsMyMoney.Models
{
    public class Expense : IEntityBase
    {
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int Id { get; set; }
    }
}