using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoDbJäsenrekisteri.Models
{
    public class JasenService
    {
        private readonly IMongoCollection<Jasen> _jasenet;

        public JasenService(IOptions<JasenrekisteriSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _jasenet = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<Jasen>(options.Value.JasenCollectionName);
        }
        public async Task<List<Jasen>> Get() =>
            await _jasenet.Find(_ => true).ToListAsync();

        public async Task<Jasen> Get(string id) =>
            await _jasenet.Find(j => j.Id == id).FirstOrDefaultAsync();

        public async Task Create(Jasen newJasen) =>
            await _jasenet.InsertOneAsync(newJasen);

        public async Task Update(string id, Jasen updateJasen) =>
            await _jasenet.ReplaceOneAsync(j => j.Id == id, updateJasen);

        public async Task Remove(string id) =>
            await _jasenet.DeleteOneAsync(j => j.Id == id);

    }
}
