using AutoMapper;
using PrimeiraApi.Domain.DTO;
using PrimeiraApi.Domain.Model.EmployeeAggregate;

namespace PrimeiraApi.Application.Mapping;

public class DomainToDTOMapping : Profile
{
    public DomainToDTOMapping()
    {
        //create map employee, empployeeDTO ja mapei ok,
        //o forMember é usado pq no DTO um atributo esta com o nome diferente da entidade Employee
        CreateMap<Employee, EmployeeDTO>()
            .ForMember(dest => dest.NameEmployee,
                m => m.MapFrom((orig => orig.name)));
    }
}