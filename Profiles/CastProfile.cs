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
        }
    }
}