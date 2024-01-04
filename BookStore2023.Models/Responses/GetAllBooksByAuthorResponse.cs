using BookStore2023.Models.Models;

namespace BookStore2023.Models.Responses
{
    public class GetAllBooksByAuthorResponse
    {
        public Author Author { get; set; }
                    
        public List<Book> Books { get; set;}

    }
}
