using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.BL.Interfaces
{
   public interface IFurnituresService
    {
        Furnitures Create(Furnitures furnitures);

        Furnitures Update(Furnitures name);

        Furnitures Delete(int id);

        Furnitures GetById(int id);

        IEnuberable<Furnitures> GetAll();
    }
}
