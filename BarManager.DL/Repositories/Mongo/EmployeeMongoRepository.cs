using BarManager.DL.Interfaces;
using BarManager.Models.Common;
using BarManager.Models.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;

namespace BarManager.DL.Repositories.Mongo
{
    public class EmployeeMongoRepository : IEmployeeRepository
    {

        private readonly IMongoCollection<Employee> _employeeCollection;

        public EmployeeMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);
            _employeeCollection = database.GetCollection<Employee>("Employees");
        }
        public Employee Create(Employee employee)
        {
            _employeeCollection.InsertOne(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            var employee = GetById(id);
            _employeeCollection.DeleteOne(employee => employee.Id == id);

            return employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeCollection.Find(employee => true).ToList();
        }

        public Employee GetById(int id)
        {
            return _employeeCollection.Find(employee => employee.Id == id).FirstOrDefault();
        }

        public Employee Update(Employee employee)
        {
            _employeeCollection.ReplaceOne(employeeToReplace => employeeToReplace.Id == employee.Id, employee);
            return employee;
        }
    }
}
