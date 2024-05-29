using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.Models.Models;
using BookStore.Models.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.GetAll();
            if (result.Count==0) return NoContent();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (id.Equals(0)) return BadRequest(id);

            var result = await _bookService.GetById(id);
            return result != null ? Ok(result) : NotFound(id);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            await _bookService.Add(book);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(id.Equals(0)) return BadRequest(id);
            await _bookService.Remove(id);
            return Ok();
        }
    }
}
