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
            CreateMap<ProductDto, Product>();
            CreateMap<ProductDto, IActionResult>();
            CreateMap<Product, ProductDto>();
        }
    }
}
