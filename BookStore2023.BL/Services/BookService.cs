using BookStore2023.BL.Interfaces;
using BookStore2023.DL.Interfaces;
using BookStore2023.Models.Models;

namespace BookStore2023.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public void AddBook(Book book)
        {
           _bookRepository.AddBook(book);
        }

        public void DeleteBook(int id)
        {
           _bookRepository.DeleteBook(id);
        }

        public List<Book> GetAllBooks()
        {
          return  _bookRepository.GetAllBooks();
        }

        public Book? GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }

        public void UpdateBook(Book book)
        {
            _bookRepository.UpdateBook(book);
        }
    }
}
