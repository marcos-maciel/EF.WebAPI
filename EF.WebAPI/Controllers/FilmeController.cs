using EF.WebAPI.Data;
using EF.WebAPI.Data.Dtos;
using EF.WebAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EF.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;

        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Filme> GetAllFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult getFilmeById(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            return Ok(filme);
        }

        [HttpPost]
        public IActionResult AddFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = new Filme
            {
                Nome = filmeDto.Nome,
                Diretor = filmeDto.Diretor,
                Duracao = filmeDto.Duracao
            };

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getFilmeById), new { Id = filme.Id }, filmeDto);
        }

        [HttpPut]
        public IActionResult UpdateFilme([FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = new Filme
            {
                Id = filmeDto.Id,
                Nome = filmeDto.Nome,
                Diretor = filmeDto.Diretor,
                Duracao = filmeDto.Duracao
            };

            try {
                _context.Filmes.Update(filme);
                _context.SaveChanges();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(getFilmeById), new { Id = filme.Id }, filmeDto);
        }
    }
}
