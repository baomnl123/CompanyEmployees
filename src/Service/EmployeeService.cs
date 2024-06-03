using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Employee;

namespace Service;

internal sealed class EmployeeService(
    IRepositoryManager repositoryManager,
    ILoggerManager logger,
    IMapper mapper
) : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly ILoggerManager _logger = logger;
    private readonly IMapper _mapper = mapper;

    public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company == null)
            throw new CompanyNotFoundException(companyId);

        var employees = _repositoryManager.Employee.GetEmployees(companyId, trackChanges);
        var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

        return employeesDto;
    }

    public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company == null)
            throw new CompanyNotFoundException(companyId);

        var employee = _repositoryManager.Employee.GetEmployee(companyId, id, trackChanges);
        if (employee == null)
            throw new EmployeeNotFoundException(id);

        var employeeDto = _mapper.Map<EmployeeDto>(employee);

        return employeeDto;
    }

    public EmployeeDto CreateEmployee(
        Guid companyId,
        EmployeeForCreationDto employeeForCreation,
        bool trackChanges
    )
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        if (company == null)
            throw new CompanyNotFoundException(companyId);

        var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

        _repositoryManager.Employee.CreateEmployee(companyId, employeeEntity);
        _repositoryManager.Save();

        var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
        return employeeToReturn;
    }
}
