using AutoMapper;
using EF.WebAPI.Data;
using EF.WebAPI.Data.Dtos;
using EF.WebAPI.Data.Dtos.User;
using EF.WebAPI.Data.Mapper;
using EF.WebAPI.Models;
using EF.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EF.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService, IMapper mapper)
        {
            _filmeService = filmeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllFilmes()
        {
            var result = await _filmeService.GetAllFilmes();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetFilmeById(int id)
        {
            Filme filme = await _filmeService.GetFilmeById(id);
            if (filme == null)
            {
                return NotFound();
            } else {
                DeleteFilmeDto filmeDto = _mapper.Map<DeleteFilmeDto>(filme);
                return Ok(filmeDto);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _filmeService.AddFilme(filme);
            return CreatedAtAction(nameof(GetFilmeById), new { Id = filme.Id }, filmeDto);
        }

        [HttpPut]
        [Authorize]
        public IActionResult UpdateFilme([FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            try {
                _filmeService.UpdateFilme(filme);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(GetFilmeById), new { Id = filme.Id }, filmeDto);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteFilme([FromBody] DeleteFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            try
            {
                _filmeService.DeleteFilme(filme);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(GetFilmeById), new { Id = filme.Id }, filmeDto);
        }
    }
}
