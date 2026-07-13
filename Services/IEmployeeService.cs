using SonarCubewithDotNet.Models;

namespace SonarCubewithDotNet.Services;

public interface IEmployeeService
{
    List<Employee> GetEmployees();
}