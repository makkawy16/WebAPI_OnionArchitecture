using Contracts.Repositories;
using Entities.Models;
using Repository.Context;

namespace Repository.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appContext) : base(appContext)
        {
        }
    }
}
