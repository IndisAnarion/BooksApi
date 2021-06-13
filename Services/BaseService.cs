using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApi.Interfaces;
using BooksApi.Services.Interfaces;
using MongoDB.Driver;

namespace BooksApi.Services
{
    public class BaseService<T> : IService<T> where T : IEntity
    {
        private readonly IMongoCollection<T> collection;
        public BaseService(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            collection = database.GetCollection<T>(typeof(T).Name.ToLower());
        }
        public async Task<T> CreateAsync(T document)
        {
            await collection.InsertOneAsync(document).ConfigureAwait(false);
            return document;
        }

        public async Task<List<T>> GetAsync()
        {
            var result = await collection.FindAsync(c => true).ConfigureAwait(false);
            return result.ToList();
        }


        public async Task<T> GetAsync(string id)
        {
            var result = await collection.FindAsync(c => c.Id == id).ConfigureAwait(false);
            return result.FirstOrDefault();
        }

        public async Task RemoveAsync(T document)
        {
            await collection.DeleteOneAsync(d => d.Id == document.Id).ConfigureAwait(false);
        }

        public async Task RemoveAsync(string id)
        {
            await collection.DeleteOneAsync(d => d.Id == id).ConfigureAwait(false);
        }

        public async Task UpdateAsync(string id, T document)
        {
           await collection.ReplaceOneAsync(d=> d.Id == id, document);
        }
    }
}