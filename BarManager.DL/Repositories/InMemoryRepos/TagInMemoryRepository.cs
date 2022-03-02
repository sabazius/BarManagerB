using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarManager.DL.InMemoryDb;

namespace BarManager.DL.Repositories.InMemoryRepos
{
    public class TagInMemoryRepository : ITagRepository
    {

        public TagInMemoryRepository()
        {
            
        }

        public Task<Tag> Create(Tag tag)
        {
            TagInMemoryCollection.TagDb.Add(tag);

            return Task.FromResult(tag);
        }

        public Task<Tag> Delete(int id)
        {
            var tag = TagInMemoryCollection.TagDb.FirstOrDefault(tag => tag.Id == id);

            TagInMemoryCollection.TagDb.Remove(tag);

            return Task.FromResult(tag);
        }

        public Task<IEnumerable<Tag>> GetAll()
        {
            return Task.FromResult(TagInMemoryCollection.TagDb.AsEnumerable());
        }

        public Task<Tag> GetById(int id)
        {
            return Task.FromResult(TagInMemoryCollection.TagDb.FirstOrDefault(x => x.Id == id));
        }

        public Task<Tag> Update(Tag tag)
        {
            var result = TagInMemoryCollection.TagDb.FirstOrDefault(x => x.Id == tag.Id);

            result.Name = tag.Name;

            return Task.FromResult(result);
        }
    }
}
