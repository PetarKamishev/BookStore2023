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

        public async Task <GetAllBooksByAuthorResponse> 
            GetAllBooksByAuthorAfterReleaseDate(
                GetAllBooksByAuthorRequest request)
        {
            var response = new GetAllBooksByAuthorResponse
            {
                Author = await _authorService
                    .GetById(request.AuthorId),
                Books = await _bookService
                    .GetAllByAuthorAfterReleaseDate(
                        request.AuthorId,
                        request.DateAfter)
            };

            return response;
        }
        public async Task<int> CheckBookCount(int input)
        {
            if (input < 1)
                return 0;
            var BookCount = await _bookService.GetAll();
            return BookCount.Count() + input;
        }
    }
}
