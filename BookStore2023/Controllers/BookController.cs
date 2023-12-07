using BookStore2023.DL.Interfaces;
using BookStore2023.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2023.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public Book? Get(int id)
        {
            if (id < 0) return null;
            return _bookRepository.GetBook(id);
        }

    }
}
