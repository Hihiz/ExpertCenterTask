using AutoMapper;
using ExpertCenterTask.Application.Dto.Column;
using ExpertCenterTask.Domain.Entities;

namespace ExpertCenterTask.Application.Profiles
{
    public class ColumnProfile : Profile
    {
        public ColumnProfile()
        {
            CreateMap<Column, /*ColumnCollectionDto*/ColumnDto>().ReverseMap();
            CreateMap<Column, ColumnDto>().ReverseMap();
            CreateMap<Column, CreateColumnDto>().ReverseMap();
            CreateMap<Column, UpdateColumnDto>().ReverseMap();
        }
    }
}
