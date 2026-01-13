using Contracts.Repositories;
using Entities.Models;
using Repository.Context;

namespace Repository.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}
