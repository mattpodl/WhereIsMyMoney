using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhereIsMyMoney.Models;
using WhereIsMyMoney.Services;

namespace WhereIsMyMoney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private const string NotFoundMessage = "No record in database";
        private readonly ICategoriesRepository _categoryRepository;

        public CategoriesController(ICategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var category = _categoryRepository.Get(id);
            if (category == null) return NotFound(NotFoundMessage);

            return Ok(category);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _categoryRepository.Add(category);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != category.Id) return BadRequest();
            if (_categoryRepository.Get(id) == null) return NotFound(NotFoundMessage);

            _categoryRepository.Update(category);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (_categoryRepository.Get(id) == null) return NotFound(NotFoundMessage);
            _categoryRepository.Delete(id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}