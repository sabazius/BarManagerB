using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using BarManager.DL.InShiftDb;

namespace BarManager.DL.Repositories.InMemoryRepos
{
    public class ShiftInMemoryRepository : IShiftRepository
    {
        public ShiftInMemoryRepository()
        {

        }
        public Shift Create(Shift shift)
        {
            ShiftInMemoryCollection.ShiftDB.Add(shift);

            return shift;
        }

        public Shift Delete(int id)
        {
            var shift = ShiftInMemoryCollection.ShiftDB.FirstOrDefault(shift => shift.Id == id);

            ShiftInMemoryCollection.ShiftDB.Remove(shift);

            return shift;
        }

        public IEnumerable<Shift> GetAll()
        {
            return ShiftInMemoryCollection.ShiftDB;
        }

        public Shift GetById(int id)
        {
            return ShiftInMemoryCollection.ShiftDB.FirstOrDefault(x => x.Id == id);
        }

        public Shift Update(Shift shift)
        {
            var result = ShiftInMemoryCollection.ShiftDB.FirstOrDefault(x => x.Id == shift.Id);

            result.Name = shift.Name;

            return result;
        }
    }
}
