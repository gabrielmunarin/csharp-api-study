namespace PrimeiraApi.Application.ViewModel;

public class EmployeeViewModel
{
    public string name { get; set; }
    public int age  { get; set; }
    
    public IFormFile? Photo { get; set; }
}