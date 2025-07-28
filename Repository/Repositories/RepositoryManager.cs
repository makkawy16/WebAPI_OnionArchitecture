using Contracts.Repositories;
using Repository.Context;

namespace Repository.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext appDbContext;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<ICompanyRepository> _companyRepository;

        public RepositoryManager(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(appDbContext));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(appDbContext));
        }

        public ICompanyRepository Company => _companyRepository.Value;

        public IEmployeeRepository Employee => _employeeRepository.Value;

        public void Save()
        => appDbContext.SaveChanges();
    }
}
