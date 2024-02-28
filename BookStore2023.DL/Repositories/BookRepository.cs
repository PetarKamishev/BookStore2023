using BookStore.DL.Interfaces;
using BookStore.DL.MemoryDb;
using BookStore.Models.Models;

namespace BookStore.DL.Repositories
{
    public class BookRepository //: IBookRepository
    {
        public List<Book> GetAll()
        {
            return InMemoryDb.BookData;
        }

        public Book GetById(int id)
        {
            return InMemoryDb.BookData
                .First(a => a.Id == id);
        }

        public void Add(Book author)
        {
            InMemoryDb.BookData.Add(author);
        }

        public void Remove(int id)
        {
            var author = GetById(id);
            InMemoryDb.BookData.Remove(author);
        }

        public List<Book> GetAllByAuthor(int authorId)
        {
            return InMemoryDb.BookData
                .Where(b => b.AuthorId == authorId)
                .ToList();
        }
    }
}
