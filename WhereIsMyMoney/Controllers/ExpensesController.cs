using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereIsMyMoney.Models;
using WhereIsMyMoney.Services;

namespace WhereIsMyMoney.Controllers
{
    [Produces("application/json")]
    [Route("api/Expenses")]
    public class ExpensesController : Controller
    {
        private const string NotFoundMessage = "No record in database";
        private readonly IExpensesRepository _expensesRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public ExpensesController(IExpensesRepository expenseRepository, ICategoriesRepository categoriesRepository)
        {
            _expensesRepository = expenseRepository;
            _categoriesRepository = categoriesRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_expensesRepository.Get());
        }

        [HttpGet("search")]
        public IActionResult GetCategory()
        {
            return Ok(_expensesRepository.Get()
                .GroupBy(e => e.Category)
                .Select(e => new Tuple<string,double> (e.First().Category.Name,e.Sum(x => x.Amount))));
            
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var expense = _expensesRepository.Get(id);
            if (expense == null)

                return NotFound(NotFoundMessage);

            return Ok(expense);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Expense expense)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _expensesRepository.Add(expense);
            return StatusCode(StatusCodes.Status201Created);
        }


        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Expense expense)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != expense.Id) return BadRequest();
            if (_expensesRepository.Get(id) == null) return NotFound(NotFoundMessage);
            _expensesRepository.Update(expense);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var expense = _expensesRepository.Get(id);
            if (expense == null) return NotFound(NotFoundMessage);
            _expensesRepository.Delete(id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}