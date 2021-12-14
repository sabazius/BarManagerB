using BarManager.DL.Interfaces;
using BarManager.Models.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using Products = BarManager.Models.DTO.Products;

namespace BarManager.DL.Repositories.Mongo
{
    public class ProductsMongoRepository : IProductsRepository
    {
        private readonly IMongoCollection<Products> _productsCollection;

        public ProductsMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _productsCollection = database.GetCollection<Products>("Products");
        }

        public Products Create(Products products)
        {
            _productsCollection.InsertOne(products);

            return products;
        }

        public Products Update(Products products)
        {
            _productsCollection.ReplaceOne(productsToReplace => productsToReplace.Id == products.Id, products);
            return products;
        }

        public Products Delete(int id)
        {
            var products = GetById(id);
            _productsCollection.DeleteOne(products => products.Id == id);

            return products;
        }

        public Products GetById(int id)
        {
            return _productsCollection.Find(products => products.Id == id).FirstOrDefault();
        }

        public IEnumerable<Products> GetAll()
        {
            return _productsCollection.Find(products => true).ToList();
        }
    }
}
