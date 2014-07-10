using CI.Model.CompanySizes;
using CI.Model.Infrastructure.UnitOfWork;

namespace CI.Repository.Repositories
{
    public class CompanySizeRepository : Repository<CompanySize>, ICompanySizeRepository
    {
        public CompanySizeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
