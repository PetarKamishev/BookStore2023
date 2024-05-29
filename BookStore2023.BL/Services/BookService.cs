using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;

namespace BookStore.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<List<Book>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book> GetById(Guid id)
        {
           return await _bookRepository.GetById(id);
        }

        public async Task Add(Book book)
        {
           await _bookRepository.Add(book);
        }

        public async Task Remove(Guid id)
        {
            await _bookRepository.Remove(id);
        }

        public Task<List<Book>> GetAllByAuthorAfterReleaseDate
            (int authorId, DateTime afterDate)
        {

            return null; //_bookRepository.GetAllByAuthor(authorId).Where(b => b.ReleaseDate >= afterDate).ToList();

            
                
        }
    }
}
