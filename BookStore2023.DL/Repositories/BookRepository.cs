using BookStore2023.DL.InMemoryDb;
using BookStore2023.DL.Interfaces;
using BookStore2023.Models.Models;
using System.Reflection;

namespace BookStore2023.DL.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void AddBook(Book book)
        {
           StaticData.Books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book =StaticData.Books.FirstOrDefault( b => b.Id==id);
            if (book == null) return;
            StaticData.Books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return StaticData.Books;
        }

        public Book? GetBook(int id)
        {
            return StaticData.Books.FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBook(Book book)
        {
            var existingbook = StaticData.Books.FirstOrDefault(b => b.Id == book.Id);

            if (existingbook == null) return;

            existingbook.Title = book.Title;
        }

        public List<Book> GetAllByAuthorAfterReleaseDate(int authorId, DateTime afterDate)
        {
            return InMemoryDb.StaticData.Books.Where(b=>b.AuthorId==authorId).ToList();
        }
    }
}
