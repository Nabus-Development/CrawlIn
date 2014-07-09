using CI.Model.Industries;
using CI.Model.Infrastructure.UnitOfWork;

namespace CI.Repository.Repositories
{
    public class IndustryRepository : Repository<Industry>, IIndustryRepository
    {
        public IndustryRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
