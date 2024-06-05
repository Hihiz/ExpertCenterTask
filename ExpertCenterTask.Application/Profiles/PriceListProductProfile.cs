using AutoMapper;
using ExpertCenterTask.Application.Dto.PriceListProduct;
using ExpertCenterTask.Domain.Entities;

namespace ExpertCenterTask.Application.Profiles
{
    public class PriceListProductProfile : Profile
    {
        public PriceListProductProfile()
        {
            CreateMap<PriceListProduct, PriceListProductDto>().ReverseMap();
            CreateMap<PriceListProduct, CreatePriceListProductDto>().ReverseMap();
            CreateMap<PriceListProduct, UpdatePriceListProductDto>().ReverseMap();
        }
    }
}
