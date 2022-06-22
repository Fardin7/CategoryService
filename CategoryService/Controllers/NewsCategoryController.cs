using AutoMapper;
using CategoryService.Data;
using CategoryService.Dtos;
using CategoryService.NewsClient;
using Microsoft.AspNetCore.Mvc;

namespace CategoryService.Controllers
{
    [Route("api/NewsCategory/")]
    [ApiController]
    public class NewsCategoryController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IClientUpdate _newsServiceUpdate;
        private readonly IMapper _mapper;

        public NewsCategoryController(IRepository repository, IClientUpdate newsServiceUpdate, IMapper mapper)
        {
            _repository = repository;
            _newsServiceUpdate = newsServiceUpdate;
            _mapper = mapper;
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

           var result=await _newsServiceUpdate.Notify(_mapper.Map<NewsCategoryCreate>(categories));

            if (result!=null)
            {
                return CreatedAtAction(nameof(Get), new { categories.Id }, categories);
            }
           return BadRequest();
        }
    }
}
