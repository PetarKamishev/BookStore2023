using BookStore2023.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore2023.DL.Interfaces
{
    public interface IAuthorRepository
    {
        public void AddAuthor(Author author);

        public void UpdateAuthor(Author author);

        public void DeleteAuthor(int id);

        public Author? GetAuthor(int id);

        public List<Author> GetAllAuthors();
    }
}
