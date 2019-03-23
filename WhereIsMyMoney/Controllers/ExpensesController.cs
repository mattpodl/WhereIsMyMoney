using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereIsMyMoney.Data;
using WhereIsMyMoney.Models;

namespace WhereIsMyMoney.Controllers
{
    [Produces("application/json")]
    [Route("api/Expenses")]
    public class ExpensesController : Controller
    {
        private const string NotFoundMessage = "No record in database";
        private readonly ExpensesDbContext _expensesDbContext;

        public ExpensesController(ExpensesDbContext expensesDbContext)
        {
            _expensesDbContext = expensesDbContext;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_expensesDbContext.Expenses);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var expense = _expensesDbContext.Expenses.SingleOrDefault(e => e.ExpenseId.Equals(id));
            if (expense == null)

                return NotFound(NotFoundMessage);

            return Ok(expense);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Expense expense)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _expensesDbContext.Expenses.Add(expense);
            _expensesDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Expense expense)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != expense.ExpenseId) return BadRequest();

            try
            {
                _expensesDbContext.Expenses.Update(expense);
                _expensesDbContext.SaveChanges();
            }
            catch
            {
                return NotFound(NotFoundMessage);
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var expense = _expensesDbContext.Expenses.SingleOrDefault(e => e.ExpenseId == id);
            if (expense == null) return NotFound(NotFoundMessage);

            _expensesDbContext.Expenses.Remove(expense);
            _expensesDbContext.SaveChanges();

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}