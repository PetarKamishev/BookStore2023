using BookStore.Models.Requests;
using FluentValidation;
using System.Runtime.InteropServices;
 
namespace BookStore.Validators
{
        public class GetAllBooksByAuthorRequestValidator: AbstractValidator<GetAllBooksByAuthorRequest>
    {
        public GetAllBooksByAuthorRequestValidator()
        {
            RuleFor(x => x.AuthorId).NotEmpty(). GreaterThan(0);
            RuleFor(x => x.DateAfter).NotEmpty().GreaterThan(new DateTime(1950, 01, 01));
        }
    }

}

    