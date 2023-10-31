using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Dtos;
using NetCoreAPI.Models;

namespace NetCoreAPI.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.Customer, opt => opt.Ignore());
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.CustomerNome, opt => opt.MapFrom(x => x.Customer.NomeCliente));
            CreateMap<CreateProductDto, Product>();


        }
    }
}
