using BarManager.DL.Interfaces;
using BarManager.Models.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using Client = BarManager.Models.DTO.Client;

namespace BarManager.DL.Repositories.Mongo
{
    public class ClientMongoRepository : IClientRepository
    {
        private readonly IMongoCollection<Client> _clientCollection;

        public ClientMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _clientCollection = database.GetCollection<Client>("Clients");
        }

        public Client Create(Client client)
        {
            _clientCollection.InsertOne(client);

            return client;
        }

        public Client Update(Client client)
        {
            _clientCollection.ReplaceOne(clientToReplace => clientToReplace.Id == client.Id, client);
            return client;
        }

        public Client Delete(int id)
        {
            var client = GetById(id);
            _clientCollection.DeleteOne(client => client.Id == id);

            return client;
        }

        public Client GetById(int id)
        {
            return _clientCollection.Find(client => client.Id == id).FirstOrDefault();
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientCollection.Find(client => true).ToList();
        }
    }
}
