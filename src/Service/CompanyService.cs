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
}
