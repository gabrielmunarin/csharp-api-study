namespace PrimeiraApi.Repository;
using PrimeiraApi.Model;
public interface IEmployeeRepository
{
    void add(Employee employee);

    List<Employee> Get();
    
    Employee? Get(int id);

}