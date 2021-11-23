using BarManager.DL.InMemoryDb;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BarManager.DL.Repositories.InMemoryRepos
{
    public class BillInMemoryRepository : IBillRepository
    {

        public BillInMemoryRepository()
        {

        }

        public Bill Create(Bill bill)
        {
            BillInMemoryCollection.BillDb.Add(bill);

            return bill;
        }

     

        public Bill Delete(int id)
        {
            var bill = BillInMemoryCollection.BillDb.FirstOrDefault(bill => bill.Id == id);

            BillInMemoryCollection.BillDb.Remove(bill);

            return bill;
        }

        public IEnumerable<Bill> GetAll()
        {
            return BillInMemoryCollection.BillDb;
        }

        public Bill GetById(int id)
        {
            return BillInMemoryCollection.BillDb.FirstOrDefault(x => x.Id == id);
        }

        public Bill Update(Bill  bill)
        {
            var result = BillInMemoryCollection.BillDb.FirstOrDefault(x => x.Id == bill.Id);

            result.Amount = bill.Amount;
            result.BillStatus = bill.BillStatus;
            result.Created = bill.Created;
            result.Finished = bill.Finished;
            result.PaymentType = bill.PaymentType;


            return result;
        }

    }
}
