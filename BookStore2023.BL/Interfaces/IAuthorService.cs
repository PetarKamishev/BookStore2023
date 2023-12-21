using BookStore2023.Models.Models;

namespace BookStore2023.BL.Interfaces
{
    public interface IAuthorService
    {
        public void AddAuthor(Author author);

        public void UpdateAuthor(Author author);

        public void DeleteAuthor(int id);

        public Author? GetAuthor(int id);

        public List<Author> GetAllAuthors();

    }
}
