using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Domain.DTO;
using PrimeiraApi.Application.ViewModel;
using PrimeiraApi.Domain.Model.EmployeeAggregate;

namespace PrimeiraApi.Controllers;

[ApiController]
[Route("api/v1/employee")]
public class EmployeeController : ControllerBase
{   
    //chamando a interface/ vai usar isso pras rotas/ precisa ser colocada dentro de um construtor
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost]
    public IActionResult Add([FromForm]EmployeeViewModel employeeViewModel)
    {
        string? filePath = null;
        
        if (employeeViewModel.Photo != null)
        {
           filePath = Path.Combine("Storage", employeeViewModel.Photo.FileName);
           using Stream fileStream = new FileStream(filePath, FileMode.Create);
           employeeViewModel.Photo.CopyTo(fileStream);
        }
        
        
        var employee = new Employee(employeeViewModel.name, employeeViewModel.age, filePath);

        _employeeRepository.add(employee);
        return Created();
    }
    
    [Authorize]
    [HttpGet("{id}/donwload")]
    public IActionResult DonwloadPhoto(int id)
    {
       var employee = _employeeRepository.Get(id);
       var dataBytes = System.IO.File.ReadAllBytes(employee.photoUrl);
       return File(dataBytes, "image/jpeg");//ou app image/png imagem/jpeg
    }
    
    [Authorize]
    [HttpGet]
    public IActionResult Get(int pageNumber, int pageQuantity)
    {
        //throw new Exception("erro teste");
        var employees = _employeeRepository.GetAll(pageNumber, pageQuantity);
        return Ok(employees);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var employee = _employeeRepository.Get(id);
        var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
        return Ok(employeeDTO);
    }

}