using System.Collections.Generic;
using System.Threading.Tasks;
using BarManager.Models.DTO;

namespace BarManager.DL.Interfaces
{
    public interface ITagRepository
    {
        Task<Tag> Create(Tag tag);

        Task<Tag> Update(Tag tag);

        Task<Tag> Delete(int id);

        Task<Tag> GetById(int id);

        Task<IEnumerable<Tag>> GetAll();
    }
}
