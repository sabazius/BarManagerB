using System.Collections.Generic;
using BarManager.Models.DTO;

namespace BarManager.DL.Interfaces
{
    public interface ITagRepository
    {
        Tag Create(Tag tag);

        Tag Update(Tag tag);

        Tag Delete(int id);

        Tag GetById(int id);

        IEnumerable<Tag> GetAll();
    }
}
