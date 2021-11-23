using BarManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarManager.DL.InMemoryDb
{
    public class EmployeesInMemoryCollection
    {
        public static List<Employee> EmployeeDB = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                Name = "Employee1",
                ClientTable = new List<int>() { 1, 2, 3 },
                Type = Models.Enums.EmployeeType.Waiter
            },
            new Employee()
            {
                Id = 2,
                Name = "Employee2",
                ClientTable = new List<int>() { 1, 3, 2 },
                Type = Models.Enums.EmployeeType.Bartender
            },
            new Employee()
            {
                Id = 3,
                Name = "Employee3",
                ClientTable = new List<int>() { 3, 2, 1 },
                Type = Models.Enums.EmployeeType.Manager
            }




        };

    }
}

