using AutoMapper;
using EF.WebAPI.Data.Dtos;
using EF.WebAPI.Models;

namespace EF.WebAPI.Data.Mapper
{
    public class EnderecoMapper: Profile
    {
        public EnderecoMapper()
        {
            CreateMap<Endereco, GetEnderecoDto>();
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
        }

    }
}
