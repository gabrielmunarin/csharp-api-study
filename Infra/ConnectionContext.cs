using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Domain.Model.CompanyAggregate;
using PrimeiraApi.Domain.Model.EmployeeAggregate;

namespace PrimeiraApi.Infra;


//arquivo de conexao com o banco
public class ConnectionContext : DbContext
{
    //procura a tabela no banco e mapeia - ORM
    public DbSet<Employee> Employees{ get; set; }
    public DbSet<Company>  Companies{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(
        "Server=localhost;" +
        "Port=5432;Database=cadastro_funcionarios;" +
        "User Id=postgres;" +
        "Password=root;");
    //tinha q ter um env pra essas info nao?
}