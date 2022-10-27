using EF.WebAPI.Data;
using EF.WebAPI.Data.Dtos;
using EF.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getFilmeById), new { Id = filmeDto.Id }, filmeDto);
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
    }
}
