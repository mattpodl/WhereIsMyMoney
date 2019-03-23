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
        private readonly ExpensesDbContext _expensesDbContext;

        public ExpensesController(ExpensesDbContext _expensesDbContext)
        {
            this._expensesDbContext = _expensesDbContext;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_expensesDbContext.Expenses);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            //return Ok(_expensesDbContext.Expenses[id]);
            return Ok();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Expense expense)
        {
            if (ModelState.IsValid)
            {
                _expensesDbContext.Expenses.Add(expense);
                _expensesDbContext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "No to sie udalo");
            }

            return BadRequest(ModelState);
        }


        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Expense expense)
        {
            //_expensesDbContext.Expenses[id] = expense;

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            //_expensesDbContext.Expenses.RemoveAt(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}