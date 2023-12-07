using BookStore2023.Models.Models;

namespace BookStore2023.DL.Interfaces
{
    public interface IBookRepository
    {
        public void AddBook(Book book);
        
        public void UpdateBook(Book book);

        public void DeleteBook(int id);

        public Book? GetBook(int id);

        public List<Book> GetAllBooks();

    }
}
