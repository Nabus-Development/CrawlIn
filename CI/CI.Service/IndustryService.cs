using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CI.Model.Industries;
using CI.Model.IndustryGroups;
using CI.Model.Infrastructure;
using CI.Model.Infrastructure.UnitOfWork;
using CI.Service.Messaging;

namespace CI.Service
{
    public class IndustryService
    {
        private IIndustryRepository _industryRepository;
        private IIndustryGroupRepository _industryGroupRepository;
        private IUnitOfWork _unitOfWork;

        public IndustryService(IIndustryRepository industryRepository, IIndustryGroupRepository industryGroupRepository, IUnitOfWork unitOfWork)
        {
            _industryRepository = industryRepository;
            _industryGroupRepository = industryGroupRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateIndustries(CreateIndustriesRequest createIndustriesRequest)
        {
            var industryCodeRowsGroupedByIndustryGroup = createIndustriesRequest.IndustryCodeRows.GroupBy(r => r.Group);

            foreach (var group in industryCodeRowsGroupedByIndustryGroup)
            {
                IndustryGroup industryGroup = new IndustryGroup();
                industryGroup.GroupName = group.First().Group;

                _industryGroupRepository.Add(industryGroup);

                foreach (var industryCodeRow in group)
                {
                    Industry industry = new Industry();
                    industry.Code = industryCodeRow.Code;
                    industry.Group = industryGroup;
                    industry.Description = industryCodeRow.Description;

                    _industryRepository.Add(industry);
                }
            }

            _unitOfWork.Commit();
        }
    }
}
