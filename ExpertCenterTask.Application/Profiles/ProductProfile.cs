using AutoMapper;
using ExpertCenterTask.Application.Dto.Product;
using ExpertCenterTask.Domain.Entities;

namespace ExpertCenterTask.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}
