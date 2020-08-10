using AutoMapper;
using OnlineShoppind.business.DTOs;
using OnlineShoppind.Business.DTOs;
using OnlineShopping.data.Models;
using OnlineShopping.Data.Models;

namespace OnlineShopping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<Orders, OrderDTO>().ReverseMap();

            CreateMap<OrderItems, ItemDTO>().ReverseMap();
        }
    }
}
