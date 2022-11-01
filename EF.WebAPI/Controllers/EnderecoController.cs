using AutoMapper;
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
    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Endereco> GetAllEnderecos()
        {
            return _context.Enderecos;
        }

        [HttpGet("{id}")]
        public IActionResult getEnderecoById(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco == null)
            {
                return NotFound();
            } else
            {
                GetEnderecoDto enderecoDto = _mapper.Map<GetEnderecoDto>(endereco);
                return Ok(enderecoDto);
            }
        }

        [HttpPost]
        public IActionResult AddEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getEnderecoById), new { Id = endereco.Id }, enderecoDto);
        }

        [HttpPut]
        public IActionResult UpdateEndereco([FromBody] UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);

            try {
                _context.Enderecos.Update(endereco);
                _context.SaveChanges();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(getEnderecoById), new { Id = endereco.Id }, enderecoDto);
        }
    }
}
