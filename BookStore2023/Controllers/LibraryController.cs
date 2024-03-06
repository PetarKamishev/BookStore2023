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
        public async Task<IActionResult> GetBooksByAuthor(GetAllBooksByAuthorRequest request)
            {
            if (request == null) return BadRequest();
            var result = await _libraryService.GetAllBooksByAuthorAfterReleaseDate(request);
            if (result==null ) return NotFound();
            return Ok(result);
        }
        [HttpPost("GetAllBooksByAuthorRequestValidation")]
        public string GetAllBooksByAuthorRequestValidator(GetAllBooksByAuthorRequest request)
        {
            return "ok";
        }
    }
}
