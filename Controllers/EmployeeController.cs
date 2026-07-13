using Microsoft.AspNetCore.Mvc;
using SonarCubewithDotNet.Services;

namespace SonarCubewithDotNet.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    public IActionResult Index()
    {
        var employees = _employeeService.GetEmployees();

        return View(employees);
    }
}