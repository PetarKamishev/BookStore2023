using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.DL.Repositories;
using BookStore.Models.Models;
using BookStore.Models.Models.Users;
using BookStore.Models.Requests;
using Moq;

namespace BookStoreTest
{
    public class LibraryServiceTests

    {

        public static List<Book> BookData
           = new List<Book>()
           {
                new Book()
                {
                    Id = 1,
                  Title = "Book 1",
                  AuthorId = 1,
                  ReleaseDate = new DateTime(2005,05,07)
                },
                new Book()
                {
                    Id = 4,
                    Title = "Book 4",
                    AuthorId = 1,
                    ReleaseDate = new DateTime(2007,05,07)
                },
                new Book()
                {
                    Id = 2,
                    Title = "Book 2",
                    AuthorId = 2,
                    ReleaseDate = new DateTime(2015,05,07)
                },
                new Book()
                {
                    Id = 3,
                  Title = "Book 3",
                  AuthorId = 3,
                  ReleaseDate = new DateTime(2010,05,07)
                },
           };
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

        [Fact]
        public void CheckBookCount_OK()
        {
            //setup
            var input = 10;
            var expectedCount = 14;

            var mockedBookRepository = new Mock<IBookRepository>();

            
            mockedBookRepository.Setup(
                x => x.GetAll()).Returns(BookData);

            // inject
            var bookService = new BookService(mockedBookRepository.Object);
            var authorService = new AuthorService(new AuthorRepository());
            var service = new LibraryService(authorService, bookService);

            //Act
            var result = service.CheckBookCount(input);

            //Assert
            Assert.Equal(expectedCount, result);

        }
        [Fact]
        public void NegativeInput()
        {
            //setup
            var input = -10;
            var expectedCount = 0;

            var mockedBookRepository = new Mock<IBookRepository>();

            
            mockedBookRepository.Setup(
                x => x.GetAll()).Returns(BookData);

            // inject
            var bookService = new BookService(mockedBookRepository.Object);
            var authorService = new AuthorService(new AuthorRepository());
            var service = new LibraryService(authorService, bookService);

            //Act
            var result = service.CheckBookCount(input);

            //Assert
            Assert.Equal(expectedCount, result);

        }
        [Fact]
        public void GetAllByAuthorAfterReleaseDate_OK()
        {
            //setup
            var request = new GetAllBooksByAuthorRequest
            {
                AuthorId = 1,
                DateAfter = new DateTime(2000, 1, 1)
        };
            var expectedCount = 2;

            var mockedBookRepository = new Mock<IBookRepository>();
            var mockedAuthorRepository = new Mock<IAuthorRepository>();

            mockedBookRepository.Setup(
                x => x.GetAllByAuthor(request.AuthorId)).Returns(BookData.Where(b => b.AuthorId == request.AuthorId).ToList());
            mockedAuthorRepository.Setup(
                x => x.GetById(request.AuthorId)).Returns(AuthorsData.FirstOrDefault(x=> x.Id == request.AuthorId)!);

            // inject
            var bookService = new BookService(mockedBookRepository.Object);
            var authorService = new AuthorService(mockedAuthorRepository.Object);
            var service = new LibraryService(authorService, bookService);

            //Act
            var result = service.GetAllBooksByAuthorAfterReleaseDate(request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Books.Count);
            
        }
    }

    
}