using BookStore.DL.Interfaces;
using BookStore.DL.MemoryDb;
using BookStore.Models.Configurations;
using BookStore.Models.Models;
using BookStore.Models.Models.Users;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.Repositories.Mongo
{
    public class AuthorMongoRepository : IAuthorRepository
    {
        IOptions<MongoConfiguration> _mongoConfig;
        private readonly IMongoCollection<Author> _authors;
        public AuthorMongoRepository(IOptions<MongoConfiguration> mongoConfig)
        {
            _mongoConfig = mongoConfig;
            var client = new MongoClient(mongoConfig.Value.ConnectionString);

            var db = client.GetDatabase(mongoConfig.Value.DatabaseName);

            _authors = db.GetCollection<Author>("Authors");
        }
        public async Task<List<Author>> GetAll()
        {
            return await _authors.Find(b => true).ToListAsync();
        }

        public async Task<Author> GetById(int id)
        {
            var result = await _authors.FindAsync(b => b.Id == id);
            return result.FirstOrDefault();
        }

        public async Task Add(Author author)
        {
            await _authors.InsertOneAsync(author);
        }

        public async Task Remove(int id)
        {
            await _authors.DeleteOneAsync(b => b.Id == id);
        }
    }
}
