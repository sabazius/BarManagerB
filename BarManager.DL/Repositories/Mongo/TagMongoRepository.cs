using BarManager.DL.Interfaces;
using BarManager.Models.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
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

        public Tag Create(Tag tag)
        {
            _tagCollection.InsertOne(tag);

            return tag;
        }

        public Tag Update(Tag tag)
        {
            _tagCollection.ReplaceOne(tagToReplace => tagToReplace.Id == tag.Id, tag);
            return tag;
        }

        public Tag Delete(int id)
        {
            var tag = GetById(id);
            _tagCollection.DeleteOne(tag => tag.Id == id);

            return tag;
        }

        public Tag GetById(int id)
        {
            return _tagCollection.Find(tag => tag.Id == id).FirstOrDefault();
        }

        public IEnumerable<Tag> GetAll()
        {
            return _tagCollection.Find(tag => true).ToList();
        }
    }
}
