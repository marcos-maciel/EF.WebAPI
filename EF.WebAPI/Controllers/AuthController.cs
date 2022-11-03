using AutoMapper;
using EF.WebAPI.Data;
using EF.WebAPI.Data.Dtos.User;
using EF.WebAPI.Models;
using EF.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EF.WebAPI.Controllers
{
    public class AuthController : Controller
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public AuthController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public dynamic Authenticate([FromBody] GetUserDto getUserDto)
        {
            var user = _mapper.Map<User>(getUserDto);
            user = _context.Users.FirstOrDefault(u => u.Nome == user.Nome && u.Senha == user.Senha);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            return new
            {
                token = token
            };
        }
    }
}
