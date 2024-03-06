using BookStore.Models.Models;

namespace BookStore.BL.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();

        Task<Book> GetById(int id);

        Task Add(Book book);

        Task Remove(int id);

        public Task<List<Book>>
            GetAllByAuthorAfterReleaseDate(
                int authorId,
                DateTime afterDate);
    }
}
