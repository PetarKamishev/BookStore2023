using BookStore2023.Models.Models;
using System;


namespace BookStore2023.BL.Interfaces
{
    public interface IAuthorService
    {
        List<Author> GetAll();

        Author GetById(int id);

        void Add(Author author);

        void Remove(int id);
    }
}