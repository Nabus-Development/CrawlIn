using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CI.Model.Industries;
using CI.Model.Infrastructure;
using CI.Model.Infrastructure.UnitOfWork;
using CI.Service.Messaging;

namespace CI.Service
{
    public class IndustryService
    {
        private IIndustryRepository _industryRepository;
        private IUnitOfWork _unitOfWork;

        public IndustryService(IIndustryRepository industryRepository, IUnitOfWork unitOfWork)
        {
            _industryRepository = industryRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateIndustries(CreateIndustriesRequest createIndustriesRequest)
        {
            foreach (IndustryCodeRow industryCodeRow in createIndustriesRequest.IndustryCodeRows)
            {
                Industry industry = new Industry();
                industry.Code = industryCodeRow.Code;
                industry.Description = industryCodeRow.Description;

                _industryRepository.Add(industry);
            }

            _unitOfWork.Commit();
        }
    }
}
