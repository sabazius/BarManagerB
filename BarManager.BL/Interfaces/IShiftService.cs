using BarManager.Models.DTO;
using System.Collections.Generic;

namespace BarManager.BL.Interfaces
{
    public interface IShiftService
    {
        Shift Create(Shift shift);

        Shift Update(Shift shift);

        Shift Delete(int id);

        Shift GetById(int id);

        IEnumerable<Shift> GetAll();
    }
}
