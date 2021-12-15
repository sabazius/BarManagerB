using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.DL.Interfaces
{
    public interface IFurnituresRepository
    {
        Furnitures Create(Furnitures furnitures);
        Furnitures Update(Furnitures furnitures);
        Furnitures Delete(int id);
        Furnitures GetById(int id);

        IEnumerable<Furnitures> GetAll();
    }
}
