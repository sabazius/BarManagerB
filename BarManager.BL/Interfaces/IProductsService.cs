using BarManager.Models.DTO;
using System.Collections.Generic;

namespace BarManager.BL.Interfaces
{
    public interface IProductsService
    {
        Products Create(Products products);

        Products Update(Products products);

        Products Delete(int id);

        Products GetById(int id);

        IEnumerable<Products> GetAll();
    }
}
