using BookStore.Models.Models;
using BookStore.Models.Models.Users;

namespace BookStore.DL.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();

        Task<Book> GetById(int id);

        public Task Add(Book book);

        public Task Remove(int  id);

        Task<List<Book>> GetAllByAuthor(int authorId);
    }
}
