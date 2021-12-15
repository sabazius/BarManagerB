using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.BL.Interfaces
{
   public interface IFurnituresService
    {
        Furnitures Create(Furnitures furnitures);

        Furnitures Update(Furnitures tag);

        Furnitures Delete(int id);

        Furnitures GetById(int id);

        IEnumerable<Furnitures> GetAll();
    }
}
