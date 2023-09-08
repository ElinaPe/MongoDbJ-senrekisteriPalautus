using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbJäsenrekisteri.Models;

namespace MongoDbJäsenrekisteri.Service
{
    public class JasenService
    {
        private readonly IMongoCollection<Jasen> _jasenet;

        public JasenService(IOptions<JasenrekisteriSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _jasenet = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Jasen>(options.Value.JasenCollectionName);
        }
        public async Task<List<Jasen>> GetAsync() =>
            await _jasenet.Find(_ => true).ToListAsync();

        public async Task<Jasen> GetAsync(string id) =>
            await _jasenet.Find(j => j.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Jasen newJasen) =>
            await _jasenet.InsertOneAsync(newJasen);

        public async Task UpdateAsync(string id, Jasen updateJasen) =>
            await _jasenet.ReplaceOneAsync(j => j.Id == id, updateJasen);

        public async Task RemoveAsync(string id) =>
            await _jasenet.DeleteOneAsync(j => j.Id == id);

    }
}
