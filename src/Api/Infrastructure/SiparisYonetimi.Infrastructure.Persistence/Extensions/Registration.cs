using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SiparisYonetimi.Api.Application.Interfaces.Repositories;
using SiparisYonetimi.Infrastructure.Persistence.Context;
using SiparisYonetimi.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetimi.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfratructureRegistration(this IServiceCollection servies, IConfiguration configuration)
        {
            servies.AddDbContext<SiparisYonetimiDbContext>(conf =>
            {
                var conStr = configuration["SiparisYonetimiConnectionString"].ToString();

                conf.UseSqlServer(conStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            servies.AddScoped<IOrderRepository, OrderRepository>();
            servies.AddScoped<IProductRepository, ProductRepository>();
            servies.AddScoped<ICompanyRepository, CompanyRepository>();
            return servies;
        }
    }
}
