using BarManager.DL.Interfaces;
using BarManager.Models.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tag = BarManager.Models.DTO.Tag;

namespace BarManager.DL.Repositories.Mongo
{
    public class TagMongoRepository : ITagRepository
    {
        private readonly IMongoCollection<Tag> _tagCollection;

        public TagMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _tagCollection = database.GetCollection<Tag>("Tags");
        }

        public async Task<Tag> Create(Tag tag)
        {
            await _tagCollection.InsertOneAsync(tag);

            return tag;
        }

        public async Task<Tag> Update(Tag tag)
        {
            await _tagCollection.ReplaceOneAsync(tagToReplace => tagToReplace.Id == tag.Id, tag);
            return tag;
        }

        public async Task<Tag> Delete(int id)
        {
            var tag = await GetById(id);
            await _tagCollection.DeleteOneAsync(t => t.Id == id);

            return tag;
        }

        public async Task<Tag> GetById(int id)
        {
            var result = await _tagCollection.FindAsync(tag => tag.Id == id);

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            var result = await _tagCollection.FindAsync(tag => true);

            return result.ToList();
        }
    }
}
