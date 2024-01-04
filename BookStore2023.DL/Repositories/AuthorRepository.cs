using BookStore2023.DL.InMemoryDb;
using BookStore2023.DL.Interfaces;
using BookStore2023.Models.Models;
using System.Reflection;

namespace BookStore2023.DL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public void AddAuthor(Author author)
        {
            StaticData.Authors.Add(author);
        }

        public void DeleteAuthor(int id)
        {
            var author = StaticData.Authors.FirstOrDefault(b => b.Id == id);
            if (author == null) return;
            StaticData.Authors.Remove(author);
        }

        public List<Author> GetAllAuthors()
        {
            return StaticData.Authors;
        }

        public Author? GetAuthor(int id)
        {
            return InMemoryDb.StaticData.Authors.FirstOrDefault(b => b.Id == id);
        }

        public void UpdateAuthor(Author author)
        {
            var existingauthor = StaticData.Authors.FirstOrDefault(b => b.Id == author.Id);

            if (existingauthor == null) return;

            existingauthor.Name = author.Name;
        }
    }
}