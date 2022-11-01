using AutoMapper;
using EF.WebAPI.Data.Dtos;
using EF.WebAPI.Models;

namespace EF.WebAPI.Data.Mapper
{
    public class CinemaMapper: Profile
    {
        public CinemaMapper()
        {
            CreateMap<Cinema, GetCinemaDto>();
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }

    }
}
