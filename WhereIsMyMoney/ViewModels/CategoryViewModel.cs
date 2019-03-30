using System.ComponentModel.DataAnnotations;

namespace WhereIsMyMoney.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(10, MinimumLength = 4, ErrorMessage = "Name is required, it have to be 4 to 10 characters long")]
        public string Name { get; set; }
    }
}