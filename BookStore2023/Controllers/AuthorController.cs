using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.Models.Models;
using BookStore.Models.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _authorService.GetAll();
            if (result.Count == 0) return NoContent();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id < 0) return BadRequest(id);

            var result = await _authorService.GetById(id);
            return result != null ? Ok(result) : NotFound(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Author author)
        {
            if (author == null) return BadRequest();
            await _authorService.Add(author);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest(id);
            await _authorService.Remove(id);
            return Ok();
        }
    }
}
