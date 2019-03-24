namespace WhereIsMyMoney.ViewModels
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string CategoryName { get; set; }
    }
}