using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.DL.Interfaces
{
    public interface IClientRepository
    {
        Client Create(Client client);

        Client Update(Client client);

        Client Delete(int id);

        Client GetById(int id);

        IEnumerable<Client> GetAll();
    }
}
