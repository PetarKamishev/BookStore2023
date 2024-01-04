using BookStore2023.Models.Requests;
using BookStore2023.Models.Responses;

namespace BookStore2023.BL.Interfaces
{
    public interface ILibraryService
    {
        GetAllBooksByAuthorResponse? GetAllByAuthorAfterReleaseDate(GetAllBooksByAuthorRequest request, DateTime afterDate);
    }
}
