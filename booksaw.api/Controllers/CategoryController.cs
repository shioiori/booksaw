using booksaw.application.Categories.CreateCategory;
using booksaw.application.Categories.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace booksaw.api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public string Get(int id)
        {
           throw new NotImplementedException();
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
