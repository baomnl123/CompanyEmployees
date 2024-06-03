using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Employee;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies/{companyId}/employees")]
[ApiController]
public class EmployeesController(IServiceManager service) : ControllerBase
{
    private readonly IServiceManager _service = service;

    [HttpGet]
    public IActionResult GetEmployees(Guid companyId)
    {
        var employees = _service.Employee.GetEmployees(companyId, trackChanges: false);
        return Ok(employees);
    }

    [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
    public IActionResult GetEmployee(Guid companyId, Guid id)
    {
        var employee = _service.Employee.GetEmployee(companyId, id, trackChanges: false);
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult CreateEmployeeForCompany(
        Guid companyId,
        [FromBody] EmployeeForCreationDto employee
    )
    {
        if (employee == null)
            return BadRequest("EmployeeForCreationDto object is null");

        var employeeToReturn = _service.Employee.CreateEmployee(
            companyId,
            employee,
            trackChanges: false
        );

        return CreatedAtRoute(
            "GetEmployeeForCompany",
            new { companyId, employeeToReturn.Id },
            employeeToReturn
        );
    }
}
