using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using BarManager.DL.InMemoryDb;


namespace BarManager.DL.Repositories.InMemoryRepos
{
    public class EmployeesInMemoryRepository : IEmployeeRepository
    {

        public EmployeesInMemoryRepository()
        {

        }

        public Employee Create(Employee employee)
        {
            EmployeesInMemoryCollection.EmployeeDB.Add(employee);

            return employee;
        }
        public Employee Delete(int id)
        {
            var employee = EmployeesInMemoryCollection.EmployeeDB.FirstOrDefault(employee => employee.Id == id);
            EmployeesInMemoryCollection.EmployeeDB.Remove(employee);
            return employee;
        }

        public Employee GetById(int id)
        {
            return EmployeesInMemoryCollection.EmployeeDB.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return EmployeesInMemoryCollection.EmployeeDB;
        }
        public Employee Update(Employee employee)
        {
            {

                var result = EmployeesInMemoryCollection.EmployeeDB.FirstOrDefault(x => x.Id == employee.Id);

                result.Name = employee.Name;

                return result;

            }
        }
    }
}

