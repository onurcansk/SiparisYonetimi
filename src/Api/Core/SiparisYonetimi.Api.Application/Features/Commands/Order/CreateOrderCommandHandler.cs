using AutoMapper;
using MediatR;
using SiparisYonetimi.Api.Application.Interfaces.Repositories;
using SiparisYonetimi.Common.Exceptions;
using SiparisYonetimi.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetimi.Api.Application.Features.Commands.Order
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;
        private readonly ICompanyRepository companyRepository;

        public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IProductRepository productRepository, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
            this.companyRepository = companyRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var company = await companyRepository.GetByIdAsyncWithCollection(request.CompanyId, false, "ProductList");
            if (company == null)
            {
                throw new ArgumentException("Bu idye sahip bir firma bulunamadı.");
            }
            if (!company.isActive)
            {
                throw new NotAvaibleCompanyException("Bu firma onaylı değil");
            }
            else
            {
                TimeSpan currentDatetime;
                if (!TimeSpan.TryParse(request.OrderTime, out currentDatetime))
                {
                    throw new Exception("Saat girişi formatı doğru değil. İstenilen format: 'HH:mm:ss' ->'10:30:00' gibi olmalıdır");
                }
                if (currentDatetime < company.OrderReleaseStartTime || currentDatetime > company.OrderReleaseEndTime)
                {
                    throw new NotInServiceTimeException($"Bu firma şuan sipariş almıyor. Sipariş saatleri: {company.OrderReleaseStartTime.ToString(@"hh\:mm\:ss")}-{company.OrderReleaseEndTime.ToString(@"hh\:mm\:ss")} arasındadır");
                }
                Domain.Models.Order order = new()
                {
                    CustomerName = request.CustomerName,
                    CompanyId = request.CompanyId,
                    OrderDate = DateTime.Now,
                };
                order.Products = new List<Domain.Models.Product>();

                foreach (var item in request.Products)
                {
                    var product = company.ProductList.FirstOrDefault(x => x.Id == item);
                    if (product == null)
                    {
                        throw new ArgumentException("Bu firmada böyle bir ürün bulunmamaktadır.");
                    }
                    order.Products.Add(product);
                }
                await orderRepository.AddAsync(order);
                return order.Id;
            }
        }
    }
}
