namespace WhereIsMyMoney.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public Category Category { get; set; }
    }
}