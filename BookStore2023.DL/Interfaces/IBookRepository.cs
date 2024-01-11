using BookStore.Models.Models;
using BookStore.Models.Models.Users;

namespace BookStore.DL.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll();

        Book GetById(int id);

        void Add(Book book);

        void Remove(int  id);

        List<Book> GetAllByAuthor(int authorId);
    }
}
