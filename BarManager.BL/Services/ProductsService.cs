using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;

namespace BarManager.BL.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Products Create(Products products)
        {
            return _productsRepository.Create(products);
        }

        public Products Update(Products products)
        {
            return _productsRepository.Update(products);
        }

        public Products Delete(int id)
        {
            return _productsRepository.Delete(id);
        }

        public Products GetById(int id)
        {
            return _productsRepository.GetById(id);
        }

        public IEnumerable<Products> GetAll()
        {
            return _productsRepository.GetAll();
        }
    }
}
