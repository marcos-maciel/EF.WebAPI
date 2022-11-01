﻿using AutoMapper;
using EF.WebAPI.Data;
using EF.WebAPI.Data.Dtos;
using EF.WebAPI.Data.Mapper;
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
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
            } else
            {
                GetCinemaDto filmeDto = _mapper.Map<GetCinemaDto>(filme);
                return Ok(filmeDto);
            }
        }

        [HttpPost]
        public IActionResult AddFilme([FromBody] CreateCinemaDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getFilmeById), new { Id = filme.Id }, filmeDto);
        }

        [HttpPut]
        public IActionResult UpdateFilme([FromBody] UpdateCinemaDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

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
