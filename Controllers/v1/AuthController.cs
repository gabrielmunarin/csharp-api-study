using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Application.Services;
using PrimeiraApi.Domain.Model.EmployeeAggregate;

namespace PrimeiraApi.Controllers.v1;
[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public IActionResult Auth(string username, string password)
    {
        if (username == "teste" && password == "123")
        {
            var token = TokenService.GenerateToken(new Employee("teste", 123, null));
            return Ok(token);
        }
        
        return Unauthorized();
    }
    
}