using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;

namespace BarManager.BL.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client Create(Client client)
        {
            return _clientRepository.Create(client);
        }

        public Client Update(Client client)
        {
            return _clientRepository.Update(client);
        }

        public Client Delete(int id)
        {
            return _clientRepository.Delete(id);
        }

        public Client GetById(int id)
        {
            return _clientRepository.GetById(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }
    }
}
