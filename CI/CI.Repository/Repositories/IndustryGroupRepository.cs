using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CI.Model.Industries;
using CI.Model.IndustryGroups;
using CI.Model.Infrastructure.UnitOfWork;

namespace CI.Repository.Repositories
{
    public class IndustryGroupRepository : Repository<IndustryGroup>, IIndustryGroupRepository
    {
        public IndustryGroupRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
