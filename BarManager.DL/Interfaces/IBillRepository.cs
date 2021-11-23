using System;
using System.Collections.Generic;
using BarManager.Models.DTO;

namespace BarManager.DL.Interfaces
{
    public interface IBillRepository
    {
        Bill Create(Bill bill);

        Bill Update(Bill bill);

        Bill Delete(int id);

        Bill GetById(int id);

        IEnumerable<Bill> GetAll();
    }
}
