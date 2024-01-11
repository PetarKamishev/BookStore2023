using BookStore.BL.Interfaces;
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
        public List<Author> GetAll()
        {
            return _authorService.GetAll();
        }

        [HttpGet("GetById")]
        public Author GetById(int id)
        {
            return _authorService.GetById(id);
        }

        [HttpPost]
        public void Add([FromBody]Author author)
        {
            _authorService.Add(author);
        }

        [HttpDelete]
        public void DeleteById(int id)
        {
            _authorService.Remove(id);
        }
    }
}
