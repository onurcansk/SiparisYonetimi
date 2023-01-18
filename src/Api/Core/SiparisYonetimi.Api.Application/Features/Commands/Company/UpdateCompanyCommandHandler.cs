using AutoMapper;
using MediatR;
using SiparisYonetimi.Api.Application.Interfaces.Repositories;
using SiparisYonetimi.Common.Models.RequestModels;

namespace SiparisYonetimi.Api.Application.Features.Commands.Company
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public UpdateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }
        public async Task<Guid> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await companyRepository.GetByIdAsync(request.Id);
            if (company == null)
            {
                throw new ArgumentException("Bu idye sahip bir firma bulunamadı.");
            }
            TimeSpan value1;
            TimeSpan value2;
            if (!TimeSpan.TryParse(request.OrderReleaseStartTime, out value1) ||
            !TimeSpan.TryParse(request.OrderReleaseEndTime, out value2))
            {
                throw new Exception("Saat girişi formatı doğru değil. İstenilen format: 'HH:mm:ss' ->'10:30:00' gibi olmalıdır");
            }
            company.isActive = request.isActive;
            company.OrderReleaseEndTime = TimeSpan.Parse(request.OrderReleaseEndTime);
            company.OrderReleaseStartTime = TimeSpan.Parse(request.OrderReleaseStartTime);
            await companyRepository.UpdateAsync(company);
            return company.Id;
        }
    }
}
