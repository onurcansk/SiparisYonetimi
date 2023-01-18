using AutoMapper;
using MediatR;
using SiparisYonetimi.Api.Application.Interfaces.Repositories;
using SiparisYonetimi.Common.Models.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetimi.Api.Application.Features.Queries.Company
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, List<CompanyDetailViewModel>>
    {
        private readonly IMapper mapper;
        private readonly ICompanyRepository companyRepository;

        public GetCompanyQueryHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }
        public async Task<List<CompanyDetailViewModel>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var companies = await companyRepository.GetListAsync(null, true, null, x => x.ProductList, z => z.Orders);

            List<CompanyDetailViewModel> companyDetailViewModels = new();
            foreach (var item in companies)
            {
                string exp = item.OrderReleaseStartTime.ToString(@"hh\:mm\:ss");
                companyDetailViewModels.Add(mapper.Map<CompanyDetailViewModel>(item));
            }
            return companyDetailViewModels;
        }
    }
}
