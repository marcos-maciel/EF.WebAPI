using AutoMapper;
using EF.WebAPI.Data.Dtos;
using EF.WebAPI.Models;

namespace EF.WebAPI.Data.Mapper
{
    public class FilmeMapper: Profile
    {
        public FilmeMapper()
        {
            CreateMap<Filme, DeleteFilmeDto>();
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<DeleteFilmeDto, Filme>();
        }

    }
}
