using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController(IServiceManager service) : ControllerBase
{
    private readonly IServiceManager _service = service;

    [HttpGet]
    public IActionResult GetCompanies()
    {
        try
        {
            var companies = _service.Company.GetAllCompanies(trackChanges: false);
            return Ok(companies);
        }
        catch
        {
            return StatusCode(500, "Internal server error");
        }
    }
}
