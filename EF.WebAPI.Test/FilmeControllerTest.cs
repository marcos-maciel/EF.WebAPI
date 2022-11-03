using AutoMapper;
using EF.WebAPI.Controllers;
using EF.WebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FakeHttpContext;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EF.WebAPI.Test
{
    public class FilmeControllerTest
    {
        private FilmeController _controller;
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeControllerTest()
        {
            _controller = new FilmeController(_context, _mapper);
        }


        //[Fact]
        //public void GetAllFilmesDeveRetornarStatusCode200()
        //{
        //    // Act
        //    var result = _controller.GetAllFilmes();


        //    // Assert
        //    Assert.Equal(200, result.GetHashCode());
        //}

        [Theory]
        [InlineData(1)]
        public void GetFilmeByIdDeveRetornarOFilmePeloSeuId(int id)
        {

            // Act
            var result = (OkObjectResult) _controller.GetFilmeById(id);

            // Assert
            Assert.Equal(200, result.StatusCode);
        }
    }
}
