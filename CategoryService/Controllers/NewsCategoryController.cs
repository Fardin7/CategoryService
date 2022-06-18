using CategoryService.Data;
using CategoryService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.Controllers
{
    [Route("api/NewsCategory/")]
    [ApiController]
    public class NewsCategoryController : ControllerBase
    {
        private readonly IRepository _repository;

        public NewsCategoryController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category =await _repository.GetById(id);

            if (category==null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _repository.Get();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewsCategoryCreate newsCategoryCreate)
        {
            var categories = await _repository.Add(newsCategoryCreate);

            return CreatedAtAction(nameof(Get), new { categories.Id }, categories );
        }
    }
}
