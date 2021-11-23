using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using BarManager.DL.InMemoryDb;

namespace BarManager.DL.Repositories.InMemoryRepos
{
    public class TagInMemoryRepository : ITagRepository
    {

        public TagInMemoryRepository()
        {
            
        }

        public Tag Create(Tag tag)
        {
            TagInMemoryCollection.TagDb.Add(tag);

            return tag;
        }

        public Tag Delete(int id)
        {
            var tag = TagInMemoryCollection.TagDb.FirstOrDefault(tag => tag.Id == id);

            TagInMemoryCollection.TagDb.Remove(tag);

            return tag;
        }

        public IEnumerable<Tag> GetAll()
        {
            return TagInMemoryCollection.TagDb;
        }

        public Tag GetById(int id)
        {
            return TagInMemoryCollection.TagDb.FirstOrDefault(x => x.Id == id);
        }

        public Tag Update(Tag tag)
        {
            var result = TagInMemoryCollection.TagDb.FirstOrDefault(x => x.Id == tag.Id);

            result.Name = tag.Name;

            return result;
        }
    }
}
