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
                Title="Book 1",
                AuthorId=1,
                ReleaseDate= new DateTime(2005, 05, 07)
            },
             new Book()
            {
                Id=4,
                Title="Book 4",
                AuthorId=1,
                ReleaseDate=new DateTime(2007, 05, 07)
              
            },
            new Book()
            {
                Id=2,
                Title="Book 2",
                AuthorId=2,
                ReleaseDate=new DateTime(2015, 05, 06)
            },
            new Book()
            {
                Id=3,
                Title="Book 3",
                AuthorId=3,
                ReleaseDate=new DateTime(2018, 08, 15)
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
