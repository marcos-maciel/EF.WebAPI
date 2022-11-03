using AutoMapper;
using EF.WebApi.TestMoq.MockData;
using EF.WebAPI.Controllers;
using EF.WebAPI.Data;
using EF.WebAPI.Data.Mapper;
using EF.WebAPI.Models;
using EF.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EF.WebApi.TestMoq
{
    public class FilmeControllerTests : IDisposable
    {
        protected readonly AppDbContext _context;
        public FilmeControllerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _context = new AppDbContext(options);

            _context.Database.EnsureCreated();
        }

        [Fact]
        public async Task DeveRetornarFilmes()
        {
            // Arrange
            _context.Filmes.AddRange(FilmeMockData.GetAll());
            _context.SaveChanges();

            var sut = new FilmeService(_context);

            // Act
            var result = await sut.GetAllFilmes();

            // Assert
            Assert.Equal(3, result.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task DeveRetornarCadaFilmePeloId(int id)
        {
            // Arrange
            _context.Filmes.AddRange(FilmeMockData.GetAll());
            _context.SaveChanges();

            var sut = new FilmeService(_context);

            // Act
            var result = await sut.GetFilmeById(id);

            // Assert
            Assert.True(result.Id == id);
        }

        [Fact]
        public async Task DeveAdicionarNovoFilme()
        {
            // Arrange
            var newFilme = FilmeMockData.AddFilme();

            _context.Filmes.AddRange(FilmeMockData.GetAll());
            _context.SaveChanges();
            
            var sut = new FilmeService(_context);

            // Act
            await sut.AddFilme(newFilme);
            var allFilmes = _context.Filmes.Select(_ => _).ToList();

            // Assert
            Assert.Equal(4, allFilmes.Count);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeveAlterarFilmeExistente(int id)
        {
            // Arrange
            _context.Filmes.AddRange(FilmeMockData.GetAll());
            _context.SaveChanges();

            var updateFilme = _context.Filmes.Where(f => f.Id == id).FirstOrDefault();
            updateFilme.Nome = "updatedFilme";
            updateFilme.Diretor = "updatedDiretor";

            _context.Update(updateFilme);
            _context.SaveChanges();

            var sut = new FilmeService(_context);

            // Act
            var result = await sut.GetFilmeById(id);

            // Assert
            Assert.Equal("updatedFilme", result.Nome);
            Assert.Equal("updatedDiretor", result.Diretor);
        }

        [Theory]
        [InlineData(1)]
        public async Task DeveDeletarFilmeExistente(int id)
        {
            // Arrange
            _context.Filmes.AddRange(FilmeMockData.GetAll());
            _context.SaveChanges();
            
            var sut = new FilmeService(_context);
            var deletefilme = await sut.GetFilmeById(id);

            // Act
            await sut.DeleteFilme(deletefilme);
            var allFilmes = _context.Filmes.Select(_ => _).ToList();

            // Assert
            Assert.Equal(2, allFilmes.Count);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
