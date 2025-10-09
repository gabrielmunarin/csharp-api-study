using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeiraApi.Domain.Model.CompanyAggregate;

[Table("company")]
public class Company
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }

    public Company(int id, string name)
    {
        Id = id;
        Name = name;
    }
}