using BookStore2023.Models.Models;

namespace BookStore2023.BL.Interfaces
{
    public interface IBookService
    {
        public void AddBook(Book book);

        public void UpdateBook(Book book);

        public void DeleteBook(int id);

        public Book? GetBook(int id);

        public List<Book> GetAllBooks();

    }
}
