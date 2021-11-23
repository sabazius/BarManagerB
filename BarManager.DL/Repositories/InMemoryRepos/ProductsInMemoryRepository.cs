using BarManager.DL.InMemoryDb;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarManager.DL.Repositories.InMemoryRepos
{

    public class ProductsInMemoryRepository : IProductsRepository
    {

        public ProductsInMemoryRepository()
        {

        }

        public Products Create(Products products)
        {
            ProductsInMemoryCollection.ProductsDb.Add(products);

            return products;
        }

        public Products Delete(int id)
        {
            var products = ProductsInMemoryCollection.ProductsDb.FirstOrDefault(products => products.Id == id);

            ProductsInMemoryCollection.ProductsDb.Remove(products);

            return products;
        }

        public IEnumerable<Products> GetAll()
        {
            return ProductsInMemoryCollection.ProductsDb;
        }

        public Products GetById(int id)
        {
            return ProductsInMemoryCollection.ProductsDb.FirstOrDefault(x => x.Id == id);
        }

        public Products Update(Products products)
        {
            var result = ProductsInMemoryCollection.ProductsDb.FirstOrDefault(x => x.Id == products.Id);

            result.Name = products.Name;

            return result;
        }
    }
}



