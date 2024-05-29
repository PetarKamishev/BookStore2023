using BookStore.BL.Interfaces;
using BookStore.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookProduceController : ControllerBase
    {
        private readonly IBookProduceService _bookProduceService;

        public BookProduceController(IBookProduceService bookProduceService)
        {
            _bookProduceService = bookProduceService;
        }

        [HttpPost("Produce")]
        public async Task<IActionResult> Produce([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            await _bookProduceService.ProduceBook(book);

            return Ok();
        }
    }
}
