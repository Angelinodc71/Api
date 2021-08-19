using Api.Entities;
using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class CastProfile : Profile
    {
        public CastProfile()
        {
            CreateMap<Cast, CastDto>();
            CreateMap<CastForCreationDto, Cast>();
            CreateMap<Cast, CastForCreationDto>();
            CreateMap<CastForUpdateDto, Cast>().ReverseMap();
        }
    }
}