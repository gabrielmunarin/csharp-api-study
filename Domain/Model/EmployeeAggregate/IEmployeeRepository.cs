using PrimeiraApi.Domain.DTO;

namespace PrimeiraApi.Domain.Model.EmployeeAggregate;

public interface IEmployeeRepository
{
    void add(Employee employee);

    List<Employee> GetAllInfo(int pageNumber, int pageQuantity);
    
    List<EmployeeDTO> GetAll(int pageNumber, int pageQuantity);
    Employee? Get(int id);

}