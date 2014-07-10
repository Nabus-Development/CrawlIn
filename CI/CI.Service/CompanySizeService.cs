using CI.Model.CompanySizes;
using CI.Model.Infrastructure.UnitOfWork;
using CI.Service.Messaging;

namespace CI.Service
{
    public class CompanySizeService
    {
        private ICompanySizeRepository _companySizeRepository;
        private IUnitOfWork _unitOfWork;

        public CompanySizeService(ICompanySizeRepository companySizeRepository, IUnitOfWork unitOfWork)
        {
            _companySizeRepository = companySizeRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateCompanySizes(CreateCompanySizesRequest createCompanySizesRequest)
        {
            foreach (var companySizeModel in createCompanySizesRequest.CompanySizeModels)
            {
                CompanySize companySize = new CompanySize();
                companySize.Code = companySizeModel.Code;
                companySize.Description = companySizeModel.Description;

                _companySizeRepository.Add(companySize);
            }

            _unitOfWork.Commit();
        }
    }
}
