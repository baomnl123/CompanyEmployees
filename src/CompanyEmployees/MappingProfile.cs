using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Employee;

namespace CompanyEmployees;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(
                c => c.FullAddress,
                opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country))
            );

        CreateMap<Employee, EmployeeDto>();

        CreateMap<CompanyForCreationDto, Company>();

        CreateMap<EmployeeForCreationDto, Employee>();
    }
}
