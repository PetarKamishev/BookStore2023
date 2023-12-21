using BookStore2023.Models.Models;

namespace BookStore2023.DL.InMemoryDb
{
    public static class StaticData
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book()
            {
                Id=1,
                Title="Book 1"
            },
            new Book()
            {
                Id=2,
                Title="Book 2"
            },
            new Book()
            {
                Id=3,
                Title="Book 3"
            }
        };

        public static List<Author> Authors = new List<Author>()
        {
            new Author()
            {
                Id = 1,
                Name = "Ivan"
            },
            new Author()
            {
                Id = 2,
                Name = "Mitko"
            },
            new Author()
            {
                Id = 3,
                Name = "Petar"
            }
        };
    }
}
