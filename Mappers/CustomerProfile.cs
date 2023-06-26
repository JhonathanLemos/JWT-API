using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Dtos;
using NetCoreAPI.Models;

namespace NetCoreAPI.Mappers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>().ForMember(x => x.Produtos, opt => opt.Ignore());
            CreateMap<Customer, CustomerDto>();
        }
    }
}
