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
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<Cinema> GetAllCinemas()
        {
            return _context.Cinemas;
        }

        [HttpGet("{id}")]
        public IActionResult getCinemaById(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema == null)
            {
                return NotFound();
            } else
            {
                GetCinemaDto cinemaDto = _mapper.Map<GetCinemaDto>(cinema);
                return Ok(cinemaDto);
            }
        }

        [HttpPost]
        public IActionResult AddCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getCinemaById), new { Id = cinema.Id }, cinemaDto);
        }

        [HttpPut]
        public IActionResult UpdateCinema([FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

            try {
                _context.Cinemas.Update(cinema);
                _context.SaveChanges();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction(nameof(getCinemaById), new { Id = cinema.Id }, cinemaDto);
        }
    }
}
