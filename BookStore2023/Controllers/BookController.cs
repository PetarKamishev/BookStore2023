
using BookStore2023.BL.Interfaces;
using BookStore2023.BL.Services;
using BookStore2023.DL.Interfaces;
using BookStore2023.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2023.Controllers
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

        [HttpGet("GetBook")]
        public Book? Get(int id)
        {
            if (id < 0) return null;
            return _bookService.GetBook(id);
        }

        [HttpGet("GetAllBooks")]
        public List<Book> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }


        [HttpPost("Add")]

        public void Add([FromBody] Book book)
        {
            _bookService.AddBook(book);
        }

        [HttpPost("UpdateBook")]

        public void UpdateBook([FromBody] Book book)
        {
            _bookService.UpdateBook(book);
        }
        [HttpDelete("Delete")]

        public void Delete(int id)
        {
            _bookService.DeleteBook(id);
        }


    }
}
