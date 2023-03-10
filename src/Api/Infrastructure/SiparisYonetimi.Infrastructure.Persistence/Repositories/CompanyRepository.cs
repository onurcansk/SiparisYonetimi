using SiparisYonetimi.Api.Application.Interfaces.Repositories;
using SiparisYonetimi.Api.Domain.Models;
using SiparisYonetimi.Infrastructure.Persistence.Context;

namespace SiparisYonetimi.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(SiparisYonetimiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
