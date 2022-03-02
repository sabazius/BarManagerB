using System;
using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace BarManager.BL.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly ILogger _logger;

        public TagService(ITagRepository tagRepository, ILogger logger)
        {
            _tagRepository = tagRepository;
            _logger = logger;
        }

        public async Task<Tag> Create(Tag tag)
        {
            var result = await _tagRepository.GetAll();

            var index = result.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            tag.Id = (int)(index != null ? index + 1 : 1);

            return await _tagRepository.Create(tag);
        }

        public async Task<Tag> Update(Tag tag)
        {
            return await _tagRepository.Update(tag);
        }

        public async Task<Tag> Delete(int id)
        {
            return await _tagRepository.Delete(id);
        }

        public async Task<Tag> GetById(int id)
        {
            return await _tagRepository.GetById(id);
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            _logger.Information("Tag GetAll Error");

            return await _tagRepository.GetAll();
        }
    }
}
