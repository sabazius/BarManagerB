using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.BL.Services
{
    public class FurnituresService : IFurnituresService
    {

        private readonly IFurnituresRepository _furnituresRepository;

        public FurnituresService(IFurnituresRepository furnituresRepository)
        {
            _furnituresRepository = furnituresRepository;
        }

        public Furnitures Create(Furnitures furnitures)
        {
            return _furnituresRepository.Create(furnitures);
        }

        public Furnitures Delete(int id)
        {
            return _furnituresRepository.Delete(id);
        }

        public IEnumerable<Furnitures> GetAll()
        {
            return _furnituresRepository.GetAll();
        }

        public Furnitures GetById(int id)
        {
            return _furnituresRepository.GetById(id);
        }

        public Furnitures Update(Furnitures tag)
        {
            return _furnituresRepository.Update(tag);
        }
    }
}
