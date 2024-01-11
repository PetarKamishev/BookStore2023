using BookStore.BL.Interfaces;
using BookStore.Models.Requests;
using BookStore.Models.Responses;

namespace BookStore.BL.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public LibraryService(
            IAuthorService authorService,
            IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        public GetAllBooksByAuthorResponse? 
            GetAllBooksByAuthorAfterReleaseDate(
                GetAllBooksByAuthorRequest request)
        {
            var response = new GetAllBooksByAuthorResponse
            {
                Author = _authorService
                    .GetById(request.AuthorId),
                Books = _bookService
                    .GetAllByAuthorAfterReleaseDate(
                        request.AuthorId,
                        request.DateAfter)
            };

            return response;
        }
    }
}
