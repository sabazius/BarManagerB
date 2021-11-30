using System;
using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
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

        public Tag Create(Tag tag)
        {
            return _tagRepository.Create(tag);
        }

        public Tag Update(Tag tag)
        {
            return _tagRepository.Update(tag);
        }

        public Tag Delete(int id)
        {
            return _tagRepository.Delete(id);
        }

        public Tag GetById(int id)
        {
            return _tagRepository.GetById(id);
        }

        public IEnumerable<Tag> GetAll()
        {
            _logger.Information("Tag GetAll Error");

            return _tagRepository.GetAll();
        }
    }
}
