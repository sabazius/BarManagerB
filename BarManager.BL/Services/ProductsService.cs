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
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ILogger _logger;

        public ProductsService(IProductsRepository productsRepository, ILogger logger)
        {
            _productsRepository = productsRepository;
            _logger = logger; 
        }

        public Products Create(Products products)
        {
            var index = _productsRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            products.Id = (int)(index != null ? index + 1 : 1);

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
