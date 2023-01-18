using AutoMapper;
using MediatR;
using SiparisYonetimi.Api.Application.Interfaces.Repositories;
using SiparisYonetimi.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetimi.Api.Application.Features.Commands.Product
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;
        private readonly ICompanyRepository companyRepository;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
            this.companyRepository = companyRepository;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var company = await companyRepository.GetByIdAsyncWithCollection(request.CompanyId, false, "ProductList");
            if (company == null)
            {
                throw new ArgumentException("Bu id'ye ait bir firma kaydı bulunamadı");
            }
            var existingProduct = company.ProductList.FirstOrDefault(x => x.ProductName == request.ProductName);
            if (existingProduct != null)
            {
                throw new InvalidOperationException("Bu firmada bu ürün adına sahip bir ürün zaten var.");
            }
            var product = mapper.Map<Domain.Models.Product>(request);
            await productRepository.AddAsync(product);
            return product.Id;
        }
    }
}
