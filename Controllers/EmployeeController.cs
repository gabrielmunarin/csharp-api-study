using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Model;
using PrimeiraApi.Repository;
using PrimeiraApi.ViewModel;

namespace PrimeiraApi.Controllers;

[ApiController]
[Route("api/v1/employee")]
public class EmployeeController : ControllerBase
{   
    //chamando a interface/ vai usar isso pras rotas/ precisa ser colocada dentro de um construtor
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
    }
    
    [HttpPost]
    public IActionResult Add([FromForm]EmployeeViewModel employeeViewModel)
    {
        var filePath = Path.Combine("Storage", employeeViewModel.Photo.FileName);
        using Stream fileStream = new FileStream(filePath, FileMode.Create);
        employeeViewModel.Photo.CopyTo(fileStream);
        
        var employee = new Employee(employeeViewModel.name, employeeViewModel.age, filePath);

        _employeeRepository.add(employee);
        return Created();
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        var employees = _employeeRepository.Get();
        return Ok(employees);
    }

}