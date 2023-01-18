using SiparisYonetimi.Api.Application.Interfaces.Repositories;
using SiparisYonetimi.Api.Domain.Models;
using SiparisYonetimi.Infrastructure.Persistence.Context;

namespace SiparisYonetimi.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SiparisYonetimiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
