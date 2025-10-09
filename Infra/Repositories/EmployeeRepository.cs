using PrimeiraApi.Domain.DTO;
using PrimeiraApi.Domain.Model.EmployeeAggregate;

namespace PrimeiraApi.Infra;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ConnectionContext _context = new ConnectionContext();
        
    public void add(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public List<Employee> GetAllInfo(int pageNumber, int pageQuantity)
    {
        return _context.Employees.ToList();
    }

    public List<EmployeeDTO> GetAll(int pageNumber, int pageQuantity)
    {   
        
        //usando o .Select/forma mais manual de converter entidade(model) pra DTO
        return _context.Employees.Skip(pageNumber * pageQuantity)
            .Take(pageQuantity).Select(b => 
            new EmployeeDTO()
            {
                Id = b.id,
                NameEmployee = b.name,
                Photo = b.photoUrl,
            })
            .ToList();
        
    }

    public Employee? Get(int id)
    {
        return _context.Employees.Find(id);
    } 
}