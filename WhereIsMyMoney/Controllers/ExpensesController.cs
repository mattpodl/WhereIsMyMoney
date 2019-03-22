using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.Controllers
{
    [Produces("application/json")]
    [Route("api/Expenses")]
    public class ExpensesController : Controller
    {
        private static readonly List<Expense> _expenses = new List<Expense>
        {
            new Expense
            {
                Amount = 13.5, Category = new Category {CategoryId = 1, Name = "Ogolne"},
                Description = "Wydane na stacji", ExpenseId = 0
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_expenses);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_expenses[id]);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Expense expense)
        {
            _expenses.Add(expense);

            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Expense expense)
        {
            _expenses[id] = expense;

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _expenses.RemoveAt(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}