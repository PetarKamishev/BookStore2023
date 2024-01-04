using BookStore2023.BL.Interfaces;
using BookStore2023.Models.Requests;
using BookStore2023.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BookStore2023.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        [HttpPost("GetAllBooksByAuthorAndDate")]
        public GetAllBooksByAuthorResponse? GetAllBooksByAythorAndDate([FromBody] GetAllBooksByAuthorRequest request, DateTime afterDate)
        {
            return _libraryService.GetAllByAuthorAfterReleaseDate(request, afterDate);
        }
    }
}
