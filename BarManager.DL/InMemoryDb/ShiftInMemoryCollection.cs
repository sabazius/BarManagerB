using System.Collections.Generic;
using BarManager.Models.DTO;

namespace BarManager.DL.InShiftDb
{
    public static class ShiftInMemoryCollection
    {
        public static List<Shift> ShiftDB = new List<Shift>()
        {
            new Shift()
            {
                Id = 1,
                Name = "Ivan",
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Id = 1,
                        Name = "TestEmployee",
                        ClientTable = new List<int>() { 1, 2, 3 },
                        Type = Models.Enums.EmployeeType.Waiter
                    }
                }
            },
            new Shift()
            {
                Id = 2,
                Name = "Petko",
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Id = 1,
                        Name = "TestEmployee",
                        ClientTable = new List<int>() { 1, 2, 3 },
                        Type = Models.Enums.EmployeeType.Waiter
                    }
                }
            },
            new Shift()
            {
                Id = 3,
                Name = "Mitko",
                Employees = new List<Employee>()
                {
                    new Employee()
                    {
                        Id = 1,
                        Name = "TestEmployee",
                        ClientTable = new List<int>() { 1, 2, 3 },
                        Type = Models.Enums.EmployeeType.Waiter
                    }
                }
            }
        };
    }
}
