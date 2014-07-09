using System.Collections.Generic;
using CI.Repository;
using CI.Repository.Repositories;
using CI.Service;
using CI.Service.Messaging;
using CI.Service.Models;

namespace SetupTool
{
    public class InitializeDbDefaultData
    {
        public void CreateIndustries()
        {
            CreateIndustriesRequest createIndustriesRequest = new CreateIndustriesRequest();
            createIndustriesRequest.IndustryCodeRowModels = LinkedInIndustryCodesScrapper.GetIndustryCodeRows();

            NHibernateUnitOfWork unitOfWork = new NHibernateUnitOfWork();
            // DI for poors
            IndustryService industryService = new IndustryService(new IndustryRepository(unitOfWork), new IndustryGroupRepository(unitOfWork), unitOfWork);

            industryService.CreateIndustries(createIndustriesRequest);
        }

        public void CreateCompanySizes()
        {
            CreateCompanySizesRequest createCompanySizesRequest = new CreateCompanySizesRequest();
            createCompanySizesRequest.CompanySizeModels = new List<CompanySizeModel>();

            CompanySizeModel companySizeModelB = new CompanySizeModel
            {
                Code = "B",
                Description = "1-10"
            };
            CompanySizeModel companySizeModelC = new CompanySizeModel
            {
                Code = "C",
                Description = "11-50"
            };
            CompanySizeModel companySizeModelD = new CompanySizeModel
            {
                Code = "D",
                Description = "51-200"
            };
            CompanySizeModel companySizeModelE = new CompanySizeModel
            {
                Code = "E",
                Description = "201-500"
            };
            CompanySizeModel companySizeModelF = new CompanySizeModel
            {
                Code = "F",
                Description = "501-1000"
            };
            CompanySizeModel companySizeModelG = new CompanySizeModel
            {
                Code = "G",
                Description = "1001-5000"
            };
            CompanySizeModel companySizeModelH = new CompanySizeModel
            {
                Code = "H",
                Description = "5001-10,000"
            };
            CompanySizeModel companySizeModelI = new CompanySizeModel
            {
                Code = "I",
                Description = "10,000+"
            };
            createCompanySizesRequest.CompanySizeModels.Add(companySizeModelB);
            createCompanySizesRequest.CompanySizeModels.Add(companySizeModelC);
            createCompanySizesRequest.CompanySizeModels.Add(companySizeModelD);
            createCompanySizesRequest.CompanySizeModels.Add(companySizeModelE);
            createCompanySizesRequest.CompanySizeModels.Add(companySizeModelF);
            createCompanySizesRequest.CompanySizeModels.Add(companySizeModelG);
            createCompanySizesRequest.CompanySizeModels.Add(companySizeModelH);
            createCompanySizesRequest.CompanySizeModels.Add(companySizeModelI);

            NHibernateUnitOfWork unitOfWork = new NHibernateUnitOfWork();
            // DI for poors
            CompanySizeService companySizeService = new CompanySizeService(new CompanySizeRepository(unitOfWork), unitOfWork);

            companySizeService.CreateCompanySizes(createCompanySizesRequest);
        }
    }
}
