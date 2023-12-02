using booksaw.application.Books.CreateBook;
using booksaw.application.Books.DeleteBook;
using booksaw.application.Books.GetAllBook;
using booksaw.application.Books.GetBookByAuthor;
using booksaw.application.Books.GetBookByCategory;
using booksaw.application.Books.GetBookById;
using booksaw.application.Books.GetBookByPublisher;
using booksaw.application.Books.UpdateBook;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace booksaw.api.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateBookCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand() { Id = id });
            if (result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _mediator.Send(new GetAllBookQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetBookByIdQuery() { Id = id });
            return Ok(result);
        }

        [HttpGet("author/{id}")]
        public async Task<IActionResult> GetByAuthorAsync(int id)
        {
            var result = await _mediator.Send(new GetBookByAuthorQuery() { AuthorId = id });
            return Ok(result);
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetByCategoryAsync(int id)
        {
            var result = await _mediator.Send(new GetBookByCategoryQuery() { CategoryId = id });
            return Ok(result);
        }

        [HttpGet("publisher/{id}")]
        public async Task<IActionResult> GetByPublisherAsync(int id)
        {
            var result = await _mediator.Send(new GetBookByPublisherQuery() { PublisherId = id });
            return Ok(result);
        }
    }
}
