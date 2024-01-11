using BookStore.Models.Models;
using BookStore.Models.Models.Users;

namespace BookStore.Models.Responses
{
    public class GetAllBooksByAuthorResponse
    {
        public Author Author { get; set; }

        public List<Book> Books { get; set; }
    }
}
