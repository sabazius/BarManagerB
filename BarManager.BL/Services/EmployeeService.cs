using BarManager.BL.Interfaces;
using BarManager.DL.Interfaces;
using BarManager.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace BarManager.BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeerepository;

        public EmployeeService(IEmployeeRepository employeerepository)
        {
            _employeerepository = employeerepository;
        }
        public Employee Create(Employee employee)
        {
            var index = _employeerepository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault()?.Id;

            employee.Id = (int)(index != null ? index + 1 : 1);

            return _employeerepository.Create(employee);
        }

        public Employee Delete(int id)
        {
            return _employeerepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeerepository.GetAll();
        }

        public Employee GetById(int id)
        {
            return _employeerepository.GetById(id);
        }

        public Employee Update(Employee employee)
        {
            return _employeerepository.Update(employee);
        }
    }
}
