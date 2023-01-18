using SiparisYonetimi.Api.Application.Interfaces.Repositories;
using SiparisYonetimi.Api.Domain.Models;
using SiparisYonetimi.Infrastructure.Persistence.Context;

namespace SiparisYonetimi.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(SiparisYonetimiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
