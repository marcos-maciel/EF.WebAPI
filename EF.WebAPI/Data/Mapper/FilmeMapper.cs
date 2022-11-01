using AutoMapper;
using EF.WebAPI.Data.Dtos;
using EF.WebAPI.Models;

namespace EF.WebAPI.Data.Mapper
{
    public class FilmeMapper: Profile
    {
        public FilmeMapper()
        {
            CreateMap<Filme, GetCinemaDto>();
            CreateMap<CreateCinemaDto, Filme>();
            CreateMap<UpdateCinemaDto, Filme>();
        }

    }
}
