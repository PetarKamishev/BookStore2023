
using BookStore2023.BL.Interfaces;
using BookStore2023.BL.Services;
using BookStore2023.DL.Interfaces;
using BookStore2023.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2023.Controllers
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

        [HttpGet("GetAuthor")]
        public Author? Get(int id)
        {
            if (id < 0) return null;
            return _authorService.GetAuthor(id);
        }

        [HttpGet("GetAllAuthors")]
        public List<Author> GetAllAuthors()
        {
            return _authorService.GetAllAuthors();
        }


        [HttpPost("AddAuthor")]

        public void Add([FromBody] Author author)
        {
            _authorService.AddAuthor(author);
        }

        [HttpPost("UpdateBook")]

        public void UpdateAuthor([FromBody] Author author)
        {
            _authorService.UpdateAuthor(author);
        }
        [HttpDelete("Delete")]

        public void Delete(int id)
        {
            _authorService.DeleteAuthor(id);
        }


    }
}
