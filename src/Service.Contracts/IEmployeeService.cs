using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Employee;

namespace Service.Contracts;

public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
    EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges);
    EmployeeDto CreateEmployee(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges);
}
