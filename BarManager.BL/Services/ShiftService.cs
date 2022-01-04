using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace BarManager.BL.Services
{
    public class ShiftService : IShiftService
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly ILogger _logger;

        public ShiftService(IShiftRepository shiftRepository, ILogger logger)
        {
            _shiftRepository = shiftRepository;
            _logger = logger;
        }

        public Shift Create(Shift shift)
        {
            var index = _shiftRepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            shift.Id = (int)(index != null ? index + 1 : 1);

            return _shiftRepository.Create(shift);
        } 
        public Shift Update(Shift shift)
        {
            return _shiftRepository.Update(shift);
        }
        public Shift GetById(int id)
        {
            return _shiftRepository.GetById(id);
        }

        public Shift Delete(int id)
        {
            return _shiftRepository.Delete(id);
        }

        public IEnumerable<Shift> GetAll()
        {
            return _shiftRepository.GetAll();
        }

        

       
    }
}
