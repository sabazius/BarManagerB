using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;

namespace BarManager.BL.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;

        public BillService(IBillRepository billRepository)
        {
           _billRepository = billRepository;
        }

        public Bill Create(Bill bill)
        {
            return _billRepository.Create(bill);
        }

        public Bill Update(Bill bill)
        {
            return _billRepository.Update(bill);
        }

        public Bill Delete(int id)
        {
            return _billRepository.Delete(id);
        }

        public Bill GetById(int id)
        {
            return _billRepository.GetById(id);
        }

        public IEnumerable<Bill> GetAll()
        {
            return _billRepository.GetAll();
        }
    }
}
