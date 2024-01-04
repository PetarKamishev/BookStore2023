namespace BookStore2023.Models.Requests
{
    public class GetAllBooksByAuthorRequest
    {
        public int AuthorId { get; set; }

        public DateTime DateAfter { get; set; } 

        
    }
}
