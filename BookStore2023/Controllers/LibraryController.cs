using BookStore.BL.Interfaces;
using BookStore.Models.Requests;
using BookStore.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        [HttpPost("GetAllBooksByAuthorAndDate")]
        public GetAllBooksByAuthorResponse? 
            GetAllBooksByAuthorAndDate([FromBody]GetAllBooksByAuthorRequest request)
        {
            return _libraryService
                .GetAllBooksByAuthorAfterReleaseDate(request);
        }
        [HttpPost("GetAllBooksByAuthorRequestValidation")]
        public string GetAllBooksByAuthorRequestValidator(GetAllBooksByAuthorRequest request)
        {
            return "ok";
        }
    }
}
