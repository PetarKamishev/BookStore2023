using BookStore2023.Models.Models;
using BookStore2023.Models.Requests;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace BookStore2023.BL.Interfaces
{
    public class GetAllBooksByAuthorRequestValidator: AbstractValidator<GetAllBooksByAuthorRequest>
    {
        public GetAllBooksByAuthorRequestValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.DateAfter).NotEmpty()
                .NotNull();
        }
    }

}
