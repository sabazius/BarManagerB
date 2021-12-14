using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.DL.Interfaces
{
    public interface IFurnituresRepository
    {
        Furnitures Create(Furnitures furnitures);
        Furnitures Update(Furnitures name);
        Furnitures Delete(int id);
        Furnitures GetById(int id);

        IEnuberable<Furnitures> GetAll();
    }
}
