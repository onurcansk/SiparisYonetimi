using MediatR;
using SiparisYonetimi.Common.Models.QueryModels;

namespace SiparisYonetimi.Api.Application.Features.Queries.Company
{
    public class GetCompanyQuery : IRequest<List<CompanyDetailViewModel>>
    {
    }
}
