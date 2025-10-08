using PrimeiraApi.Domain.DTO;

namespace PrimeiraApi.Domain.Repository;
using PrimeiraApi.Domain.Model;
public interface IEmployeeRepository
{
    void add(Employee employee);

    List<Employee> GetAllInfo(int pageNumber, int pageQuantity);
    
    List<EmployeeDTO> Get(int pageNumber, int pageQuantity);
    Employee? Get(int id);

}