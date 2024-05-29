using BookStore.Models.Models;
using BookStore.Models.Models.Users;

namespace BookStore.DL.MemoryDb
{
    public static class InMemoryDb
    {
        public static List<Author> AuthorsData
            = new List<Author>()
            {
                new Author()
                {
                    Id = 1,
                    Name = "Ivan",
                    BirthDay = DateTime.Now
                },
                new Author()
                {
                    Id = 2,
                    Name = "Dimitar",
                    BirthDay = DateTime.Now
                },
                new Author()
                {
                    Id = 3,
                    Name = "Petar",
                    BirthDay = DateTime.Now
                },
            };

        public static List<Book> BookData
            = new List<Book>()
            {
                new Book()
                {
                    Id = Guid.NewGuid(),
                  Title = "Book 1",
                  AuthorId = 1,
                  ReleaseDate = new DateTime(2005,05,07)
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = "Book 4",
                    AuthorId = 1,
                    ReleaseDate = new DateTime(2007,05,07)
                },
                new Book()
                {
                    Id = Guid.NewGuid() ,
                    Title = "Book 2",
                    AuthorId = 2,
                    ReleaseDate = new DateTime(2015,05,07)
                },
                new Book()
                {
                    Id = Guid.NewGuid(),
                  Title = "Book 3",
                  AuthorId = 3,
                  ReleaseDate = new DateTime(2010,05,07)
                },
            };
    }
}
