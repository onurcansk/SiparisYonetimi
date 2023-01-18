using AutoMapper;
using SiparisYonetimi.Api.Domain.Models;
using SiparisYonetimi.Common.Models.QueryModels;
using SiparisYonetimi.Common.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetimi.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommand, Company>()
                .ForMember(x => x.OrderReleaseStartTime, y => y.MapFrom(z => TimeSpan.Parse(z.OrderReleaseStartTime)))
                .ForMember(x => x.OrderReleaseEndTime, y => y.MapFrom(z => TimeSpan.Parse(z.OrderReleaseEndTime)));


            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
            CreateMap<Company, CompanyDetailViewModel>()
                .ForMember(x => x.OrderReleaseStartTime, y => y.MapFrom(z => z.OrderReleaseStartTime.ToString(@"hh\:mm\:ss")))
                .ForMember(x => x.OrderReleaseEndTime, y => y.MapFrom(z => z.OrderReleaseEndTime.ToString(@"hh\:mm\:ss")));

            CreateMap<Product, ProductDetailViewModel>().ReverseMap();
            CreateMap<Order, OrderDetailViewModel>().ReverseMap();


            CreateMap<Product, CreateProductCommand>().ReverseMap();                  
        }
    }
}
