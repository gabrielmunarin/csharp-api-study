using Microsoft.AspNetCore.Mvc;
using PrimeiraApi.Application.Services;
using PrimeiraApi.Domain.Model;

namespace PrimeiraApi.Controllers;
[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    [HttpPost]
    public IActionResult Auth(string username, string password)
    {
        if (username == "teste" && password == "123")
        {
            var token = TokenService.GenerateToken(new Employee());
            return Ok(token);
        }
        
        return Unauthorized();
    }
    
}