using AutoMapper;
using ExpertCenterTask.Application.Dto.PriceList;
using ExpertCenterTask.Domain.Entities;

namespace ExpertCenterTask.Application.Profiles
{
    public class PriceListProfile : Profile
    {
        public PriceListProfile()
        {
            CreateMap<PriceList, PriceListDto>().ReverseMap();
            CreateMap<PriceList, CreatePriceListDto>().ReverseMap();
            CreateMap<PriceList, UpdatePriceListDto>().ReverseMap();
        }
    }
}
