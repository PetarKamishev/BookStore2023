using BookStore2023.BL.Interfaces;
using BookStore2023.Models.Requests;
using BookStore2023.Models.Responses;
using System.Reflection.Metadata.Ecma335;

namespace BookStore2023.BL.Services
{
   
    public class LibraryService : ILibraryService
    {
       
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public LibraryService(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
            
        }
        public GetAllBooksByAuthorResponse?
            GetAllByAuthorAfterReleaseDate(GetAllBooksByAuthorRequest request, DateTime afterDate)
        {
            var books = _bookService.GetAllByAuthorAfterReleaseDate(request.AuthorId, request.DateAfter);
            if (books.Count > 0)
            {
                var response = new GetAllBooksByAuthorResponse()
                {
                    Author = _authorService.GetAuthor(request.AuthorId),
                    Books = books.Where(b => b.ReleaseDate == afterDate).ToList()
                };
                return response;
            }
            return null;
        }
         
        }
    }

