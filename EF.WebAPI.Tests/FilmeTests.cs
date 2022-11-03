using EF.WebAPI.Data;
using EF.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using System.Web;
using EF.WebAPI.Controllers;

namespace EF.WebAPI.Tests
{
    public class FilmeTests
    {

        [Fact]
        public async Task DeveRetornarTodosOsDoisFilmes()
        {
            using var application = new WebApiAplication();
            await FilmeMock.CreateFilmes(application, true);

            //var filmeController = new FilmeController();

            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //Assert.NotNull(filmes);
            //Assert.True(filmes.Count == 2);

        }
    }
}
