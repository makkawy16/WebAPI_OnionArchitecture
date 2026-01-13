using Contracts.RegisterServices;

namespace Contracts.Repositories
{
    public interface IRepositoryManager : IScopedService
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
