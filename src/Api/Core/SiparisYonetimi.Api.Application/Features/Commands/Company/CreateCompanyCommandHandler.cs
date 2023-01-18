using AutoMapper;
using MediatR;
using SiparisYonetimi.Api.Application.Interfaces.Repositories;
using SiparisYonetimi.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetimi.Api.Application.Features.Commands.Company
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public CreateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            TimeSpan value1;
            TimeSpan value2;
            if (!TimeSpan.TryParse(request.OrderReleaseStartTime, out value1) ||
            !TimeSpan.TryParse(request.OrderReleaseEndTime, out value2))
            {
                throw new Exception("Saat girişi formatı doğru değil. İstenilen format: 'HH:mm:ss' ->'10:30:00' gibi olmalıdır");
            }
            var existingCompany = await companyRepository.FirstOrDefaultAsync(x => x.CompanyName == request.CompanyName);
            if (existingCompany != null)
            {
                throw new InvalidOperationException("Bu isimde bir firma zaten var.");
            }
            var company = mapper.Map<Domain.Models.Company>(request);
            await companyRepository.AddAsync(company);
            return company.Id;
        }
    }
}
