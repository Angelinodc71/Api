using Api.Entities;
using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<Movie, MovieWithoutCastDto>();
        }
    }
}