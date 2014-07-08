using System.Collections.Generic;
using CI.Model.Infrastructure;
using CI.Repository;
using CI.Repository.Repositories;
using CI.Service.Messaging;

namespace CI.Service
{
    public class InitializeDbDefaultData
    {
        public void CreateIndustries()
        {
            CreateIndustriesRequest createIndustriesRequest = new CreateIndustriesRequest();
            createIndustriesRequest.IndustryCodeRows = LinkedInIndustryCodesScrapper.GetIndustryCodeRows();

            NHibernateUnitOfWork unitOfWork = new NHibernateUnitOfWork();
            // DI for poors
            IndustryService industryService = new IndustryService(new IndustryRepository(unitOfWork), new IndustryGroupRepository(unitOfWork), unitOfWork);

            industryService.CreateIndustries(createIndustriesRequest);
        }
    }
}
