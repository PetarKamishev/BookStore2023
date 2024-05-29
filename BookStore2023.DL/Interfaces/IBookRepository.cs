using BookStore.Models.Models;
using BookStore.Models.Models.Users;

namespace BookStore.DL.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();

        Task<Book> GetById(Guid id);

        public Task Add(Book book);

        public Task Remove(Guid  id);

        Task<List<Book>> GetAllByAuthor(int authorId);
    }
}
