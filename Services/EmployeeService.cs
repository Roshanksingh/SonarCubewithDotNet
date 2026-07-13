using SonarCubewithDotNet.Models;

namespace SonarCubewithDotNet.Services;

public class EmployeeService : IEmployeeService
{
    public List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Alex",
                Department = "Software",
                Salary = 85000
            }
        };
    }
}