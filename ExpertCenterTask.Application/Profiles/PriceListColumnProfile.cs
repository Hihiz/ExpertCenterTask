using AutoMapper;
using ExpertCenterTask.Application.Dto.PriceListColumn;
using ExpertCenterTask.Domain.Entities;

namespace ExpertCenterTask.Application.Profiles
{
    public class PriceListColumnProfile : Profile
    {
        public PriceListColumnProfile() 
        {
            CreateMap<PriceListColumn, PriceListColumnDto>().ReverseMap();
            CreateMap<PriceListColumn, CreatePriceListColumnDto>().ReverseMap();
            CreateMap<PriceListColumn, UpdatePriceListColumnDto>().ReverseMap();
        }
    }
}
