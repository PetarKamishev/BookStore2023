using BookStore.Models.Models;

namespace BookStore.BL.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();

        Task<Book> GetById(Guid id);

        Task Add(Book book);

        Task Remove(Guid id);

        public Task<List<Book>>
            GetAllByAuthorAfterReleaseDate(
                int authorId,
                DateTime afterDate);
    }
}
