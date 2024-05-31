using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTranserObjects;

namespace Service;

internal sealed class CompanyService(
    IRepositoryManager repositoryManager,
    ILoggerManager logger,
    IMapper mapper
) : ICompanyService
{
    private readonly IRepositoryManager _repositoryManager = repositoryManager;
    private readonly ILoggerManager _logger = logger;
    private readonly IMapper _mapper = mapper;

    public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
    {
        var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);

        var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

        return companiesDto;
    }

    public CompanyDto GetCompany(Guid companyId, bool trackChanges)
    {
        var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);
        // Check if company is null

        var companyDto = _mapper.Map<CompanyDto>(company);

        return companyDto;
    }
}
