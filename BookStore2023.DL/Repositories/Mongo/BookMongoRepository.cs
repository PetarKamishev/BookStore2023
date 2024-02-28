using BookStore.DL.Interfaces;
using BookStore.Models.Configurations;
using BookStore.Models.Models;
using BookStore.Models.Requests;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BookStore.DL.Repositories.Mongo
{
    public class BookMongoRepository : IBookRepository
    {
        IOptions<MongoConfiguration> _mongoConfig;
        private readonly IMongoCollection<Book> _books;
        public BookMongoRepository(IOptions<MongoConfiguration> mongoConfig)
        {
            _mongoConfig = mongoConfig;
            var client = new MongoClient(mongoConfig.Value.ConnectionString);

            var db = client.GetDatabase(mongoConfig.Value.DatabaseName);

            _books = db.GetCollection<Book>("Books");
        }
        public async Task Add(Book book)
        {
           await _books.InsertOneAsync(book);  
        }

        public async Task< List<Book>> GetAll()
        {
            return await _books.Find(b => true).ToListAsync();
           
        }
    
        public async Task<Book> GetById(int id)
        {
           var result =  await _books.FindAsync(b=> b.Id == id);
            return result.FirstOrDefault();
        }

        public async Task Remove(int id)
        {
            await _books.DeleteOneAsync(b => b.Id == id);
        }

        public async Task<List<Book>> GetAllByAuthor(int authorId)
        {
            return await _books.Find(b => b.AuthorId == authorId).ToListAsync();
        }
    }
}
